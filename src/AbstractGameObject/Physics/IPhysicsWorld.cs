using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.Physics {

	/// <summary>
	/// Физический мир.
	/// </summary>
	public interface IPhysicsWorld {

		/// <summary>
		/// Гравитация по оси X.
		/// </summary>
		float GravityX {
			get;
			set;
		}

		/// <summary>
		/// Гравитация по оси Y.
		/// </summary>
		float GravityY {
			get;
			set;
		}

		/// <summary>
		/// Обновить состояние физических объектов физического собственно говоря мира.
		/// </summary>
		void Update ( IGameState state );

		/// <summary>
		/// Добавить физический объект.
		/// </summary>
		/// <param name="physicsObject">Физический объект.</param>
		void AddObject ( IPhysicsObject physicsObject );

		/// <summary>
		/// Удалить физический объект.
		/// </summary>
		/// <param name="physicsObject">Физический объект.</param>
		void RemoveObject ( IPhysicsObject physicsObject );

	}

}
