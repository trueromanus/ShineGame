using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.Audio {

	/// <summary>
	/// Звук.
	/// </summary>
	public interface ISound : IGameObject {

		/// <summary>
		/// Идентификатор звука.
		/// </summary>
		string Sound {
			get;
			set;
		}

		/// <summary>
		/// Громкость.
		/// </summary>
		int Volume {
			get;
			set;
		}

		/// <summary>
		/// Проиграть звук.
		/// </summary>
		void Play ();

	}

}
