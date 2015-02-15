using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.Physics;

namespace AbstractGameLogic.Factories {

	/// <summary>
	/// Фабрика физиеских объектов.
	/// </summary>
	public interface IPhysicsFactory {

		/// <summary>
		/// Создать физический мир.
		/// </summary>
		/// <param name="gravityX">Гравитация по оси X.</param>
		/// <param name="gravityY">Гравитация по оси Y.</param>
		/// <returns>Физический мир.</returns>
		IPhysicsWorld CreateWorld ( float gravityX , float gravityY );

		/// <summary>
		/// Создать прямоугольник в физическом мире.
		/// </summary>
		/// <returns>Прямоугольник.</returns>
		IPhysicsBox CreateBox ( IPhysicsWorld world );

		/// <summary>
		/// Создать линию в физическом мире.
		/// </summary>
		/// <returns>Линия.</returns>
		IPhysicsLine CreateLine ( IPhysicsWorld world );

	}

}
