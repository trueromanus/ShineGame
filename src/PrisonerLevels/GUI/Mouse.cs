using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic;
using AbstractGameLogic.Attributes;
using AbstractGameLogic.State;

namespace PrisonerLevelBehaviours.GUI {

	/// <summary>
	/// Поведение для работы с мышью.
	/// </summary>
	[ObjectBindBehaviour ( Name = Mouse.NameBehaviour , Description = "Поведение для управлением мышью." )]
	[GameAction ( Name = Mouse.VisibleMouseAction , Description = "Сделать мышку видимой. Курсор берется из текущей шкуры." )]
	[GameAction ( Name = Mouse.InVisibleMouseAction , Description = "Сделать мышку невидимой." )]
	[GameEvent ( Name = Mouse.HitEvent , Description = "Событие клика на видимом активном элементе." )]
	public class Mouse : ObjectBehaviour {

		public const string NameBehaviour = "Mouse";

		public const string VisibleMouseAction = "visible";

		public const string InVisibleMouseAction = "invisible";

		public const string HitEvent = "hit";

		/// <summary>
		/// Обработчик событий.
		/// </summary>
		/// <param name="event">Обработчик событий.</param>
		public override void EventHandler ( IEvent @event ) {
			switch ( @event.Action ) {
				case VisibleMouseAction:
					VisualObject.DrawLevel.GameWorld.GUIManager.IsMouseVisible = true;
					break;
				case InVisibleMouseAction:
					VisualObject.DrawLevel.GameWorld.GUIManager.IsMouseVisible = false;
					break;
			}
		}

		/// <summary>
		/// Обновление состояния поведения.
		/// </summary>
		/// <param name="gameState">Игровое состояние.</param>
		public override void Update ( IGameState gameState ) {
			if ( gameState.InputState.IsMouseUp ( MouseButtonKey.Left ) ) {
				
			}
		}

	}
}
