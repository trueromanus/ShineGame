using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace XNACCC {

	/// <summary>
	/// Класс для работы с папками.
	/// </summary>
	internal static class Folder {

		/// <summary>
		/// Обход всех файлов в каталоге и вызов для каждого действия.
		/// </summary>
		/// <param name="name">Имя папки.</param>
		/// <param name="fileProcessor">Действие для файлов.</param>
		public static void BypassFolderData ( string name , Action<string> fileProcessor ) {
			foreach ( string file in Directory.GetFiles ( name ) ) {
				fileProcessor ( Path.GetFullPath ( file ) );
			}

			foreach ( string dir in Directory.GetDirectories ( name ) ) {
				BypassFolderData ( Path.GetFullPath ( dir ) , fileProcessor );
			}
		}

		/// <summary>
		/// Обработчик содержимого папок.
		/// </summary>
		/// <param name="name">Имя папки которую необходимо очистить.</param>
		public static void DirectoryContentPreHandler ( string name , Action<string> fileProcessor , Action<string> dirProcessor ) {
			foreach ( string file in Directory.GetFiles ( name ) ) fileProcessor ( file );

			foreach ( string dir in Directory.GetDirectories ( name ) ) {
				DirectoryContentPreHandler ( dir , fileProcessor , dirProcessor );
				dirProcessor ( dir );
			}
		}

		/// <summary>
		/// Обработчик содержимого папок.
		/// </summary>
		/// <param name="name">Имя папки которую необходимо очистить.</param>
		public static void DirectoryContentPostHandler ( string name , Action<string> fileProcessor , Action<string> dirProcessor ) {
			foreach ( string dir in Directory.GetDirectories ( name ) ) {
				dirProcessor ( dir );
				DirectoryContentPostHandler ( dir , fileProcessor , dirProcessor );
			}

			foreach ( string file in Directory.GetFiles ( name ) ) fileProcessor ( file );
		}

		/// <summary>
		/// Добавить конечный слэш если такового нет.
		/// </summary>
		/// <param name="name">Имя папки.</param>
		/// <returns>Имя папки с конечным слэшем.</returns>
		public static string AddEndSlash ( string name ) {
			return !name.EndsWith ( "\\" ) ? name + "\\" : name;
		}


	}
}
