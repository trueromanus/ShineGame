using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.ObjectVisual {
	
	/// <summary>
	/// Объекта представляющий координаты квадратной или прямоуглольной области.
	/// </summary>
	public interface IRectangle {

		int X {
			get;
			set;
		}

		int Y {
			get;
			set;
		}

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
