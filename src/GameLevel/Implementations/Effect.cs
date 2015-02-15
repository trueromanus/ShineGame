using AbstractGameLogic.ObjectVisual;
using System.Runtime.Serialization;

namespace GameLevel.Implementations {
	
	/// <summary>
	/// Визуальный эффект.
	/// </summary>
	[DataContract]
	public class GameEffect : GameObjectVisual , IEffect {

		/// <summary>
		/// Время жизни объектов.
		/// </summary>		
		[DataMember]
		public int TimeToLife {
			get;
			set;
		}

		/// <summary>
		/// Название эффекта.
		/// </summary>
		[DataMember]
		public string EffectName {
			get;
			set;
		}
	}
}
