using System;
using System.Threading;
using System.Threading.Tasks;
using AbstractGameLogic;
using AbstractGameLogic.Factories;
using AbstractGameLogic.GameLevel;
using ShineGame.CommonRoutine;
using ShineGame.Game;

namespace ShineGame.Levels {

	/// <summary>
	/// Менеджер уровней.
	/// </summary>
	public sealed class LevelManager : ILevelManager {

		private IFactoryHost m_FactoryHost = GameHost.Game.FactoryHost;

		private MainGame m_Game = GameHost.Game;

		/// <summary>
		/// Загрузить уровень.
		/// </summary>
		/// <param name="name">Имя уровня.</param>
		/// <param name="levelLoader">Загрузчик уровня.</param>
		public void LoadLevel ( string name ) {
			m_Game.DeleteWorld ( m_Game.ActiveGameWorld.Name );

			var level = new ShineLevel ();
			level.Level = name;
			var newWorld = level.GetGameWorld ();

			m_Game.AddWorld ( newWorld );
		}

	}
}
