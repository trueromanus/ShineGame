using AbstractGameLogic;
using Microsoft.Xna.Framework.Graphics;
using ShineGame.CommonRoutine;
using System;
using Microsoft.Xna.Framework;
using AbstractGameLogic.ObjectVisual;
using ShineGame.DrawLevels;
using GameMathHelpers;

namespace ShineGame.VisualObjects {

	/// <summary>
	/// Статический объект игрового пространства 
	/// </summary>
	public class ShineStaticObject : GameObjectVisualImplementation , IStaticObject {

		private string m_ImageName;

		private IRectangle m_TileRectangle;

		private Texture2D m_Texture;

		private TileManager m_TileManager = new TileManager ();

		private int? m_TilePosition;

		/// <summary>
		/// Название изображения.
		/// </summary>
		public string Image {
			get {
				return m_ImageName;
			}
			set {
				m_ImageName = value;
				m_Texture = ContentManager.GetTexture ( m_ImageName );
				if ( Width == 0 && Height == 0 ) {
					Width = m_Texture.Width;
					Height = m_Texture.Height;
					return;
				}
				else {
					m_TileManager.Width = m_Texture.Width;
					m_TileManager.Height = m_Texture.Height;
					m_TileManager.TileWidth = Width;
					m_TileManager.TileHeight = Height;
					m_TileManager.Calculate ();
				}
				if ( Width > m_Texture.Width || Height > m_Texture.Height ) throw new InvalidOperationException ( "Свойства Width и/или Height превышают размеры оригинального изображения." );
			}
		}

		/// <summary>
		/// Позиция тайла внутри изображения.
		/// </summary>
		public int? TilePosition {
			get {
				return m_TilePosition;
			}
			set {
				if ( value.HasValue ) m_TileRectangle = m_TileManager.GetTileCoodinates ( value.Value );
				m_TilePosition = value;
			}
		}

		/// <summary>
		/// Рисование объекта на экране.
		/// </summary>
		public override void Draw () {
			if ( Rotate > 0 || Rotate < 0 ) {
				var vector = GetVector ();
				float localX = vector.X - DrawLevel.Viewport.X;
				float localY = vector.Y - DrawLevel.Viewport.Y;
				var halfWidth = Width / 2;
				var halfHeight = Height / 2;
				GameSpriteBatch.DrawTexture ( localX + halfWidth , localY + halfHeight , halfWidth , halfHeight , m_Texture , Rotate , 1.0f , SpriteEffects.None );
			}
			else {
				if ( TilePosition.HasValue ) {
					GameSpriteBatch.DrawTexture ( WorldX - DrawLevel.Viewport.X , WorldY - DrawLevel.Viewport.Y , m_Texture , m_TileRectangle );
				}
				else {
					GameSpriteBatch.DrawTexture ( WorldX - DrawLevel.Viewport.X , WorldY - DrawLevel.Viewport.Y , m_Texture );
				}
			}
		}

		/// <summary>
		/// Данный метод может быть перекрыт в 
		/// </summary>
		/// <param name="inputGamestate"></param>
		public override void Update ( IGameState inputGamestate ) {
			RunVisualBehaviours ( inputGamestate );
		}

		/// <summary>
		/// Прочесть данные из стороннего объекта и
		/// заполнить их внутри себя.
		/// </summary>
		/// <param name="gameObject">Игровой объект.</param>		
		public override void CloneGameObjectData ( IGameObject gameObject ) {
			base.CloneGameObjectData ( gameObject );

			var staticObject = ( gameObject as IStaticObject );
			if ( staticObject == null ) return;

			if ( staticObject.TilePosition.HasValue ) {
				Width = staticObject.Width;
				Height = staticObject.Height;
			}
			Image = staticObject.Image;
			TilePosition = staticObject.TilePosition;
		}

	}
}
