using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.State {
	
	/// <summary>
	/// Возбужденное событие.
	/// </summary>
	public interface IEventRaises {

		/// <summary>
		/// Имя объекта.
		/// </summary>
		string ObjectName {
			get;
			set;
		}

		/// <summary>
		/// Последствие событий котрые были возбуждены.
		/// </summary>
		IEnumerable<string> Events {
			get;
			set;
		}

	}

}
