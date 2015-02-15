using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.ObjectBehavior {
	
	/// <summary>
	/// Представление для 
	/// </summary>
	public interface IGameObjectBehaviourable {

		/// <summary>
		/// Набор поведений объекта.
		/// </summary>
		IObjectBehaviors BehaviourCollection {
			get;
		}

	}

}
