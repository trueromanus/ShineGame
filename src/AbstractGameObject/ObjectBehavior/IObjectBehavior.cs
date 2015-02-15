using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.ObjectBehavior {
	
	/// <summary>
	/// Поведение объекта.
	/// </summary>
	public interface IObjectBehavior : IObjectEventHandled {

		/// <summary>
		/// Порядок выполнения поведения.
		/// </summary>
		int Order {
			get;
			set;
		}

		/// <summary>
		/// Имя поведения.
		/// </summary>
		string Name {
			get;
			set;
		}

	}

}
