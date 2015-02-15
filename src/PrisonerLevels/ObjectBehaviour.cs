using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic;
using AbstractGameLogic.Factories;
using AbstractGameLogic.ObjectBehavior;
using AbstractGameLogic.ObjectVisual;
using AbstractGameLogic.State;

namespace PrisonerLevelBehaviours {

	/// <summary>
	/// Базовый класс поведения.
	/// </summary>
	public class ObjectBehaviour : IVisualObjectBehaviour {

		protected IFactoryHost m_FactoryHost;

		/// <summary>
		/// Номер по порядку.
		/// </summary>
		public int Order {
			get;
			set;
		}

		/// <summary>
		/// Имя поведения.
		/// </summary>
		public string Name {
			get;
			set;
		}

		/// <summary>
		/// Обработка событий.
		/// </summary>
		/// <param name="event">Возбужденное событие.</param>
		/// <returns>Следующее по цепочке событие.</returns>
		public virtual void EventHandler ( IEvent @event ) {
		}

		/// <summary>
		/// Коллекция обработчиков событий.
		/// </summary>
		public IEventCollection EventCollection {
			get;
			set;
		}

		/// <summary>
		/// Текущее событие.
		/// </summary>
		public string ThrowedEvent {
			get {
				throw new NotSupportedException ( "Не поддерживается хранение состояний возбуждаемых событий." );
			}
			set {
				VisualObject.DrawLevel.AddEvent ( VisualObject.Name , value );
			}
		}

		/// <summary>
		/// Визуальный объект.
		/// </summary>
		public IGameObjectVisual VisualObject {
			get;
			set;
		}

		/// <summary>
		/// Инициализация поведения.
		/// </summary>
		/// <param name="factorys">Хост фабрик.</param>
		public void Initialize ( IFactoryHost factorys ) {
			m_FactoryHost = factorys;
			InitializeVisualObject ();
		}

		/// <summary>
		/// Метод для перекрытия в потомках для инициализации визуального объекта.
		/// </summary>
		public virtual void InitializeVisualObject () {
		}

		/// <summary>
		/// Обновление состояния поведения.
		/// </summary>
		/// <param name="gameState">Игровое состояние.</param>
		public virtual void Update ( IGameState gameState ) {
		}
	}
}
