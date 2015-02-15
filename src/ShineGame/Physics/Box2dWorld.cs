using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic;
using AbstractGameLogic.Physics;
using Box2D.XNA;
using Microsoft.Xna.Framework;

namespace ShineGame.Physics {

	/// <summary>
	/// Физический мир.
	/// </summary>
	public class Box2dWorld : IPhysicsWorld {

		private World m_World;

		/// <summary>
		/// Физический мир Box2D.
		/// </summary>
		public World World {
			get {
				return m_World;
			}
		}

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="gravityX">Гравитация по оси X.</param>
		/// <param name="gravityY">Гравитация по оси Y.</param>
		public Box2dWorld ( float gravityX , float gravityY ) {
			m_World = new World ( new Vector2 ( gravityX , gravityY ) , true );
			Settings.b2_maxTranslation = 3.1f;
		}

		/// <summary>
		/// Гравитация по оси X.
		/// </summary>
		public float GravityX {
			get {
				return m_World.Gravity.X;
			}
			set {
				m_World.Gravity = new Vector2 ( value , GravityY );
			}
		}

		/// <summary>
		/// Гравитация по оси X.
		/// </summary>
		public float GravityY {
			get {
				return m_World.Gravity.Y;
			}
			set {
				m_World.Gravity = new Vector2 ( GravityX , value );
			}
		}

		/// <summary>
		/// Обновить состояние физического мира.
		/// </summary>
		/// <param name="state">Состояние игры.</param>
		public void Update ( IGameState state ) {
			//m_World.ClearForces ();
			m_World.Step ( 1.0f / 64.0f , 8 , 3 );
		}

		public void AddObject ( IPhysicsObject physicsObject ) {

		}

		public void RemoveObject ( IPhysicsObject physicsObject ) {
			throw new NotImplementedException ();
		}
	}
}
