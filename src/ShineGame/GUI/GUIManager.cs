using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AbstractGameLogic;
using AbstractGameLogic.GUI;
using AbstractGameLogic.State;
using ShineGame.CommonRoutine;

namespace ShineGame.GUI {

	/// <summary>
	/// Менеджер графического интерфейса.
	/// </summary>
	internal class GUIManager : IGUIManager , ISkinResources {

		private string m_Skin;

		private const string BasicSkinsDirectoryName = "Skins";

		private IList<IGUIWindow> m_Windows = new List<IGUIWindow> ();

		private Lazy<List<IObjectState>> m_States = new Lazy<List<IObjectState>> ();

		private IMouseCursor m_MouseCursor;

		/// <summary>
		/// Курсор мыши.
		/// </summary>
		public IMouseCursor MouserCursor {
			get {
				return m_MouseCursor;
			}
		}

		/// <summary>
		/// Окна.
		/// </summary>
		public IEnumerable<IGUIWindow> Windows {
			get {
				return m_Windows;
			}
		}

		/// <summary>
		/// Текущая шкура.
		/// </summary>
		public string Skin {
			get {
				return m_Skin;
			}
			set {
				m_Skin = value;
				Resources = new SkinResources {
					CommonFont = GameContentManager.GetFont ( Path.Combine ( BasicSkinsDirectoryName , m_Skin , "commonFont" ) ) ,
					ContainerTexture = GameContentManager.GetTexture ( Path.Combine ( BasicSkinsDirectoryName , m_Skin , "containerTexture" ) ) ,
					MouseCursorTexture = GameContentManager.GetTexture ( Path.Combine ( BasicSkinsDirectoryName , m_Skin , "mouseCursor" ) )
				};
				m_MouseCursor = new MouseCursor {
					Manager = this ,
					Name = "DisplayCursor" ,
					IsEnabled = true ,
					IsVisible = true ,
					Parent = null
				};
				m_MouseCursor.Initialize ();
			}
		}

		/// <summary>
		/// Ресурсы шкуры.
		/// </summary>
		public SkinResources Resources {
			get;
			set;
		}

		/// <summary>
		/// Обновить состояние графического интерфейса.
		/// </summary>
		/// <param name="gameState">Игровое состояние.</param>
		public void Update ( IGameState gameState ) {
			m_MouseCursor.Update ( gameState );
			foreach ( var window in m_Windows.OrderBy ( a => a.ZIndex ) ) window.Update ( gameState );
		}

		/// <summary>
		/// Нарисовать графический интерфейс.
		/// </summary>
		public void Draw () {
			foreach ( var window in m_Windows.OrderBy ( a => a.ZIndex ) ) window.Draw ();
			if ( IsMouseVisible ) m_MouseCursor.Draw ();
		}

		/// <summary>
		/// Отобразить окно.
		/// </summary>
		/// <param name="window"></param>
		public void ShowWindow ( IGUIWindow window ) {
			if ( !m_Windows.Contains ( window ) ) m_Windows.Add ( window );
			ActivateWindow ( window );
		}

		/// <summary>
		/// Имя.
		/// </summary>
		public string Name {
			get;
			set;
		}

		/// <summary>
		/// Состояния.
		/// </summary>
		public IList<IObjectState> States {
			get {
				return m_States.Value;
			}
		}

		/// <summary>
		/// Закрыть окно.
		/// </summary>
		/// <param name="window">Окно для закрытия.</param>
		public void CloseWindow ( IGUIWindow window ) {
			if ( m_Windows.Contains ( window ) ) m_Windows.Remove ( window );
		}

		/// <summary>
		/// Активировать окно.
		/// </summary>
		/// <param name="window">Окно для активации.</param>
		public void ActivateWindow ( IGUIWindow window ) {
			//меняем порядок всех окон относительно нового 
			window.ZIndex = m_Windows.Max ( a => a.ZIndex ) + 1;
			var windows = m_Windows.OrderBy ( a => a.ZIndex );
			var iterator = 0;
			foreach ( var currentWindow in windows ) {
				currentWindow.ZIndex = iterator;
				window.IsFocused = false;
				iterator++;
			}
			window.IsFocused = true;
		}

		/// <summary>
		/// Признак видимости курсора мыши.
		/// </summary>
		public bool IsMouseVisible {
			get;
			set;
		}
	}

}
