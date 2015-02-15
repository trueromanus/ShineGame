using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrisonerLevelBehaviours.Actions;
using PrisonerLevelBehaviours.Environment;
using ShineGame.Factories;

namespace PrisonerBehaviourUnitTest {

	/// <summary>
	/// Тесты для кнопки.
	/// </summary>
	[TestClass]
	public class ButtonUnitTest {

		/// <summary>
		/// Включение кнопки.
		/// </summary>
		[TestMethod]
		public void CheckUncheck () {
			var stateFactory = new StateFactory ();
			var gameObjectFactory = new GameObjectFactory ();

			var button = new Button ();
			button.EventCollection = stateFactory.CreateEventCollection ();
			button.EventCollection.Add ( stateFactory.CreateEvent ( "" , "" , Button.ChangeModeActionName ) );
			button.VisualObject = gameObjectFactory.CreateHidden ();
			button.VisualObject.DrawLevel = gameObjectFactory.CreateDrawLevel ();
			var state = stateFactory.CreateObjectState ();
			state.Name = Button.ModeStateName;
			state.Value = "False";
			button.VisualObject.States.Add ( state );

			button.Initialize ( null );
			Assert.IsFalse ( button.IsChecked , "Не корректное установленное по умолачнию состояние." );

			button.EventHandler ( button.EventCollection.Events.First () );
			Assert.IsTrue ( button.IsChecked , "Не корректное указанное значение состояния." );

			button.EventHandler ( button.EventCollection.Events.First () );
			Assert.IsFalse ( button.IsChecked , "Не корректное указанное значение состояния." );

		}

		/// <summary>
		/// Выключение кнопки.
		/// </summary>
		[TestMethod]
		public void Blocked () {
			var stateFactory = new StateFactory ();
			var gameObjectFactory = new GameObjectFactory ();

			var button = new Button ();
			button.EventCollection = stateFactory.CreateEventCollection ();
			button.EventCollection.Add ( stateFactory.CreateEvent ( "" , "" , Button.BlockedActionName ) );
			button.EventCollection.Add ( stateFactory.CreateEvent ( "" , "" , Button.ChangeModeActionName ) );
			button.EventCollection.Add ( stateFactory.CreateEvent ( "" , "" , Button.UnBlockedActionName ) );
			button.VisualObject = gameObjectFactory.CreateHidden ();
			button.VisualObject.DrawLevel = gameObjectFactory.CreateDrawLevel ();
			var state = stateFactory.CreateObjectState ();
			state.Name = Button.BlockedStateName;
			state.Value = "True";
			button.VisualObject.States.Add ( state );

			button.Initialize ( null );
			Assert.IsTrue ( button.IsBlocked , "Не корректное установленное по умолачнию состояние." );

			var mode = button.IsChecked;
			button.EventHandler ( button.EventCollection.Events.ElementAt ( 1 ) );
			Assert.IsTrue ( button.IsChecked == mode , "Значение состояния кнопки изменилось во время блокировки." );

			button.EventHandler ( button.EventCollection.Events.Last () );
			Assert.IsFalse ( button.IsBlocked , "Не корректное указанное значение состояния." );

			button.EventHandler ( button.EventCollection.Events.First () );
			Assert.IsTrue ( button.IsBlocked , "Не корректное указанное значение состояния." );

		}

	}
}
