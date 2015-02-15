using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using AbstractGameLogic.ObjectBehavior;

namespace GameLevel.Implementations {

	/// <summary>
	/// Коллекция поведений.
	/// </summary>
	[DataContract]
	public class ObjectBehaviours : IObjectBehaviors {

		[DataMember]
		private List<IObjectBehavior> m_Behaviours = new List<IObjectBehavior> ();

		public IEnumerable<IObjectBehavior> Behaviors {
			get {
				return m_Behaviours;
			}
		}

		public void Add ( IObjectBehavior behavior ) {
			m_Behaviours.Add ( behavior );
		}

		public void AddRange ( IEnumerable<IObjectBehavior> behaviors ) {
			m_Behaviours.AddRange ( behaviors );
		}

		public void Remove ( IObjectBehavior behavior ) {
			throw new NotImplementedException ();
		}
	}

}
