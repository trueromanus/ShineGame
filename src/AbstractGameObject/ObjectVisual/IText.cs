
namespace AbstractGameLogic.ObjectVisual {
	
	/// <summary>
	/// Текстовой объект.
	/// </summary>
	public interface IText : IGameObjectVisual {

		/// <summary>
		/// Сообщение для вывода.
		/// </summary>
		string Message {
			get;
			set;
		}

		/// <summary>
		/// Имя шрифта.
		/// </summary>
		string Font {
			get;
			set;
		}

		/// <summary>
		/// Размер шрифта.
		/// </summary>
		int Size {
			get;
			set;			
		}

		/// <summary>
		/// Цвет шрифта.
		/// </summary>
		IColor Color {
			get;
			set;
		}

	}
}
