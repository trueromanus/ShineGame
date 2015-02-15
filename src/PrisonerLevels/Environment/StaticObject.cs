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
	/// Статический объект.
	/// </summary>
	[ObjectBindBehaviour ( Name = StaticObject.NameBehaviour , Description = "Статический неизменяемый объект (стена, пол, потолок и т.п.)." )]
	public class StaticObject : ObjectBehaviour {

		private IPhysicsBox m_Box;

		public const string NameBehaviour = "Static";

		/// <summary>
		/// Инициализация объекта поведения.
		/// </summary>
		/// <param name="object">Объект к которому будет привязано поведение.</param>
		/// <param name="factorys"></param>
		public override void InitializeVisualObject () {
			m_Box = m_FactoryHost.Physics.CreateBox ( VisualObject.DrawLevel.PhysicsWorld );
			m_Box.Type = PhysicsType.Static;
			m_Box.IsRotating = false;
			m_Box.Density = 1.0f;
			m_Box.Width = VisualObject.Width;
			m_Box.Height = VisualObject.Height;
			m_Box.UpdateState ();
			m_Box.SetPosition ( VisualObject.WorldX , VisualObject.WorldY );
			m_Box.Object = VisualObject;
		}

		/// <summary>
		/// Обновление состояния объекта.
		/// </summary>
		/// <param name="object">Объект по кот</param>
		/// <param name="gameState">Игровое состояние.</param>
		public override void Update ( IGameState gameState ) {
			//заглушка
		}

	}

}
