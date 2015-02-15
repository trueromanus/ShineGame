using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameMathHelpers {
	
	/// <summary>
	/// Помошник для работы с матрицами.
	/// </summary>
	public static class MatrixHelper {

		/// <summary>
		/// Вычислить позицию в столбца и строки в матрице,
		/// зная только позицию элемента по порядку.
		/// </summary>
		/// <param name="countColumn">Количество столбцов.</param>
		/// <param name="countRow">Количество строк.</param>
		/// <param name="position">Позиция по порядку.</param>
		/// <returns>Позиция элемента в матрице.</returns>
		/// <remarks>
		/// </remarks>
		public static Tuple<int , int> GetMatrixPosition ( int countColumn , int countRow , int position ) {
			//если первая строка то ничего не вычисляем
			if ( position <= countColumn ) return new Tuple<int , int> ( 1 , position );

			//вычисляем столбец
			var column = position % countColumn;
			//вычисляем строку
			var row = ( position / countColumn );
			//если остаток больше одного, прибавляем единицу
			if ( column > 0 ) row++;
			//если столбец 0 то значит он последний
			if ( column == 0 ) column = countColumn;
			//формируем результат
			return new Tuple<int , int> ( row , column );
		}


	}

}
