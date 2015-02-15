using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic {

	/// <summary>
	/// Режим работы камеры.
	/// </summary>
	public enum CameraMode {
		
		/// <summary>
		/// Свободная камера.
		/// </summary>
		Free ,
		
		/// <summary>
		/// Привязанная к объекту.
		/// </summary>
		AttachedWithObject
	}
}
