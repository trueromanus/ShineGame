using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic;
using ShineGame.CommonRoutine;
using Microsoft.Xna.Framework;
using GameMathHelpers;
using AbstractGameLogic.State;
using AbstractGameLogic.GUI;

namespace ShineGame.GameWorlds {

	/// <summary>
	/// Класс реализации игрового мира игровой надстройки HotHead.
	/// </summary>
	public sealed class GameWorld : IGameWorld {

		List<IDrawLevel> m_DrawLevels = new List<IDrawLevel> ();

		private int m_WorldX;

		private int m_WorldY;

		private List<IObjectState> m_States = new List<IObjectState> ();

		private List<Action<IGameWorld>> m_PostUpdateActions = new List<Action<IGameWorld>> ();

		private IList<ICamera> m_Cameras = new List<ICamera> ();

		private ICamera m_ActiveCamera;

		/// <summary>
		/// Конструктор.
		/// </summary>
		public GameWorld () {
			WorldXMax = 10000;
			WorldYMax = 10000;
		}

		/// <summary>
		/// Графические слои игры.
		/// </summary>
		public IEnumerable<IDrawLevel> DrawLevels {
			get {
				foreach ( var drawLevel in m_DrawLevels ) {
					yield return drawLevel;
				}
			}
		}

		/// <summary>
		/// Рисуем мир.
		/// </summary>
		///<param name="ElapsedTime">Пройденное время с последнего обновления.</param>
		///<param name="TotalTime">Общее время после запуска игры.</param>
		public void Draw ( TimeSpan totalTime , TimeSpan elapsedTime ) {
			//нет камеры то и смысла рисовать что-то нет
			if ( ActiveCamera == null ) return;

			//рисуем все уровни мира.
			foreach ( var @object in DrawLevels ) {
				@object.Draw ( WorldX , WorldY , WorldXEnd , WorldYEnd );
			}
			if ( GUIManager != null ) GUIManager.Draw ();
		}

		/// <summary>
		/// Обновить состояние объектов.
		/// </summary>
		///<param name="ElapsedTime">Пройденное время с последнего обновления.</param>
		///<param name="TotalTime">Общее время после запуска игры.</param>
		public void Update ( TimeSpan totalTime , TimeSpan elapsedTime ) {
			var gameState = new GameState {
				InputState = GameInput.GetGameState () ,
				TotalTime = totalTime ,
				ElapsedTime = elapsedTime ,
				ViewportWidth = ViewportWidth ,
				ViewportHeight = ViewportHeight ,
				WorldXMax = WorldXMax ,
				WorldYMax = WorldYMax
			};
			if ( InputGameStateHandler != null ) InputGameStateHandler ( gameState.InputState );

			ExecutePostOperation ();

			if ( ActiveCamera != null ) ActiveCamera.Focus ();

			IEnumerable<IEventRaises> events = new List<IEventRaises> ();

			//обновляем все графические слои
			foreach ( var drawLevel in DrawLevels ) {
				drawLevel.Update ( gameState );
				events = events.Union ( drawLevel.Events ).ToList ();
				drawLevel.ClearEvents ();
			}

			//обработка событий
			if ( events.Count () > 0 ) {
				var allBehaviours = DrawLevels
						.AsParallel ()
						.SelectMany ( drawLevel => drawLevel.Objects )
						.SelectMany ( @object => @object.BehaviourCollection.Behaviors )
						.ToList ();
				foreach ( var @event in events ) {
					var behaviours = allBehaviours
						.Where ( behaviour => behaviour.EventCollection.Events.Any ( gameEvent => gameEvent.Handler == @event.ObjectName ) )
						.ToList ();
					foreach ( var eventName in @event.Events ) {
						behaviours
							.AsParallel ()
							.Where ( a => a.EventCollection.Events.Any ( gameEvent => gameEvent.Name == eventName ) )
							.ForAll (
								( a ) => {
									a.EventHandler ( a.EventCollection.Events.First ( gameEvent => gameEvent.Name == eventName ) );
								}
							);
					}
				}
			}

			//обновляем менеджер интерфейса
			if ( GUIManager != null ) GUIManager.Update ( gameState );
		}

