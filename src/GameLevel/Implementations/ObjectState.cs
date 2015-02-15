using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.State;

namespace GameLevel.Implementations {
	
	/// <summary>
	/// Состояние объекта.
	/// </summary>
	public class ObjectState : IObjectState {
		
		public string Name {
			get;
			set;
		}

		public object Value {
			get;
			set;
		}

		public T GetValue<T> () {
			return (T) Value;
		}
	}
}
