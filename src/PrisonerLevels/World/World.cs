using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic;
using AbstractGameLogic.Attributes;

namespace PrisonerLevelBehaviours.World {

	/// <summary>
	/// Поведение для мира.
	/// </summary>
	/// <remarks>
	/// Поведение нужно для обработки глобальных событий
	/// связанных с целым уровнем.
	/// </remarks>
	[GameEvent ( Name = World.WorldLoadedEvent )]
	[ObjectBindBehaviour ( Name = World.NameBehaviour , Description = "Поведение для обработки событий на уровне мира вне зависимости от объекта к которому привязано." )]
	public class World : ObjectBehaviour {

		public const string NameBehaviour = "World";

		public const string WorldLoadedEvent = "loaded";

		private bool m_Loaded = false;

		/// <summary>
		/// Обновления состояния поведения.
		/// </summary>
		/// <param name="gameState">Игровое состояние.</param>
		public override void Update ( IGameState gameState ) {
			if ( !m_Loaded ) {
				ThrowedEvent = WorldLoadedEvent;
				m_Loaded = true;
			}
		}

	}

}
