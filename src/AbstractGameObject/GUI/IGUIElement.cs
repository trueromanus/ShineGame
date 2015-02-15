using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.ObjectVisual;

namespace AbstractGameLogic.GUI {

	/// <summary>
	/// Элемент графического интерфейса.
	/// </summary>
	public interface IGUIElement : IGameObjectVisual {

		/// <summary>
		/// Признак того активны ли процессы работы с элементом.
		/// </summary>
		bool IsVisible {
			get;
			set;
		}

		/// <summary>
		/// Родительский элемент управления.
		/// </summary>
		IGUIElement Parent {
			get;
			set;
		}

		/// <summary>
		/// Признак того находиться ли фокус на элементе.
		/// </summary>
		bool IsFocused {
			get;
			set;
		}

		/// <summary>
		/// Менеджер графического интрефейса.
		/// </summary>
		IGUIManager Manager {
			get;
			set;
		}

		/// <summary>
		/// Инициализация элемента.
		/// </summary>
		void Initialize ();

	}

}
