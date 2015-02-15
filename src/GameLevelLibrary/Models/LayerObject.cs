using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLevelLibrary.Models {

	/// <summary>
	/// Объект слоя.
	/// </summary>
	public class LayerObject {

		/// <summary>
		/// Ширина.
		/// </summary>
		public int Width {
			get;
			set;
		}

		/// <summary>
		/// Высота.
		/// </summary>
		public int Height {
			get;
			set;
		}

		/// <summary>
		/// Признак того что он отображается.
		/// </summary>
		public bool Visible {
			get;
			set;
		}

		/// <summary>
		/// Координата по оси X.
		/// </summary>
		public int X {
			get;
			set;
		}

		/// <summary>
		/// Координата по оси Y.
		/// </summary>
		public int Y {
			get;
			set;
		}

		/// <summary>
		/// Имя объекта.
		/// </summary>
		public string Name {
			get;
			set;
		}

		/// <summary>
		/// Тип объекта.
		/// </summary>
		public string Type {
			get;
			set;
		}

		/// <summary>
		/// Свойства объекта.
		/// </summary>
		public Dictionary<string , string> Properties {
			get;
			set;
		}

	}

}
