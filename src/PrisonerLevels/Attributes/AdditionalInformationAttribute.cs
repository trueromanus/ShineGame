using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrisonerLevelBehaviours.Attributes {
	
	/// <summary>
	/// Атрибут содержащий дополнительную информацию.
	/// </summary>
	public class AdditionalInformationAttribute : Attribute {

		/// <summary>
		/// Информация.
		/// </summary>
		public string Information {
			get;
			set;
		}

	}

}
