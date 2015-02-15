using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioursDocumentationGenerator.Models {
	
	/// <summary>
	/// Данные о поведении.
	/// </summary>
	public class BehaviourModel {

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

		/// <summary>
		/// Действия которые может выполнять поведение.
		/// </summary>
		public IEnumerable<GameMetaDataModel> Actions {
			get;
			set;
		}

		/// <summary>
		/// Состояния которые можно задавать у поведения.
		/// </summary>
		public IEnumerable<GameMetaDataModel> States {
			get;
			set;
		}

		/// <summary>
		/// События которые может посылать поведение.
		/// </summary>
		public IEnumerable<GameMetaDataModel> Events {
			get;
			set;
		}

	}

}
