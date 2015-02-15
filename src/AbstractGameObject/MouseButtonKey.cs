using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AbstractGameLogic {
	
	/// <summary>
	/// Перечесление кнопок мыши.
	/// </summary>
	[DataContract]
	public enum MouseButtonKey : int {
		
		/// <summary>
		/// Правая кнопка.
		/// </summary>
		[EnumMember]
		Right = 0 ,
		
		/// <summary>
		/// Левая кнопка.
		/// </summary>
		[EnumMember]
		Left  = 1,
		
		/// <summary>
		/// Средняя кнопка.
		/// </summary>
		[EnumMember]
		Middle = 2

	}
}
