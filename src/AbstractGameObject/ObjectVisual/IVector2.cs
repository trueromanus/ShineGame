using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.ObjectVisual {
	
	/// <summary>
	/// Двухкомпонентный вектор.
	/// </summary>
	public interface IVector2 {

		/// <summary>
		/// Значение X.
		/// </summary>
		float X {
			get;
			set;
		}

		/// <summary>
		/// Значение Y.
		/// </summary>
		float Y {
			get;
			set;
		}

	}

}
