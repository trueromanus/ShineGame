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
using AbstractGameLogic.State;

namespace PrisonerLevelBehaviours.Actions {

	/// <summary>
	/// Камень.
	/// </summary>
	[ObjectBindBehaviour ( Name = Stone.NameBehaviour , Description = "Поведение для бросаемого камня с учетом физики." )]
	[GameAction ( Name = Stone.ThrowAction , Description = "Бросить камень." )]
	[GameState ( Name = Stone.ThrowedObjectState , Description = "Привязанный к камню визуальный объект." )]
	public class Stone : ObjectBehaviour {

		public const string ThrowAction = "throw";

		public const string ThrowedObjectState = "ThrowedObject";

		public const string NameBehaviour = "Stone";

		private IPhysicsBox m_Box;

		private bool m_IsFirstCollide = false;

		private int m_Distance = 0;

		private IGameObjectVisual m_AttachedObject;

		/// <summary>
		/// Инициализация поведения.
		/// </summary>
		/// <param name="factorys">Хост фабрик.</param>
		/// <exception cref="ArgumentException"></exception>
		public override void InitializeVisualObject () {
			m_Box = m_FactoryHost.Physics.CreateBox ( VisualObject.DrawLevel.PhysicsWorld );
			m_Box.Type = PhysicsType.Dynamic;
			m_Box.IsAllowSleep = true;
			m_Box.Density = 25.0f;
			m_Box.Friction = 0.0f;
			m_Box.Width = VisualObject.Width;
			m_Box.Height = VisualObject.Height;
			m_Box.Restitution = 0.0f;
			m_Box.IsRotating = true;
			m_Box.AngularDumping = 0.0f;
			m_Box.LinearDumping = 0.0f;
			m_Box.IsBullet = true;
			m_Box.UpdateState ();
			m_Box.SetPosition ( VisualObject.WorldX , VisualObject.WorldY );
			m_Box.IsAwake = false;
			m_Box.Object = VisualObject;

			string attachedObjectName = VisualObject.States
				.Where ( a => a.Name == ThrowedObjectState )
				.Select ( a => a.Value.ToString () )
				.FirstOrDefault ();
			if ( attachedObjectName == null ) throw new ArgumentException ( string.Format ( "Нет состояния в объекте с именем {0}." , ThrowedObjectState ) );
			m_AttachedObject = VisualObject.DrawLevel.Objects
				.Where ( a => a.Name == attachedObjectName )
				.FirstOrDefault ();
			if ( m_AttachedObject == null ) throw new ArgumentException ( "Не удалось найти " );
		}

		/// <summary>
		/// Обновление состояния поведения.
		/// </summary>
		/// <param name="gameState">Состояние игры.</param>
		public override void Update ( IGameState gameState ) {
			if ( !m_Box.IsAwake ) return;

			VisualObject.SetVector ( m_Box.GetVector () );
			VisualObject.Rotate = m_Box.Rotate;
			if ( !m_IsFirstCollide ) {
				if ( ( VisualObject.WorldX - m_Distance ) < 150 ) {
					m_Box.ApplyLinearImpulse ( 12000.0f - ( VisualObject.WorldX - m_Distance ) , ( VisualObject.WorldX - m_Distance ) < 100 ? -4000.0f : -1000.0f , (float) ( VisualObject.WorldX ) , (float) ( VisualObject.WorldYEnd + 1.0f ) );
					m_Box.ApplyAngularImpulse ( 200.0f + ( VisualObject.WorldX - m_Distance ) );
				}
				m_IsFirstCollide = m_Box.GetCollisionList ().Any ();
				if ( m_IsFirstCollide ) {
					m_Box.AngularDumping = 60.0f;
					m_Box.Friction = 1.0f;
				}
			}
			else {
				m_Box.LinearDumping = m_Box.GetCollisionList ().Any () ? 5.0f : 0.1f;
			}

		}

		/// <summary>
		/// Обработчик событий.
		/// </summary>
		/// <param name="event">Событие.</param>
		public override void EventHandler ( IEvent @event ) {
			if ( @event.Action == ThrowAction && m_AttachedObject != null ) Throw ();
		}

		/// <summary>
		/// Бросить камень.
		/// </summary>
		public void Throw () {
			if ( !m_Box.IsAwake ) {
				m_Box.IsAwake = true;
			}
			else {
				m_Box.IsAwake = false;
				m_Box.SetPosition ( -100 , -100 );
				m_Box.IsAwake = true;
			}
			m_Box.SetPosition ( m_AttachedObject.WorldXEnd + 5 , m_AttachedObject.WorldY - 2 );
			m_IsFirstCollide = false;
			m_Distance = m_AttachedObject.WorldX;
			m_Box.LinearDumping = 0.0f;
		}
	}

}
