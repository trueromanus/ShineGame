using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic {
	
	/// <summary>
	/// Игровой объект требующей абстрактной инициализации.
	/// </summary>
	public interface IGameObjectInitialization {

		/// <summary>
		/// Инициализация.
		/// </summary>
		void Initialize ();

	}
}
