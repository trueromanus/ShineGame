using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.State;

namespace ShineGame {

	/// <summary>
	/// Игровое состояние.
	/// </summary>
	public class ObjectState : IObjectState {

		/// <summary>
		/// Имя состояния.
		/// </summary>
		public string Name {
			get;
			set;
		}

		/// <summary>
		/// Значение состояния.
		/// </summary>
		public object Value {
			get;
			set;
		}

		/// <summary>
		/// Преобразовать значение объекта в указанный тип.
		/// </summary>
		/// <returns>Значение в указанном типе или null в случае неудачи.</returns>
		public T GetValue<T> () {
			return (T) Value;
		}
	}
}
