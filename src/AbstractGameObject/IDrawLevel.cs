using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.ObjectVisual;
using AbstractGameLogic.Physics;
using AbstractGameLogic.State;

namespace AbstractGameLogic {

	/// <summary>
	/// Слой графики необходим для
	/// группировки объектов с единой
	/// областью видимости. (например фон это один уровень, игрок и враги второй а hud это третий)
	/// </summary>
	public interface IDrawLevel {

		/// <summary>
		/// Объекты уровня.
		/// </summary>
		IEnumerable<IGameObjectVisual> Objects {
			get;
		}

		/// <summary>
		/// Физический мир.
		/// </summary>
		IPhysicsWorld PhysicsWorld {
			get;
		}

		/// <summary>
		/// Игровой мир.
		/// </summary>
		IGameWorld GameWorld {
			get;
			set;
		}

		/// <summary>
		/// Список текущих событий.
		/// </summary>
		IEnumerable<IEventRaises> Events {
			get;
		}

		/// <summary>
		/// Имя слоя графики.
		/// </summary>
		string Name {
			get;
			set;
		}

		/// <summary>
		/// Признак того будут ли выполняться проверки
		/// колизий во время обновления состояния объектов в графическом слое.
		/// </summary>
		bool IsCheckCollision {
			get;
			set;
		}

		/// <summary>
		/// Область вывода графического слоя.
		/// </summary>
		IRectangle Viewport {
			get;
			set;
		}

		/// <summary>
		/// Добавить игровой объект.
		/// </summary>
		/// <param name="gameObject">Визуальный игровой объект.</param>
		void Add ( IGameObjectVisual gameObject );

		/// <summary>
		/// Добавить возбужденное событие.
		/// </summary>
		/// <param name="objectName">Имя объекта.</param>
		/// <param name="eventRaises">Возбужденное событие.</param>
		void AddEvent ( string objectName, string eventRaises );

		/// <summary>
		/// Очистить возбужденные события.
		/// </summary>
		void ClearEvents ();

		/// <summary>
		/// Получить объект по имени.
		/// </summary>
		/// <param name="name">Имя объекта.</param>
		/// <returns>Найденный объект или null.</returns>
		IGameObjectVisual GetObject ( string name );

		/// <summary>
		/// Удалить игровой объект.
		/// </summary>
		/// <param name="name">Имя объекта.</param>
		void Remove ( string name );

		/// <summary>
		/// Обновить состояние всех объектов в уровне.
		/// </summary>
		/// <param name="inputGamestate">Состояние устройств ввода.</param>
		void Update ( IGameState inputGamestate );

		/// <summary>
		/// Отрисовать все объекты которые в уровне которые находятся в определенной области видимости.
		/// </summary>
		/// <param name="worldX">Мировые координаты по оси X.</param>
		/// <param name="worldY">Мировые координаты по оси Y.</param>		
		/// <param name="worldXEnd">Мировые координаты по оси X конец диапазона.</param>
		/// <param name="worldYEnd">Мировые координаты по оси Y конец диапазона.</param>		
		void Draw ( int worldX , int worldY , int worldXEnd , int worldYEnd );

		/// <summary>
		/// Освободить ресурсы захваченные графическим слоем.
		/// </summary>
		void FreeResources ();

	}
}
