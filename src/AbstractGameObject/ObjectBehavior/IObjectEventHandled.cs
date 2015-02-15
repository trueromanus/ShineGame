using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.State;

namespace AbstractGameLogic.ObjectBehavior {

	/// <summary>
	/// Объект поддерживающий обработку событий.
	/// </summary>
	public interface IObjectEventHandled {

		/// <summary>
		/// Коллекция событий которые может обрабатывать объект.
		/// </summary>
		IEventCollection EventCollection {
			get;
			set;
		}

		/// <summary>
		/// Возбужденное исключение.
		/// </summary>
		string ThrowedEvent {
			get;
			set;
		}

		/// <summary>
		/// Обработчик событий.
		/// </summary>
		/// <param name="event">Возбужденное событие.</param>
		void EventHandler ( IEvent @event );

	}

}
