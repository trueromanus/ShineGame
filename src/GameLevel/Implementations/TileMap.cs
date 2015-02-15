using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using AbstractGameLogic.ObjectVisual;

namespace GameLevel.Implementations {
	
	[DataContract]
	public class TileMap : GameObjectVisual , ITileMap {
	
		[DataMember]
		public int ColumnCount {
			get;
			set;
		}

		[DataMember]
		public int RowCount {
			get;
			set;
		}

		[DataMember]
		public int CellWidth {
			get;
			set;
		}

		[DataMember]
		public int CellHeight {
			get;
			set;
		}

		[DataMember]
		public string DefaultImage {
			get;
			set;
		}

		[DataMember]
		public List<string> m_Tiles = new List<string> ();
	
		public IEnumerable<string> Tiles {
			get {
				return m_Tiles;
			}
		}

		public void AddTile ( string imageName , int column , int row ) {
			throw new NotImplementedException ();
		}

		public string GetTile ( int column , int row ) {
			throw new NotImplementedException ();
		}

		public void AddTileToAll ( string imageName ) {
			throw new NotImplementedException ();
		}
	}
}
