using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.ObjectVisual {
	
	/// <summary>
	/// Графический эффект.
	/// </summary>
	public interface IEffect : IGameObjectVisual {

		/// <summary>
		/// Время жизни объектов.
		/// </summary>
		int TimeToLife {
			get;
			set;
		}

		/// <summary>
		/// Название эффекта.
		/// </summary>
		string EffectName {
			get;
			set;
		}

	}

}
