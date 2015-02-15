using System;
using System.Linq;
using AbstractGameLogic.Attributes;
using AbstractGameLogic.Audio;
using AbstractGameLogic.State;

namespace PrisonerLevelBehaviours.Audio {

	/// <summary>
	/// Поведение для музыкального плеера.
	/// </summary>
	[GameAction ( Name = MusicPlayer.PlayAction , Description = "Начать воспроизведение. Необходимо указать имя трека без пробела после имени действия." )]
	[GameAction ( Name = MusicPlayer.StopAction , Description = "Остановить воспроизведение." )]
	[GameAction ( Name = MusicPlayer.PauseAction , Description = "Приостановить воспроизведение." )]
	[GameAction ( Name = MusicPlayer.ResumeAction , Description = "Продолжить воспроизведение." )]
	[GameAction ( Name = MusicPlayer.NextAction , Description = "Включить следующий трек." )]
	[GameAction ( Name = MusicPlayer.PreviousAction , Description = "Включить предыдущий трек." )]
	[GameState ( Name = MusicPlayer.TrackState , Description = "Указание трека. После имени указать идентификатор трека." )]
	[ObjectBindBehaviour ( Name = MusicPlayer.NameBehaviour , Description = "Музыкальный плеер. Должен находиться на карте в единственном экземпляре." )]
	public class MusicPlayer : ObjectBehaviour {

		public const string NameBehaviour = "MusicPlayer";

		public const string PlayAction = "play";

		public const string StopAction = "stop";

		public const string PauseAction = "pause";

		public const string NextAction = "next";

		public const string PreviousAction = "previous";

		public const string ResumeAction = "resume";

		public const string TrackState = "Track";

		private IMusicPlayer m_MusicPlayer;

		/// <summary>
		/// Инициализация визуального объекта.
		/// </summary>
		public override void InitializeVisualObject () {
			m_MusicPlayer = m_FactoryHost.GameObjects.CreateMusicPlayer ( "LevelPlayer" );

			m_MusicPlayer.IsCollectionPlaying = false;
			m_MusicPlayer.IsLoop = true;

			m_MusicPlayer.AddTracks (
				VisualObject.States
					.Where ( a => a.Name.StartsWith ( TrackState ) )
					.Select ( a => m_FactoryHost.GameObjects.CreateMusicTrack ( a.Name.Replace ( TrackState , "" ) , a.Value.ToString () ) )
					.ToList ()
			);
		}

		/// <summary>
		/// Обработчик событий.
		/// </summary>
		/// <param name="event">Возбужденное событие.</param>
		/// <exception cref="NotSupportedException"></exception>
		public override void EventHandler ( IEvent @event ) {
			if ( @event.Action.StartsWith ( PlayAction ) ) {
				m_MusicPlayer.Play ( @event.Action.Replace ( PlayAction , "" ) );
				return;
			}
			switch ( @event.Action ) {
				case StopAction:
					m_MusicPlayer.Stop ();
					break;
				case PauseAction:
					m_MusicPlayer.Pause ();
					break;
				case ResumeAction:
					m_MusicPlayer.Resume ();
					break;
				case NextAction:
					m_MusicPlayer.NextTrack ();
					break;
				case PreviousAction:
					m_MusicPlayer.PreviousTrack ();
					break;
				default:
					throw new NotSupportedException ( string.Format ( "Имя действия {0} некорректно" , @event.Action ) );
			}
		}

	}

}
