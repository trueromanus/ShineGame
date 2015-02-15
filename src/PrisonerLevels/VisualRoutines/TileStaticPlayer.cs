using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic;
using AbstractGameLogic.Attributes;
using AbstractGameLogic.ObjectVisual;
using AbstractGameLogic.State;

namespace PrisonerLevelBehaviours.VisualRoutines {

	/// <summary>
	/// Плеер статической смены изображений в виде тайлов.
	/// </summary>
	[GameAction ( Name = TileStaticPlayer.ChangeTileAction , Description = "Сменить тайл для вывода. Номер тайла указывается после названия действия без пробелов." )]
	[ObjectBindBehaviour (
			Name = TileStaticPlayer.NameBehaviour ,
			Description = "Плеер статических тайлов. Все тайлы должны находиться на одном изображении."
		)
	]
	public class TileStaticPlayer : ObjectBehaviour {

		public const string NameBehaviour = "TileStaticPlayer";

		public const string ChangeTileAction = "ChangeTile";

		private IStaticObject m_StaticObject;

		/// <summary>
		/// Инициализация визуального объекта.
		/// </summary>
		public override void InitializeVisualObject () {
			m_StaticObject = ( VisualObject as IStaticObject );
			if ( m_StaticObject == null ) throw new NotSupportedException ( "Поведение TileStaticPlayer поддерживает только связь со статиеским объектом." );
		}

		/// <summary>
		/// Обработать событие объекта.
		/// </summary>
		/// <param name="event">Событие.</param>
		/// <exception cref="ArgumentException"></exception>
		public override void EventHandler ( IEvent @event ) {
			if ( !@event.Action.StartsWith ( TileStaticPlayer.ChangeTileAction ) ) {
				throw new ArgumentException ( string.Format ( "Действие {0} не поддерживается." , @event.Action ) , "@event" );
			}

			try {
				var number = Convert.ToInt32 ( @event.Action.Replace ( ChangeTileAction , "" ) );
				m_StaticObject.TilePosition = number;
			}
			catch ( FormatException ) {
				throw new ArgumentException ( "Номер тайла не корректного формата." , "@event" );
			}
			catch ( Exception ) {
				throw new InvalidOperationException ( "Не удалось выполнить смену тайла, тайл с таким номером не существует." );
			}
		}

	}

}
