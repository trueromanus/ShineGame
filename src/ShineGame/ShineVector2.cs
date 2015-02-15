using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.ObjectVisual;

namespace ShineGame {
	
	/// <summary>
	/// Двухкомпонентный верктор.
	/// </summary>
	public class ShineVector2 : IVector2 {

		/// <summary>
		/// Координата по оси X.
		/// </summary>
		public float X {
			get;
			set;
		}

		/// <summary>
		/// Координата по оси Y.
		/// </summary>
		public float Y {
			get;
			set;
		}
	}

}
