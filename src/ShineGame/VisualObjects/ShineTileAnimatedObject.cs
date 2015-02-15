using System;
using System.Collections.Generic;
using AbstractGameLogic;
using GameMathHelpers;
using Microsoft.Xna.Framework.Graphics;
using ShineGame.CommonRoutine;
using Microsoft.Xna.Framework;
using AbstractGameLogic.ObjectVisual;

namespace ShineGame.VisualObjects {

	/// <summary>
	/// Анимированный объект с тайловым
	/// содержимым.
	/// </summary>
	public class ShineTileAnimatedObject : GameObjectVisualImplementation , ITileAnimatedObject {

		private int m_TileWidth;

		private int m_TileHeight;

		private int m_TileColumnCount;

		private int m_TileRowCount;

		private int m_StartFrame;

		private int m_EndFrame;

		protected int m_CurrentFrame = 0;

		private Texture2D m_Texture;

		private List<Texture2D> m_TilesTexture = new List<Texture2D> ();

		private int m_AnimateSpeed;

		private TimeSpan m_PreviousTime;

		/// <summary>
		/// Ширина тайла.
		/// </summary>
		public int TileWidth {
			get {
				return m_TileWidth;
			}
			set {
				m_TileWidth = value.LimitToPositive ();
				Width = m_TileWidth;
			}
		}

		/// <summary>
		/// Высота тайла.
		/// </summary>
		public int TileHeight {
			get {
				return m_TileHeight;
			}
			set {
				m_TileHeight = value.LimitToPositive ();
				Height = m_TileHeight;
			}
		}

		/// <summary>
		/// Диапазон отображения анимаций.
		/// </summary>		
		public Tuple<int , int> AnimationRange {
			get {
				return new Tuple<int , int> ( m_StartFrame , m_EndFrame );
			}
			set {
				m_StartFrame = value.Item1;
				m_EndFrame = value.Item2;
				m_CurrentFrame = m_StartFrame;
			}
		}

		/// <summary>
		/// Скорость анимации.
		/// </summary>
		public int AnimateSpeed {
			get {
				return m_AnimateSpeed;
			}
			set {
				m_AnimateSpeed = value.LimitToRange ( 1 , 6000 );
			}
		}

		/// <summary>
		/// Вертикальное отражение изображения.
		/// </summary>
		public bool IsVerticalMirror {
			get;
			set;
		}

		/// <summary>
		/// Имя изображения.
		/// </summary>
		public string ImageName {
			get {
				return m_Texture.Name;
			}
			set {
				m_Texture = ContentManager.GetTexture ( value );
				m_TilesTexture.Clear ();

				m_TileColumnCount = m_Texture.Width / m_TileWidth;
				m_TileRowCount = m_Texture.Height / m_TileHeight;
				Width = m_TileWidth;
				Height = m_TileHeight;
				var rowPosition = 0;
				for ( var row = 0 ; row < m_TileRowCount ; row++ ) {
					var columPosition = 0;
					for ( var column = 0 ; column < m_TileColumnCount ; column++ ) {
						m_TilesTexture.Add (
							GameSpriteBatch.Crop ( m_Texture , new Rectangle ( columPosition , rowPosition , m_TileWidth , m_TileHeight ) )
						);
						columPosition += m_TileWidth;
					}
					rowPosition += m_TileHeight;
				}
			}
		}

		/// <summary>
		/// Нарисовать текущий кадр анимации.
		/// </summary>
		public override void Draw () {
			var localX = WorldX - DrawLevel.Viewport.X;
			var localY = WorldY - DrawLevel.Viewport.Y;
			if ( IsVerticalMirror ) {
				GameSpriteBatch.DrawTexture ( localX , localY , 0 , 0 , m_TilesTexture[m_CurrentFrame] , 0 , 1 , SpriteEffects.FlipHorizontally );
			}
			else {
				GameSpriteBatch.DrawTexture ( localX , localY , m_TilesTexture[m_CurrentFrame] );
			}
		}

		/// <summary>
		/// Обновить состояние объекта.
		/// </summary>
		/// <param name="gamestate">Текущее игровое состояние.</param>
		public override void Update ( IGameState gamestate ) {
			RunVisualBehaviours ( gamestate );

			if ( ( gamestate.TotalTime.TotalMilliseconds - m_PreviousTime.TotalMilliseconds ) >= m_AnimateSpeed ) {
				m_CurrentFrame = m_CurrentFrame == m_EndFrame ? ( IsLoop ? m_StartFrame : m_EndFrame ) : m_CurrentFrame + 1;
				m_PreviousTime = gamestate.TotalTime;
			}
		}

		/// <summary>
		/// Прочесть данные из стороннего объекта и
		/// заполнить их внутри себя.
		/// </summary>
		/// <param name="gameObject">Игровой объект.</param>
		public override void CloneGameObjectData ( IGameObject gameObject ) {
			base.CloneGameObjectData ( gameObject );

			var tileAnimatedObject = ( gameObject as ITileAnimatedObject );
			if ( tileAnimatedObject == null ) return;

			TileWidth = tileAnimatedObject.TileWidth;
			TileHeight = tileAnimatedObject.TileHeight;
			AnimateSpeed = tileAnimatedObject.AnimateSpeed;
			ImageName = tileAnimatedObject.ImageName;
			AnimationRange = tileAnimatedObject.AnimationRange;
			IsLoop = tileAnimatedObject.IsLoop;
		}

		/// <summary>
		/// Текущий фрейм анимации.
		/// </summary>
		public int CurrentFrame {
			get {
				return m_CurrentFrame;
			}
			set {
				m_CurrentFrame = value;
			}
		}

		/// <summary>
		/// Признак того должна ли анимация крутиться циклично.
		/// </summary>
		public bool IsLoop {
			get;
			set;
		}
	}
}
