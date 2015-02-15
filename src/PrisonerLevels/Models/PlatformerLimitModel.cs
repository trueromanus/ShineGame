using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrisonerLevelBehaviours.Models {
	
	/// <summary>
	/// Ограничения платформера.
	/// </summary>
	public class PlatformerLimitModel {
		
		/// <summary>
		/// Лимит слева.
		/// </summary>
		public bool Left {
			get;
			set;
		}

		/// <summary>
		/// Лимит справа.
		/// </summary>
		public bool Right {
			get;
			set;
		}

		/// <summary>
		/// Лимит сверху.
		/// </summary>
		public bool Top {
			get;
			set;
		}

		/// <summary>
		/// Лимит снизу.
		/// </summary>
		public bool Bottom {
			get;
			set;
		}

		/// <summary>
		/// Очистить состояние.
		/// </summary>
		public void Clear () {
			Left = false;
			Right = false;
			Top = false;
			Bottom = false;
		}

	}

}
