using System;
using System.Collections.Generic;
using AbstractGameLogic;
using AbstractGameLogic.State;

namespace GameLevel {

	/// <summary>
	/// Предстваление логики игрового уровня.
	/// </summary>
	public interface IGameLevelLogic {

		/// <summary>
		/// Данные уровня.
		/// </summary>
		IGameLevelData LevelData {
			get;
		}

		/// <summary>
		/// Обработчик устройств ввода для текущего уровня.
		/// </summary>
		Action<IInputGameState> InputHandler {
			get;
			set;
		}

		/// <summary>
		/// Объекты состояния.
		/// </summary>
		IEnumerable<IObjectState> States {
			get;
		}

		/// <summary>
		/// Инициализация.
		/// </summary>
		IGameWorld Initialize ();

	}

}
