using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLevel.Implementations;
using GameLevelLibrary.Implementations;
using GameLevelLibrary.Models;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace GameLevelLibrary {

	/// <summary>
	/// Обработчик модель данных.
	/// </summary>
	[ContentProcessor ( DisplayName = "Level Processor" )]
	public class LevelContentProcessor : ContentProcessor<JsonLevelModel , GameLevelData> {

		/// <summary>
		/// Выполнить обработку модели.
		/// </summary>
		public override GameLevelData Process ( JsonLevelModel input , ContentProcessorContext context ) {
			return (GameLevelData) new TiledJsonLevelDataReader ().ReadDataFromModel ( input );
		}

	}
}
