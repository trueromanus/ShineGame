using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.ObjectBehavior;
using AbstractGameLogic.State;

namespace ShineGame {

	/// <summary>
	/// Коллекция событий.
	/// </summary>
	public class ShineEventCollection : IEventCollection {

		private List<IEvent> m_Events = new List<IEvent> ();

		/// <summary>
		/// Добавить событие.
		/// </summary>
		/// <param name="event"></param>
		public void Add ( IEvent @event ) {
			m_Events.Add ( @event );
		}

		/// <summary>
		/// Удалить событие.
		/// </summary>
		/// <param name="event"></param>
		public void Remove ( IEvent @event ) {
			m_Events.Remove ( @event );
		}

		/// <summary>
		/// Коллекция событий.
		/// </summary>
		public IEnumerable<IEvent> Events {
			get {
				return m_Events;
			}
		}
	}

}
