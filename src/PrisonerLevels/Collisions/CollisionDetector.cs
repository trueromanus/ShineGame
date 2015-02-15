using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic;
using AbstractGameLogic.Attributes;
using AbstractGameLogic.Physics;

namespace PrisonerLevelBehaviours.Collisions {

	/// <summary>
	/// Поведение для обнаружения колизий.
	/// </summary>
	[GameEvent ( Name = CollisionEvent , Description = "Событие возникающее при колизиях с объектами. К названию будет добавлено имя объекта с которым произошла колизия." )]
	[ObjectBindBehaviour ( Name = CollisionDetector.NameBehaviour , Description = "Поведение позволяющее обрабатывать колизии относительно себя. При столкновении оно будет рассылать события до тех пор пока объекты не сдвинутся." )]
	public class CollisionDetector : ObjectBehaviour {

		public const string NameBehaviour = "CollisionDetector";

		public const string CollisionEvent = "Collision";

		private IPhysicsBox m_Box;

		/// <summary>
		/// Инициализация визуального объекта.
		/// </summary>
		public override void InitializeVisualObject () {
			m_Box = m_FactoryHost.Physics.CreateBox ( VisualObject.DrawLevel.PhysicsWorld );
			m_Box.Type = PhysicsType.Dynamic;
			m_Box.IsRotating = false;
			m_Box.Width = VisualObject.Width;
			m_Box.Height = VisualObject.Height;
			m_Box.IsSensor = true;
			m_Box.UpdateState ();
			m_Box.SetPosition ( VisualObject.WorldX , VisualObject.WorldY );
			m_Box.Object = VisualObject;
		}

		/// <summary>
		/// Обновление состояние детектора колизий.
		/// </summary>
		/// <param name="gameState">Игровое состояние.</param>
		public override void Update ( IGameState gameState ) {
			m_Box.SetPosition ( VisualObject.WorldX , VisualObject.WorldY );
			var names = m_Box.GetCollisionList ()
				.Select ( a => a.Name )
				.ToList ();
			foreach ( var name in names ) ThrowedEvent = CollisionEvent + name;
		}

	}

}
