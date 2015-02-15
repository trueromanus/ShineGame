using System;
using System.Linq;
using AbstractGameLogic.Attributes;
using AbstractGameLogic.State;

namespace PrisonerLevelBehaviours.Levels {

	/// <summary>
	/// Переключатель уровней.
	/// </summary>
	[GameState ( Name = LevelChanger.NewLevelNameState , Description = "Указание имени уровня который будет загружен." )]
	[ObjectBindBehaviour ( Name = LevelChanger.NameBehaviour , Description = "Поведение для смены уровня. Текущий уровень выгружается, указанный в поведение загружается." )]
	[GameAction ( Name = LevelChanger.ChangeLevelAction , Description = "Сменить уровень. Сменить на уровень который указан в состоянии " + LevelChanger.NewLevelNameState + "." )]
	public class LevelChanger : ObjectBehaviour {

		public const string NameBehaviour = "LevelChanger";

		public const string NewLevelNameState = "NewLevelName";

		public const string ChangeLevelAction = "changeLevel";

		private string m_NewLevelName;

		/// <summary>
		/// Инициализация визуального объекта.
		/// </summary>
		/// <exception cref="ArgumentException"></exception>
		public override void InitializeVisualObject () {
			m_NewLevelName = VisualObject.States
				.Where ( a => a.Name == NewLevelNameState )
				.Select ( a => a.Value.ToString () )
				.FirstOrDefault ();
			if ( string.IsNullOrEmpty ( m_NewLevelName ) ) throw new ArgumentException ( string.Format ( "Нет состояния с именем {0}" , NewLevelNameState ) );
		}

		/// <summary>
		/// Обработчик событий.
		/// </summary>
		/// <param name="event">Возбужденное событие.</param>
		public override void EventHandler ( IEvent @event ) {
			if ( @event.Action != LevelChanger.ChangeLevelAction ) throw new ArgumentException ( "Не корректное действие в поведении LevelChanger." , "@event" );
			//TODO:Здесь нужно нарисовать картинку для ожидания
			//m_FactoryHost.Levels.CreateLevelLoader ();
			VisualObject.DrawLevel.GameWorld.AddPostOperation ( ( a ) => {
				var levelManager = m_FactoryHost.Levels.CreateLevelManager ();
				levelManager.LoadLevel ( m_NewLevelName );
			} );
		}

	}
}
