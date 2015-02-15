using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.State;

namespace ShineGame {
	
	/// <summary>
	/// Возбуждаемое событие.
	/// </summary>
	public class EventRaises : IEventRaises {
		
		/// <summary>
		/// Имя объекта возбудившего событие.
		/// </summary>
		public string ObjectName {
			get;
			set;
		}

		/// <summary>
		/// Последовательность возбужденных событий.
		/// </summary>
		public IEnumerable<string> Events {
			get;
			set;
		}

	}
}
