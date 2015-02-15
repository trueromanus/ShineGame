using System.Runtime.Serialization;
using AbstractGameLogic;
using AbstractGameLogic.ObjectVisual;

namespace GameLevel.Implementations {
	
	[DataContract]
	public class ParallaxBackground : GameObjectVisual , IParallaxBackground {

		[DataMember]
		public bool IsScrollable {
			get;
			set;
		}

		[DataMember]
		public ParallaxDirection Direction {
			get;
			set;
		}

		[DataMember]
		public int Speed {
			get;
			set;
		}

		[DataMember]
		public int Position {
			get;
			set;
		}

		[DataMember]
		public string Image {
			get;
			set;
		}
	}
}
