using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehavioursDocumentationGenerator.Models;
using BehavioursDocumentationGenerator.Templates;

namespace BehavioursDocumentationGenerator.Implementation {

	/// <summary>
	/// Генератор документации в виде HTML.
	/// </summary>
	internal sealed class HTMLDocumentationGenerator : IDocumentationGenerator {

		/// <summary>
		/// Сгенерить документацию.
		/// </summary>
		/// <param name="path">Путь для финальных файлов.</param>
		/// <param name="behaviourManager">Менеджер поведений.</param>
		/// <param name="assembly">Файл сборки.</param>
		public void Generate ( string path , IBehaviourManager behaviourManager , string assembly ) {
			var sourcePath = Path.GetFullPath ( path );
			var models = behaviourManager.GetModels ( Path.GetFullPath ( assembly ) );
			models
				.AsParallel ()
				.OrderBy ( a => a.Name )
				.ForAll (
					a =>
						File.WriteAllText ( Path.Combine ( sourcePath , a.Name + ".html" ) ,
						new BehaviourPage {
							Model = a
						}.TransformText () ,
						Encoding.UTF8
					)
				);
			File.WriteAllText ( Path.Combine ( sourcePath , "index.html" ) , new IndexPage {
				Models = models
			}.TransformText () ,
			Encoding.UTF8 );
		}
	}

}
