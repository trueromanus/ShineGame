using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.State {

	/// <summary>
	/// Состояние объекта.
	/// </summary>
	public interface IObjectState {

		/// <summary>
		/// Имя состояния.
		/// </summary>
		string Name {
			get;
			set;
		}

		/// <summary>
		/// Значение состояния.
		/// </summary>
		object Value {
			get;
			set;
		}

		/// <summary>
		/// Получить значение с определенным типом.
		/// </summary>
		/// <returns>Значение приведенное к указанному типу.</returns>
		T GetValue<T> ();

	}

}
