using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.GameMenu {

	/// <summary>
	/// Пункт меню.
	/// </summary>
	public interface IMenuItem {

		/// <summary>
		/// Имя пункта.
		/// </summary>
		string Name {
			get;
			set;
		}

		/// <summary>
		/// Текст для вывода.
		/// </summary>
		string Text {
			get;
			set;
		}

		/// <summary>
		/// Имя изображения.
		/// </summary>
		string BackgroundImage {
			get;
			set;
		}

		/// <summary>
		/// Режим фонового изображения.
		/// </summary>
		BackgroundImageMode BackgroundMode {
			get;
			set;
		}

		/// <summary>
		/// Под пункты меню.
		/// </summary>
		IEnumerable<IMenuItem> SubItems {
			get;
		}

		/// <summary>
		/// Родительский пункт меню если таковой есть.
		/// </summary>
		IMenuItem ParentItem {
			get;
		}

		/// <summary>
		/// Добавить подпункт.
		/// </summary>
		/// <param name="item">Подпункт.</param>
		IMenuItem AddSubItem ();

		/// <summary>
		/// Удалить подпункт.
		/// </summary>
		/// <param name="item">Подпункт.</param>
		void RemoveSubItem ( IMenuItem item );

	}

}
