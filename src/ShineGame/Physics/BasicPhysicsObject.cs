using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic;
using AbstractGameLogic.ObjectVisual;
using AbstractGameLogic.Physics;
using Box2D.XNA;
using Microsoft.Xna.Framework;

namespace ShineGame.Physics {

	/// <summary>
	/// Базовый физический объект.
	/// </summary>
	public abstract class BasicPhysicsObject : IPhysicsObject , IBox2dBody {

		protected Body m_Body;
		private float m_Restitution;

		/// <summary>
		/// Угол поворота.
		/// </summary>
		public float Rotate {
			get {
				return m_Body.Rotation;
			}
			set {
				m_Body.Rotation = value;
			}
		}

		/// <summary>
		/// Может ли объект поворачиваться.
		/// </summary>
		public bool IsRotating {
			get {
				return m_Body.IsFixedRotation ();
			}
			set {
				m_Body.SetFixedRotation ( value == true ? false : true );
			}
		}

		/// <summary>
		/// Физический тип объекта.
		/// </summary>
		public PhysicsType Type {
			get {
				var type = m_Body.GetType ();
				switch ( type ) {
					case BodyType.Static:
						return PhysicsType.Static;
					case BodyType.Dynamic:
						return PhysicsType.Dynamic;
					default:
						return PhysicsType.Static;
				}
			}
			set {
				switch ( value ) {
					case PhysicsType.Static:
						m_Body.SetType ( BodyType.Static );
						break;
					case PhysicsType.Dynamic:
						m_Body.SetType ( BodyType.Dynamic );
						break;
					default:
						m_Body.SetType ( BodyType.Static );
						break;
				}
			}
		}

		/// <summary>
		/// Физческое тело из объекта класса.
		/// </summary>
		public Body Body {
			get {
				return m_Body;
			}
			set {
				m_Body = value;
			}
		}

		/// <summary>
		/// Координата по оси X.
		/// </summary>
		public int X {
			get {
				return GetX ();
			}
		}

		/// <summary>
		/// Получить координату объекта по оси X.
		/// </summary>
		protected abstract int GetX ();

		/// <summary>
		/// Получить координату объекта по оси Y.
		/// </summary>
		protected abstract int GetY ();

		/// <summary>
		/// Координата по оси Y.
		/// </summary>
		public int Y {
			get {
				return GetY ();
			}
		}

		/// <summary>
		/// Установить линейную скорость.
		/// </summary>
		/// <param name="x">По оси Х.</param>
		/// <param name="y">По оси Y/</param>
		public void SetLinearVelocity ( float x , float y ) {
			m_Body.SetLinearVelocity ( new Vector2 ( x , y ) );
		}


		/// <summary>
		/// Плотность.
		/// </summary>
		public float Density {
			get;
			set;
		}

		/// <summary>
		/// Трение.
		/// </summary>
		public float Friction {
			get;
			set;
		}

		/// <summary>
		/// Инерция.
		/// </summary>
		public float Inertia {
			get;
			set;
		}

		/// <summary>
		/// Масса.
		/// </summary>
		public float Mass {
			get;
			set;
		}

		/// <summary>
		/// Является ли объект пулей.
		/// </summary>
		public bool IsBullet {
			get {
				return m_Body.IsBullet;
			}
			set {
				m_Body.SetBullet ( value );
			}
		}

		/// <summary>
		/// Является ли объект сенсором.
		/// </summary>
		public bool IsSensor {
			get;
			set;
		}

		/// <summary>
		/// Упругость.
		/// </summary>
		public float Restitution {
			get {
				return m_Restitution;
			}
			set {
				m_Restitution = MathHelper.Clamp ( value , 0.0f , 1.0f );
			}
		}

		/// <summary>
		/// Уголовое торможение.
		/// </summary>
		public float AngularDumping {
			get {
				return m_Body.GetAngularDamping ();
			}
			set {
				m_Body.SetAngularDamping ( MathHelper.Clamp ( value , 0.0f , 0.1f ) );
			}
		}

		/// <summary>
		/// Установить позицию.
		/// </summary>
		/// <param name="x">Координата по оси X.</param>
		/// <param name="y">Координата по оси Y.</param>
		public virtual void SetPosition ( int x , int y ) {
			//m_Body.Position = new Vector2 ( x , y );
			m_Body.SetTransform ( new Vector2 ( x , y ) , Rotate );
		}

		/// <summary>
		/// Обновить состояние объекта.
		/// </summary>
		public virtual void UpdateState () {
			throw new NotImplementedException ();
		}