		/// <summary>
		/// Выполнить пост операции.
		/// </summary>
		private void ExecutePostOperation () {
			//выполнить пост операции
			foreach ( var action in m_PostUpdateActions ) action ( this );
			m_PostUpdateActions.Clear ();
		}

		/// <summary>
		/// Добавить слой графики.
		/// </summary>
		/// <param name="drawLevel">Слой графики.</param>
		public void Add ( IDrawLevel drawLevel ) {
			drawLevel.GameWorld = this;
			m_DrawLevels.Add ( drawLevel );
		}

		/// <summary>
		/// Удалить слой графики.
		/// </summary>
		/// <param name="name">Имя слоя графики.</param>		
		public void Remove ( string name ) {
			var levels = m_DrawLevels.Where ( a => a.Name == name ).ToList ();
			foreach ( var level in levels ) {
				m_DrawLevels.Remove ( level );
			}
		}

		/// <summary>
		/// Текущие мировые координаты по оси X.
		/// </summary>
		public int WorldX {
			get {
				return m_WorldX;
			}
			set {
				m_WorldX = value.LimitToRange ( 0 , WorldXMax );
			}
		}

		/// <summary>
		/// Текущие мировые координаты по оси Y.
		/// </summary>		
		public int WorldY {
			get {
				return m_WorldY;
			}
			set {
				m_WorldY = value.LimitToRange ( 0 , WorldYMax );
			}
		}

		/// <summary>
		/// Ширина области просмотра.
		/// </summary>
		public int ViewportWidth {
			get;
			set;
		}

		/// <summary>
		/// Высота области просмотра.
		/// </summary>
		public int ViewportHeight {
			get;
			set;
		}

		/// <summary>
		/// Мировая текущая координата по оси X конец диапазона.
		/// </summary>
		public int WorldXEnd {
			get {
				return WorldX + ViewportWidth;
			}
		}

		/// <summary>
		/// Мировая текущая координата по оси Y конец диапазона.
		/// </summary>		
		public int WorldYEnd {
			get {
				return WorldY + ViewportHeight;
			}
		}

		/// <summary>
		/// Максимальная координата по оси X.
		/// </summary>
		public int WorldXMax {
			get;
			set;
		}

		/// <summary>
		/// Максимальная координата по оси Y.
		/// </summary>
		public int WorldYMax {
			get;
			set;
		}

		/// <summary>
		/// Имя игрового мира.
		/// </summary>
		public string Name {
			get;
			set;
		}

		/// <summary>
		/// Обработчик состояния устройств ввода.
		/// </summary>
		public Action<IInputGameState> InputGameStateHandler {
			get;
			set;
		}

		/// <summary>
		/// Коллекция состояний игрового мира.
		/// </summary>
		public IList<IObjectState> States {
			get {
				return m_States;
			}
		}

		/// <summary>
		/// Освободить ресурсы.
		/// </summary>
		public void FreeResources () {
			foreach ( var drawLevel in m_DrawLevels ) {
				drawLevel.FreeResources ();
			}
		}

		/// <summary>
		/// Менеджер GUI.
		/// </summary>
		public IGUIManager GUIManager {
			get;
			set;
		}

		/// <summary>
		/// Добавить постоперацию обновления.
		/// </summary>
		/// <param name="action">Действие которое будет выполнено после обновления.</param>
		public void AddPostOperation ( Action<IGameWorld> action ) {
			m_PostUpdateActions.Add ( action );
		}

		/// <summary>
		/// Камеры игрового мира.
		/// </summary>
		public IList<ICamera> Cameras {
			get {
				return m_Cameras;
			}
		}

		/// <summary>
		/// Активная камера.
		/// </summary>
		public ICamera ActiveCamera {
			get {
				return m_ActiveCamera;
			}
			set {
				if ( m_Cameras.Contains ( value ) ) m_ActiveCamera = value;
			}
		}
	}
}
