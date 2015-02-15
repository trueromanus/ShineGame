using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic;
using AbstractGameLogic.Factories;
using AbstractGameLogic.ObjectVisual;

namespace GameLevel {

	/// <summary>
	/// Ресурсы игрового уровня.
	/// </summary>
	public static class GameLevelResource {

		/// <summary>
		/// Клонировать визуальный объект.
		/// </summary>
		/// <param name="object">Объект.</param>
		/// <param name="gameObjectFactory">Фабрика визуальных объектов.</param>
		/// <param name="drawLevel">Графический слой.</param>
		/// <returns>Визуальный объект.</returns>
		private static IGameObjectVisual CloneVisualObject ( IGameObjectVisual @object , IGameObjectFactory gameObjectFactory , IDrawLevel drawLevel ) {
			IGameObjectVisual newObject = null;

			if ( @object is IText ) newObject = gameObjectFactory.CreateText ();
			if ( @object is IAnimatedObject ) newObject = gameObjectFactory.CreateAnimatedObject ();
			if ( @object is ITileAnimatedObject ) newObject = gameObjectFactory.CreateTileAnimatedObject ();
			if ( @object is ITileMap ) newObject = gameObjectFactory.CreateTileMap ();
			if ( @object is IStaticObject ) newObject = gameObjectFactory.CreateStaticObject ();
			if ( @object is IEffect ) newObject = gameObjectFactory.CreateEffect ();
			if ( @object is IBackground ) newObject = gameObjectFactory.CreateBackground ();
			if ( @object is IParallaxBackground ) newObject = gameObjectFactory.CreateParallaxBackground ();
			if ( @object is IHidden ) newObject = gameObjectFactory.CreateHidden ();

			if ( newObject == null ) throw new ArgumentException ( "Не поддерживаемый тип объектов." , "@object" );

			newObject.DrawLevel = drawLevel;

			var readable = ( newObject as IGameObjectReadeable );
			if ( readable != null ) readable.CloneGameObjectData ( @object );

			return newObject;
		}

		/// <summary>
		/// Создать игровой мир.
		/// </summary>
		/// <param name="levelData">Данные уровня.</param>
		/// <param name="factoryHost">Хост фабрик.</param>
		/// <param name="callback">Для обратного вызова завершения чтения уровня.</param>
		/// <returns>Игровой мир.</returns>
		public static IGameWorld CreateGameWorld ( IGameLevelData levelData , IFactoryHost factoryHost , Action<IGameWorld> callback = null ) {
			var world = factoryHost.GameObjects.CreateGameWorld ();
			world.Name = levelData.Name;
			world.GUIManager = factoryHost.Levels.CreateGUIManager();
			world.GUIManager.Name = levelData.GUIManager.Name;
			world.GUIManager.Skin = levelData.GUIManager.Skin;
			foreach ( var drawLevel in levelData.DrawLevels ) {
				var newDrawLevel = factoryHost.GameObjects.CreateDrawLevel ();
				newDrawLevel.Name = drawLevel.Name;
				newDrawLevel.IsCheckCollision = drawLevel.IsCheckCollision;
				var objects = drawLevel.Objects
						.Select ( a => CloneVisualObject ( a , factoryHost.GameObjects , newDrawLevel ) )
						.ToList ();

				foreach ( var @object in objects ) newDrawLevel.Add ( @object );

				world.Add ( newDrawLevel );

				var initializationObjects = newDrawLevel.Objects
					.OfType<IGameObjectInitialization> ();
				foreach ( var initializationObject in initializationObjects ) initializationObject.Initialize ();
			}

			if ( callback != null ) callback ( world );

			return world;
		}

	}

}
