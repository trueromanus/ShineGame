using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.Attributes {

	/// <summary>
	/// Атрибут для привязки поведений к объектам.
	/// </summary>
	[AttributeUsage ( AttributeTargets.Class , AllowMultiple = false , Inherited = true )]
	public class ObjectBindBehaviourAttribute : Attribute {

		/// <summary>
		/// Имя поведения.
		/// </summary>
		public string Name {
			get;
			set;
		}

		/// <summary>
		/// Описание.
		/// </summary>
		public string Description {
			get;
			set;
		}

	}

}
