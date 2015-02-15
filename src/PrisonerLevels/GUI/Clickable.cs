using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.Attributes;
using AbstractGameLogic.State;

namespace PrisonerLevelBehaviours.GUI {
	
	/// <summary>
	/// Поведение для объекта который можно кликнуть мышью.
	/// </summary>
	[ObjectBindBehaviour ( Name = Clickable.NameBehaviour , Description = "Поведение для объектов которые можно кликнуть мышкой." )]
	public class Clickable : ObjectBehaviour {
		
		public const string NameBehaviour = "Clickable";

		/// <summary>
		/// Обработчик событий.
		/// </summary>
		/// <param name="event"></param>
		public override void EventHandler ( IEvent @event ) {
			
		}

	}

}
