using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic;
using AbstractGameLogic.Attributes;
using AbstractGameLogic.Factories;
using AbstractGameLogic.ObjectBehavior;
using AbstractGameLogic.ObjectVisual;
using AbstractGameLogic.Physics;

namespace PrisonerLevelBehaviours.Environment {

	/// <summary>
	/// Класс описывающий ящик.
	/// </summary>
	[ObjectBindBehaviour ( Name = Box.NameBehaviour , Description = "Квадратная коробка с включенной физикой." )]
	public class Box : ObjectBehaviour {

		public const string NameBehaviour = "Box";

		private IPhysicsBox m_Box;

		/// <summary>
		/// Инициализация объекта.
		/// </summary>
		/// <param name="factorys">Хост фабрик.</param>
		public override void InitializeVisualObject () {
			m_Box = m_FactoryHost.Physics.CreateBox ( VisualObject.DrawLevel.PhysicsWorld );
			m_Box.Type = PhysicsType.Dynamic;
			m_Box.Density = 500.0f;
			m_Box.Friction = 1.0f;
			m_Box.IsRotating = false;
			m_Box.Width = VisualObject.Width;
			m_Box.Height = VisualObject.Height;
			m_Box.UpdateState ();
			m_Box.SetPosition ( VisualObject.WorldX , VisualObject.WorldY );
			m_Box.Object = VisualObject;
		}

		/// <summary>
		/// Обновление состояния объекта.
		/// </summary>
		/// <param name="gameState">Состояние игры.</param>
		public override void Update ( IGameState gameState ) {
			VisualObject.SetVector ( m_Box.GetVector () );
			VisualObject.Rotate = m_Box.Rotate;
			var velocity = m_Box.GetLinearVelocity ();
			if ( m_Box.GetCollisionList ().Any () && velocity.Item2 < 0.3f ) {
				m_Box.SetLinearVelocity ( velocity.Item1 > 1.0f || velocity.Item1 < -1.0f ? 1.0f : 0.0f , velocity.Item2 );
			}
		}
	}

}
