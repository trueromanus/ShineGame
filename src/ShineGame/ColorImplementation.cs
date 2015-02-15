using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic;
using Microsoft.Xna.Framework;

namespace ShineGame {
	
	/// <summary>
	/// Реализация интерфейса для представления цвета <see cref="AbstractGameLogic.IColor"/>.
	/// </summary>
	public class ColorImplementation : IColor {

		/// <summary>
		/// Красный канал.
		/// </summary>
		public int RChannel {
			get;
			set;
		}

		/// <summary>
		/// Зеленый канал.
		/// </summary>
		public int GChannel {
			get;
			set;
		}

		/// <summary>
		/// Синий канал.
		/// </summary>		
		public int BChannel {
			get;
			set;
		}

		/// <summary>
		/// Альфа канал.
		/// </summary>
		public int AChannel {
			get;
			set;
		}

		/// <summary>
		/// Преобразовать в экземпляр класса <see cref="Color"/> с аналогичными данными.
		/// </summary>
		public Color GetXnaColor () {
			return new Color ( RChannel , GChannel , BChannel , AChannel );
		}

		/// <summary>
		/// Создать экземпляр класса <see cref="ColorImplementation"/> с данными из класса <see cref="Color"/>.
		/// </summary>
		/// <param name="color">Цвет каркаса Xna для преобразования.</param>
		public static ColorImplementation GetColor ( Color color ) {
			return new ColorImplementation{
				AChannel = color.A,
				RChannel = color.R,
				BChannel = color.B,
				GChannel = color.G
			};
		}

	}
}
