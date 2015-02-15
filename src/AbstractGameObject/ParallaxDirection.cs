using System.Runtime.Serialization;

namespace AbstractGameLogic {

	/// <summary>
	/// Направление паралакса.
	/// </summary>
	[DataContract]
	public enum ParallaxDirection {

		/// <summary>
		/// Слева направо.
		/// </summary>
		[EnumMember]
		LeftToRight ,
		
		/// <summary>
		/// Справо налево.
		/// </summary>
		[EnumMember]
		RightToLeft ,
		
		/// <summary>
		/// Сверху вниз.
		/// </summary>
		[EnumMember]
		UpToDown ,
		
		/// <summary>
		/// Снизу вверх.
		/// </summary>
		[EnumMember]
		DownToUp

	}

}
