using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.ObjectBehavior {

	/// <summary>
	/// Набор поведений объекта.
	/// </summary>
	public interface IObjectBehaviors {

		/// <summary>
		/// Последовательность поведений объекта.
		/// </summary>
		IEnumerable<IObjectBehavior> Behaviors {
			get;
		}

		/// <summary>
		/// Добавить поведение.
		/// </summary>
		/// <param name="behavior">Поведение.</param>
		void Add ( IObjectBehavior behavior );

		/// <summary>
		/// Добавить последовательность поведений.
		/// </summary>
		/// <param name="behaviors">Поведение.</param>
		void AddRange ( IEnumerable<IObjectBehavior> behaviors );

		/// <summary>
		/// Удалить поведение.
		/// </summary>
		/// <param name="behavior">Поведение.</param>
		void Remove ( IObjectBehavior behavior );

	}
}
