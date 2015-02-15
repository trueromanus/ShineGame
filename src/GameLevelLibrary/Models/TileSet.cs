using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLevelLibrary.Models {

	/// <summary>
	/// Данные о тайле.
	/// </summary>
	public class TileSet {

		private long m_Lastgid = -1;

		/// <summary>
		/// Начальная часть в глобальном списке.
		/// </summary>
		public long Firstgid {
			get;
			set;
		}

		/// <summary>
		/// Конечная часть в глобальном списке.
		/// </summary>
		public long Lastgid {
			get {
				if ( m_Lastgid == -1 ) {
					if ( ImageWidth == TileWidth && ImageHeight == TileHeight ) {
						m_Lastgid = Firstgid;
					}
					else {
						var columns = ImageWidth / TileWidth;
						var rows = ImageHeight / TileHeight;
						m_Lastgid = ( Firstgid + ( columns * rows ) ) - 1;
					}
				}
				return m_Lastgid;
			}
			set {
			}
		}

		/// <summary>
		/// Путь к картинке.
		/// </summary>
		public string Image {
			get;
			set;
		}

		/// <summary>
		/// Ширина изображения.
		/// </summary>
		public int ImageWidth {
			get;
			set;
		}

		/// <summary>
		/// Высота изображения.
		/// </summary>
		public int ImageHeight {
			get;
			set;
		}

		/// <summary>
		/// Отступ.
		/// </summary>
		public int Margin {
			get;
			set;
		}

		/// <summary>
		/// Имя тайла.
		/// </summary>
		public string Name {
			get;
			set;
		}

		/// <summary>
		/// Отступ между ячейками.
		/// </summary>
		public int Spacing {
			get;
			set;
		}

		/// <summary>
		/// Ширина тайла.
		/// </summary>
		public int TileHeight {
			get;
			set;
		}

		/// <summary>
		/// Высота тайла.
		/// </summary>
		public int TileWidth {
			get;
			set;
		}

		/// <summary>
		/// Свойства тайла.
		/// </summary>
		public IDictionary<string , string> Properties {
			get;
			set;
		}

	}
}
