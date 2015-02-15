using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace ShineGame.GUI {
	
	/// <summary>
	/// Ресурсы шкуры.
	/// </summary>
	internal class SkinResources {

		/// <summary>
		/// Общий для контента фон.
		/// </summary>
		public SpriteFont CommonFont {
			get;
			set;
		}

		/// <summary>
		/// Текстура для курсора мыши.
		/// </summary>
		public Texture2D MouseCursorTexture {
			get;
			set;
		}

		/// <summary>
		/// Текстура для контейнера вроде окон, кнопок и групп.
		/// </summary>
		public Texture2D ContainerTexture {
			get;
			set;
		}

	}

}
