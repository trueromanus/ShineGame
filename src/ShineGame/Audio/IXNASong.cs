using System;
using Microsoft.Xna.Framework.Media;

namespace ShineGame.Audio {

	/// <summary>
	/// Интерфейс для получения класс <see cref="Song"/>.
	/// </summary>
	internal interface IXNASong {

		/// <summary>
		/// Получить песню.
		/// </summary>
		Song Song {
			get;
			set;
		}

	}
}
