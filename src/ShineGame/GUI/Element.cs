using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic;
using AbstractGameLogic.GUI;
using AbstractGameLogic.ObjectBehavior;
using AbstractGameLogic.ObjectVisual;
using AbstractGameLogic.State;

namespace ShineGame.GUI {

	/// <summary>
	/// Элемент графического интерфейса.
	/// </summary>
	internal class Element : IGUIElement {

		private IList<IObjectState> m_States = new List<IObjectState> ();

		private IObjectBehaviors m_Behaviours = new BehaviourCollection ();

		/// <summary>
		/// Признак того нужно ли рисовать элемент.
		/// </summary>
		public bool IsVisible {
			get;
			set;
		}

		/// <summary>
		/// Родительский элемент.
		/// </summary>
		public IGUIElement Parent {
			get;
			set;
		}

		/// <summary>
		/// Признак того стоит ли фокус на данном элементе.
		/// </summary>
		public bool IsFocused {
			get;
			set;
		}

		/// <summary>
		/// Менеджер графического интерфейса.
		/// </summary>
		public IGUIManager Manager {
			get;
			set;
		}

		/// <summary>
		/// Координата по оси X.
		/// </summary>
		public int WorldX {
			get;
			set;
		}

		/// <summary>
		/// Координата по оси Y.
		/// </summary>
		public int WorldY {
			get;
			set;
		}

		public int WorldXEnd {
			get {
				throw new NotImplementedException ();
			}
		}

		public int WorldYEnd {
			get {
				throw new NotImplementedException ();
			}
		}

		/// <summary>
		/// Ширина.
		/// </summary>
		public int Width {
			get;
			set;
		}

		/// <summary>
		/// Высота.
		/// </summary>
		public int Height {
			get;
			set;
		}

		/// <summary>
		/// Угол поворота.
		/// </summary>
		public float Rotate {
			get;
			set;
		}

		/// <summary>
		/// Порядковый номер элемента.
		/// </summary>
		public int ZIndex {
			get;
			set;
		}

		/// <summary>
		/// Графический слой.
		/// </summary>
		/// <remarks>
		/// Не поддерживается.
		/// </remarks>
		public IDrawLevel DrawLevel {
			get {
				throw new NotSupportedException ();
			}
			set {
				throw new NotSupportedException ();
			}
		}

		/// <summary>
		/// Обновить состояние элемента.
		/// </summary>
		/// <param name="inputGamestate"></param>
		public virtual void Update ( IGameState inputGamestate ) {
		}

		/// <summary>
		/// Нарисовать элемент.
		/// </summary>
		public virtual void Draw () {
		}

		/// <summary>
		/// Получить вектор позиции.
		/// </summary>
		/// <remarks>
		/// Не поддерживается.
		/// </remarks>
		public IVector2 GetVector () {
			throw new NotSupportedException ();
		}

		/// <summary>
		/// Установить вектор позиции.
		/// </summary>
		/// <remarks>
		/// Не поддерживается.
		/// </remarks>
		public void SetVector ( IVector2 vector ) {
			throw new NotImplementedException ();
		}

		/// <summary>
		/// Установить вектор позиции.
		/// </summary>
		/// <remarks>
		/// Не поддерживается.
		/// </remarks>
		public void SetVector ( float x , float y ) {
			throw new NotImplementedException ();
		}

		/// <summary>
		/// Имя элемента.
		/// </summary>
		public string Name {
			get;
			set;
		}

		/// <summary>
		/// Состояния.
		/// </summary>
		public IList<IObjectState> States {
			get {
				return m_States;
			}
		}

		/// <summary>
		/// Коллекция поведений.
		/// </summary>
		public IObjectBehaviors BehaviourCollection {
			get {
				return m_Behaviours;
			}
		}

		/// <summary>
		/// Инициализация элемента.
		/// </summary>
		public virtual void Initialize () {
		}
	}

}
