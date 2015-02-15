using System.Collections.Generic;

namespace AbstractGameLogic.GUI {

	/// <summary>
	/// Менеджер графического интерфейса пользователя.
	/// </summary>
	public interface IGUIManager : IGameObject {

		/// <summary>
		/// Текущая шкура.
		/// </summary>
		string Skin {
			get;
			set;
		}

		/// <summary>
		/// Окна.
		/// </summary>
		IEnumerable<IGUIWindow> Windows {
			get;
		}

		/// <summary>
		/// Видим ли курсор мыши.
		/// </summary>
		bool IsMouseVisible {
			get;
			set;
		}

		/// <summary>
		/// Обновить состояние GUI.
		/// </summary>
		/// <param name="gameState">Игровое состояние.</param>
		void Update ( IGameState gameState );

		/// <summary>
		/// Нарисовать GUI.
		/// </summary>
		void Draw ();

		/// <summary>
		/// Показать окно.
		/// </summary>
		/// <param name="window">Окно для показа.</param>
		void ShowWindow ( IGUIWindow window );

		/// <summary>
		/// Закрыть окно.
		/// </summary>
		/// <param name="window">Окно дла закрытия.</param>
		void CloseWindow ( IGUIWindow window );

		/// <summary>
		/// Активировать окно.
		/// </summary>
		/// <param name="window">Окно для активации.</param>
		void ActivateWindow ( IGUIWindow window );

	}

}
