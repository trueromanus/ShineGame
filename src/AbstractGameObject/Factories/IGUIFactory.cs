using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.GUI;

namespace AbstractGameLogic.Factories {

	/// <summary>
	/// Представление фабрики GUI объектов.
	/// </summary>
	public interface IGUIFactory {

		/// <summary>
		/// Создать менеджер графического интерфейса.
		/// </summary>
		/// <returns>Менеджер графического интерфейса.</returns>
		IGUIManager CreateManager ();

		/// <summary>
		/// Создать окно.
		/// </summary>
		/// <returns>Окно.</returns>
		IGUIWindow CreateWidow ();

		/// <summary>
		/// Создать кнопку.
		/// </summary>
		/// <returns>Кнопка.</returns>
		IGUIButton CreateButton ( IGUIElement parent );

		/// <summary>
		/// Создать текстовое поле.
		/// </summary>
		/// <returns>Текстовое поле.</returns>
		IGUITextBox CreateTextBox ( IGUIElement parent );

		/// <summary>
		/// Создать переключатель.
		/// </summary>
		/// <returns>Переключатель.</returns>
		IGUICheckBox CreateCheckBox ( IGUIElement parent );

	}

}
