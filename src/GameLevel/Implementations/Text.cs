using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using AbstractGameLogic.ObjectVisual;
using AbstractGameLogic;

namespace GameLevel.Implementations {

	[DataContract]
	public class Text : GameObjectVisual , IText {

		[DataMember]
		public string Message {
			get;
			set;
		}

		[DataMember]
		public string Font {
			get;
			set;
		}

		[DataMember]
		public int Size {
			get;
			set;
		}

		[DataMember]
		public IColor Color {
			get;
			set;
		}
	}
}
