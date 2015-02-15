using System;
using System.Collections.Generic;
using AbstractGameLogic.ObjectVisual;
using AbstractGameLogic.State;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PrisonerLevelBehaviours.Statistics;

namespace PrisonerBehaviourUnitTest {

	/// <summary>
	/// Модульные тесты для класса <see cref="HeroStatisticsUnitTest"/>.
	/// </summary>
	[TestClass]
	public class HeroStatisticsUnitTest {

		private const string TestFirstStatisticsName = "First";

		private const string TestSecondStatisticsName = "Second";

		/// <summary>
		/// Получить объектное состояние.
		/// </summary>
		/// <param name="name">Имя.</param>
		/// <param name="value">Значение.</param>
		/// <returns>Состояние объекта.</returns>
		private IObjectState GetObjectState ( string name , string value ) {
			var objectStateMock = new Mock<IObjectState> ();
			objectStateMock
				.Setup ( a => a.Name )
				.Returns ( name );
			objectStateMock
				.Setup ( a => a.Value )
				.Returns ( value );
			return objectStateMock.Object;
		}

		/// <summary>
		/// Тест вычисления статистики.
		/// </summary>
		[TestMethod]
		public void CalculateTest () {
			HeroStatistics statistics = new HeroStatistics ();

			var mockVisualObject = new Mock<IGameObjectVisual> ();
			mockVisualObject
				.Setup ( a => a.States )
				.Returns (
					new List<IObjectState> () {
						GetObjectState(HeroStatistics.StatisticNamesState,string.Format ( "{0},{1}" , TestFirstStatisticsName , TestSecondStatisticsName ))
					}
				);
			statistics.VisualObject = mockVisualObject.Object;
			statistics.InitializeVisualObject ();

			statistics.CalculateStatistic ( StatisticsOperation.Plus , TestFirstStatisticsName , 5 );
			Assert.AreEqual ( statistics.Statistics[TestFirstStatisticsName] , 5 );

			statistics.CalculateStatistic ( StatisticsOperation.Minus , TestFirstStatisticsName , 3 );
			Assert.AreEqual ( statistics.Statistics[TestFirstStatisticsName] , 2 );

			statistics.CalculateStatistic ( StatisticsOperation.Assing , TestSecondStatisticsName , 8 );
			Assert.AreEqual ( statistics.Statistics[TestSecondStatisticsName] , 8 );
		}

		/// <summary>
		/// Тест выполнения обработчика событий.
		/// </summary>
		[TestMethod]
		public void EventTest () {
			HeroStatistics statistics = new HeroStatistics ();

			var mockVisualObject = new Mock<IGameObjectVisual> ();
			mockVisualObject
				.Setup ( a => a.States )
				.Returns (
					new List<IObjectState> () {
						GetObjectState(HeroStatistics.StatisticNamesState,string.Format ( "{0},{1}" , TestFirstStatisticsName , TestSecondStatisticsName )),
						GetObjectState(HeroStatistics.StatisticDefaultValueState + TestFirstStatisticsName,"3"),
						GetObjectState(HeroStatistics.StatisticDefaultValueState + TestSecondStatisticsName,"8")
					}
				);
			statistics.VisualObject = mockVisualObject.Object;
			statistics.InitializeVisualObject ();

			statistics.EventHandler ( 
				Mock
					.Of<IEvent> ( a => a.Action == string.Format ( "{0}{1}{2}{3}" , HeroStatistics.SetStatisticsAction , TestFirstStatisticsName , "+" , "3" ) )
			);
			Assert.AreEqual ( statistics.Statistics[TestFirstStatisticsName] , 6 );

			statistics.EventHandler ( 
				Mock
					.Of<IEvent> ( a => a.Action == string.Format ( "{0}{1}{2}{3}" , HeroStatistics.SetStatisticsAction , TestFirstStatisticsName , "-" , "3" ) ) 
			);
			Assert.AreEqual ( statistics.Statistics[TestFirstStatisticsName] , 3 );

			statistics.EventHandler ( 
				Mock
					.Of<IEvent> ( a => a.Action == string.Format ( "{0}{1}{2}{3}" , HeroStatistics.SetStatisticsAction , TestFirstStatisticsName , "=" , "4" ) )
			);
			Assert.AreEqual ( statistics.Statistics[TestFirstStatisticsName] , 4 );

		}

	}
}
