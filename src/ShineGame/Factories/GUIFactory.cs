using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.Factories;
using AbstractGameLogic.GUI;

namespace ShineGame.Factories {

	/// <summary>
	/// Фабрика элементов GUI.
	/// </summary>
	public class GUIFactory : IGUIFactory {

		/// <summary>
		/// Создать менеджер GUI.
		/// </summary>
		public IGUIManager CreateManager () {
			throw new NotImplementedException ();
		}

		/// <summary>
		/// Создать окно.
		/// </summary>
		public IGUIWindow CreateWidow () {
			throw new NotImplementedException ();
		}

		/// <summary>
		/// Создать кнопку.
		/// </summary>
		/// <param name="parent">Контейнер.</param>
		public IGUIButton CreateButton ( IGUIElement parent ) {
			throw new NotImplementedException ();
		}

		public IGUITextBox CreateTextBox ( IGUIElement parent ) {
			throw new NotImplementedException ();
		}

		public IGUICheckBox CreateCheckBox ( IGUIElement parent ) {
			throw new NotImplementedException ();
		}
	}

}
