using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrisonerLevelBehaviours.Models {
	
	/// <summary>
	/// Направление края.
	/// </summary>
	public enum DirectEdge {

		/// <summary>
		/// Слева.
		/// </summary>
		Left = 1,

		/// <summary>
		/// Справа.
		/// </summary>
		Right = 2,

		/// <summary>
		/// Сверху.
		/// </summary>
		Top = 3,

		/// <summary>
		/// Снизу.
		/// </summary>
		Bottom = 4
	}
}
