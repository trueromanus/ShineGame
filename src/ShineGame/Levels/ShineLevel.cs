using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AbstractGameLogic;
using AbstractGameLogic.GameLevel;
using AbstractGameLogic.State;
using GameLevel.Implementations;
using ShineGame.CommonRoutine;
using ShineGame.Factories;

namespace ShineGame.Levels {

	/// <summary>
	/// Уровень игры.
	/// </summary>
	public class ShineLevel : ILevel {

		private List<IObjectState> m_States = new List<IObjectState> ();

		private string m_LevelName;

		private GameLevelData m_LevelData;

		public string Level {
			get {
				return m_LevelName;
			}
			set {
				m_LevelData = GameContentManager.GetLevelData ( value );
				m_LevelName = value;
			}
		}

		/// <summary>
		/// Имя уровня.
		/// </summary>
		public string Name {
			get;
			set;
		}

		/// <summary>
		/// Состояния уровня.
		/// </summary>
		public IList<IObjectState> States {
			get {
				return m_States;
			}
		}

		/// <summary>
		/// Получить игровой мир из данных уровня.
		/// </summary>
		/// <returns>Игровой мир.</returns>
		public IGameWorld GetGameWorld () {
			if ( m_LevelData == null ) throw new InvalidOperationException ( "Данные уровня не созданы." );

			return GameContentManager.GetGameWorld ( m_LevelData , GameHost.Game.FactoryHost );
		}

	}
}
