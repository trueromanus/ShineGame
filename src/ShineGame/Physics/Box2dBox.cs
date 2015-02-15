using System;
using Box2D.XNA;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.Physics;
using Microsoft.Xna.Framework;
using AbstractGameLogic.ObjectVisual;

namespace ShineGame.Physics {

	/// <summary>
	/// Прямоугольник физический.
	/// </summary>
	public class Box2dBox : BasicPhysicsObject , IPhysicsBox {

		private int m_WidthHalf;

		private int m_HeightHalf;

		private PolygonShape m_Shape = new PolygonShape ();

		private Fixture m_Fixture;

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="box2dWorld"></param>
		public Box2dBox ( World box2dWorld ) {
			var def = new BodyDef ();
			m_Body = box2dWorld.CreateBody ( new BodyDef () );
		}

		/// <summary>
		/// Высота.
		/// </summary>
		public int Width {
			get;
			set;
		}

		/// <summary>
		/// Длина.
		/// </summary>
		public int Height {
			get;
			set;
		}

		/// <summary>
		/// Получить координату объекта по оси X.
		/// </summary>
		protected override int GetX () {
			return Convert.ToInt32 ( m_Body.Position.X - m_WidthHalf );
		}

		/// <summary>
		/// Получить координату объекта по оси Y.
		/// </summary>
		protected override int GetY () {
			return Convert.ToInt32 ( m_Body.Position.Y - m_HeightHalf );
		}

		/// <summary>
		/// Обновить состояние объекта.
		/// </summary>
		public override void UpdateState () {
			if ( m_Fixture != null ) m_Body.DestroyFixture ( m_Fixture );

			m_WidthHalf = Width / 2;
			m_HeightHalf = Height / 2;
			MassData massData;
			m_Shape.SetAsBox ( m_WidthHalf , m_HeightHalf );
			m_Shape.ComputeMass ( out massData , Density );
			m_Body.SetMassData ( ref massData );
			m_Fixture = m_Body.CreateFixture ( m_Shape , Density );
			m_Fixture.SetFriction ( Friction );
		}

		/// <summary>
		/// Установить позицию.
		/// </summary>
		/// <param name="x">Координата по оси X.</param>
		/// <param name="y">Координата по оси Y.</param>
		public override void SetPosition ( int x , int y ) {
			base.SetPosition ( x + m_WidthHalf , y + m_HeightHalf );
		}

		/// <summary>
		/// Получить вектор положения.
		/// </summary>
		public override IVector2 GetVector () {
			return new ShineVector2 {
				X = m_Body.Position.X - m_WidthHalf ,
				Y = m_Body.Position.Y - m_HeightHalf
			};
		}

	}
}
