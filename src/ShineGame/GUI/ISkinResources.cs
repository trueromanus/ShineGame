using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShineGame.GUI {
	
	/// <summary>
	/// Доступ к ресурсам шкуры.
	/// </summary>
	internal interface ISkinResources {

		/// <summary>
		/// Ресурсы шкуры.
		/// </summary>
		SkinResources Resources {
			get;
			set;
		}

	}

}
