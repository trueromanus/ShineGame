using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using AbstractGameLogic.ObjectVisual;

namespace GameLevel.Implementations {
	
	[DataContract]
	public class TileAnimatedObject : GameObjectVisual , ITileAnimatedObject {

		[DataMember]
		public int TileWidth {
			get;
			set;
		}

		[DataMember]
		public int TileHeight {
			get;
			set;
		}

		[DataMember]
		public Tuple<int , int> AnimationRange {
			get;
			set;
		}

		[DataMember]
		public int AnimateSpeed {
			get;
			set;
		}

		[DataMember]
		public string ImageName {
			get;
			set;
		}


		public bool IsVerticalMirror {
			get;
			set;
		}

		public int CurrentFrame {
			get;
			set;
		}

		[DataMember]
		public bool IsLoop {
			get;
			set;
		}
	}

}
