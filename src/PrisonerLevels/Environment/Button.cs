using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic;
using AbstractGameLogic.Attributes;
using AbstractGameLogic.Factories;
using AbstractGameLogic.State;

namespace PrisonerLevelBehaviours.Environment {

	/// <summary>
	/// Кнопка имеющая два состояния вкл/выкл.
	/// </summary>
	[GameEvent ( Name = Button.CheckedEventName , Description = "Событие возбуждаемое при включении переключателя." )]
	[GameEvent ( Name = Button.UnCheckedEventName , Description = "Событие возбуждаемое при выключении переключателя." )]
	[GameAction ( Name = Button.ChangeModeActionName , Description = "Сменить состояния." )]
	[GameAction ( Name = Button.BlockedActionName , Description = "Блокировать кнопку." )]
	[GameAction ( Name = Button.UnBlockedActionName , Description = "Разблокировать кнопку." )]
	[GameState ( Name = Button.ModeStateName , Description = "Начальное состояние кнопки (True/False)." )]
	[GameState ( Name = Button.BlockedStateName , Description = "Начальное состояние блокировки (True/False)." )]
	[ObjectBindBehaviour ( Name = Button.NameBehaviour , Description = "Кнопка имеющая два состояния (вкл/выкл) и возможность блокировки." )]
	public class Button : ObjectBehaviour {

		public const string NameBehaviour = "Button";

		public const string CheckedEventName = "checked";

		public const string UnCheckedEventName = "unchecked";

		public const string ChangeModeActionName = "changemode";

		public const string BlockedActionName = "blocked";

		public const string UnBlockedActionName = "unblocked";

		public const string ModeStateName = "Mode";

		public const string BlockedStateName = "Blocked";

		private bool m_IsChecked;

		private bool m_IsBlocked;

		/// <summary>
		/// Признак того активирована ли кнопка.
		/// </summary>
		public bool IsChecked {
			get {
				return m_IsChecked;
			}
			set {
				m_IsChecked = value;
			}
		}

		/// <summary>
		/// Признак того блокирована ли кнопка.
		/// </summary>
		public bool IsBlocked {
			get {
				return m_IsBlocked;
			}
			set {
				m_IsBlocked = value;
			}
		}

		/// <summary>
		/// Инициализация поведения.
		/// </summary>
		/// <param name="factorys">Хост фабрик.</param>
		public override void InitializeVisualObject () {
			m_IsChecked = VisualObject.States.Any ( a => a.Name == Button.ModeStateName && a.Value.ToString () == "True" );
			m_IsBlocked = VisualObject.States.Any ( a => a.Name == Button.BlockedStateName && a.Value.ToString () == "True" );
		}

		/// <summary>
		/// Обработка событий на которые подписан объект.
		/// </summary>
		/// <param name="event">Возбужденное событие.</param>
		public override void EventHandler ( IEvent @event ) {
			if ( m_IsBlocked ) {
				m_IsBlocked = @event.Action == Button.UnBlockedActionName ? false : true;
				if ( m_IsBlocked ) return;
			}

			if ( @event.Action == Button.ChangeModeActionName ) {
				m_IsChecked = !m_IsChecked;
				ThrowedEvent = m_IsChecked ? Button.CheckedEventName : Button.UnCheckedEventName;
				return;
			}
			if ( @event.Action == Button.BlockedActionName ) m_IsBlocked = true;
		}

	}
}
