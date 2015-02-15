using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LevelPropertyEditor.Models;

namespace LevelPropertyEditor {

	/// <summary>
	/// Менеджер сборок поведений.
	/// </summary>
	public interface IAssemblyBehaviourManager {

		/// <summary>
		/// Последовательность сборок.
		/// </summary>
		IEnumerable<AssemblyBehaviourModel> Assemblies {
			get;
		}

		/// <summary>
		/// Добавить сборку.
		/// </summary>
		/// <param name="assembly">Сборка.</param>
		void AddAssembly ( Assembly assembly );

		/// <summary>
		/// Добавить сборки.
		/// </summary>
		/// <param name="assemblies">Последовательность сборок.</param>
		void AddAssemblies ( IEnumerable<Assembly> assemblies );
		
	}

}
