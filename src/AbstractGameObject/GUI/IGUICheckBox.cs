using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.GUI {
	
	/// <summary>
	/// Переключатель.
	/// </summary>
	public interface IGUICheckBox : IGUIElement {

		/// <summary>
		/// Текст для описания чекбокса.
		/// </summary>
		string Text {
			get;
			set;
		}

		/// <summary>
		/// Состояние переключателя.
		/// </summary>
		bool IsChecked {
			get;
			set;
		}

		/// <summary>
		/// Обработчик смены состояния.
		/// </summary>
		Action<IGUICheckBox> ChangeState {
			get;
			set;
		}

	}

}
