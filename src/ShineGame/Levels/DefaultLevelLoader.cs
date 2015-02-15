using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic;
using AbstractGameLogic.GameLevel;
using ShineGame.CommonRoutine;
using ShineGame.DrawLevels;
using ShineGame.GameWorlds;
using ShineGame.VisualObjects;

namespace ShineGame.Levels {
	public class DefaultLevelLoader : ILevelLoader {

		/// <summary>
		/// Получить игровой мир который будет крутиться
		/// в время загрузки уровня.
		/// </summary>
		public IGameWorld GetLoaderWorld () {
			var gameHost = GameHost.Game.GraphicsManager;
			var world = new GameWorld {
				Name = "LoadWorld" ,
				ViewportHeight = gameHost.PreferredBackBufferHeight ,
				ViewportWidth = gameHost.PreferredBackBufferWidth
			};
			var drawLevel = new ShineDrawLevel {
				Name = "LoadBackground" ,
			};
			drawLevel.Add ( new ShineBackground {
				Name = "Background" ,
				Image = @"Backgrounds\test"
			} );
			world.Add ( drawLevel );

			return world;
		}
	}
}
