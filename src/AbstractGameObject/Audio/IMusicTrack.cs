using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.Audio {

	/// <summary>
	/// Музыкальный трек.
	/// </summary>
	public interface IMusicTrack : IGameObject {

		/// <summary>
		/// Длина трека.
		/// </summary>
		long Length {
			get;
		}

		/// <summary>
		/// Имя трека.
		/// </summary>
		string Track {
			get;
			set;
		}

	}

}
