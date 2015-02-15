using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelPropertyEditor.Models {

	/// <summary>
	/// Модель сборки поведения.
	/// </summary>
	public class AssemblyBehaviourModel {

		/// <summary>
		/// Последовательность поведений.
		/// </summary>
		public IEnumerable<BehaviourModel> Behaviours {
			get;
			set;
		}

		/// <summary>
		/// Имя сборки поведения.
		/// </summary>
		public string Name {
			get;
			set;
		}

		/// <summary>
		/// Описание сборки поведения.
		/// </summary>
		public string Description {
			get;
			set;
		}

	}

}