		/// <summary>
		/// Получить последовательность соприкоснувшихся объектов.
		/// </summary>
		/// <returns>Последовательность соприкоснувшихся объектов.</returns>
		public IEnumerable<IGameObjectVisual> GetCollisionList () {
			var contactList = m_Body.GetContactList ();
			if ( contactList == null ) return Enumerable.Empty<IGameObjectVisual> ();
			List<IGameObjectVisual> list = new List<IGameObjectVisual> ();

			ContactEdge currentContact = contactList;
			IGameObjectVisual @object = null;
			do {
				@object = (IGameObjectVisual) currentContact.Other.GetUserData ();
				list.Add ( @object );
				currentContact = currentContact.Next;
			} while ( currentContact != null );

			return list;
		}

		/// <summary>
		/// Визуальный объект привязанный к телу.
		/// </summary>
		public IGameObjectVisual Object {
			get {
				return ( m_Body.GetUserData () as IGameObjectVisual );
			}
			set {
				m_Body.SetUserData ( value );
			}
		}

		/// <summary>
		/// Доступно ли засыпание объекта.
		/// </summary>
		public bool IsAllowSleep {
			get {
				return m_Body.IsSleepingAllowed;
			}
			set {
				m_Body.AllowSleeping ( value );
			}
		}

		/// <summary>
		/// Установить уголовую скорость.
		/// </summary>
		/// <param name="value">Значение.</param>
		public void SetAngularVelocity ( float value ) {
			m_Body.SetAngularVelocity ( value );
		}

		/// <summary>
		/// Применить импульса.
		/// </summary>
		/// <param name="forceX">Сила по оси X.</param>
		/// <param name="forceY">Сила по оси Y.</param>
		/// <param name="pointX">Точка применения по оси X.</param>
		/// <param name="pointY">Точка применения по оси Y.</param>
		public void ApplyForce ( float forceX , float forceY , float pointX , float pointY ) {
			m_Body.ApplyForce ( new Vector2 ( forceX , forceY ) , new Vector2 ( pointX , pointY ) );
		}

		/// <summary>
		/// Применить момент.
		/// </summary>
		/// <param name="torque">Коэффициент кручения.</param>
		public void ApplyTorque ( float torque ) {
			m_Body.ApplyTorque ( torque );
		}

		/// <summary>
		/// Применить линейный импульс.
		/// </summary>
		/// <param name="impulseX">Импульс по оси Х.</param>
		/// <param name="impulseY">Импульс по оси Y.</param>
		/// <param name="pointX">Точка применения по оси X.</param>
		/// <param name="pointY">Точка применения по оси Y.</param>
		public void ApplyLinearImpulse ( float impulseX , float impulseY , float pointX , float pointY ) {
			m_Body.ApplyLinearImpulse ( new Vector2 ( impulseX , impulseY ) , new Vector2 ( pointX , pointY ) );
		}

		/// <summary>
		/// Применить угловой импульс.
		/// </summary>
		/// <param name="impulseX">Импульс.</param>
		public void ApplyAngularImpulse ( float impulse ) {
			m_Body.ApplyAngularImpulse ( impulse );
		}

		/// <summary>
		/// Признак того бодорствует ли объект или спит.
		/// </summary>
		public bool IsAwake {
			get {
				return m_Body.IsAwake ();
			}
			set {
				m_Body.SetAwake ( value );
			}
		}

		/// <summary>
		/// Линейное торможение.
		/// </summary>
		public float LinearDumping {
			get {
				return m_Body.GetLinearDamping ();
			}
			set {
				m_Body.SetLinearDamping ( MathHelper.Clamp ( value , 0.0f , 10.0f/*0.1f*/ ) );
			}
		}

		/// <summary>
		/// Получить линейную скорость.
		/// </summary>
		public Tuple<float , float> GetLinearVelocity () {
			var vector = m_Body.GetLinearVelocity ();
			return new Tuple<float , float> ( vector.X , vector.Y );
		}

		/// <summary>
		/// Установоить позицию.
		/// </summary>
		/// <param name="vector">Вектор положения.</param>
		public virtual void SetPosition ( IVector2 vector ) {
			m_Body.SetTransform ( new Vector2 ( vector.X , vector.Y ) , 0.0f );
		}

		/// <summary>
		/// Установоить позицию.
		/// </summary>
		/// <param name="x">Координата по оси X.</param>
		/// <param name="y">Координата по оси Y.</param>
		public virtual void SetPosition ( float x , float y ) {
			m_Body.SetTransform ( new Vector2 ( x , y ) , 0.0f );
		}

		/// <summary>
		/// Получить вектор положения.
		/// </summary>
		/// <returns></returns>
		public virtual IVector2 GetVector () {
			return new ShineVector2 {
				X = m_Body.Position.X,
				Y = m_Body.Position.Y
			};
		}
	}
}
