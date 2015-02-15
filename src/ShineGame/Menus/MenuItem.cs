using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.GameMenu;

namespace ShineGame.Menus {

	/// <summary>
	/// Пункт меню.
	/// </summary>
	internal sealed class MenuItem : IMenuItem {

		private List<IMenuItem> m_SubItems = new List<IMenuItem> ();

		private IMenuItem m_Parent = null;

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="parent">Родительский пункт меню.</param>
		public MenuItem ( IMenuItem parent ) {
			m_Parent = parent;
		}

		/// <summary>
		/// Конструктор.
		/// </summary>
		public MenuItem () {
			m_Parent = null;
		}

		/// <summary>
		/// Имя пункта меню.
		/// </summary>
		public string Name {
			get;
			set;
		}

		/// <summary>
		/// Текст меню.
		/// </summary>
		public string Text {
			get;
			set;
		}

		/// <summary>
		/// Фоновое изображение.
		/// </summary>
		public string BackgroundImage {
			get;
			set;
		}

		/// <summary>
		/// Тип рисования фона.
		/// </summary>
		public BackgroundImageMode BackgroundMode {
			get;
			set;
		}

		/// <summary>
		/// Подпункты меню.
		/// </summary>
		public IEnumerable<IMenuItem> SubItems {
			get {
				return m_SubItems;
			}
		}

		/// <summary>
		/// Пункт верхнего уровня.
		/// </summary>
		public IMenuItem ParentItem {
			get {
				throw new NotImplementedException ();
			}
		}

		/// <summary>
		/// Добавить подпункт.
		/// </summary>
		public IMenuItem AddSubItem () {
			var item = new MenuItem ( this );
			m_SubItems.Add ( item );
			return item;
		}

		/// <summary>
		/// Удалить подпункт.
		/// </summary>
		/// <param name="item">Подпункт который необходимо удалить.</param>
		public void RemoveSubItem ( IMenuItem item ) {
			m_SubItems.Remove ( item );
		}
	}

}
