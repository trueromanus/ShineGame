using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.ObjectBehavior;
using AbstractGameLogic.State;

namespace AbstractGameLogic.Factories {

	/// <summary>
	/// Фабрика состояний.
	/// </summary>
	public interface IStateFactory {

		/// <summary>
		/// Создать состояние объекта.
		/// </summary>
		IObjectState CreateObjectState ();

		/// <summary>
		/// Создать коллекцию событий.
		/// </summary>
		/// <returns>Коллекция событий.</returns>
		IEventCollection CreateEventCollection ();

		/// <summary>
		/// Создать событие.
		/// </summary>
		/// <param name="action">Действие которое должно быть выполнено.</param>
		/// <param name="handler">Объект событие которого мы будем слушать.</param>
		/// <param name="name">Имя события.</param>
		/// <returns>Событие.</returns>
		IEvent CreateEvent ( string handler , string name , string action );

		/// <summary>
		/// Создать описание возбуждаемых объектом событий.
		/// </summary>
		/// <param name="objectName">Имя объекта.</param>
		/// <param name="events">Последовательность имен возбужденных событий.</param>
		/// <returns>Возбужденное событие.</returns>
		IEventRaises CreateEventRaises ( string objectName , IEnumerable<string> events );

	}

}
