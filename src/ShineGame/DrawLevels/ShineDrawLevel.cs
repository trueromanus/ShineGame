using System.Collections.Generic;
using System.Linq;
using AbstractGameLogic;
using Microsoft.Xna.Framework;
using System.Runtime.Serialization;
using AbstractGameLogic.ObjectVisual;
using AbstractGameLogic.ObjectBehavior;
using AbstractGameLogic.Physics;
using ShineGame.CommonRoutine;
using AbstractGameLogic.State;
using Microsoft.Xna.Framework.Graphics;
using System;
using ProjectMercury;
using ShineGame.VisualObjects;

namespace ShineGame.DrawLevels {

	/// <summary>
	/// Логический слой рисования.
	/// </summary>
	public sealed class ShineDrawLevel : IDrawLevel , IContentManager {

		List<IGameObjectVisual> m_Objects = new List<IGameObjectVisual> ();

		IPhysicsWorld m_PhysicsWorld;

		private bool m_IsCheckCollision;

		private List<IEventRaises> m_Events = new List<IEventRaises> ();

		private Lazy<Dictionary<string , Texture2D>> m_Textures = new Lazy<Dictionary<string , Texture2D>> ( true );

		private Lazy<Dictionary<string , ParticleEffect>> m_Effects = new Lazy<Dictionary<string , ParticleEffect>> ( true );

		private Lazy<Dictionary<string , SpriteFont>> m_Fonts = new Lazy<Dictionary<string , SpriteFont>> ( true );

		private Rectangle m_Rectangle;

		private IRectangle m_Viewport = new ShineRectangle ();

		/// <summary>
		/// Объекты в игровом слое.
		/// </summary>
		public IEnumerable<IGameObjectVisual> Objects {
			get {
				return m_Objects;
			}
		}

		/// <summary>
		/// Список текущих событий.
		/// </summary>
		public IEnumerable<IEventRaises> Events {
			get {
				return m_Events;
			}
		}

		/// <summary>
		/// Обновить состояние всех объектов в графическом слое.
		/// </summary>
		/// <param name="gameState">Состояние устройств ввода.</param>
		public void Update ( IGameState gameState ) {
			//сначала обновляем физический мир
			if ( m_IsCheckCollision ) m_PhysicsWorld.Update ( gameState );

			//потом игровую логику
			foreach ( var @object in m_Objects ) @object.Update ( gameState );
		}

		/// <summary>
		/// Отрисовать все объекты которые в уровне которые находятся в определенной области видимости.
		/// </summary>
		public void Draw ( int worldX , int worldY , int worldXEnd , int worldYEnd ) {

			m_Rectangle.X = worldX;
			m_Rectangle.Y = worldY;
			m_Rectangle.Width = worldXEnd;
			m_Rectangle.Height = worldYEnd;

			Viewport.X = worldX;
			Viewport.Y = worldY;
			Viewport.Width = worldXEnd;
			Viewport.Height = worldYEnd;

			//сначала объекты которые частично попадают на экран
			var objects = m_Objects
				.AsParallel ()
				.Where ( a => m_Rectangle.Intersects ( ( (IRectangleVisualObject) a ).ObjectRectangle ) )
				.ToList ()
				.OrderBy ( a => a.ZIndex );

			foreach ( var @object in objects ) @object.Draw ();
		}

		/// <summary>
		/// Добавить игровой объект.
		/// </summary>
		/// <param name="gameObject">Визуальный игровой объект.</param>
		public void Add ( IGameObjectVisual gameObject ) {
			gameObject.ZIndex = m_Objects.Count;
			gameObject.DrawLevel = this;

			m_Objects.Add ( gameObject );
		}

		/// <summary>
		/// Удалить игровой объект.
		/// </summary>
		/// <param name="name">Имя объекта.</param>
		public void Remove ( string name ) {
			var removingObjects = m_Objects.Where ( a => a.Name == name ).ToList ();
			foreach ( var removeObject in removingObjects ) {
				m_Objects.Remove ( removeObject );
			}
		}

		/// <summary>
		/// Имя слоя графики.
		/// </summary>
		public string Name {
			get;
			set;
		}

