
namespace AbstractGameLogic.ObjectVisual {
	
	/// <summary>
	/// Прокручиваемый фон.
	/// </summary>
	public interface IParallaxBackground : IGameObjectVisual {

		/// <summary>
		/// Признакт того что фон прокручивается.
		/// </summary>		
		bool IsScrollable {
			get;
			set;
		}

		/// <summary>
		/// Направление прокрутки.
		/// </summary>
		ParallaxDirection Direction {
			get;
			set;
		}

		/// <summary>
		/// Скорость прокрутки.
		/// </summary>
		int Speed {
			get;
			set;
		}

		/// <summary>
		/// Текущая позиция прокрутки.
		/// </summary>
		int Position {
			get;
			set;
		}

		/// <summary>
		/// Имя изображения.
		/// </summary>
		string Image {
			get;
			set;
		}

	}
}
