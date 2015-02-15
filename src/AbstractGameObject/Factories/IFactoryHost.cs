using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.Factories {
	
	/// <summary>
	/// Хост фабрик.
	/// </summary>
	public interface IFactoryHost {

		/// <summary>
		/// Фабрика пользовательского интерфейса.
		/// </summary>
		IGUIFactory GUI {
			get;
			set;
		}

		/// <summary>
		/// Фабрика поведений.
		/// </summary>
		IBehaviourFactory Behaviour {
			get;
			set;
		}

		/// <summary>
		/// Фабрика физики.
		/// </summary>
		IPhysicsFactory Physics {
			get;
			set;
		}

		/// <summary>
		/// Фабрика игровых объектов.
		/// </summary>
		IGameObjectFactory GameObjects {
			get;
			set;
		}

		/// <summary>
		/// Фабрика состояний.
		/// </summary>
		IStateFactory States {
			get;
			set;
		}

		/// <summary>
		/// Фабрика уровней.
		/// </summary>
		ILevelFactory Levels {
			get;
			set;
		}

	}

}