		/// <summary>
		/// Признак того будут ли выполняться проверки
		/// колизий во время обновления состояния объектов в графическом слое.
		/// </summary>
		public bool IsCheckCollision {
			get {
				return m_IsCheckCollision;
			}
			set {
				if ( m_IsCheckCollision && value ) return;
				if ( value && m_PhysicsWorld == null ) {
					m_PhysicsWorld = GameHost.Game.FactoryHost.Physics.CreateWorld ( 0.0f , 100.0f );
				}
				m_IsCheckCollision = value;
			}
		}

		/// <summary>
		/// Получить объект по имени.
		/// </summary>
		/// <param name="name">Имя объекта.</param>
		/// <returns>Найденный объект или null.</returns>
		public IGameObjectVisual GetObject ( string name ) {
			return m_Objects
				.Where ( a => a.Name == name )
				.FirstOrDefault ();
		}

		/// <summary>
		/// Освободить ресурсы.
		/// </summary>
		public void FreeResources () {
			if ( m_Textures.IsValueCreated ) {
				foreach ( var texture in m_Textures.Value.OfType<IDisposable> () ) {
					texture.Dispose ();
				}
			}
			if ( m_Effects.IsValueCreated ) m_Effects.Value.Clear ();
			if ( m_Fonts.IsValueCreated ) m_Fonts.Value.Clear ();
			m_Objects.Clear ();
		}

		/// <summary>
		/// Физический мир.
		/// </summary>
		public IPhysicsWorld PhysicsWorld {
			get {
				return m_PhysicsWorld;
			}
		}

		/// <summary>
		/// Область вывода графического слоя.
		/// </summary>
		public IRectangle Viewport {
			get {
				return m_Viewport;
			}
			set {
				m_Viewport = value;
			}
		}

		/// <summary>
		/// Добавить возбужденное событие.
		/// </summary>
		/// <param name="objectName">Имя объекта.</param>
		/// <param name="eventRaises">Возбужденное событие.</param>
		public void AddEvent ( string objectName , string eventRaises ) {
			var currentEvent = m_Events.FirstOrDefault ( a => a.ObjectName == objectName );
			if ( currentEvent == null ) {
				currentEvent = new EventRaises {
					ObjectName = objectName ,
					Events = Enumerable.Empty<string> ()
				};
				m_Events.Add ( currentEvent );
			}

			currentEvent.Events = currentEvent.Events.Union ( Enumerable.Repeat<string> ( eventRaises , 1 ) ).ToList ();
		}

		/// <summary>
		/// Очистить возбужденные события.
		/// </summary>
		public void ClearEvents () {
			m_Events.Clear ();
		}

		/// <summary>
		/// Получить текстуру.
		/// </summary>
		/// <param name="name">Имя текстуры.</param>
		/// <returns>Текстура.</returns>
		public Texture2D GetTexture ( string name ) {
			var texture = m_Textures.Value
				.Where ( a => a.Key == name )
				.Select ( a => a.Value )
				.FirstOrDefault ();
			if ( texture == null ) {
				var texture2d = GameContentManager.GetTexture ( name );
				m_Textures.Value.Add ( name , texture2d );
				return texture2d;
			}
			return texture;
		}

		/// <summary>
		/// Получить шрифт.
		/// </summary>
		/// <param name="name">Имя шрифта.</param>
		/// <returns>Шрифт.</returns>
		public SpriteFont GetFont ( string name ) {
			var font = m_Fonts.Value
				.Where ( a => a.Key == name )
				.Select ( a => a.Value )
				.FirstOrDefault ();
			if ( font == null ) {
				var resourceFont = GameContentManager.GetFont ( name );
				m_Fonts.Value.Add ( name , resourceFont );
				return resourceFont;
			}
			return font;
		}

		/// <summary>
		/// Получить эффект.
		/// </summary>
		/// <param name="name">Имя эффекта.</param>
		/// <returns>Эффект.</returns>
		public ParticleEffect GetEffect ( string name ) {
			var effect = m_Effects.Value
				.Where ( a => a.Key == name )
				.Select ( a => a.Value )
				.FirstOrDefault ();
			if ( effect == null ) {
				var resourceEffect = GameContentManager.GetParticleEffect ( name );
				m_Effects.Value.Add ( name , resourceEffect );
				return resourceEffect;
			}
			return effect;
		}

		/// <summary>
		/// Игровой мир.
		/// </summary>
		public IGameWorld GameWorld {
			get;
			set;
		}
	}

}
