using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic {
	
	/// <summary>
	/// Представления цвета.
	/// </summary>
	public interface IColor {

		/// <summary>
		/// Красный канал.
		/// </summary>
		int RChannel {
			get;
			set;
		}

		/// <summary>
		/// Зеленый канал.
		/// </summary>
		int GChannel {
			get;
			set;
		}

		/// <summary>
		/// Голубой канал.
		/// </summary>
		int BChannel {
			get;
			set;
		}

		/// <summary>
		/// Альфа канал.
		/// </summary>
		int AChannel {
			get;
			set;
		}

	}

}
