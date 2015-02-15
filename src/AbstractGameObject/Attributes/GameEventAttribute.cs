using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.Attributes {

	/// <summary>
	/// Атрибут дополняющий 
	/// </summary>
	[AttributeUsage ( AttributeTargets.Class , AllowMultiple = true , Inherited = false )]
	public sealed class GameEventAttribute : Attribute {

		/// <summary>
		/// Имя события допустимого в данном поведении.
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
