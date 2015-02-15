using System.Runtime.Serialization;
using AbstractGameLogic.ObjectVisual;

namespace GameLevel.Implementations {

	[DataContract]
	public class StaticObject : GameObjectVisual , IStaticObject {

		[DataMember]
		public string Image {
			get;
			set;
		}

		[DataMember]
		public int? TilePosition {
			get;
			set;
		}

	}
}
