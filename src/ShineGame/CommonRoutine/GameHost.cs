using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShineGame.Game;

namespace ShineGame.CommonRoutine {
	
	/// <summary>
	/// Хост игры.
	/// </summary>
	public static class GameHost {

		/// <summary>
		/// Текущий объект игры.
		/// </summary>
		public static MainGame Game {
			get;
			set;
		}

	}

}
