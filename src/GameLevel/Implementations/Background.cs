using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using AbstractGameLogic.ObjectVisual;

namespace GameLevel.Implementations {
	
	[DataContract]
	public class Background : GameObjectVisual, IBackground {

		[DataMember]
		public string Image {
			get;
			set;
		}

	}
}
