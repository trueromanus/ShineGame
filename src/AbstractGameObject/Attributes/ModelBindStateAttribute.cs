using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.Attributes {

	/// <summary>
	/// Атрибут для привязки моделей к поведениям.
	/// </summary>
	[AttributeUsage ( AttributeTargets.Class , AllowMultiple = false , Inherited = true )]
	public class ModelBindStateAttribute : Attribute {

		/// <summary>
		/// Имя поведения.
		/// </summary>
		public string NameBehaviour {
			get;
			set;
		}

		/// <summary>
		/// Имя состояния.
		/// </summary>
		public string NameState {
			get;
			set;
		}

	}

}
