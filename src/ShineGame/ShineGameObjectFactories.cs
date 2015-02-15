using ShineGame.Factories;
using AbstractGameLogic.Factories;

namespace ShineGame {

	/// <summary>
	/// Фабрики библиотеки.
	/// </summary>
	public static class ShineGameObjectFactories {

		/// <summary>
		/// Создать фабрику поведений.
		/// </summary>
		/// <returns></returns>
		public static IBehaviourFactory CreateBehaviourFactory () {
			return new BehavioursFactory ();
		}

		/// <summary>
		/// Создать фабрику игровых объектов.
		/// </summary>
		public static IGameObjectFactory CreateGameObjectFactory () {
			return new GameObjectFactory ();
		}

		/// <summary>
		/// Создать фабрику GUI объектов.
		/// </summary>
		public static IGUIFactory CreateGUIFactory () {
			return new GUIFactory ();
		}

		/// <summary>
		/// Создать фабрику физических объектов.
		/// </summary>
		public static IPhysicsFactory CreatePhysicsFactory () {
			return new Box2DPhysicsFactory ();
		}

		/// <summary>
		/// Создать фабрику состояний.
		/// </summary>
		public static IStateFactory CreateStateFactory () {
			return new StateFactory ();
		}

		/// <summary>
		/// Создать фабрику уровней.
		/// </summary>
		public static ILevelFactory CreateLevelFactory () {
			return new LevelFactory ();
		}

	}

}
