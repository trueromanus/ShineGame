using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.State;

namespace ShineGame {
	
	/// <summary>
	/// Событие.
	/// </summary>
	public class ShineEvent : IEvent {

		/// <summary>
		/// Имя объекта чье событие будет обработано.
		/// </summary>
		public string Handler {
			get;
			set;
		}

		/// <summary>
		/// Имя события которое нужно обработать.
		/// </summary>
		public string Name {
			get;
			set;
		}

		/// <summary>
		/// Имя действия которое необходимо выполнить.
		/// </summary>
		public string Action {
			get;
			set;
		}
	}

}
