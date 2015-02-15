using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using AbstractGameLogic;
using AbstractGameLogic.Factories;
using AbstractGameLogic.ObjectVisual;
using GameLevel;
using GameLevel.Implementations;
using GameLevelLibrary.Implementations;

namespace GameLevelLibrary {

	/// <summary>
	/// Класс для предоставления доступа к
	/// данным игрового уровня.
	/// </summary>
	public static class GameLevelResource {

		/// <summary>
		/// Загрузить уровень из файла.
		/// </summary>
		/// <param name="fileName">Имя файла.</param>
		public static IGameLevelData LoadFromFile ( string fileName ) {
			//TODO:определять по расширению и вызывать соответствующий ридер.
			var reader = new TiledJsonLevelDataReader ();
			var model = reader.ReadModelFromFile ( fileName );

			var stream = new MemoryStream ();
			var serializer = new DataContractSerializer ( typeof ( GameLevelData ) );
			serializer.WriteObject ( stream , reader.ReadDataFromModel ( model ) );
			stream.Position = 0;
			byte[] buffer = new byte[stream.Length];
			stream.Read ( buffer , 0 , buffer.Length );
			var str = Encoding.UTF8.GetString ( buffer );

			return reader.ReadDataFromModel ( model );
		}

	}
}
