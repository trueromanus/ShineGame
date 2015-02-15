using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.ObjectBehavior;

namespace AbstractGameLogic.Factories {
	
	/// <summary>
	/// Фабрика для поведений.
	/// </summary>
	public interface IBehaviourFactory {

		/// <summary>
		/// Создать поведение при колизиях.
		/// </summary>
		IObjectBehaviors CreateBehavioursCollection ();

		/// <summary>
		/// Создать поведение для визуализации.
		/// </summary>
		IVisualObjectBehaviour CreateVisualBehaviour ();

	}

}
