using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using GameMathHelpers;
using AbstractGameLogic.ObjectVisual;

namespace ShineGame.CommonRoutine {

	/// <summary>
	/// Графический слой игры.
	/// </summary>
	public static class GameSpriteBatch {

		private static SpriteBatch m_SpriteBatch;

		/// <summary>
		/// Графический слой игры.
		/// </summary>
		public static SpriteBatch SpriteBatch {
			get {
				return m_SpriteBatch;
			}
			set {
				m_SpriteBatch = value;
			}
		}

		/// <summary>
		/// Создать структуру <see cref="Microsoft.Xna.Framework.Rectangle"/> с координатами и шириной и высотой.
		/// </summary>
		/// <param name="x">Коорданата по оси X.</param>
		/// <param name="y">Коорданата по оси Y.</param>
		/// <param name="texture">Двумерная текстура.</param>
		/// <returns>Структура с необходимыми данными.</returns>
		public static Rectangle GetRectangleOnTextureSize ( int x , int y , Texture2D texture , int? width = null , int? height = null ) {
			return new Rectangle {
				X = x ,
				Y = y ,
				Width = width ?? texture.Width ,
				Height = height ?? texture.Height
			};
		}

		/// <summary>
		/// Обрезать текстуру по указанным координатам.
		/// </summary>
		/// <param name="image">Исходное изображение.</param>
		/// <param name="cropSize">Размер обрезки.</param>
		/// <returns>Обрезанная текстура.</returns>
		public static Texture2D Crop ( Texture2D image , Rectangle cropSize ) {
			var graphics = image.GraphicsDevice;
			var ret = new RenderTarget2D ( graphics , cropSize.Width , cropSize.Height );
			var sb = new SpriteBatch ( graphics );

			graphics.SetRenderTarget ( ret );
			graphics.Clear ( new Color ( 0 , 0 , 0 , 0 ) );

			sb.Begin ();
			sb.Draw ( image , Vector2.Zero , cropSize , Color.White );
			sb.End ();

			graphics.SetRenderTarget ( null );

			return (Texture2D) ret;
		}

		/// <summary>
		/// Получить два значения для смещения.
		/// </summary>
		/// <param name="originalValue">Оригинальное значение.</param>
		/// <param name="offset">Смещение.</param>
		/// <returns>Два значения для смещения и измененного значения.</returns>
		private static Tuple<int , int> GetOffsetValue ( int originalValue , int offset ) {
			if ( offset.IsPositive () ) return new Tuple<int , int> ( offset , originalValue - offset );
			if ( offset.IsNegative () ) return new Tuple<int , int> ( originalValue - -offset , -offset );

			throw new ArgumentException ( "Смещение не может быть равно нулю." , "offset" );
		}

		/// <summary>
		/// Нарисовать текстуру в определенных координатах.
		/// </summary>
		/// <param name="x">Коорданата по оси X.</param>
		/// <param name="y">Коорданата по оси Y.</param>
		/// <param name="texture">Двумерная текстура.</param>
		public static void DrawTexture ( int x , int y , Texture2D texture ) {
			m_SpriteBatch.Draw ( texture , GetRectangleOnTextureSize ( x , y , texture ) , Color.White );
		}

		/// <summary>
		/// Нарисовать часть текстуры в определенных координатах. 
		/// </summary>
		/// <param name="x">Координата по оси X.</param>
		/// <param name="y">Координата по оси Y.</param>
		/// <param name="texture">Текстура</param>
		/// <param name="rectangle">Область которую необходимо вырезать</param>
		public static void DrawTexture ( int x , int y , Texture2D texture , IRectangle rectangle ) {
			m_SpriteBatch.Draw (
				texture ,
				GetRectangleOnTextureSize ( x , y , texture , rectangle.Width , rectangle.Height ) ,
				GetRectangleOnTextureSize ( rectangle.X , rectangle.Y , texture , rectangle.Width , rectangle.Height ) ,
				Color.White
			);
		}

