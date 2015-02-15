using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GameLevelLibrary.Exceptions {

	/// <summary>
	/// Исключение при чтении данных уровня.
	/// </summary>
	[Serializable]
	public class ReadLevelException : ApplicationException {

		/// <summary>
		/// Имя файла уровня.
		/// </summary>
		public string FileName {
			get;
			private set;
		}

		/// <summary>
		/// Констурктор по уомлчанию.
		/// </summary>
		public ReadLevelException ()
			: base () {
		}

		/// <summary>
		/// Конструктор с имененм файла.
		/// </summary>
		/// <param name="fileName">Полный путь к файлу уровня.</param>
		public ReadLevelException ( string fileName )
			: base ( string.Format ( "Error loading level {0}" , fileName ) ) {
			FileName = fileName;
		}

		/// <summary>
		/// Конструктор с именем файла, сообщением и вложенным исключением.
		/// </summary>
		/// <param name="fileName">Имя файла уровня.</param>
		/// <param name="message">Сообщение.</param>
		/// <param name="innerException">Вложенное сообщение.</param>
		public ReadLevelException ( string fileName , string message , Exception innerException )
			: base ( message , innerException ) {
			FileName = fileName;
		}

		/// <summary>
		/// Сформировать данные об объекте.
		/// </summary>
		public override void GetObjectData ( SerializationInfo info , StreamingContext context ) {
			base.GetObjectData ( info , context );
		}

	}

}
