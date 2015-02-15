using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.Attributes;

namespace PrisonerLevelBehaviours.Models {

	/// <summary>
	/// Модель состояний платформера.
	/// </summary>
	public class PlatformerStateModel {

		private PlatformerLimitModel m_Limits = new PlatformerLimitModel ();

		private MovingControllerModel m_Controller = new MovingControllerModel ();

		private PlatformerStateType m_StateType;

		/// <summary>
		/// Признак того что выполняется прыжок.
		/// </summary>
		public bool IsJumping {
			get {
				return m_StateType == PlatformerStateType.Jumping;
			}
		}

		/// <summary>
		/// Признак того что выполняется падение.
		/// </summary>
		public bool IsFalling {
			get {
				return m_StateType == PlatformerStateType.Falling;
			}
		}

		/// <summary>
		/// Тип состояния.
		/// </summary>
		public PlatformerStateType StateType {
			get {
				return m_StateType;
			}
			set {
				m_StateType = value;				
			}
		}

		/// <summary>
		/// Признак того блокированы ли движения.
		/// </summary>
		public bool IsBlocked {
			get;
			set;
		}

		/// <summary>
		/// Скорость перемещения.
		/// </summary>
		public float MovingSpeed {
			get;
			set;
		}

		/// <summary>
		/// Скорость перемещения в прыжке.
		/// </summary>
		public float MovingSpeedInJump {
			get;
			set;
		}

		/// <summary>
		/// Скорость прыжка.
		/// </summary>
		public float JumpSpeed {
			get;
			set;
		}

		/// <summary>
		/// Скорость падения.
		/// </summary>
		public float FallSpeed {
			get;
			set;
		}

		/// <summary>
		/// Высота прыжка.
		/// </summary>
		public int JumpHeight {
			get;
			set;
		}

		/// <summary>
		/// Конструктор.
		/// </summary>
		public PlatformerStateModel () {
			JumpSpeed = -200.0f;
			FallSpeed = 500.0f;
			JumpHeight = 100;
			MovingSpeed = 500.0f;
			MovingSpeedInJump = 100.0f;
		}

		/// <summary>
		/// Ограничения.
		/// </summary>
		public PlatformerLimitModel Limits {
			get {
				return m_Limits;
			}
			set {
				m_Limits = value;
			}
		}

		/// <summary>
		/// Контролер управления движением объекта.
		/// </summary>
		public MovingControllerModel Controller {
			get {
				return m_Controller;
			}
			set {
				m_Controller = value;
			}
		}

		/// <summary>
		/// Признак того что стоит на земле.
		/// </summary>
		public bool IsStayGround {
			get {
				return m_StateType == PlatformerStateType.Stand;
			}
			set {
				m_StateType = PlatformerStateType.Stand;
			}
		}

		/// <summary>
		/// Признак того активны ли передвижения по горизонтали.
		/// </summary>
		public bool IsHorizontalController {
			get {
				return Controller.IsLeft || Controller.IsRight;
			}
		}

	}

}
