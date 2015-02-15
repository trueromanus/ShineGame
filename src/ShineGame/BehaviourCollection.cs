using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.ObjectBehavior;

namespace ShineGame {
	
	/// <summary>
	/// Коллекция поведений.
	/// </summary>
	public class BehaviourCollection : IObjectBehaviors {

		private List<IObjectBehavior> m_Behaviours = new List<IObjectBehavior> ();

		/// <summary>
		/// Получить последовательность поведений.
		/// </summary>
		public IEnumerable<IObjectBehavior> Behaviors {
			get {
				return m_Behaviours;
			}
		}

		/// <summary>
		/// Добавить поведение.
		/// </summary>
		/// <param name="behavior">Поведение для добавления.</param>
		public void Add ( IObjectBehavior behavior ) {
			m_Behaviours.Add ( behavior );
		}

		/// <summary>
		/// Добавить последовательность поведений.
		/// </summary>
		/// <param name="behaviors">Последовательность поведений для добавления.</param>
		public void AddRange ( IEnumerable<IObjectBehavior> behaviors ) {
			m_Behaviours.AddRange ( behaviors );
		}

		/// <summary>
		/// Удалить поведение.
		/// </summary>
		/// <param name="behavior"></param>
		public void Remove ( IObjectBehavior behavior ) {
			try {
				m_Behaviours.Remove ( behavior );
			}
			catch ( Exception ) {
			}
		}
	}

}
