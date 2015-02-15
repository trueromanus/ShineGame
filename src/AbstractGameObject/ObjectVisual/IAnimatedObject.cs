using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.ObjectVisual {

	/// <summary>
	/// Анимированный объект.
	/// </summary>
	public interface IAnimatedObject : IGameObjectVisual {

		/// <summary>
		/// Кадры анимации.
		/// </summary>
		IEnumerable<string> Frames {
			get;
		}

		/// <summary>
		/// Диапазон отображения анимаций.
		/// </summary>
		Tuple<int , int> AnimationRange {
			get;
			set;
		}

		/// <summary>
		/// Скорость анимации.
		/// </summary>
		int AnimateSpeed {
			get;
			set;
		}

		/// <summary>
		/// Добавить кадры.
		/// </summary>
		/// <param name="frames">Последовательность имен кадров.</param>
		void AddFrames ( IEnumerable<string> frames );

	}
}
