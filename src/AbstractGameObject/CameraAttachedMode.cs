using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic {
	
	/// <summary>
	////Режим привязки камеры.
	/// </summary>
	public enum CameraAttachedMode {
		
		/// <summary>
		/// Центрировать относительно объекта.
		/// </summary>
		Center,

		/// <summary>
		/// Статическая позиция относительно объекта.
		/// </summary>
		Static,

		/// <summary>
		/// Выровнять по левым верхним координатам объекта.
		/// </summary>
		LeftTop,

		/// <summary>
		/// Выровнять по правым верхним координатам объекта.
		/// </summary>
		RightTop ,

		/// <summary>
		/// Выровнять по левым нижним координатам объекта.
		/// </summary>
		LeftBottom ,

		/// <summary>
		/// Выровнять по правым нижним координатам объекта.
		/// </summary>
		RightBottom

	}

}
