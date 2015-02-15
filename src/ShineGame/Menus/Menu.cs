using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.GameMenu;

namespace ShineGame.Menus {

	/// <summary>
	/// Игровое меню.
	/// </summary>
	public class Menu : IMenu {

		private List<IMenuItem> m_MenuItems = new List<IMenuItem> ();

		private IMenuItem m_SelectedItem;

		private int m_SelectedItemLevel = 0;

		/// <summary>
		/// Пункты меню.
		/// </summary>
		public IEnumerable<IMenuItem> Items {
			get {
				return m_MenuItems;
			}
		}

		/// <summary>
		////Выбранный пункт.
		/// </summary>
		public IMenuItem SelectedItem {
			get {
				return m_SelectedItem;
			}
			set {
				m_SelectedItem = value;
			}
		}

		/// <summary>
		/// Уровень вложенности.
		/// </summary>
		public int SelectedItemLevel {
			get {
				return m_SelectedItemLevel;
			}
		}


		/// <summary>
		/// Путь к текущему выбранному пункту меню.
		/// </summary>
		public IEnumerable<IMenuItem> BreadCrumb {
			get {
				if ( m_SelectedItemLevel == 0 ) return null;
				var currentItem = m_SelectedItem.ParentItem;
				List<IMenuItem> result = new List<IMenuItem> ();
				while ( currentItem != null ) {
					result.Add ( currentItem );
					currentItem = currentItem.ParentItem;
				}
				return result;
			}
		}

		/// <summary>
		/// Добавить пункт меню.
		/// </summary>
		public IMenuItem AddItem () {
			var item = new MenuItem ();
			m_MenuItems.Add ( item );
			return item;
		}

		/// <summary>
		/// Удалить пункт меню.
		/// </summary>
		/// <param name="item">Удалить пункт меню.</param>
		public void RemoveItem ( IMenuItem item ) {
			if ( m_MenuItems.Contains ( item ) ) {
				m_MenuItems.Remove ( item );
			}
		}

		/// <summary>
		/// Вернуться на предыдущий уровень.
		/// </summary>
		/// <returns>Пункт меню являющийся базовым для подпунктов, или null в случае дохода до корневого элемента.</returns>
		public IMenuItem BackToPreviousLevel () {
			if ( m_SelectedItemLevel == 0 ) return null;

			if ( m_SelectedItem != null && m_SelectedItem.ParentItem != null ) {
				m_SelectedItem = m_SelectedItem.ParentItem;
				m_SelectedItemLevel -= 1;
				return m_SelectedItem.ParentItem;
			}

			return null;
		}

	}

}
