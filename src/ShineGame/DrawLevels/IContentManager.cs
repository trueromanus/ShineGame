using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using ProjectMercury;

namespace ShineGame.DrawLevels {

	/// <summary>
	/// Менеджер ресурсов.
	/// </summary>
	public interface IContentManager {

		/// <summary>
		/// Получить текстуру.
		/// </summary>
		/// <param name="name">Имя текстуры.</param>
		/// <returns>Текстура.</returns>
		Texture2D GetTexture ( string name );

		/// <summary>
		/// Получить шрифт.
		/// </summary>
		/// <param name="name">Имя шрифта.</param>
		/// <returns>Шрифт.</returns>
		SpriteFont GetFont ( string name );

		/// <summary>
		/// Получить эффект.
		/// </summary>
		/// <param name="name">Имя эффекта.</param>
		/// <returns>Эффект.</returns>
		ParticleEffect GetEffect ( string name );

	}

}
