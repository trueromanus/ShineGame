using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.GUI {
	
	/// <summary>
	/// Текстовое поле.
	/// </summary>
	public interface IGUITextBox : IGUIElement {

		/// <summary>
		/// Линии текста.
		/// </summary>
		IEnumerable<string> Lines {
			get;
		}

		/// <summary>
		/// Признак того только редактирование в поле или нет.
		/// </summary>
		bool IsReadOnly {
			get;
			set;
		}

		/// <summary>
		/// Добавить линию текста.
		/// </summary>
		/// <param name="line">Линия текста.</param>
		void AddLine ( string line );

		/// <summary>
		/// Очистить текстовое поле.
		/// </summary>
		void Clear ();

	}

}
