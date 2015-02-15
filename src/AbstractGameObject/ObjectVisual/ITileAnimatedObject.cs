using System;

namespace AbstractGameLogic.ObjectVisual {
	
	/// <summary>
	/// Анимированный объект с тайловым
	/// содержимым.
	/// </summary>
	public interface ITileAnimatedObject : IGameObjectVisual {

		/// <summary>
		/// Текущий фрейм.
		/// </summary>
		int CurrentFrame {
			get;
			set;
		}

		/// <summary>
		/// Проигрывать ли анимацию циклично.
		/// </summary>
		bool IsLoop {
			get;
			set;
		}

		/// <summary>
		/// Ширина тайла.
		/// </summary>
		int TileWidth {
			get;
			set;
		}

		/// <summary>
		/// Высота тайла.
		/// </summary>
		int TileHeight {
			get;
			set;
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
		/// Имя изображения.
		/// </summary>
		string ImageName {
			get;
			set;
		}

		/// <summary>
		/// Признак того что изображение будет
		/// отражено при рисовании.
		/// </summary>
		bool IsVerticalMirror {
			get;
			set;
		}

	}

}
