using System;
using System.Collections.Generic;
using System.Linq;
using AbstractGameLogic;
using Microsoft.Xna.Framework.Graphics;
using ShineGame.CommonRoutine;
using AbstractGameLogic.ObjectVisual;

namespace ShineGame.VisualObjects {

	/// <summary>
	/// Тайловая карта.
	/// </summary>	
	public class ShineTileMap : GameObjectVisualImplementation , ITileMap {

		protected List<Texture2D> m_Textures = new List<Texture2D> ();

		protected int m_ColumnCount = 1;

		protected int m_RowCount = 1;

		protected int m_CellWidth = 0;

		protected int m_CellHeight = 0;

		private Texture2D m_DefaultImage;

		/// <summary>
		/// Пересчитать координаты.
		/// </summary>
		/// <exception cref="InvalidOperationException"></exception>
		private void CalculateCoordinates () {
			if ( m_DefaultImage == null ) throw new InvalidOperationException ( "Необходимо сначала установить значение свойства DefaultImage." );

			Width = m_ColumnCount * m_CellWidth;
			Height = m_RowCount * m_CellHeight;

			m_Textures = Enumerable.Repeat ( m_DefaultImage , m_ColumnCount * m_RowCount ).ToList ();
		}

		/// <summary>
		/// Количество столбцов.
		/// </summary>		
		public int ColumnCount {
			get {
				return m_ColumnCount;
			}
			set {
				m_ColumnCount = value;
				CalculateCoordinates ();
			}
		}

		/// <summary>
		/// Количество строк.
		/// </summary>		
		public int RowCount {
			get {
				return m_RowCount;
			}
			set {
				m_RowCount = value;
				CalculateCoordinates ();
			}
		}

		/// <summary>
		/// Ширина ячейки.
		/// </summary>		
		public int CellWidth {
			get {
				return m_CellWidth;
			}
			set {
				m_CellWidth = value;
				CalculateCoordinates ();
			}
		}

		/// <summary>
		/// Высота ячейки.
		/// </summary>		
		public int CellHeight {
			get {
				return m_CellHeight;
			}
			set {
				m_CellHeight = value;
				CalculateCoordinates ();
			}
		}

		/// <summary>
		/// Изобаржение по умолчанию.
		/// </summary>		
		public string DefaultImage {
			get {
				return m_DefaultImage.Name;
			}
			set {
				m_DefaultImage = ContentManager.GetTexture ( value );
			}
		}

		/// <summary>
		/// Последовательность тайлов.
		/// </summary>		
		public IEnumerable<string> Tiles {
			get {
				foreach ( var texture in m_Textures ) {
					yield return texture.Name;
				}
			}
		}

		/// <summary>
		/// Добавить тайл.
		/// </summary>
		/// <param name="column">Столбец.</param>
		/// <param name="row">Строка.</param>
		/// <param name="imageName">Имя изображения.</param>
		/// <exception cref="System.ArgumentOutOfRangeException"></exception>
		/// <exception cref="System.ArgumentNullException"></exception>
		public void AddTile ( string imageName , int column , int row ) {
			if ( column > m_ColumnCount && column < 1 ) throw new ArgumentOutOfRangeException ( "column" );
			if ( row > m_RowCount && row < 1 ) throw new ArgumentOutOfRangeException ( "row" );
			if ( imageName == null ) throw new ArgumentNullException ( "fillImage" );

			m_Textures[( m_RowCount * row ) - column] = ContentManager.GetTexture ( imageName );
		}

		/// <summary>
		/// Получить тайл по координатам в матрице.
		/// </summary>
		/// <param name="column">Столбец.</param>
		/// <param name="row">Строка.</param>
		/// <returns>Имя тайла находящегося в указанных координатах.</returns>		
		public string GetTile ( int column , int row ) {
			if ( column > m_ColumnCount && column < 1 ) throw new ArgumentOutOfRangeException ( "column" );
			if ( row > m_RowCount && row < 1 ) throw new ArgumentOutOfRangeException ( "row" );

			return m_Textures[( m_RowCount * row ) - column].Name;
		}

		/// <summary>
		/// Добавить картинку по все ячейки тайловой карты.
		/// </summary>
		/// <param name="imageName">Имя картинки.</param>
		/// <exception cref="System.ArgumentNullException"></exception>
		/// <exception cref="System.NotSupportedException"></exception>
		public void AddTileToAll ( string imageName ) {
			if ( imageName == null ) throw new ArgumentNullException ( "fillImage" );

			var texture = ContentManager.GetTexture ( imageName );
			if ( texture.Width != Width || texture.Height != Height ) {
				throw new NotSupportedException ( string.Format ( "Тайловая карта поддерживает только размер {0}x{1}" , Width , Height ) );
			}
			m_Textures = Enumerable.Repeat ( texture , m_Textures.Count ).ToList ();
		}

		/// <summary>
		/// Нарисовать тайловую карту.
		/// </summary>
		public override sealed void Draw () {
			var localX = WorldX - DrawLevel.Viewport.X;
			var localY = WorldY - DrawLevel.Viewport.Y;
			var currentY = localY;
			for ( var row = 0 ; row < m_RowCount ; row++ ) {
				var texturesInRow = m_Textures.Skip ( row ).Take ( m_ColumnCount );
				var currentX = localX;
				foreach ( var texture in texturesInRow ) {
					GameSpriteBatch.DrawTexture ( currentX , currentY , texture );
					currentX += m_CellWidth;
				}
				currentY += m_CellHeight;
			}
		}

		public override void Update ( IGameState inputGamestate ) {
			//заглушка.
		}

		/// <summary>
		/// Прочесть данные из стороннего объекта и
		/// заполнить их внутри себя.
		/// </summary>
		/// <param name="gameObject">Игровой объект.</param>
		/// <exception cref="System.ArgumentOutOfRangeException"></exception>
		public override void CloneGameObjectData ( IGameObject gameObject ) {
			base.CloneGameObjectData ( gameObject );

			var tileMap = ( gameObject as ITileMap );
			if ( tileMap == null ) return;

			DefaultImage = tileMap.DefaultImage;
			ColumnCount = tileMap.ColumnCount;
			RowCount = tileMap.RowCount;
			CellHeight = tileMap.CellHeight;
			CellWidth = tileMap.CellWidth;

			if ( tileMap.Tiles.Count () != m_Textures.Count ) throw new ArgumentOutOfRangeException ( "gameObject.Tiles" );
			
			var iterator = 0;
			foreach ( var tileImageName in tileMap.Tiles ) {
				m_Textures[iterator] = string.IsNullOrEmpty ( tileImageName ) ? m_DefaultImage : ContentManager.GetTexture ( tileImageName );
			}
		}

	}

}
