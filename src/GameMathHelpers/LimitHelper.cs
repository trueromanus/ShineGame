using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameMathHelpers {

	/// <summary>
	/// Помошник для различных ограничений.
	/// </summary>
	public static class LimitHelper {

		/// <summary>
		/// Ограничить значение в диапазоне. 
		/// Если значение будет вне диапазона будет установлено крайнее значение.
		/// </summary>
		/// <param name="value">Исходное значение.</param>
		/// <param name="min">Минимальное значение.</param>
		/// <param name="max">Максимальное значение.</param>
		/// <returns>Число возвращенное в диапазоне.</returns>
		public static int LimitToRange ( this int value , int min , int max ) {
			if ( value < min ) return min;
			if ( value > max ) return max;
			return value;
		}

		/// <summary>
		/// Ограничить значение только в положительном диапазоне.
		/// </summary>
		/// <param name="value">Исходное значение.</param>
		/// <returns>Полученное значение.</returns>
		public static int LimitToPositive ( this int value ) {
			return value < 0 ? 0 : value;
		}

		/// <summary>
		/// Ограничить значение только в указанном диапазоне.
		/// </summary>
		/// <param name="value">Исходное значение.</param>
		/// <returns>Полученное значение.</returns>
		public static int LimitToPositive ( this int value , int start ) {
			return value < start ? start : value;
		}

		/// <summary>
		/// Проверить положительное ли число.
		/// </summary>
		/// <param name="value">Исходное значение.</param>
		/// <returns>Признак того что число положительное.</returns>
		public static bool IsPositive ( this int value ) {
			return value > 0;
		}

		/// <summary>
		/// Проверить отрицательное ли число.
		/// </summary>
		/// <param name="value">Исходное значение.</param>
		/// <returns>Признак того что число отрицательное.</returns>
		public static bool IsNegative ( this int value ) {
			return value < 0;
		}

		/// <summary>
		/// Проверка кратности числа.
		/// </summary>
		/// <param name="value">Исходное значение.</param>
		/// <returns>Признак того что число кратное.</returns>
		public static bool IsOdd ( this int value ) {
			return ( value % 2 ) == 0;
		}

	}
}
