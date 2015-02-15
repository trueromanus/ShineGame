using System;
using System.Collections.Generic;
using AbstractGameLogic;
using System.Runtime.Serialization;
using AbstractGameLogic.ObjectBehavior;
using AbstractGameLogic.ObjectVisual;
using AbstractGameLogic.State;

namespace GameLevel.Implementations {

	/// <summary>
	/// Игровой визуальный объект.
	/// </summary>
	[DataContract]
	public class GameObjectVisual : IGameObjectVisual {

		[DataMember]
		public List<IObjectState> m_States = new List<IObjectState> ();

		[DataMember]
		public int WorldX {
			get;
			set;
		}

		[DataMember]
		public int WorldY {
			get;
			set;
		}

		public int WorldXEnd {
			get {
				return 0;
			}
		}

		public int WorldYEnd {
			get {
				return 0;
			}
		}

		[DataMember]
		public int Width {
			get;
			set;
		}

		[DataMember]
		public int Height {
			get;
			set;
		}

		[DataMember]
		public int ZIndex {
			get;
			set;
		}

		public void Update ( IGameState inputGamestate ) {
			throw new NotImplementedException ();
		}

		public void Draw () {
			throw new NotImplementedException ();
		}

		public void OnCollision ( IEnumerable<IGameObjectVisual> objects ) {
			throw new NotImplementedException ();
		}

		[DataMember]
		public string Name {
			get;
			set;
		}

		[DataMember]
		public ObjectBehaviours BehaviourCollectionMember {
			get;
			set;
		}

		/// <summary>
		/// Последовательность поведений объекта.
		/// </summary>
		public IObjectBehaviors BehaviourCollection {
			get {
				return BehaviourCollectionMember;
			}
		}

		/// <summary>
		/// Состояния.
		/// </summary>
		public IList<IObjectState> States {
			get {
				return m_States;
			}
		}

		/// <summary>
		/// Графический слой.
		/// </summary>
		public IDrawLevel DrawLevel {
			get;
			set;
		}


		public float Rotate {
			get;
			set;
		}


		public IVector2 GetVector () {
			throw new NotImplementedException ();
		}

		public void SetVector ( IVector2 vector ) {
			throw new NotImplementedException ();
		}

		public void SetVector ( float x , float y ) {
			throw new NotImplementedException ();
		}
	}
}
