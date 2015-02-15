
namespace AbstractGameLogic.ObjectVisual {
	
	/// <summary>
	/// Статический игровой объект.
	/// </summary>
	public interface IStaticObject : IGameObjectVisual {

		/// <summary>
		/// Имя изображения.
		/// </summary>
		string Image {
			get;
			set;
		}

		/// <summary>
		/// Позиция тайла внутри изображения.
		/// </summary>
		int? TilePosition {
			get;
			set;
		}

	}
}
