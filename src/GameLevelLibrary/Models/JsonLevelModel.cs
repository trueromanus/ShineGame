using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLevelLibrary.Models {
	
	/// <summary>
	/// Модель уровня для JSON представления.
	/// </summary>
	public class JsonLevelModel {

		/// <summary>
		/// Высота.
		/// </summary>
		public int Height {
			get;
			set;
		}

		/// <summary>
		/// Ширина.
		/// </summary>
		public int Width {
			get;
			set;
		}

		/// <summary>
		/// Ширина тайла.
		/// </summary>
		public int TileWidth {
			get;
			set;
		}

		/// <summary>
		/// Высота тайла.
		/// </summary>
		public int TileHeight {
			get;
			set;
		}

		/// <summary>
		/// Версия карты.
		/// </summary>
		public long Version {
			get;
			set;
		}

		/// <summary>
		/// Ориентация.
		/// </summary>
		public string Orientation {
			get;
			set;
		}

		/// <summary>
		/// Свойства карты.
		/// </summary>
		public IDictionary<string,string> Properties {
			get;
			set;
		}

		/// <summary>
		/// Информация об тайлах.
		/// </summary>
		public IEnumerable<TileSet> TileSets {
			get;
			set;
		}

		/// <summary>
		/// Слои.
		/// </summary>
		public IEnumerable<Layer> Layers {
			get;
			set;
		}

	}

}
