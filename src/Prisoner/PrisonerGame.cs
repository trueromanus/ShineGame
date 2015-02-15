using System;
using System.Collections.Generic;
using AbstractGameLogic;
using System.Linq;
using ShineGame.Game;
using ShineGame.Levels;
using System.Reflection;
using PrisonerLevelBehaviours;
using AbstractGameLogic.GUI;

namespace ShineGameEditor {

	/// <summary>
	/// Прототип игры основанной на окружении Shine.
	/// </summary>
	public class PrisonerGame : MainGame {

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="isWindowed">Признак того что нужно запустить игру в оконном режиме.</param>
		/// <param name="isDeveloper">Признак разработческого режима.</param>
		public PrisonerGame ( bool isWindowed , bool isDeveloper )
			: base ( isWindowed , isDeveloper ) {

			AddBehavoiurAssemblys ( new List<Assembly> { Assembly.GetAssembly ( typeof ( ObjectBehaviour ) ) } );
		}

		/// <summary>
		/// Загружаем миры.
		/// </summary>
		/// <returns>Последовательность миров.</returns>
		protected override IEnumerable<IGameWorld> LoadWorlds () {
			var level = new ShineLevel {
				Name = "Лялька" ,
				Level = @"Levels\level1"
			};

			var world = level.GetGameWorld ();

			return new List<IGameWorld> { world };
		}

		/// <summary>
		/// Загрузить графические слои.
		/// </summary>
		/// <returns>Последовательность графических слоев.</returns>
		public override IEnumerable<IDrawLevel> LoadDrawLevels ( string worldName ) {
			SetActiveWorld ( worldName );

			return Enumerable.Empty<IDrawLevel> ();
		}

	}

}
