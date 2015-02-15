using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.Factories;
using AbstractGameLogic.ObjectBehavior;

namespace ShineGame.Factories {

	/// <summary>
	/// Фабрика поведений.
	/// </summary>
	public class BehavioursFactory : IBehaviourFactory {

		public IVisualObjectBehaviour CreateVisualBehaviour () {
			throw new NotImplementedException ();
		}

		/// <summary>
		/// Создать коллекцию поведений.
		/// </summary>
		/// <returns></returns>
		public IObjectBehaviors CreateBehavioursCollection () {
			return new BehaviourCollection ();
		}
	}

}
