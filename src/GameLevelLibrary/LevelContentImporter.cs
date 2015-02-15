using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLevelLibrary.Implementations;
using GameLevelLibrary.Models;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace GameLevelLibrary {

	/// <summary>
	/// Импортер данных уровня.
	/// </summary>
	[ContentImporter ( ".json" , DefaultProcessor = "LevelImporter" , DisplayName = "Level Content Importer" )]
	public class LevelContentImporter : ContentImporter<JsonLevelModel> {

		/// <summary>
		/// Импорт данных из файла уровня.
		/// </summary>
		/// <param name="filename">Имя файла уровня.</param>
		/// <param name="context">Контекст импортера.</param>
		/// <returns>Модель данных.</returns>
		public override JsonLevelModel Import ( string filename , ContentImporterContext context ) {
			return new TiledJsonLevelDataReader ().ReadModelFromFile ( filename );
		}

	}
}
