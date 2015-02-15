using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrisonerLevelBehaviours.Models {
	
	/// <summary>
	/// Тип состояния платформера.
	/// </summary>
	public enum PlatformerStateType {
		
		/// <summary>
		/// Стояние на земле.
		/// </summary>
		Stand = 0,

		/// <summary>
		/// Прыжок.
		/// </summary>
		Jumping = 1,

		/// <summary>
		/// Падение.
		/// </summary>
		Falling = 2

	}

}
