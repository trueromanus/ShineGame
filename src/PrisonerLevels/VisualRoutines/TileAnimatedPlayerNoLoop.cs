using System;
using System.Collections.Generic;
using System.Linq;
using AbstractGameLogic;
using AbstractGameLogic.Attributes;
using AbstractGameLogic.ObjectVisual;
using AbstractGameLogic.State;

namespace PrisonerLevelBehaviours.VisualRoutines {

	/// <summary>
	/// Анимационный плеер проигрывающий анимацию не циклично.
	/// </summary>
	[GameAction ( Name = TileAnimatedPlayerNoLoop.PlayAction , Description = "Проигрывать анимацию. К имени действия надо добавить значения в формате X-Y где X - это начало диапазона Y - конец диапазона." )]
	[ObjectBindBehaviour (
			Name = TileAnimatedPlayerNoLoop.NameBahaviour ,
			Description = "Плеер тайловой не цикличной анимации(т.е. проигравшийся ряд анимаций будет закончен и анимация не будет продолжена). Все тайлы должны находиться на одном изображении."
		)
	]
	public class TileAnimatedPlayerNoLoop : ObjectBehaviour {

		public const string PlayAction = "Play";

		public const string NameBahaviour = "TileAnimatedPlayerNoLoop";

		private ITileAnimatedObject m_TileAnimated;

		/// <summary>
		/// Инициализация визуального объекта.
		/// </summary>
		public override void InitializeVisualObject () {
			m_TileAnimated = ( VisualObject as ITileAnimatedObject );
			if ( m_TileAnimated == null ) throw new ArgumentException ( "Объект для привязки к поведению TileAnimatedPlayerNoLoop должен быть с типом тайловой анимации." , "@object" );

			m_TileAnimated.IsLoop = false;
		}

		/// <summary>
		/// Обработчик событий.
		/// </summary>
		/// <param name="event">Возбужденное событие.</param>
		/// <exception cref="ArgumentException"></exception>
		public override void EventHandler ( IEvent @event ) {
			if ( !@event.Action.StartsWith ( PlayAction ) ) {
				throw new ArgumentException ( string.Format ( "Действие {0} не поддерживается." , @event.Action ) , "@event" );
			}

			List<int> numbers = null;
			try {
				numbers = @event.Action
						.Replace ( PlayAction , "" )
						.Split ( '-' )
						.Select ( a => Convert.ToInt32 ( a ) )
						.ToList ();
			}
			catch ( InvalidCastException ) {
				throw new ArgumentException ( "Не корректный диапазон анимации." , "@event" );
			}
			if ( numbers.Count != 2 ) throw new ArgumentException ( "Для анимации указывается диапазон в формате X-Y где X это номер начального кадра а Y это номер конечного кадра." , "@event" );

			m_TileAnimated.AnimationRange = new Tuple<int , int> ( numbers.First () , numbers.Last () );
		}

	}

}
