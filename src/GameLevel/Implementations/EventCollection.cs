using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using AbstractGameLogic.ObjectBehavior;
using AbstractGameLogic.State;

namespace GameLevel.Implementations {

	[DataContract]
	public class EventCollection : IEventCollection {

		[DataMember]
		public List<IEvent> m_Events = new List<IEvent> ();

		public void Add ( IEvent @event ) {
			m_Events.Add ( @event );
		}

		public void Remove ( IEvent @event ) {
			m_Events.Remove ( @event );
		}

		public IEnumerable<IEvent> Events {
			get {
				return m_Events;
			}
		}
	}
}
