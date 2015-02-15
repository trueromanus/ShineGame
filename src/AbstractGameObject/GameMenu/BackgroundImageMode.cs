using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.GameMenu {
	
	/// <summary>
	/// Режим фонового изображения.
	/// </summary>
	public enum BackgroundImageMode {
		
		/// <summary>
		/// Оригинальный размер, выровнять по центру.
		/// </summary>
		OriginalCenter = 1,
		
		/// <summary>
		/// РАстянуть по размеру экрана.
		/// </summary>
		Stretch = 2 ,

		/// <summary>
		/// Замостить тайлами.
		/// </summary>
		Tiles = 3
	}

}
