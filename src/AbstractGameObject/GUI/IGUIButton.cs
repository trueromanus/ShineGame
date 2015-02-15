using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.GUI {
	
	/// <summary>
	/// Представление кнопки графического интерфейса.
	/// </summary>
	public interface IGUIButton : IGUIElement {

		/// <summary>
		/// Нажата ли кнопка.
		/// </summary>
		bool IsPressed {
			get;
			set;
		}

		/// <summary>
		/// Название кнопки.
		/// </summary>
		string Text {
			get;
			set;
		}

	}

}
