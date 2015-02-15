using System;
using System.Collections.Generic;
using System.Linq;
using AbstractGameLogic.Audio;
using AbstractGameLogic.State;
using Microsoft.Xna.Framework.Media;

namespace ShineGame.Audio {

	/// <summary>
	/// Музыкальный плеер.
	/// </summary>
	internal class MusicPlayer : IMusicPlayer {

		private List<IMusicTrack> m_PlayList = new List<IMusicTrack> ();

		private List<IObjectState> m_ObjectStateCollection = new List<IObjectState> ();

		private IMusicTrack m_Current;

		/// <summary>
		/// Список воспроизведения.
		/// </summary>
		public IEnumerable<IMusicTrack> PlayList {
			get {
				return m_PlayList;
			}
		}

		/// <summary>
		/// Признак того воспроизведение будет бесконечным.
		/// </summary>
		public bool IsLoop {
			get {
				return MediaPlayer.IsRepeating;
			}
			set {
				MediaPlayer.IsRepeating = value;
			}
		}

		/// <summary>
		/// Признак того что берутся треки из коллекции по окончании текущей песни.
		/// </summary>
		public bool IsCollectionPlaying {
			get;
			set;
		}

		public int Volume {
			get {
				var digits = MediaPlayer.Volume.ToString ( "F2" ).Split ( ',' )
					.Select ( a => Convert.ToInt32 ( a ) )
					.ToList ();
				if ( digits.First () == 1 ) return 100;
				if ( digits.Last () == 0 ) return 0;

				return digits.Last ();
			}
			set {
				if ( value == 100 ) {
					MediaPlayer.Volume = 1.0f;
					return;
				}
				MediaPlayer.Volume = float.Parse ( "0," + value.ToString () );
			}
		}

		/// <summary>
		/// Конструктор.
		/// </summary>
		public MusicPlayer () {
			MediaPlayer.MediaStateChanged +=
				delegate ( object sender , EventArgs e ) {
					if ( PlayList.Count () == 0 ) return;

					if ( MediaPlayer.State == MediaState.Stopped ) {
						if ( IsCollectionPlaying ) {
							NextTrack ();
						}
						else {
							if ( IsLoop ) Play ( m_Current.Track );
						}
					}
				};
		}

		/// <summary>
		/// Доабвить трек в плейлист.
		/// </summary>
		/// <param name="track">Трек для добавления.</param>
		/// <exception cref="ArgumentException"></exception>
		public void AddTrack ( IMusicTrack track ) {
			if ( m_PlayList.FirstOrDefault ( a => a.Name == track.Name ) != null ) throw new ArgumentException ( string.Format ( "Трек с названием {0} существует в списке воспроивзедения." , track.Name ) , "track" );
			m_PlayList.Add ( track );
		}

		/// <summary>
		/// Добавить последовательность треков в плейлист.
		/// </summary>
		/// <param name="tracks">Треки для добавления.</param>
		/// <exception cref="ArgumentException"></exception>
		public void AddTracks ( IEnumerable<IMusicTrack> tracks ) {
			var dubles = m_PlayList.Intersect ( tracks ).ToList ();
			if ( dubles.Count > 0 ) throw new ArgumentException ( string.Format ( "Треки с названиями {0}" , dubles.Select ( a => a.Name ).Aggregate ( ( a , b ) => a + b ) ) );

			m_PlayList.AddRange ( tracks );
		}

		/// <summary>
		/// Воспроизведение.
		/// </summary>
		/// <exception cref="ArgumentException"></exception>
		public void Play ( string name ) {
			var song = m_PlayList.Where ( a => a is IXNASong ).FirstOrDefault ( a => a.Name == name );
			if ( song == null ) throw new ArgumentException ( string.Format ( "Трека с именем {0} не в списке воспроизведения." , name ) , "name" );

			m_Current = song;
			MediaPlayer.Play ( ( song as IXNASong ).Song );
		}

		/// <summary>
		/// Остановить воспроиведение и сбросить позиция текущего трека в начало.
		/// </summary>
		public void Stop () {
			MediaPlayer.Stop ();
		}

		/// <summary>
		/// Поставить текущий трек на паузу.
		/// </summary>
		public void Pause () {
			MediaPlayer.Pause ();
		}

		/// <summary>
		/// Имя плеера.
		/// </summary>
		public string Name {
			get;
			set;
		}

		/// <summary>
		/// Набор состояний объекта.
		/// </summary>
		public IList<IObjectState> States {
			get {
				return m_ObjectStateCollection;
			}
		}

		/// <summary>
		/// Продолжить воспроивзедение.
		/// </summary>
		public void Resume () {
			MediaPlayer.Resume ();
		}

		/// <summary>
		/// Начать воспроизведение следующего трека.
		/// </summary>
		public void NextTrack () {
			if ( m_Current == null ) return;

			var index = m_PlayList.FindIndex ( a => a.Name == m_Current.Name );
			var nextTrack = m_PlayList.ElementAtOrDefault ( index++ );

			if ( nextTrack != null ) MediaPlayer.Play ( ( nextTrack as IXNASong ).Song );
		}

		/// <summary>
		/// Начать воспроизведение предыдущего трека.
		/// </summary>
		public void PreviousTrack () {
			if ( m_Current == null ) return;

			var index = m_PlayList.FindIndex ( a => a.Name == m_Current.Name );
			var previousTrack = m_PlayList.ElementAtOrDefault ( index-- );

			if ( previousTrack != null ) MediaPlayer.Play ( ( previousTrack as IXNASong ).Song );

		}
	}

}
