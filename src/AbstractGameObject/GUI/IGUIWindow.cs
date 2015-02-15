using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.GUI {

	/// <summary>
	/// Представление контейнерного окна.
	/// </summary>
	public interface IGUIWindow : IGUIElement {

		/// <summary>
		/// Текст заголовка.
		/// </summary>
		string CaptionText {
			get;
			set;
		}

		/// <summary>
		/// Элементы окна.
		/// </summary>
		IEnumerable<IGUIElement> Elements {
			get;
		}

		/// <summary>
		/// Добавить элемент на окно.
		/// </summary>
		/// <param name="element">Элемент для добавления.</param>
		void AddElement ( IGUIElement element );

		/// <summary>
		/// Добавить элемент в уже существующий элемент окна.
		/// </summary>
		/// <param name="container">Элемент который выступит в роли контейнера.</param>
		/// <param name="innerElement">Вложенный элемент.</param>
		void AddElementToElement ( IGUIElement container , IGUIElement innerElement );

		/// <summary>
		/// Удалить элемент с окна.
		/// </summary>
		/// <param name="element">Элемент для удаления.</param>
		void RemoveElement ( IGUIElement element );

		/// <summary>
		/// Поставить фокус на указанный элемент.
		/// </summary>
		/// <param name="element">Элемент для фокусировки.</param>
		void Focus ( IGUIElement element );

	}

}
