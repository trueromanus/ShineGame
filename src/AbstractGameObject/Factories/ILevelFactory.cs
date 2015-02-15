using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.GameLevel;
using AbstractGameLogic.GUI;

namespace AbstractGameLogic.Factories {

	/// <summary>
	/// Фабрика уровней.
	/// </summary>
	public interface ILevelFactory {

		/// <summary>
		/// Создать менеджер уровней.
		/// </summary>
		/// <returns>Менеджер уровней</returns>
		ILevelManager CreateLevelManager ();

		/// <summary>
		/// Создать загрузчик уровней.
		/// </summary>
		/// <returns>Загрузчик уровней.</returns>
		ILevelLoader CreateLevelLoader ();

		/// <summary>
		/// Создать менеджер графического интерфейса.
		/// </summary>
		/// <returns></returns>
		IGUIManager CreateGUIManager ();

	}

}
