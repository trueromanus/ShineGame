using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.State;

namespace GameLevel.Implementations {
	
	/// <summary>
	/// Игровое событие.
	/// </summary>
	public class GameEvent : IEvent {
		public string Handler {
			get;
			set;
		}

		public string Name {
			get;
			set;
		}

		public string Action {
			get;
			set;
		}
	}

}
