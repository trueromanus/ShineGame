using System.Collections.Generic;
using AbstractGameLogic.ObjectBehavior;

namespace AbstractGameLogic.ObjectVisual {

	/// <summary>
	/// Визуальный игровой объект.
	/// </summary>
	public interface IGameObjectVisual : IGameObject , IGameObjectBehaviourable {

		/// <summary>
		/// Координата по оси X в мировом пространстве.
		/// </summary>
		int WorldX {
			get;
			set;
		}

		/// <summary>
		/// Координата по оси Y в мировом пространстве.
		/// </summary>
		int WorldY {
			get;
			set;
		}

		/// <summary>
		/// Координата по оси X в мировом пространстве.
		/// </summary>
		int WorldXEnd {
			get;
		}

		/// <summary>
		/// Координата по оси Y в мировом пространстве.
		/// </summary>
		int WorldYEnd {
			get;
		}

		/// <summary>
		/// Ширина объекта.
		/// </summary>
		int Width {
			get;
			set;
		}

		/// <summary>
		/// Высота объекта.
		/// </summary>
		int Height {
			get;
			set;
		}

		/// <summary>
		/// Угол поворота.
		/// </summary>
		float Rotate {
			get;
			set;
		}

		/// <summary>
		/// Порядок элемента.
		/// </summary>
		int ZIndex {
			get;
			set;
		}

		/// <summary>
		/// Графический слой объекта.
		/// </summary>
		IDrawLevel DrawLevel {
			get;
			set;
		}

		/// <summary>
		/// Обновить состояние объекта.
		/// </summary>
		void Update ( IGameState inputGamestate );

		/// <summary>
		/// Отросивать объект.
		/// </summary>
		void Draw ();

		/// <summary>
		/// Получить позицию объекта в виде вектора.
		/// </summary>
		/// <returns>Вектор позиции.</returns>
		IVector2 GetVector ();

		/// <summary>
		/// Установить позицию объекта с помощью вектора.
		/// </summary>
		/// <param name="vector">Вектор.</param>
		void SetVector ( IVector2 vector );

		/// <summary>
		/// Установить позицию с помощью значений.
		/// </summary>
		/// <param name="x">Координаты по оси X.</param>
		/// <param name="y">Координаты по оси Y.</param>
		void SetVector ( float x , float y );

	}

}
