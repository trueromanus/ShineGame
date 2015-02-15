using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.Factories;

namespace ShineGame.Factories {
	
	/// <summary>
	/// Хост фабрик.
	/// </summary>
	public class FactoryHost : IFactoryHost {

		/// <summary>
		/// Фабрика пользовательского интерфейса.
		/// </summary>
		public IGUIFactory GUI {
			get;
			set;
		}

		/// <summary>
		/// Фабрика поведений.
		/// </summary>
		public IBehaviourFactory Behaviour {
			get;
			set;
		}

		/// <summary>
		/// Фабрика физики.
		/// </summary>
		public IPhysicsFactory Physics {
			get;
			set;
		}

		/// <summary>
		/// Фабрика игровых объектов.
		/// </summary>
		public IGameObjectFactory GameObjects {
			get;
			set;
		}

		/// <summary>
		/// Фабрика состояний.
		/// </summary>
		public IStateFactory States {
			get;
			set;
		}

		/// <summary>
		/// Фабрика уровней.
		/// </summary>
		public ILevelFactory Levels {
			get;
			set;
		}

	}
}
