using System;
using System.Linq;
using AbstractGameLogic;
using AbstractGameLogic.Attributes;
using AbstractGameLogic.Factories;
using AbstractGameLogic.ObjectBehavior;
using AbstractGameLogic.ObjectVisual;
using AbstractGameLogic.Physics;
using AbstractGameLogic.State;
using PrisonerLevelBehaviours.Models;

namespace PrisonerLevelBehaviours.Actions {

	/// <summary>
	/// Движение для платформера.
	/// </summary>
	[ObjectBindBehaviour ( Name = PlatformerMoving.BehaviourName , Description = "Поведение позволяющее передвигаться и прыгать с учетом физики уровня." )]
	[GameAction ( Name = PlatformerMoving.MovingLeft , Description = "Двигаться влево." )]
	[GameAction ( Name = PlatformerMoving.MovingRight , Description = "Двигаться вправо." )]
	[GameAction ( Name = PlatformerMoving.Jump , Description = "Прыгнуть." )]
	[GameAction ( Name = PlatformerMoving.Squat , Description = "Присесть." )]
	[GameAction ( Name = PlatformerMoving.Blocking , Description = "Заблокировать поведение. Это нужно например чтобы проиграть сценку или вывести текст и в этот момент игрок не двигался." )]
	[GameAction ( Name = PlatformerMoving.Unblocking , Description = "Разблокировать поведение." )]
	public class PlatformerMoving : ObjectBehaviour {

		public const string BehaviourName = "Platformer";

		public const string MovingLeft = "movingLeft";

		public const string MovingRight = "movingRight";

		public const string Jump = "jump";

		public const string Squat = "squat";

		public const string Blocking = "blocking";

		public const string Unblocking = "unblocking";

		private IPhysicsBox m_Box;

		private int m_EndJumpPosition = 0;

		private ITileAnimatedObject m_TileAnimated;

		private PlatformerStateModel m_PlatformerStateModel;

		/// <summary>
		/// Обновить состояние объекта.
		/// </summary>
		/// <param name="object">Объект для обновления.</param>
		/// <param name="gameState">Игровое состояние.</param>
		public override void Update ( IGameState gameState ) {
			//если модель заблокирована то не обрабатываем поведение
			if ( m_PlatformerStateModel.IsBlocked ) return;

			VisualObject.WorldX = m_Box.X;
			VisualObject.WorldY = m_Box.Y;
			float velocityY = 0.0f;
			float velocityX = 0.0f;

			var collisionList = m_Box.GetCollisionList ().ToList ();

			var bottomCollision = collisionList.Any ( a => a.WorldY >= VisualObject.WorldYEnd );

			if ( bottomCollision && !m_PlatformerStateModel.IsJumping ) {
				m_PlatformerStateModel.StateType = PlatformerStateType.Stand;
				velocityY = m_PlatformerStateModel.FallSpeed;
			}
			if ( !bottomCollision && !m_PlatformerStateModel.IsJumping ) {
				m_PlatformerStateModel.StateType = PlatformerStateType.Falling;
				velocityY = m_Box.GetLinearVelocity ().Item2 + 0.001f;
			}
			if ( m_PlatformerStateModel.IsJumping ) {
				if ( !m_PlatformerStateModel.Controller.IsTop || VisualObject.WorldY <= m_EndJumpPosition || collisionList.Any ( a => a.WorldYEnd <= VisualObject.WorldY ) ) {
					m_PlatformerStateModel.StateType = PlatformerStateType.Falling;
					velocityY = 0.0f;
				}
				else {
					velocityY = m_PlatformerStateModel.JumpSpeed;
				}
			}

			if ( m_PlatformerStateModel.Controller.IsTop ) {
				if ( m_PlatformerStateModel.IsStayGround ) {
					m_EndJumpPosition = VisualObject.WorldY - m_PlatformerStateModel.JumpHeight;
					m_PlatformerStateModel.StateType = PlatformerStateType.Jumping;
					velocityY = m_PlatformerStateModel.JumpSpeed;
				}
			}
			if ( m_PlatformerStateModel.IsHorizontalController ) {
				m_TileAnimated.IsVerticalMirror = m_PlatformerStateModel.Controller.IsLeft;
				if ( !m_PlatformerStateModel.IsStayGround ) {
					velocityX = m_PlatformerStateModel.Controller.IsLeft ? -m_PlatformerStateModel.MovingSpeedInJump : m_PlatformerStateModel.MovingSpeedInJump;
				}
				else {
					velocityX = m_PlatformerStateModel.Controller.IsLeft ? -m_PlatformerStateModel.MovingSpeed : m_PlatformerStateModel.MovingSpeed;
				}
			}
			m_Box.SetLinearVelocity ( velocityX , velocityY );

			m_PlatformerStateModel.Controller.Reset ();
		}

		/// <summary>
		/// Инициализация.
		/// </summary>
		/// <param name="object">Визуальный объект.</param>
		public override void InitializeVisualObject () {
			m_TileAnimated = ( VisualObject as ITileAnimatedObject );
			if ( m_TileAnimated == null ) throw new ArgumentException ( "Объект для привязки к платформер должен быть с типом тайловой анимации." , "@object" );
			m_PlatformerStateModel = new PlatformerStateModel ();

			m_Box = m_FactoryHost.Physics.CreateBox ( VisualObject.DrawLevel.PhysicsWorld );
			m_Box.Type = PhysicsType.Dynamic;
			m_Box.Density = 60.0f;
			m_Box.Friction = 0.0f;
			m_Box.IsRotating = false;
			m_Box.Width = VisualObject.Width;
			m_Box.Height = VisualObject.Height;
			m_Box.UpdateState ();
			m_Box.SetPosition ( VisualObject.WorldX , VisualObject.WorldY );
			m_Box.Object = VisualObject;
		}

		/// <summary>
		/// Обработчик событий.
		/// </summary>
		/// <param name="event">Возбужденное событие.</param>
		public override void EventHandler ( IEvent @event ) {
			switch ( @event.Action ) {
				case MovingLeft:
					m_PlatformerStateModel.Controller.IsLeft = true;
					break;
				case MovingRight:
					m_PlatformerStateModel.Controller.IsRight = true;
					break;
				case Jump:
					m_PlatformerStateModel.Controller.IsTop = true;
					break;
				case Squat:
					m_PlatformerStateModel.Controller.IsBottom = true;
					break;
			}
		}

	}

}
