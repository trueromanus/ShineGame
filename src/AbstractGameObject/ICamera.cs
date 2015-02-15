using AbstractGameLogic.ObjectVisual;

namespace AbstractGameLogic {
	
	/// <summary>
	/// Камера.
	/// </summary>
	public interface ICamera : IGameObject {

		/// <summary>
		/// Игровой мир к которому привязана камера.
		/// </summary>
		IGameWorld World {
			get;
			set;
		}

		/// <summary>
		/// Привязанный к камере объект.
		/// </summary>
		IGameObjectVisual AttachObject {
			get;
			set;
		}

		/// <summary>
		/// Режим работы камеры.
		/// </summary>
		CameraMode Mode {
			get;
			set;
		}

		/// <summary>
		/// Режим привязки камеры.
		/// </summary>
		CameraAttachedMode AttachedMode {
			get;
			set;
		}

		/// <summary>
		/// Координата по оси X.
		/// </summary>
		int X {
			get;
			set;
		}

		/// <summary>
		/// Координата по оси Y.
		/// </summary>
		int Y {
			get;
			set;
		}

		/// <summary>
		/// Фокусировка камеры.
		/// </summary>
		void Focus ();

	}
}
