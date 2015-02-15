using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.Factories;
using AbstractGameLogic.ObjectBehavior;
using AbstractGameLogic.State;

namespace ShineGame.Factories {

	/// <summary>
	/// Фабрика состояний.
	/// </summary>
	public class StateFactory : IStateFactory {

		/// <summary>
		/// Создать состояние объекта.
		/// </summary>
		public IObjectState CreateObjectState () {
			return new ObjectState ();
		}

		/// <summary>
		/// Создать коллекцию событий.
		/// </summary>
		/// <returns>Коллекция событий.</returns>
		public IEventCollection CreateEventCollection () {
			return new ShineEventCollection ();
		}

		/// <summary>
		/// Создать событие.
		/// </summary>
		/// <param name="action">Действие которое должно быть выполнено.</param>
		/// <param name="handler">Объект событие которого мы будем слушать.</param>
		/// <param name="name">Имя события.</param>
		/// <returns>Событие.</returns>
		public IEvent CreateEvent ( string handler , string name , string action ) {
			return new ShineEvent {
				Handler = handler ,
				Name = name ,
				Action = action
			};
		}

		/// <summary>
		/// Создать возбуждаемое событие.
		/// </summary>
		/// <param name="objectName">Имя объекта.</param>
		/// <param name="events">Последовательность событий.</param>
		/// <returns>Возбуждаемое событие.</returns>
		public IEventRaises CreateEventRaises ( string objectName , IEnumerable<string> events ) {
			return new EventRaises {
				ObjectName = objectName ,
				Events = events
			};
		}
	}

}
