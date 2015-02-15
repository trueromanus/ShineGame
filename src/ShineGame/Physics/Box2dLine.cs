using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.Physics;
using Box2D.XNA;
using Microsoft.Xna.Framework;

namespace ShineGame.Physics {

	/// <summary>
	/// Физическая линия.
	/// </summary>
	public class Box2dLine : BasicPhysicsObject , IPhysicsLine {

		private EdgeShape m_Shape = new EdgeShape ();

		private Fixture m_Fixture;

		private int m_WidthHalf;

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="box2dWorld">Физический мир к которому привязать объект.</param>
		public Box2dLine ( World box2dWorld ) {
			m_Body = box2dWorld.CreateBody ( new BodyDef () );
		}

		/// <summary>
		/// Ширина линии.
		/// </summary>
		public int Width {
			get;
			set;
		}

		/// <summary>
		/// Получить координату объекта по оси X.
		/// </summary>
		protected override int GetX () {
			return Convert.ToInt32 ( m_Body.Position.X );
		}

		/// <summary>
		/// Получить координату объекта по оси Y.
		/// </summary>
		protected override int GetY () {
			return Convert.ToInt32 ( m_Body.Position.Y );
		}

		/// <summary>
		/// Обновить состояние объекта.
		/// </summary>
		public override void UpdateState () {
			if ( m_Fixture != null ) m_Body.DestroyFixture ( m_Fixture );

			m_WidthHalf = Width / 2;

			m_Shape.Set ( new Vector2 ( -m_WidthHalf , 0.0f ) , new Vector2 ( m_WidthHalf , 0.0f ) );
			
			MassData massData;
			m_Body.GetMassData ( out massData );
			massData.mass = Mass;
			massData.I = Inertia;
			m_Body.SetMassData ( ref massData );

			m_Fixture = m_Body.CreateFixture ( m_Shape , Density );
			m_Fixture.SetFriction ( Friction );
		}

	}
}
