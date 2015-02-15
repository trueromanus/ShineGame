using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic {
	
	/// <summary>
	/// Состояние игровых устройств ввода.
	/// </summary>
	public interface IInputGameState {

		/// <summary>
		/// Признак того нажата ли клавиша.
		/// </summary>
		/// <param name="key">Имя клавиши.</param>
		bool IsKeyDown ( KeyboardButtonKey key );

		/// <summary>
		/// Признак того были ли отпущена клавиша.
		/// </summary>
		/// <param name="key">Имя клавиши.</param>
		bool IsKeyUp ( KeyboardButtonKey key );

		/// <summary>
		/// Признак того была ли нажата клавиша мыши.
		/// </summary>
		/// <param name="key">Имя клавиши.</param>
		bool IsMouseDown ( MouseButtonKey key );

		/// <summary>
		/// Признак того была ли отпущена клавиша мыши.
		/// </summary>
		/// <param name="key">Имя клавиши.</param>
		bool IsMouseUp ( MouseButtonKey key );

		/// <summary>
		/// Получить координаты мыши.
		/// </summary>
		/// <returns>Координаты мыши.</returns>
		Tuple<int , int> GetMousePosition ();

	}
}
