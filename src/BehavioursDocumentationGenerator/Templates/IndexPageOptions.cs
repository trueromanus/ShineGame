using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehavioursDocumentationGenerator.Models;

namespace BehavioursDocumentationGenerator.Templates {
	
	/// <summary>
	/// Настройки для шаблона 
	/// </summary>
	public partial class IndexPage {

		/// <summary>
		/// Последовательность моделей.
		/// </summary>
		public IEnumerable<BehaviourModel> Models {
			get;
			set;
		}

	}
}
