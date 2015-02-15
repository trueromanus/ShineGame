using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.Physics {
	
	/// <summary>
	/// Физический объект линии.
	/// </summary>
	public interface IPhysicsLine : IPhysicsObject {

		/// <summary>
		/// Ширина линии.
		/// </summary>
		int Width {
			get;
			set;
		}

	}

}
