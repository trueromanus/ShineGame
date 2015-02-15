using AbstractGameLogic;
using GameMathHelpers;
using ShineGame.CommonRoutine;
using Microsoft.Xna.Framework.Graphics;
using AbstractGameLogic.ObjectVisual;

namespace ShineGame.VisualObjects {

	/// <summary>
	/// Реализация интерфейса <see cref="IParallaxBackground"/> скролируемого фона.
	/// </summary>
	public class ShineParallaxBackground : GameObjectVisualImplementation , IParallaxBackground {

		private int m_Position;

		protected Texture2D m_BackgroundTexture;

		/// <summary>
		/// Признак активности скролирования фона.
		/// </summary>
		public bool IsScrollable {
			get;
			set;
		}

		/// <summary>
		/// Направление скролирования.
		/// </summary>
		public ParallaxDirection Direction {
			get;
			set;
		}

		/// <summary>
		/// Скорость прокрутки.
		/// </summary>
		public int Speed {
			get;
			set;
		}

		/// <summary>
		/// Текущая позиция прокрутки.
		/// </summary>
		public int Position {
			get {
				return m_Position;
			}
			set {
				m_Position = m_Position.LimitToRange ( 0 , Width );
			}
		}

		/// <summary>
		/// Нарисовать паралакс.
		/// </summary>
		/// <param name="localX">Локальные координаты по оси X.</param>
		/// <param name="localY">Локальные координаты по оси Y.</param>
		public override void Draw () {
			int offsetX = 0;
			int offsetY = 0;

			if ( Direction == ParallaxDirection.LeftToRight ) offsetX = m_Position;
			if ( Direction == ParallaxDirection.RightToLeft ) offsetX -= m_Position;
			if ( Direction == ParallaxDirection.UpToDown ) offsetY = m_Position;
			if ( Direction == ParallaxDirection.DownToUp ) offsetY -= m_Position;

			if ( offsetX == 0 && offsetY == 0 ) {
				GameSpriteBatch.DrawTexture ( 0 , 0 , m_BackgroundTexture );
			}
			else {
				GameSpriteBatch.DrawTexture ( 0 , 0 , m_BackgroundTexture , offsetX , offsetY );
			}
		}

		/// <summary>
		/// Обновить сосотояние скролируемого фона.
		/// </summary>
		/// <param name="inputGamestate">Игровое состояние.</param>
		public override void Update ( IGameState inputGamestate ) {
			RunVisualBehaviours ( inputGamestate );

			Width = inputGamestate.WorldXMax;
			Height = inputGamestate.WorldYMax;

			if ( !IsScrollable ) return;

			int maxLimit = 0;
			if ( Direction == ParallaxDirection.LeftToRight || Direction == ParallaxDirection.RightToLeft ) {
				maxLimit = Width;
			}
			else {
				maxLimit = Height;
			}

			m_Position = ( m_Position + Speed ).LimitToRange ( 0 , maxLimit );

			if ( m_Position == maxLimit ) m_Position = 0;
		}

		/// <summary>
		/// Имя изображения.
		/// </summary>
		public string Image {
			get {
				return m_BackgroundTexture.Name;
			}
			set {
				m_BackgroundTexture = ContentManager.GetTexture ( value );
			}
		}

		/// <summary>
		/// Прочесть данные из стороннего объекта и
		/// заполнить их внутри себя.
		/// </summary>
		/// <param name="gameObject">Игровой объект.</param>
		public override void CloneGameObjectData ( IGameObject gameObject ) {
			base.CloneGameObjectData ( gameObject );
			var parallaxBackground = ( gameObject as IParallaxBackground );
			if ( parallaxBackground == null ) return;

			IsScrollable = parallaxBackground.IsScrollable;
			Direction = parallaxBackground.Direction;
			Speed = parallaxBackground.Speed;
			Image = parallaxBackground.Image;
			Position = parallaxBackground.Position;
		}

	}
}
