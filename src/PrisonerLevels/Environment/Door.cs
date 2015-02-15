using System;
using System.Linq;
using AbstractGameLogic.Attributes;
using AbstractGameLogic.State;

namespace PrisonerLevelBehaviours.Environment {

	/// <summary>
	/// Дверь имеющая два состояния Открыто и закрыто.
	/// </summary>
	[GameEvent ( Name = Door.OpenedEventName , Description = "Событие возбуждаемое при открытии двери." )]
	[GameEvent ( Name = Door.ClosedEventName , Description = "Событие возбуждаемое при закрытии двери." )]
	[GameAction ( Name = Door.OpenActionName , Description = "Открыть дверь." )]
	[GameAction ( Name = Door.CloseActionName , Description = "Закрыть дверь." )]
	[GameState ( Name = Door.ModeStateName , Description = "Начальное состояние двери (True/False)." )]
	[ObjectBindBehaviour ( Name = Door.NameBehaviour , Description = "Дверь имеющая состояния открыто/закрыто." )]
	public class Door : ObjectBehaviour {

		public const string NameBehaviour = "Door";

		public const string OpenedEventName = "opened";

		public const string ClosedEventName = "closed";

		public const string OpenActionName = "open";

		public const string CloseActionName = "close";

		public const string ModeStateName = "Mode";

		private bool m_IsOpened;

		/// <summary>
		/// Признак того что дверь открыта.
		/// </summary>
		public bool IsOpened {
			get {
				return m_IsOpened;
			}
		}

		/// <summary>
		/// Инициализация поведения.
		/// </summary>
		/// <param name="factorys">Хост фабрик объектов.</param>
		public override void InitializeVisualObject () {
			m_IsOpened = VisualObject.States.Any ( a => a.Name == Door.ModeStateName && a.Value.ToString () == "True" );
		}

		/// <summary>
		/// Обработчик событий.
		/// </summary>
		/// <param name="event">Возбужденное событие.</param>
		public override void EventHandler ( IEvent @event ) {
			switch ( @event.Action ) {
				case Door.OpenActionName:
					if ( m_IsOpened ) return;
					m_IsOpened = true;
					ThrowedEvent = Door.OpenedEventName;
					break;
				case Door.CloseActionName:
					if ( !m_IsOpened ) return;
					m_IsOpened = false;
					ThrowedEvent = Door.ClosedEventName;
					break;
				default:
					throw new ArgumentException ( "Поведение двери не поддерживает такое действие." , "@event" );
			}
		}

	}

}
