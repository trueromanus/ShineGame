using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AbstractGameLogic;
using AbstractGameLogic.ObjectBehavior;
using AbstractGameLogic.ObjectVisual;
using AbstractGameLogic.State;
using Microsoft.Xna.Framework;
using ShineGame.CommonRoutine;
using ShineGame.DrawLevels;
using ShineGame.VisualObjects;

namespace ShineGame {

	/// <summary>
	/// Реализация интерфейса <see cref="IGameObjectVisual"/> по для внешних клиентов.
	/// </summary>
	public abstract class GameObjectVisualImplementation : IGameObjectVisual , IGameObjectReadeable , IRectangleVisualObject , IGameObjectInitialization {

		protected List<IObjectState> m_States = new List<IObjectState> ();

		protected IObjectBehaviors m_BehaviourCollection = new BehaviourCollection ();

		private IVector2 m_Vector = new ShineVector2 ();

		private Rectangle m_Rectangle = new Rectangle ();

		private int m_WorldX;

		private int m_WorldY;

		private IEnumerable<IVisualObjectBehaviour> m_VisualBehavoiurs;

		private int m_Width;

		private int m_Height;

		/// <summary>
		/// Координата по оси X в мировом пространстве.
		/// </summary>		
		public int WorldX {
			get {
				return m_WorldX;
			}
			set {
				m_Vector.X = (float) value;
				m_WorldX = value;
				SetNewRectangleValue ();
			}
		}

		/// <summary>
		/// Координата по оси Y в мировом пространстве.
		/// </summary>		
		public int WorldY {
			get {
				return m_WorldY;
			}
			set {
				m_Vector.Y = (float) value;
				m_WorldY = value;
				SetNewRectangleValue ();
			}
		}

		/// <summary>
		/// Координата по оси X в мировом пространстве.
		/// </summary>		
		public int WorldXEnd {
			get {
				return WorldX + Width;
			}
		}

		/// <summary>
		/// Координата по оси Y в мировом пространстве.
		/// </summary>		
		public int WorldYEnd {
			get {
				return WorldY + Height;
			}
		}

		/// <summary>
		/// Ширина объекта.
		/// </summary>		
		public int Width {
			get {
				return m_Width;
			}
			set {
				m_Width = value;
				SetNewRectangleValue ();
			}
		}

		/// <summary>
		/// Высота объекта.
		/// </summary>		
		public int Height {
			get {
				return m_Height;
			}
			set {
				m_Height = value;
				SetNewRectangleValue ();
			}
		}

		/// <summary>
		/// Обновить состояние объекта.
		/// </summary>		
		public abstract void Update ( IGameState inputGamestate );

		/// <summary>
		/// Отросивать объект.
		/// </summary>		
		public abstract void Draw ();

		/// <summary>
		/// Имя объекта.
		/// </summary>
		public string Name {
			get;
			set;
		}

		/// <summary>
		/// Порядок элемента.
		/// </summary>
		public int ZIndex {
			get;
			set;
		}

		/// <summary>
		/// Набор поведений объекта.
		/// </summary>
		public IObjectBehaviors BehaviourCollection {
			get {
				return m_BehaviourCollection;
			}
		}

		/// <summary>
		/// Графический слой объекта.
		/// </summary>
		public IDrawLevel DrawLevel {
			get;
			set;
		}

		/// <summary>
		/// Область объекта.
		/// </summary>
		public Rectangle ObjectRectangle {
			get {
				return m_Rectangle;
			}
		}

		/// <summary>
		/// Установить новое значение квадрата объекта.
		/// </summary>
		private void SetNewRectangleValue () {
			m_Rectangle.X = WorldX;
			m_Rectangle.Y = WorldY;
			m_Rectangle.Width = Width;
			m_Rectangle.Height = Height;
		}

		/// <summary>
		/// Прочесть данные из стороннего объекта и
		/// заполнить их внутри себя.
		/// </summary>
		/// <param name="gameObject">Игровой объект.</param>
		public virtual void CloneGameObjectData ( IGameObject gameObject ) {
			var visualObject = ( gameObject as IGameObjectVisual );
			if ( visualObject == null ) return;
			Name = visualObject.Name;
			WorldX = visualObject.WorldX;
			WorldY = visualObject.WorldY;
			Rotate = visualObject.Rotate;
			if ( visualObject.ZIndex != 0 ) ZIndex = visualObject.ZIndex;

			if ( visualObject.BehaviourCollection != null && visualObject.BehaviourCollection.Behaviors.Count () > 0 ) {
				foreach ( var behaviourName in visualObject.BehaviourCollection.Behaviors.Select ( a => a.Name ) ) {
					GameContentManager.GetBehavoiursAndStates ( this , behaviourName , gameObject , GameHost.Game.FactoryHost );
				}
			}
			if ( visualObject.States != null && visualObject.States.Count () > 0 ) {
				foreach ( var state in visualObject.States ) {
					var newState = GameHost.Game.FactoryHost.States.CreateObjectState ();
					state.Name = state.Name;
					state.Value = state.Value;
					States.Add ( state );
				}
			}
		}

		/// <summary>
		/// Запустить визуальное поведение.
		/// </summary>
		protected void RunVisualBehaviours ( IGameState gameState ) {
			foreach ( var updateBehaviour in m_VisualBehavoiurs ) updateBehaviour.Update ( gameState );
		}

		/// <summary>
		/// Выполнить инициализацию объекта.
		/// </summary>
		public void Initialize () {
			m_VisualBehavoiurs = m_BehaviourCollection.Behaviors
				.OfType<IVisualObjectBehaviour> ()
				.OrderBy ( a => a.Order );

			foreach ( var updateBehaviour in m_VisualBehavoiurs ) {
				updateBehaviour.VisualObject = this;
				updateBehaviour.Initialize ( GameHost.Game.FactoryHost );
			}
		}

		/// <summary>
		/// Коллекция состояний.
		/// </summary>
		public IList<IObjectState> States {
			get {
				return m_States;
			}
		}

		/// <summary>
		/// Угол поворота.
		/// </summary>
		public float Rotate {
			get;
			set;
		}

		/// <summary>
		/// Получить вектор положения объекта.
		/// </summary>
		/// <returns>Вектор положения объекта.</returns>
		public IVector2 GetVector () {
			return m_Vector;
		}

		/// <summary>
		/// Установить вектор положения объекта.
		/// </summary>
		/// <param name="vector">Новый вектор положения.</param>
		public void SetVector ( IVector2 vector ) {
			m_Vector.X = vector.X;
			m_Vector.Y = vector.Y;
			m_WorldX = Convert.ToInt32 ( vector.X );
			m_WorldY = Convert.ToInt32 ( vector.Y );
		}

		/// <summary>
		/// Установить вектор положения объекта.
		/// </summary>
		/// <param name="x">Координата по оси X.</param>
		/// <param name="y">Координата по оси Y.</param>
		public void SetVector ( float x , float y ) {
			m_Vector.X = x;
			m_Vector.Y = y;
			m_WorldX = Convert.ToInt32 ( x );
			m_WorldY = Convert.ToInt32 ( y );
		}

		/// <summary>
		/// Менеджер ресурсов.
		/// </summary>
		public IContentManager ContentManager {
			get {
				var manager = ( DrawLevel as IContentManager );
				if ( manager == null ) throw new NotSupportedException ( "Менеджер на уровне графического слоя не поддерживается." );
				return manager;
			}
		}

	}
}
