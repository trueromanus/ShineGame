
using System.Collections.Generic;
using AbstractGameLogic.State;
namespace AbstractGameLogic {

	/// <summary>
	/// Интерфейс любого игрового объекта.
	/// </summary>
	public interface IGameObject {

		/// <summary>
		/// Имя игрового объекта.
		/// </summary>
		string Name {
			get;
			set;
		}

		/// <summary>
		/// Коллекция состояний.
		/// </summary>
		IList<IObjectState> States {
			get;
		}

	}

}