		/// <summary>
		/// Нарисовать текстуру в определенных координатах.
		/// </summary>
		/// <param name="x">Коорданата по оси X.</param>
		/// <param name="y">Коорданата по оси Y.</param>
		/// <param name="texture">Двумерная текстура.</param>
		/// <param name="offsetX">Смещение по оси X.</param>
		/// <param name="offsetX">Смещение по оси Y.</param>
		/// <exception cref="NotSupportedException"></exception>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public static void DrawTexture ( int x , int y , Texture2D texture , int offsetX = 0 , int offsetY = 0 ) {
			if ( offsetX > 0 && offsetY > 0 ) throw new NotSupportedException ( "В данной версии не поддерживаются смещение по двум осям сразу." );
			if ( offsetX == 0 && offsetY == 0 ) throw new NotSupportedException ( "Необходимо указать смещение по одной из осей." );

			if ( offsetX != 0 ) {
				var values = GetOffsetValue ( texture.Width , offsetX );

				var firstImage = Crop ( texture , GetRectangleOnTextureSize ( x , y , texture , width: values.Item1 ) );
				var lastImage = Crop ( texture , GetRectangleOnTextureSize ( x + values.Item1 , y , texture , width: values.Item2 ) );

				DrawTexture ( values.Item2 , y , firstImage , Color.White );
				DrawTexture ( x , y , lastImage , Color.White );
			}

			if ( offsetY != 0 ) {
				var values = GetOffsetValue ( texture.Height , offsetY );

				var firstImage = Crop ( texture , GetRectangleOnTextureSize ( x , y , texture , height: values.Item1 ) );
				var lastImage = Crop ( texture , GetRectangleOnTextureSize ( x , y + values.Item1 , texture , height: values.Item2 ) );

				DrawTexture ( x , values.Item2 , firstImage , Color.White );
				DrawTexture ( x , y , lastImage , Color.White );
			}
		}

		/// <summary>
		/// Нарисовать текстуру в определенных координатах.
		/// </summary>
		/// <param name="x">Коорданата по оси X.</param>
		/// <param name="y">Коорданата по оси Y.</param>
		/// <param name="texture">Двумерная текстура.</param>
		/// <param name="color">Цветовой фильтр.</param>
		public static void DrawTexture ( int x , int y , Texture2D texture , Color color ) {
			m_SpriteBatch.Draw ( texture , GetRectangleOnTextureSize ( x , y , texture ) , color );
		}

		/// <summary>
		/// Нарисовать текстуру в определенных координатах.
		/// </summary>
		/// <param name="x">Коорданата по оси X.</param>
		/// <param name="y">Коорданата по оси Y.</param>
		/// <param name="texture">Двумерная текстура.</param>
		/// <param name="color">Цветовой фильтр.</param>
		public static void DrawTexture ( int x , int y , int originx , int originy , Texture2D texture , float rotation , float scale , SpriteEffects spriteEffect ) {
			m_SpriteBatch.Draw (
				texture ,
				new Vector2 ( (float) x , (float) y ) ,
				null ,
				Color.White ,
				rotation ,
				new Vector2 ( (float) originx , (float) originy ) ,
				scale ,
				spriteEffect ,
				0
			);
		}

		/// <summary>
		/// Нарисовать текстуру в определенных координатах.
		/// </summary>
		/// <param name="x">Коорданата по оси X.</param>
		/// <param name="y">Коорданата по оси Y.</param>
		/// <param name="texture">Двумерная текстура.</param>
		/// <param name="color">Цветовой фильтр.</param>
		public static void DrawTexture ( float x , float y , float originx , float originy , Texture2D texture , float rotation , float scale , SpriteEffects spriteEffect ) {
			m_SpriteBatch.Draw (
				texture ,
				new Vector2 ( x , y ) ,
				null ,
				Color.White ,
				rotation ,
				new Vector2 ( originx , originy ) ,
				scale ,
				spriteEffect ,
				0
			);
		}

		/// <summary>
		/// Нарисовать текст.
		/// </summary>
		/// <param name="x">Координаты по оси X.</param>
		/// <param name="y">Координаты по оси Y.</param>
		/// <param name="message">Текст сообщения.</param>
		/// <param name="font">Шрифт.</param>
		public static void DrawText ( int x , int y , string message , SpriteFont font , Color color ) {
			m_SpriteBatch.DrawString (
				font ,
				message ,
				new Vector2 ( x , y ) ,
				color
			);
		}

	}

}
