using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.GameMenu {

	/// <summary>
	/// Игровое меню.
	/// </summary>
	public interface IMenu {

		/// <summary>
		/// Пункты меню.
		/// </summary>
		IEnumerable<IMenuItem> Items {
			get;
		}

		/// <summary>
		/// Текущий выбранный пункт меню.
		/// </summary>
		IMenuItem SelectedItem {
			get;
			set;
		}

		/// <summary>
		/// Уровень вложенности выбранного элемента.
		/// </summary>
		int SelectedItemLevel {
			get;
		}

		/// <summary>
		/// Путь к текущему выбранному пункту меню.
		/// </summary>
		IEnumerable<IMenuItem> BreadCrumb {
			get;
		}

		/// <summary>
		/// Добавить пункт.
		/// </summary>
		IMenuItem AddItem ( );

		/// <summary>
		/// Удалить пункт.
		/// </summary>
		/// <param name="item">Подпункт меню.</param>
		void RemoveItem ( IMenuItem item );

		/// <summary>
		/// Вернуться на предыдущий уровень.
		/// </summary>
		/// <returns>Пункт меню являющийся базовым для подпунктов, или null в случае дохода до корневого элемента.</returns>
		IMenuItem BackToPreviousLevel ();

	}
}
