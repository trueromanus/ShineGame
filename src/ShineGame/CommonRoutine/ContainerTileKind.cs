using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShineGame.CommonRoutine {
	
	/// <summary>
	/// Тип тайла контейнера.
	/// </summary>
	public enum ContainerTileKind {
		
		/// <summary>
		/// Левый верхний.
		/// </summary>
		LeftTop = 1,
		
		/// <summary>
		/// Правый верхний.
		/// </summary>
		RightTop = 2,
		
		/// <summary>
		/// Левый нижний.
		/// </summary>
		LeftBottom = 3,
		
		/// <summary>
		/// Правый нижний.
		/// </summary>
		RightBottom = 4,

		/// <summary>
		/// Горизонтальная линия.
		/// </summary>
		Horizontal = 5,

		/// <summary>
		/// Вертикальная линия.
		/// </summary>
		Vertical = 6,

		/// <summary>
		/// Фон.
		/// </summary>
		Background = 7

	}

}
