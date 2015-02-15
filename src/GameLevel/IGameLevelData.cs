using System;
using System.Collections.Generic;
using AbstractGameLogic;
using AbstractGameLogic.GUI;

namespace GameLevel {

	/// <summary>
	/// Данные об игровом уровне.
	/// </summary>
	public interface IGameLevelData {

		/// <summary>
		/// Имя уровня.
		/// </summary>
		string Name {
			get;
			set;
		}

		/// <summary>
		/// Описание уровня.
		/// </summary>
		string Description {
			get;
			set;
		}

		/// <summary>
		/// Графические слои.
		/// </summary>
		IEnumerable<IDrawLevel> DrawLevels {
			get;
		}

		/// <summary>
		/// Менеджер графического интерфейса.
		/// </summary>
		IGUIManager GUIManager {
			get;
			set;
		}

	}

}
