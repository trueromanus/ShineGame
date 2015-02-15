using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using AbstractGameLogic.ObjectBehavior;
using AbstractGameLogic.State;

namespace GameLevel.Implementations {
	
	/// <summary>
	/// Объект реализующий поведение.
	/// </summary>
	[DataContract]
	public class ObjectBehaviour : IObjectBehavior {

		[DataMember]
		public EventCollection m_EventCollection = new EventCollection ();

		[DataMember]
		public int Order {
			get;
			set;
		}

		[DataMember]
		public string Name {
			get;
			set;
		}

		public void EventHandler ( IEvent @event ) {
			throw new NotImplementedException ();
		}

		public IEventCollection EventCollection {
			get {
				return m_EventCollection;
			}
			set {
				
			}
		}

		public string ThrowedEvent {
			get;
			set;
		}
	}

}
