﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.Attributes {
	
	/// <summary>
	/// Атрибут для пометки данных сборки поведения.
	/// </summary>
	public class AssemblyBehaviourAttribute : Attribute {

		/// <summary>
		/// Имя.
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
