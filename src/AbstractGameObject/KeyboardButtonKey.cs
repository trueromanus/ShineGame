using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AbstractGameLogic {
	
	/// <summary>
	/// Клавиша клавиатуры.
	/// </summary>
	[DataContract]
	public enum KeyboardButtonKey {
		
		/// <summary>
		/// Влево.
		/// </summary>
		[EnumMember]
		Left = 5,
		
		/// <summary>
		/// Вправо.
		/// </summary>
		[EnumMember]
		Right = 6,
		
		/// <summary>
		/// Вверх.
		/// </summary>
		[EnumMember]
		Up = 7,
		
		/// <summary>
		/// Вниз.
		/// </summary>
		[EnumMember]
		Down = 8,
		
		/// <summary>
		/// Ввод.
		/// </summary>
		[EnumMember]
		Enter = 20,
		
		/// <summary>
		/// Backspace.
		/// </summary>
		[EnumMember]
		Backspace = 21,
		
		/// <summary>
		/// Пробел.
		/// </summary>
		[EnumMember]
		Space = 22,

		/// <summary>
		/// Escape.
		/// </summary>
		[EnumMember]
		Esc = 23
	}
}
