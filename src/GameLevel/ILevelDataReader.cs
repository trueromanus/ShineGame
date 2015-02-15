using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLevel {

	/// <summary>
	/// Представление читателя данных уровня.
	/// </summary>
	public interface ILevelDataReader<T> {

		/// <summary>
		/// Формируем модель из данных в файле.
		/// </summary>
		/// <param name="fileName">Имя файла.</param>
		/// <returns>Модель данных.</returns>
		T ReadModelFromFile ( string fileName );

		/// <summary>
		/// Читаем данные из файла.
		/// </summary>
		/// <param name="fileName">Имя файла.</param>
		/// <returns>Возвращаем полученные данные.</returns>
		IGameLevelData ReadDataFromModel ( T model );

	}

}
