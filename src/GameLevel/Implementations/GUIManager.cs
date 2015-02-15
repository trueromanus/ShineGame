using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using AbstractGameLogic;
using AbstractGameLogic.GUI;

namespace GameLevel.Implementations {

	/// <summary>
	/// Менеджер графического интерфейса.
	/// </summary>
	[DataContract]
	public class GUIManager : IGUIManager {

		/// <summary>
		/// Имя шкуры.
		/// </summary>
		[DataMember]
		public string Skin {
			get;
			set;
		}

		/// <summary>
		/// Имя.
		/// </summary>
		[DataMember]
		public string Name {
			get;
			set;
		}

		public void Update ( IGameState gameState ) {
			throw new NotImplementedException ();
		}

		public void Draw () {
			throw new NotImplementedException ();
		}

		public void ShowWindow ( IGUIWindow window ) {
			throw new NotImplementedException ();
		}

		public void CloseWindow ( IGUIWindow window ) {
			throw new NotImplementedException ();
		}

		public void ActivateWindow ( IGUIWindow window ) {
			throw new NotImplementedException ();
		}

		public IList<AbstractGameLogic.State.IObjectState> States {
			get {
				throw new NotImplementedException ();
			}
		}

		public IEnumerable<IGUIWindow> Windows {
			get {
				throw new NotImplementedException ();
			}
		}

		public bool IsMouseVisible {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}
	}

}
