using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.State;

namespace AbstractGameLogic.ObjectBehavior {
	
	/// <summary>
	/// Коллекция событий.
	/// </summary>
	public interface IEventCollection {

		/// <summary>
		/// Добавить событие в коллекцию.
		/// </summary>
		void Add ( IEvent @event );

		/// <summary>
		/// Удалить в коллекции событие.
		/// </summary>
		/// <param name="event"></param>
		void Remove ( IEvent @event );

		/// <summary>
		/// Последовательность событий.
		/// </summary>
		IEnumerable<IEvent> Events {
			get;
		}

	}

}
