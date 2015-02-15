using System;
using System.Collections.Generic;
using AbstractGameLogic;
using System.Runtime.Serialization;
using AbstractGameLogic.ObjectVisual;
using AbstractGameLogic.Physics;
using AbstractGameLogic.State;

namespace GameLevel.Implementations {

	[DataContract]
	public class DrawLevel : IDrawLevel {

		[DataMember]
		public List<IGameObjectVisual> m_Objects = new List<IGameObjectVisual> ();

		public IEnumerable<IGameObjectVisual> Objects {
			get {
				return m_Objects;
			}
		}

		[DataMember]
		public string Name {
			get;
			set;
		}

		[DataMember]
		public bool IsCheckCollision {
			get;
			set;
		}

		public void Add ( IGameObjectVisual gameObject ) {
			m_Objects.Add ( gameObject );
		}

		public IGameObjectVisual GetObject ( string name ) {
			throw new NotImplementedException ();
		}

		public void Remove ( string name ) {
			throw new NotImplementedException ();
		}

		public void Update ( IGameState inputGamestate ) {
			throw new NotImplementedException ();
		}

		public void Draw ( int worldX , int worldY , int worldXEnd , int worldYEnd ) {
			throw new NotImplementedException ();
		}


		public void FreeResources () {
			throw new NotImplementedException ();
		}


		public IPhysicsWorld PhysicsWorld {
			get {
				return null;
			}
		}


		public IRectangle Viewport {
			get {
				return null;
			}
			set {
				
			}
		}


		public IEnumerable<IEventRaises> Events {
			get {
				return null;
			}
		}


		public void AddEvent ( string objectName , string eventRaises ) {
			throw new NotImplementedException ();
		}


		public void ClearEvents () {
			throw new NotImplementedException ();
		}


		public IGameWorld GameWorld {
			get {
				return null;
			}
			set {
				throw new NotImplementedException ();
			}
		}
	}
}
