using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehavioursDocumentationGenerator.Implementation;

namespace BehavioursDocumentationGenerator {
	
	/// <summary>
	/// Класс программы.
	/// </summary>
	class Program {
		
		/// <summary>
		/// Точка входа приложения.
		/// </summary>
		/// <param name="args">Массив аргументов.</param>
		static void Main ( string[] args ) {
			Console.WriteLine("Assembly Documentation Generator version 0.1");
			Console.WriteLine("Copyright (c) 2013 Romanus");
			Console.WriteLine("");
			if ( args.Length != 2 ) {
				Console.WriteLine ( "\tCommand line format is follow: <outputpath> <assemblypath>" );
				return;
			}

			IDocumentationGenerator generator = new HTMLDocumentationGenerator ();
			try {
				generator.Generate ( args.First () , new MetadataBehaviourManager () , args.Last () );
				Console.WriteLine ( "Generate documentation sucessfully" );
			}
			catch ( Exception ) {
				Console.WriteLine ( "Error generation documentation" );
			}
		}

	}
}
