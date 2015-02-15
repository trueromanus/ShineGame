using System;
using System.Diagnostics;
using System.IO;
using XNAContentCompiler;

namespace XNACCC {

	class Program {

		static void Main ( string[] args ) {
			if ( args.Length == 0 ) {
				Console.WriteLine ( "XNA Content Compiler Console Edition version 1.0" );
				Console.WriteLine ( "Command line example follow:" );
				Console.WriteLine ( "\tXNACCC <pathtocontentdir> <outputdir>" );
				return;
			}

			Trace.WriteLine ( "Старт программы" );

			var path = Path.GetFullPath ( Folder.AddEndSlash ( args[0] ) );

			Trace.WriteLine ( string.Format ( "Путь к исходным файлам {0}" , path ) );

			var builder = new ContentBuilder ();
			Folder.BypassFolderData ( args[0] , fileName => builder.Add ( fileName , Path.GetFileNameWithoutExtension ( fileName ) , path ) );
			var errors = builder.Build ( path );
			if ( !string.IsNullOrEmpty ( errors ) ) {
				Console.WriteLine ( errors );
				Trace.WriteLine ( string.Format ( "Возникла ошибка сборки {0}" , errors ) );
				return;
			}

			var outputDirectory = Path.GetFullPath ( Folder.AddEndSlash ( args[1] ) );

			Trace.WriteLine ( string.Format ( "Папка для сборки {0}" , outputDirectory ) );

			Folder.DirectoryContentPreHandler (
				outputDirectory ,
				fileName => File.Delete ( fileName ) ,
				directoryName => Directory.Delete ( directoryName )
			);

			var outputProjectDirectory = Path.GetFullPath ( Folder.AddEndSlash ( builder.OutputDirectory ) );

			Folder.DirectoryContentPostHandler (
				outputProjectDirectory ,
				fileName => File.Copy ( fileName , Path.Combine ( outputDirectory , fileName.Replace ( outputProjectDirectory , "" ) ) ) ,
				directoryName => Directory.CreateDirectory ( Path.Combine ( outputDirectory , directoryName.Replace ( outputProjectDirectory , "" ) ) )
			);

			Trace.WriteLine ( "Программа завершила свое выполнение." );
		}

	}
}
