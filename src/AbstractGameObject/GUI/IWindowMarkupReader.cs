using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.GUI {

	/// <summary>
	/// Десериализатор разметки окон.
	/// </summary>
	public interface IWindowMarkupReader {

		/// <summary>
		/// Получить окно из ресурса с именем name.
		/// </summary>
		/// <param name="name">Имя ресурса.</param>
		/// <returns>Окно.</returns>
		IGUIWindow GetWindow ( string name );

	}

}
