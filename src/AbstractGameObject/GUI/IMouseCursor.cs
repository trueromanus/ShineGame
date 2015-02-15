using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.GUI {

	/// <summary>
	/// Кусор мыши.
	/// </summary>
	public interface IMouseCursor : IGUIElement {

		/// <summary>
		/// Активен ли курсор.
		/// </summary>
		bool IsEnabled {
			get;
			set;
		}

		/// <summary>
		/// Получить элемент с котором пересекается курсор мыши.
		/// </summary>
		/// <returns>Окно и визуальный элемент с которым пересекся курсор мыши.</returns>
		Tuple<IGUIWindow , IGUIElement> GetHitCursor ();

	}

}
