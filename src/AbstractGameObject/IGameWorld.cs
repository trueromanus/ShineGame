using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.GUI;

namespace AbstractGameLogic {

	/// <summary>
	/// Игровой мир.
	/// </summary>
	public interface IGameWorld : IGameObject {

		/// <summary>
		/// Мировая текущая координата по оси X.
		/// </summary>
		int WorldX {
			get;
			set;
		}

		/// <summary>
		/// Мировая текущая координата по оси Y.
		/// </summary>
		int WorldY {
			get;
			set;
		}

		/// <summary>
		/// Мировая текущая координата по оси X конец диапазона.
		/// </summary>
		int WorldXEnd {
			get;
		}

		/// <summary>
		/// Мировая текущая координата по оси Y конец диапазона.
		/// </summary>
		int WorldYEnd {
			get;
		}

		/// <summary>
		/// Ширина области просмотра.
		/// </summary>
		int ViewportWidth {
			get;
			set;
		}

		/// <summary>
		/// Высота области просмотра.
		/// </summary>
		int ViewportHeight {
			get;
			set;
		}

		/// <summary>
		/// Максимальная координата по оси X.
		/// </summary>
		int WorldXMax {
			get;
			set;
		}

		/// <summary>
		/// Максимальная координата по оси Y.
		/// </summary>
		int WorldYMax {
			get;
			set;
		}

		/// <summary>
		/// Уровни отрисовки мира.
		/// </summary>
		IEnumerable<IDrawLevel> DrawLevels {
			get;
		}

		/// <summary>
		/// Обработчик состояния устройств ввода.
		/// </summary>
		Action<IInputGameState> InputGameStateHandler {
			get;
			set;
		}

		/// <summary>
		/// Менеджер графического интерфейса.
		/// </summary>
		IGUIManager GUIManager {
			get;
			set;
		}

		/// <summary>
		/// Список камер.
		/// </summary>
		IList<ICamera> Cameras {
			get;
		}

		/// <summary>
		/// Активная в текущий момент камера.
		/// </summary>
		ICamera ActiveCamera {
			get;
			set;
		}

		/// <summary>
		/// Добавить слой графики.
		/// </summary>
		/// <param name="drawLevel">Слой графики.</param>
		void Add ( IDrawLevel drawLevel );

		/// <summary>
		/// Добавить операцию после обновления.
		/// </summary>
		/// <param name="action">Действие которое будет выполнено после обновления.</param>
		void AddPostOperation ( Action<IGameWorld> action );

		/// <summary>
		/// Удалить слой графики.
		/// </summary>
		/// <param name="name">Имя слоя графики.</param>
		void Remove ( string name );

		/// <summary>
		/// Отрисовать игровой мир.
		/// </summary>
		///<param name="elapsedTime">Пройденное время с последнего обновления.</param>
		///<param name="totalTime">Общее время после запуска игры.</param>
		void Draw ( TimeSpan totalTime , TimeSpan elapsedTime );

		/// <summary>
		/// Обновить состояние игрового мира.
		/// </summary>
		///<param name="elapsedTime">Пройденное время с последнего обновления.</param>
		///<param name="totalTime">Общее время после запуска игры.</param>
		void Update ( TimeSpan totalTime , TimeSpan elapsedTime );

		/// <summary>
		/// Освободить ресурсы захваченные миром.
		/// </summary>
		void FreeResources ();

	}
}
