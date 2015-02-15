using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLevelLibrary.Models {

	/// <summary>
	/// Слой карты.
	/// </summary>
	public class Layer {

		/// <summary>
		/// Данные.
		/// </summary>
		public IEnumerable<long> Data {
			get;
			set;
		}

		/// <summary>
		/// Объекты.
		/// </summary>
		public IEnumerable<LayerObject> Objects {
			get;
			set;
		}

		/// <summary>
		/// Ширина слоя.
		/// </summary>
		public int Width {
			get;
			set;
		}

		/// <summary>
		/// Длина слоя.
		/// </summary>
		public int Height {
			get;
			set;
		}

		/// <summary>
		/// Имя слоя.
		/// </summary>
		public string Name {
			get;
			set;
		}

		/// <summary>
		/// Прозрачность.
		/// </summary>
		public float Opacity {
			get;
			set;
		}

		/// <summary>
		/// Координата начала слоя по оси X.
		/// </summary>
		public int X {
			get;
			set;
		}

		/// <summary>
		/// Координата начала слоя по оси Y.
		/// </summary>
		public int Y {
			get;
			set;
		}

		/// <summary>
		/// Тип слоя.
		/// </summary>
		public string Type {
			get;
			set;
		}

		/// <summary>
		/// Признак показывается или слой или нет.
		/// </summary>
		public bool Visible {
			get;
			set;
		}

		/// <summary>
		/// Путь к изображению.
		/// </summary>
		public string Image {
			get;
			set;
		}

		/// <summary>
		/// Свойства слоя.
		/// </summary>
		public IDictionary<string , string> Properties {
			get;
			set;
		}

	}

}
