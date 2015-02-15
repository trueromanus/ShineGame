using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractGameLogic.GameLevel {
	
	/// <summary>
	/// Представление уровня игры.
	/// </summary>
	public interface ILevel : IGameObject {

		/// <summary>
		/// Название уровня.
		/// </summary>
		string Level {
			get;
			set;
		}

		/// <summary>
		/// Получить игровой мир из данных уровня.
		/// </summary>
		/// <returns>Игровой мир.</returns>
		IGameWorld GetGameWorld ();

	}

}
