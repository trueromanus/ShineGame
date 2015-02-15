using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelPropertyEditor.Models {
	
	/// <summary>
	/// Модель поведения.
	/// </summary>
	public class BehaviourModel {

		/// <summary>
		/// События.
		/// </summary>
		public IEnumerable<EventModel> Events {
			get;
			set;
		}

		/// <summary>
		/// Состояния.
		/// </summary>
		public IEnumerable<StateModel> States {
			get;
			set;
		}

		/// <summary>
		/// Действия.
		/// </summary>
		public IEnumerable<ActionModel> Actions {
			get;
			set;
		}

	}

}
