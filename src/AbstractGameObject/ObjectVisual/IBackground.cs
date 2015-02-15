using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.ObjectVisual {

	/// <summary>
	/// Фоновый объект.
	/// </summary>
	public interface IBackground : IGameObjectVisual {

		/// <summary>
		/// Имя изображения.
		/// </summary>
		string Image {
			get;
			set;
		}

	}
}
