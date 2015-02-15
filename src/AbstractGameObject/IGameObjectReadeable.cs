using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic;

namespace AbstractGameLogic {

	/// <summary>
	/// Интерфейс для игровых объект которые умеют получать
	/// данные из аналогичных объектов реализующих необходимый интерфейс.
	/// </summary>
	public interface IGameObjectReadeable {

		/// <summary>
		/// Прочесть данные из стороннего объекта и
		/// заполнить их внутри себя.
		/// </summary>
		/// <param name="gameObject">Игровой объект.</param>
		void CloneGameObjectData ( IGameObject gameObject );

	}
}
