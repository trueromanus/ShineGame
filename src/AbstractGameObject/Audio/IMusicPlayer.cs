using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic.Audio {

	/// <summary>
	/// Музыкальный плеер.
	/// </summary>
	public interface IMusicPlayer : IGameObject {

		/// <summary>
		/// Список воспроизведения.
		/// </summary>
		IEnumerable<IMusicTrack> PlayList {
			get;
		}

		/// <summary>
		/// Признак того воспроизведение будет бесконечным.
		/// </summary>
		bool IsLoop {
			get;
			set;
		}

		/// <summary>
		/// Признак того что берутся треки из коллекции по окончании текущей песни.
		/// </summary>
		bool IsCollectionPlaying {
			get;
			set;
		}

		/// <summary>
		/// Громкость музыки.
		/// </summary>
		int Volume {
			get;
			set;
		}

		/// <summary>
		/// Доабвить трек в плейлист.
		/// </summary>
		/// <param name="track">Трек для добавления.</param>
		void AddTrack ( IMusicTrack track );

		/// <summary>
		/// Добавить последовательность треков в плейлист.
		/// </summary>
		/// <param name="tracks">Треки для добавления.</param>
		void AddTracks ( IEnumerable<IMusicTrack> tracks );

		/// <summary>
		/// Воспроизведение.
		/// </summary>
		void Play ( string name );

		/// <summary>
		/// Остановить воспроиведение и сбросить позиция текущего трека в начало.
		/// </summary>
		void Stop ();

		/// <summary>
		/// Поставить текущий трек на паузу.
		/// </summary>
		void Pause ();

		/// <summary>
		/// Продолжить воспроизведение.
		/// </summary>
		void Resume ();

		/// <summary>
		/// Начать воспроизведение следующего трека.
		/// </summary>
		void NextTrack ();

		/// <summary>
		/// Начать воспроизведение предыдущего трека.
		/// </summary>
		void PreviousTrack ();

	}

}
