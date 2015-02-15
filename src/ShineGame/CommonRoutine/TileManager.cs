using AbstractGameLogic.ObjectVisual;
using GameMathHelpers;

namespace ShineGame.CommonRoutine {

	/// <summary>
	/// Менеджер тайлов.
	/// </summary>
	public class TileManager {

		/// <summary>
		/// Количество столбцов.
		/// </summary>
		public int ColumnCount {
			get;
			private set;
		}

		/// <summary>
		/// Количество строк.
		/// </summary>
		public int RowCount {
			get;
			private set;
		}

		/// <summary>
		/// Ширина тайла.
		/// </summary>
		public int TileWidth {
			get;
			set;
		}

		/// <summary>
		/// Высота тайла.
		/// </summary>
		public int TileHeight {
			get;
			set;
		}

		/// <summary>
		/// Ширина.
		/// </summary>
		public int Width {
			get;
			set;
		}

		/// <summary>
		/// Высота.
		/// </summary>
		public int Height {
			get;
			set;
		}

		/// <summary>
		/// Вычислить коэффициенты.
		/// </summary>
		public void Calculate () {
			ColumnCount = Width / TileWidth;
			RowCount = Height / TileHeight;
		}

		/// <summary>
		/// Получить координаты тайла по номеру.
		/// </summary>
		/// <param name="tileNumber">Номер тайла.</param>
		/// <returns>Координаты тайла.</returns>
		public IRectangle GetTileCoodinates ( int tileNumber ) {
			var position = MatrixHelper.GetMatrixPosition ( ColumnCount , RowCount , tileNumber );
			var column = ( position.Item2 - 1 ) * TileHeight;
			var row = ( position.Item1 - 1 ) * TileWidth;
			return new ShineRectangle {
				Y = row ,
				X = column ,
				Width = TileWidth ,
				Height = TileHeight
			};
		}

	}

}
