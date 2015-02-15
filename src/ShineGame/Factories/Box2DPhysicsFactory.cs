using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.Factories;
using AbstractGameLogic.Physics;
using Box2D.XNA;
using ShineGame.Physics;

namespace ShineGame.Factories {

	/// <summary>
	/// Фабрика физики на основе Box2D.
	/// </summary>
	public class Box2DPhysicsFactory : IPhysicsFactory {

		/// <summary>
		/// Создать физический мир.
		/// </summary>
		/// <param name="gravityX">Гравитация по оси X.</param>
		/// <param name="gravityY">Гравитация по оси Y.</param>
		/// <returns>Физический мир.</returns>
		public IPhysicsWorld CreateWorld ( float gravityX , float gravityY ) {
			return new Box2dWorld ( gravityX , gravityY );
		}

		/// <summary>
		/// Получить физический мир  Box2d.
		/// </summary>
		/// <param name="world">Абстракция физического мира.</param>
		/// <returns>Физический мир Box2d.</returns>
		private World GetBox2dWorld ( IPhysicsWorld world ) {
			Box2dWorld box2Dworld = ( world as Box2dWorld );
			if ( box2Dworld == null ) throw new InvalidCastException ( "При использовании движка Box2D необходимо использование класса физического мира - Box2dWorld." );

			return box2Dworld.World;
		}

		/// <summary>
		/// Создать объект прямоугольник.
		/// </summary>
		/// <returns>Прямоугольник.</returns>
		public IPhysicsBox CreateBox ( IPhysicsWorld world ) {
			var box = new Box2dBox ( GetBox2dWorld ( world ) );
			world.AddObject ( box );
			return box;
		}

		/// <summary>
		/// Создать объект линия.
		/// </summary>
		/// <returns>Линия.</returns>
		public IPhysicsLine CreateLine ( IPhysicsWorld world ) {
			var line = new Box2dLine ( GetBox2dWorld ( world ) );
			world.AddObject ( line );
			return line;
		}

	}


}
