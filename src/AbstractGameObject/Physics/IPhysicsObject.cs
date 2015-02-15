using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.ObjectVisual;

namespace AbstractGameLogic.Physics {

	/// <summary>
	/// Физический объект.
	/// </summary>
	public interface IPhysicsObject {

		/// <summary>
		/// Координата по оси X.
		/// </summary>
		int X {
			get;
		}

		/// <summary>
		/// Корданата по оси Y.
		/// </summary>
		int Y {
			get;
		}

		/// <summary>
		/// Угол наклона.
		/// </summary>
		float Rotate {
			get;
			set;
		}

		/// <summary>
		/// Может ли объект поворачиваться.
		/// </summary>
		bool IsRotating {
			get;
			set;
		}

		/// <summary>
		/// Является ли объект пулей.
		/// </summary>
		bool IsBullet {
			get;
			set;
		}

		/// <summary>
		/// Доступно ли засыпание объекта.
		/// </summary>
		bool IsAllowSleep {
			get;
			set;
		}

		/// <summary>
		/// Разбужен ли объект или находиться в состоянии сна.
		/// </summary>
		bool IsAwake {
			get;
			set;
		}

		/// <summary>
		/// Физический тип объекта.
		/// </summary>
		PhysicsType Type {
			get;
			set;
		}

		/// <summary>
		/// Плотность.
		/// </summary>
		float Density {
			get;
			set;
		}

		/// <summary>
		/// Трение.
		/// </summary>
		float Friction {
			get;
			set;
		}

		/// <summary>
		/// Инерция.
		/// </summary>
		float Inertia {
			get;
			set;
		}

		/// <summary>
		/// Масса.
		/// </summary>
		float Mass {
			get;
			set;
		}

		/// <summary>
		/// Является ли объект сенсором.
		/// </summary>
		bool IsSensor {
			get;
			set;
		}

		/// <summary>
		/// Упругость.
		/// </summary>
		float Restitution {
			get;
			set;
		}

		/// <summary>
		/// Угловое торможение.
		/// </summary>
		float AngularDumping {
			get;
			set;
		}

		/// <summary>
		/// Линейное торможение.
		/// </summary>
		float LinearDumping {
			get;
			set;
		}

		/// <summary>
		/// Визуальный объект привязанный к физическому телу.
		/// </summary>
		IGameObjectVisual Object {
			get;
			set;
		}

		/// <summary>
		/// Установить позицию.
		/// </summary>
		/// <param name="x">Координата по оси X.</param>
		/// <param name="y">Координата по оси Y.</param>
		void SetPosition ( int x , int y );

		/// <summary>
		/// Установить позицию.
		/// </summary>
		/// <param name="vector">Вектор положения.</param>
		void SetPosition ( IVector2 vector );

		/// <summary>
		/// Установить позицию.
		/// </summary>
		/// <param name="x">Координата по оси X.</param>
		/// <param name="y">Координата по оси Y.</param>
		void SetPosition ( float x , float y );

		/// <summary>
		/// Получить вектор положения.
		/// </summary>
		/// <returns>Вектор положения.</returns>
		IVector2 GetVector ();

		/// <summary>
		/// Установить линейную скорость.
		/// </summary>
		/// <param name="x">По оси X.</param>
		/// <param name="y">По оси Y.</param>
		void SetLinearVelocity ( float x , float y );

		/// <summary>
		/// Получить линейную скорость.
		/// </summary>
		Tuple<float,float> GetLinearVelocity ();

		/// <summary>
		/// Установить угловую скорость.
		/// </summary>
		/// <param name="value">Значение.</param>
		void SetAngularVelocity ( float value );

		/// <summary>
		/// Обновить состояние объекта.
		/// </summary>
		void UpdateState ();

		/// <summary>
		/// Получить последовательность соприкоснувшихся объектов.
		/// </summary>
		/// <returns>Последовательность соприкоснувшихся объектов.</returns>
		IEnumerable<IGameObjectVisual> GetCollisionList ();

		/// <summary>
		/// Применить силу.
		/// </summary>
		/// <param name="forceX">Сила по оси X.</param>
		/// <param name="forceY">Сила по оси Y.</param>
		/// <param name="pointX">Точка применения по оси X.</param>
		/// <param name="pointY">Точка применения по оси Y.</param>
		void ApplyForce ( float forceX , float forceY , float pointX , float pointY );

		/// <summary>
		/// Применить момент.
		/// </summary>
		/// <param name="torque">Коэффициент кручения.</param>
		void ApplyTorque ( float torque  );

		/// <summary>
		/// Применить линейный импульс.
		/// </summary>
		/// <param name="impulseX">Импульс по оси Х.</param>
		/// <param name="impulseY">Импульс по оси Y.</param>
		/// <param name="pointX">Точка применения по оси X.</param>
		/// <param name="pointY">Точка применения по оси Y.</param>
		void ApplyLinearImpulse ( float impulseX , float impulseY , float pointX , float pointY );

		/// <summary>
		/// Применить угловой импульс.
		/// </summary>
		/// <param name="impulseX">Импульс.</param>
		void ApplyAngularImpulse ( float impulse  );

	}

}
