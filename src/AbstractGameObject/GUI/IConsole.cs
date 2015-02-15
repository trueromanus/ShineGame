using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.GUI {

	/// <summary>
	/// Консоль.
	/// </summary>
	public interface IConsole : IGUIWindow {

		
		/// <summary>
		/// Действие для обратного вызова при вводе команды в консоль.
		/// </summary>
		Action<string> CallbackAction {
			get;
			set;
		}

	}

}
