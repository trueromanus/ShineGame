using AbstractGameLogic.Factories;
using AbstractGameLogic.ObjectVisual;

namespace AbstractGameLogic.ObjectBehavior {

	/// <summary>
	/// Ппведение визуального объекта.
	/// </summary>
	public interface IVisualObjectBehaviour : IObjectBehavior {

		/// <summary>
		/// Визуальный объект.
		/// </summary>
		IGameObjectVisual VisualObject {
			get;
			set;
		}

		/// <summary>
		/// Инициализация объекта отношения.
		/// </summary>
		/// <param name="factorys">Фабрики для создания объектов.</param>
		void Initialize ( IFactoryHost factorys );

		/// <summary>
		/// Обновить состояние поведения.
		/// </summary>
		/// <param name="gameState">Состояние игры.</param>
		void Update ( IGameState gameState );

	}

}
