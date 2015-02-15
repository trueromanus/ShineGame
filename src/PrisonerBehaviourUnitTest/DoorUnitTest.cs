using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrisonerLevelBehaviours.Actions;
using PrisonerLevelBehaviours.Environment;
using ShineGame.Factories;

namespace PrisonerBehaviourUnitTest {

	/// <summary>
	/// Тесты для поведения <see cref="Door"/>.
	/// </summary>
	[TestClass]
	public class DoorUnitTest {


		/// <summary>
		/// Открытие двери.
		/// </summary>
		[TestMethod]
		public void OpenDoor () {
			var stateFactory = new StateFactory ();
			var gameObjectFactory = new GameObjectFactory ();

			var door = new Door ();
			door.EventCollection = stateFactory.CreateEventCollection ();
			door.EventCollection.Add ( stateFactory.CreateEvent ( "" , "" , Door.OpenActionName ) );
			door.VisualObject = gameObjectFactory.CreateHidden ();
			door.VisualObject.DrawLevel = gameObjectFactory.CreateDrawLevel ();

			door.EventHandler ( door.EventCollection.Events.First () );
			Assert.IsTrue ( door.IsOpened , "Состояние двери некорректно." );

			door.EventHandler ( door.EventCollection.Events.First () );
			Assert.IsTrue ( door.IsOpened , "Повторное изменение состояние двери некорректно." );
		}

		/// <summary>
		/// Закрытие двери.
		/// </summary>
		[TestMethod]
		public void CloseDoor () {
			var stateFactory = new StateFactory ();
			var gameObjectFactory = new GameObjectFactory ();

			var door = new Door ();
			door.EventCollection = stateFactory.CreateEventCollection ();
			door.EventCollection.Add ( stateFactory.CreateEvent ( "" , "" , Door.CloseActionName ) );
			door.VisualObject = gameObjectFactory.CreateHidden ();
			door.VisualObject.DrawLevel = gameObjectFactory.CreateDrawLevel ();

			door.EventHandler ( door.EventCollection.Events.First () );
			Assert.IsTrue ( !door.IsOpened , "Состояние двери некорректно." );

			door.EventHandler ( door.EventCollection.Events.First () );
			Assert.IsTrue ( !door.IsOpened , "Повторное изменение состояние двери некорректно." );
		}

	}
}
