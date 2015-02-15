using Microsoft.Xna.Framework;

namespace ShineGame.VisualObjects {

	/// <summary>
	/// Квадратный визуальный объект.
	/// </summary>
	public interface IRectangleVisualObject {

		/// <summary>
		/// Квадрат представленный в виде структуры XNA.
		/// </summary>
		Rectangle ObjectRectangle {
			get;
		}

	}
}
