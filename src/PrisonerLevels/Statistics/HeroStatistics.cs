using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AbstractGameLogic.Attributes;
using AbstractGameLogic.State;
using PrisonerLevelBehaviours.Attributes;

namespace PrisonerLevelBehaviours.Statistics {

	/// <summary>
	/// Операция статистики.
	/// </summary>
	public enum StatisticsOperation {

		/// <summary>
		/// Сложение.
		/// </summary>
		[AdditionalInformation ( Information = "+" )]
		Plus = 1 ,

		/// <summary>
		/// Вычитание.
		/// </summary>
		[AdditionalInformation ( Information = "-" )]
		Minus = 2 ,

		/// <summary>
		/// Присвоение.
		/// </summary>
		[AdditionalInformation ( Information = "=" )]
		Assing = 3

	};

	/// <summary>
	/// Статистика героя.
	/// </summary>
	[ObjectBindBehaviour ( Name = HeroStatistics.NameBehaviour , Description = "Статистика героя (жизни, очки и т.п.)" )]
	[GameAction ( Name = HeroStatistics.SetStatisticsAction , Description = "Установить значение статистики. Поддерживаются форматы NNN+XXX, NNN-XXX, NNN=XXX где XXX это число, NNN это имя статистики. Например Score+30 - добавить к очкам 30." )]
	[GameState ( Name = HeroStatistics.StatisticNamesState , Description = "Названия всех статистик для текущего объекта. Формат записи NNN,NNN где NNN имя статистики. Например Score,Life" )]
	[GameState ( Name = HeroStatistics.StatisticDefaultValueState , Description = "Значение по умолчанию для статистики. Обязательно должно быть объявлено после состояния " + HeroStatistics.StatisticNamesState )]
	public class HeroStatistics : ObjectBehaviour {

		public const string NameBehaviour = "HeroStatistics";

		public const string SetStatisticsAction = "setStatistic";

		public const string StatisticNamesState = "Statistics";

		public const string StatisticDefaultValueState = "StatisticValue";

		private IDictionary<string , int> m_Statistics = new Dictionary<string , int> ();

		/// <summary>
		/// Статистики.
		/// </summary>
		public IDictionary<string , int> Statistics {
			get {
				return m_Statistics;
			}
		}

		/// <summary>
		/// Обработчик событий.
		/// </summary>
		/// <param name="event">Возбужденное событие.</param>
		public override void EventHandler ( IEvent @event ) {
			if ( !@event.Action.StartsWith ( SetStatisticsAction ) ) return;

			var statisticExpression = @event.Action.Replace ( SetStatisticsAction , "" );
			if ( !Regex.IsMatch ( statisticExpression , @"[A-Za-z]*[\+\-\=]{1}[0-9]*" ) ) throw new InvalidOperationException ( "Некорректный формат данных для изменения статистики. Корректный <Имя Статистики>[+-=]<число>." );

			var operation = Regex.Match ( statisticExpression , @"[\+\-\=]{1}" ).Value;
			var nameStatistic = Regex.Match ( statisticExpression , @"[A-Za-z]*" ).Value;

			var memberType = typeof ( StatisticsOperation )
				.GetFields ()
				.Where ( a => a.GetCustomAttributes ( false ).Any ( attribute => attribute is AdditionalInformationAttribute && ( attribute as AdditionalInformationAttribute ).Information == operation ) )
				.First ()
				.GetValue ( null );
			CalculateStatistic ( (StatisticsOperation) memberType , nameStatistic , GetNumberInString ( statisticExpression ) );
		}

		/// <summary>
		/// Получить номер из строки.
		/// </summary>
		/// <param name="statisticExpression">Выражение статистики.</param>
		private static int GetNumberInString ( string statisticExpression ) {
			string numberString = string.Empty;
			var matches = Regex.Matches ( statisticExpression , @"([0-9])" );

			foreach ( var match in matches ) numberString += ( match as Match ).Value;

			return Convert.ToInt32 ( numberString );
		}

		/// <summary>
		/// Вычислить статистику.
		/// </summary>
		/// <param name="operation">Операция.</param>
		/// <param name="nameStatistic">Имя статистики.</param>
		/// <param name="value">Значение для вычисления.</param>
		/// <exception cref="ArgumentException"></exception>
		public void CalculateStatistic ( StatisticsOperation operation , string nameStatistic , int value ) {
			if ( !m_Statistics.ContainsKey ( nameStatistic ) ) throw new ArgumentException ( string.Format ( "Нет статистики с именем {0}." , nameStatistic ) , "nameStatistic" );

			switch ( operation ) {
				case StatisticsOperation.Plus:
					m_Statistics[nameStatistic] += value;
					break;
				case StatisticsOperation.Minus:
					m_Statistics[nameStatistic] -= value;
					break;
				case StatisticsOperation.Assing:
					m_Statistics[nameStatistic] = value;
					break;
			}
		}

		/// <summary>
		/// Инициализация визуального объекта.
		/// </summary>
		public override void InitializeVisualObject () {
			var namesString = VisualObject.States
				.Where ( a => a.Name == StatisticNamesState )
				.Select ( a => a.Value )
				.OfType<string> ()
				.FirstOrDefault ();
			foreach ( var name in namesString.Split ( ',' ) ) m_Statistics.Add ( name , 0 );

			var stateValues = VisualObject.States
				.Where ( a => a.Name.StartsWith ( StatisticDefaultValueState ) )
				.ToList ();
			foreach ( var stateValue in stateValues ) m_Statistics[stateValue.Name.Replace ( StatisticDefaultValueState , "" )] = Convert.ToInt32 ( stateValue.Value );
		}

	}
}
