using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic {
	
	/// <summary>
	/// Представление объекта который может быть уничтожен
	/// во время игровой сессии.
	/// </summary>
	public interface IGameObjectDisposable {

		/// <summary>
		/// Признак того необходимо ли уничтожить объект
		/// при следующем обновлении состояния игры.
		/// </summary>
		bool IsNeedDispose {
			get;
			set;
		}

		/// <summary>
		/// Освободить ресурсы и уничтожить сам объект.
		/// </summary>
		void DisposeResource ();
	
	}

}
