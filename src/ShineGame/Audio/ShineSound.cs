using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.Audio;
using AbstractGameLogic.State;
using Microsoft.Xna.Framework.Audio;
using ShineGame.CommonRoutine;
using GameMathHelpers;

namespace ShineGame.Audio {

	/// <summary>
	/// Звук.
	/// </summary>
	internal class ShineSound : ISound {

		private SoundEffect m_SoundEffect;

		private List<IObjectState> m_StateCollection = new List<IObjectState> ();

		private int m_Volume;

		/// <summary>
		/// Идентификатор звука.
		/// </summary>
		public string Sound {
			get {
				if ( m_SoundEffect != null ) return m_SoundEffect.Name;
				return string.Empty;
			}
			set {
				m_SoundEffect = GameContentManager.Manager.Load<SoundEffect> ( value );
			}
		}

		/// <summary>
		/// Громкость.
		/// </summary>
		public int Volume {
			get {
				return m_Volume;
			}
			set {
				m_Volume = value.LimitToRange ( 0 , 100 );
			}
		}

		/// <summary>
		/// Проиграть звук.
		/// </summary>
		public void Play () {
			float volume = m_Volume == 100 ? 1.0f : float.Parse ( "0," + m_Volume );
			m_SoundEffect.Play ( volume , 0.0f , 0.0f );
		}

		/// <summary>
		/// Имя звука.
		/// </summary>
		public string Name {
			get;
			set;
		}

		/// <summary>
		/// Последовательность состояний.
		/// </summary>
		public IList<IObjectState> States {
			get {
				return m_StateCollection;
			}
		}
	}
}
