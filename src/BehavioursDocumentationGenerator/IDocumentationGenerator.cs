using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehavioursDocumentationGenerator.Models;

namespace BehavioursDocumentationGenerator {

	/// <summary>
	/// Генератор документации.
	/// </summary>
	public interface IDocumentationGenerator {

		/// <summary>
		/// Сгенерить документацию.
		/// </summary>
		/// <param name="path">Путь где будут размещены сгенерированная документация.</param>
		/// <param name="behaviourManager">Менеджер поведений.</param>
		/// <param name="assembly">Файл сборки.</param>
		void Generate ( string path , IBehaviourManager behaviourManager , string assembly );

	}

}
