using AbstractGameLogic.Factories;
using AbstractGameLogic.GameLevel;
using AbstractGameLogic.GUI;
using ShineGame.GUI;
using ShineGame.Levels;

namespace ShineGame.Factories {

	/// <summary>
	/// Фабрика уровней.
	/// </summary>
	internal class LevelFactory : ILevelFactory {

		/// <summary>
		/// Создать менеджер уровней.
		/// </summary>
		/// <returns>Менеджер уровней.</returns>
		public ILevelManager CreateLevelManager () {
			return new LevelManager ();
		}

		/// <summary>
		/// Создать загрузчик уровней.
		/// </summary>
		/// <returns>Загрузчик уровней.</returns>
		public ILevelLoader CreateLevelLoader () {
			return new DefaultLevelLoader ();
		}

		/// <summary>
		/// Создать менеджер графического интерфейса.
		/// </summary>
		/// <returns>Менеджер графического интерфейса.</returns>
		public IGUIManager CreateGUIManager () {
			return new GUIManager ();
		}

	}

}
