using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using AbstractGameLogic.ObjectVisual;

namespace GameLevel.Implementations {

	[DataContract]
	public class AnimatedObject : GameObjectVisual , IAnimatedObject {

		[DataMember]
		public List<string> m_Frames = new List<string> ();

		public IEnumerable<string> Frames {
			get {
				return m_Frames;
			}
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

		public void AddFrames ( IEnumerable<string> frames ) {
			throw new NotImplementedException ();
		}
	}
}
