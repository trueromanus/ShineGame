using System.Collections.Generic;

namespace AbstractGameLogic.ObjectVisual {

	/// <summary>
	/// Тайловая карта.
	/// </summary>
	public interface ITileMap : IGameObjectVisual {

		/// <summary>
		/// Количество столбцов.
		/// </summary>
		int ColumnCount {
			get;
			set;
		}

		/// <summary>
		/// Количество строк.
		/// </summary>
		int RowCount {
			get;
			set;
		}

		/// <summary>
		/// Ширина ячейки.
		/// </summary>
		int CellWidth {
			get;
			set;			
		}

		/// <summary>
		/// Высота ячейки.
		/// </summary>
		int CellHeight {
			get;
			set;
		}

		/// <summary>
		/// Изображение по умолчанию.
		/// </summary>
		string DefaultImage {
			get;
			set;
		}

		/// <summary>
		/// Последовательность тайлов.
		/// </summary>
		IEnumerable<string> Tiles {
			get;
		}

		/// <summary>
		/// Добавить тайл.
		/// </summary>
		/// <param name="column">Столбец.</param>
		/// <param name="row">Строка.</param>
		/// <param name="imageName">Имя изображения.</param>
		void AddTile ( string imageName , int column , int row );

		/// <summary>
		/// Получить тайл по координатам в матрице.
		/// </summary>
		/// <param name="column">Столбец.</param>
		/// <param name="row">Строка.</param>
		/// <returns>Имя тайла находящегося в указанных координатах.</returns>
		string GetTile ( int column , int row );

		/// <summary>
		/// Добавить картинку по все ячейки тайловой карты.
		/// </summary>
		/// <param name="imageName">Имя картинки.</param>
		void AddTileToAll ( string imageName );

	}
}
