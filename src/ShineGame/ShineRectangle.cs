using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.ObjectVisual;

namespace ShineGame {
	
	/// <summary>
	/// Класс представляющий прямоугольную область.
	/// </summary>
	public class ShineRectangle : IRectangle {
		
		/// <summary>
		/// Координата по оси X.
		/// </summary>
		public int X {
			get;
			set;
		}

		/// <summary>
		/// Координата по оси Y.
		/// </summary>
		public int Y {
			get;
			set;
		}

		/// <summary>
		/// Ширина.
		/// </summary>
		public int Width {
			get;
			set;
		}

		/// <summary>
		/// Высота.
		/// </summary>
		public int Height {
			get;
			set;
		}

	}
}
