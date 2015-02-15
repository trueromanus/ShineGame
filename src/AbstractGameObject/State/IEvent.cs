using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.State {
	
	/// <summary>
	/// Событие.
	/// </summary>
	public interface IEvent {

		/// <summary>
		/// Имя объекта чье событие будет обработано.
		/// </summary>
		string Handler {
			get;
			set;
		}

		/// <summary>
		/// Имя события которое нужно обработать.
		/// </summary>
		string Name {
			get;
			set;
		}

		/// <summary>
		/// Имя действия которое необходимо выполнить.
		/// </summary>
		string Action {
			get;
			set;
		}

	}

}
