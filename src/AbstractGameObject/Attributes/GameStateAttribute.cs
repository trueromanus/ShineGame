using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.Attributes {
	
	/// <summary>
	/// Атрибут для маркировки классов поведений допускающих действия.
	/// </summary>
	[AttributeUsage ( AttributeTargets.Class , AllowMultiple = true , Inherited = false )]
	public class GameStateAttribute : Attribute {

		/// <summary>
		/// Имя состояния.
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
