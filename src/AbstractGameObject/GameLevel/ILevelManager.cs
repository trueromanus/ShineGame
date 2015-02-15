using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.GameLevel {
	
	/// <summary>
	/// Менеджер уровней.
	/// </summary>
	public interface ILevelManager {

		/// <summary>
		/// Загрузить уровень.
		/// </summary>
		/// <param name="name">Имя уровня.</param>
		void LoadLevel ( string name );

	}

}
