using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.Audio;
using AbstractGameLogic.State;
using Microsoft.Xna.Framework.Media;
using ShineGame;
using ShineGame.CommonRoutine;

namespace ShineGame.Audio {

	/// <summary>
	/// Музыкальный трек.
	/// </summary>
	internal class MusicTrack : IMusicTrack, IXNASong {

		private Song m_Song;

		private List<IObjectState> m_StateCollection = new List<IObjectState> ();

		/// <summary>
		/// Длина трека.
		/// </summary>
		public long Length {
			get {
				if ( m_Song == null ) return 0;

				return Convert.ToInt64 ( m_Song.Duration.TotalSeconds );
			}
		}

		/// <summary>
		/// Имя трека.
		/// </summary>
		public string Track {
			get {
				return m_Song.Name;
			}
			set {
				m_Song = GameContentManager.Manager.Load<Song> ( value );
			}
		}

		/// <summary>
		/// Имя объекта.
		/// </summary>
		public string Name {
			get;
			set;
		}

		/// <summary>
		/// Коллекция состояний.
		/// </summary>
		public IList<IObjectState> States {
			get {
				return m_StateCollection;
			}
		}

		/// <summary>
		/// Песня XNA.
		/// </summary>
		public Song Song {
			get {
				return m_Song;
			}
			set {
				m_Song = value;
			}
		}

	}
}
