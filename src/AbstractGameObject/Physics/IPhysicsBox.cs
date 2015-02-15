using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.Physics {

	/// <summary>
	/// Физический объект представляющий объект прямоугольной формы.
	/// </summary>
	public interface IPhysicsBox : IPhysicsObject {

		/// <summary>
		/// Ширина.
		/// </summary>
		int Width {
			get;
			set;
		}

		/// <summary>
		/// Высота.
		/// </summary>
		int Height {
			get;
			set;
		}

	}

}
