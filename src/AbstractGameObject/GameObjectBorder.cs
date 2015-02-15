using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AbstractGameLogic {
	
	/// <summary>
	/// Граница игрового объекта.
	/// </summary>
	[Flags]
	[DataContract]
	public enum GameObjectBorder {
		
		/// <summary>
		/// Левая.
		/// </summary>
		[EnumMember]
		Left = 0,

		/// <summary>
		/// Правая.
		/// </summary>
		[EnumMember]
		Right = 2,

		/// <summary>
		/// Верхняя.
		/// </summary>
		[EnumMember]
		Top = 4,

		/// <summary>
		/// Нижняя.
		/// </summary>
		[EnumMember]
		Bottom = 6

	}
}
