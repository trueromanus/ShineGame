using System.IO;
using System.Runtime.Serialization;
using System.Text;
using GameLevel.Implementations;
using Microsoft.Xna.Framework.Content;

namespace GameLevel {

	/// <summary>
	/// Читатель данных уровня.
	/// </summary>
	public class LevelContentReader : ContentTypeReader<GameLevelData> {

		/// <summary>
		/// Читаем данные из файла и сериализуем в данные игрового уровня.
		/// </summary>
		/// <param name="input">Бинарный поток.</param>
		/// <param name="existingInstance">Существующий инстанс.</param>
		/// <returns>Данные полученные из файла.</returns>
		protected override GameLevelData Read ( ContentReader input , GameLevelData existingInstance ) {
			var stream = new MemoryStream ();
			var buffer = Encoding.UTF8.GetBytes ( input.ReadString () );
			stream.Write ( buffer , 0 , buffer.Length );
			stream.Position = 0;
			var serializer = new DataContractSerializer ( typeof ( GameLevelData ) );
			return (GameLevelData) serializer.ReadObject ( stream );
		}

	}
}
