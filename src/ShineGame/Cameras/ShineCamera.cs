using System;
using System.Collections.Generic;
using AbstractGameLogic;
using AbstractGameLogic.ObjectVisual;
using AbstractGameLogic.State;

namespace ShineGame.Cameras {

	/// <summary>
	/// Камера для игрового мира.
	/// </summary>
	public class ShineCamera : ICamera {

		private int m_X;

		private int m_Y;

		private List<IObjectState> m_StateCollection = new List<IObjectState> ();

		/// <summary>
		/// Игровой мир к которому привязана камера.
		/// </summary>
		public IGameWorld World {
			get;
			set;
		}

		/// <summary>
		/// Привязанный к камере объект.
		/// </summary>
		public IGameObjectVisual AttachObject {
			get;
			set;
		}

		/// <summary>
		/// Режим камеры.
		/// </summary>
		public CameraMode Mode {
			get;
			set;
		}

		/// <summary>
		/// Режим привязки камеры к привязанному объекту.
		/// </summary>
		public CameraAttachedMode AttachedMode {
			get;
			set;
		}

		/// <summary>
		/// Координата камеры по оси X.
		/// </summary>
		public int X {
			get {
				return m_X;
			}
			set {
				m_X = value;
				if ( m_X < 0 ) m_X = 0;
			}
		}

		/// <summary>
		/// Координата камеры по оси Y.
		/// </summary>
		public int Y {
			get {
				return m_Y;
			}
			set {
				m_Y = value;
				if ( m_Y < 0 ) m_Y = 0;
			}
		}

		/// <summary>
		/// Получить координаты для камеры относительно режима прикрепления.
		/// </summary>
		private void SetCoordinatesCamera () {
			switch ( AttachedMode ) {
				case CameraAttachedMode.Center:
					World.WorldX = ( AttachObject.WorldXEnd - ( AttachObject.Width / 2 ) ) - ( World.ViewportWidth / 2 );
					World.WorldY = ( AttachObject.WorldYEnd - ( AttachObject.Height / 2 ) ) - ( World.ViewportHeight / 2 );
					break;
				case CameraAttachedMode.Static:
					World.WorldX = AttachObject.WorldX + X;
					World.WorldY = AttachObject.WorldY + Y;
					break;
				case CameraAttachedMode.LeftTop:
					World.WorldX = AttachObject.WorldX;
					World.WorldY = AttachObject.WorldY;
					break;
				case CameraAttachedMode.RightTop:
					World.WorldX = ( AttachObject.WorldX - ( World.ViewportWidth - AttachObject.Width ) );
					World.WorldY = AttachObject.WorldY;
					break;
				case CameraAttachedMode.LeftBottom:
					World.WorldX = AttachObject.WorldX;
					World.WorldY = ( AttachObject.WorldY - ( World.ViewportHeight - AttachObject.Height ) );
					break;
				case CameraAttachedMode.RightBottom:
					World.WorldX = ( AttachObject.WorldX - ( World.ViewportWidth - AttachObject.Width ) );
					World.WorldY = ( AttachObject.WorldY - ( World.ViewportHeight - AttachObject.Height ) );
					break;
				default:
					throw new NotSupportedException ( "Режим привязки к объекту не поддерживается." );
			}
		}

		/// <summary>
		/// Фокусировка камеры.
		/// </summary>
		public void Focus () {
			switch ( Mode ) {
				//для режима свободной камеры просто
				//подгоняем ее координаты под координаты мира
				case CameraMode.Free:
					World.WorldX = X;
					World.WorldY = Y;
					break;
				//для режима привязки к объектам
				//просто подгоняем координаты под расположение объекта
				case CameraMode.AttachedWithObject:
					SetCoordinatesCamera ();
					break;
			}
		}

		/// <summary>
		/// Имя камеры.
		/// </summary>
		public string Name {
			get;
			set;
		}

		/// <summary>
		/// Колекция состояний камеры.
		/// </summary>
		/// <remarks>В текущей версии не поддерживается.</remarks>
		public IList<IObjectState> States {
			get {
				return m_StateCollection;
			}
		}
	}
}
