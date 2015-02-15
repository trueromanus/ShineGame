using System;
using ShineGame.GameWorlds;
using AbstractGameLogic;
using ShineGame.DrawLevels;
using ShineGame.Cameras;
using AbstractGameLogic.ObjectVisual;
using ShineGame.VisualObjects;
using AbstractGameLogic.Factories;
using System.Collections.Generic;
using AbstractGameLogic.Audio;
using ShineGame.Audio;

namespace ShineGame.Factories {

	/// <summary>
	/// Фабрика игровых объектов.
	/// </summary>
	public class GameObjectFactory : IGameObjectFactory {

		/// <summary>
		/// Создать игровой мир.
		/// </summary>
		/// <returns>Игровой мир.</returns>
		public IGameWorld CreateGameWorld () {
			return new GameWorld ();
		}

		/// <summary>
		/// Создать графический слой.
		/// </summary>
		/// <returns>Графический слой.</returns>
		public IDrawLevel CreateDrawLevel () {
			return new ShineDrawLevel ();
		}

		/// <summary>
		/// Создать камеру.
		/// </summary>
		/// <returns>Камера.</returns>
		public ICamera CreateCamera () {
			return new ShineCamera ();
		}

		/// <summary>
		/// Создать анимированный объект.
		/// </summary>
		/// <returns>Анимированный объект.</returns>
		public IAnimatedObject CreateAnimatedObject () {
			return new ShineAnimatedObject ();
		}

		/// <summary>
		/// Создать тайловый анимированный объект.
		/// </summary>
		/// <returns>Тайловый анимированный объект.</returns>
		public ITileAnimatedObject CreateTileAnimatedObject () {
			return new ShineTileAnimatedObject ();
		}

		/// <summary>
		/// Создать фоновый объект.
		/// </summary>
		/// <returns>Фоновый объект.</returns>
		public IBackground CreateBackground () {
			return new ShineBackground ();
		}

		/// <summary>
		/// Создать фоновый паралакс.
		/// </summary>
		/// <returns>Фоновый паралакс.</returns>
		public IParallaxBackground CreateParallaxBackground () {
			return new ShineParallaxBackground ();
		}

		/// <summary>
		/// Создать эффект.
		/// </summary>
		/// <returns>Эффект.</returns>
		public IEffect CreateEffect () {
			return new ShineEffect ();
		}

		/// <summary>
		/// Создать статический объект.
		/// </summary>
		/// <returns>Статический объект.</returns>
		public IStaticObject CreateStaticObject () {
			return new ShineStaticObject ();
		}

		/// <summary>
		/// Создать скрытый объект.
		/// </summary>
		/// <returns>Скрытый объект.</returns>
		public IHidden CreateHidden () {
			return new HiddenObject ();
		}

		/// <summary>
		/// Создать тайловую карту.
		/// </summary>
		/// <returns>Тайловая карта.</returns>
		public ITileMap CreateTileMap () {
			return new ShineTileMap ();
		}

		/// <summary>
		/// Создать текстовый объект.
		/// </summary>
		/// <returns>Текстовый объект.</returns>
		public IText CreateText () {
			return new ShineText ();
		}

		/// <summary>
		/// Создать игровой мир с параметрами.
		/// </summary>
		/// <param name="name">Имя мира.</param>
		/// <param name="drawLevels">Графические слои.</param>
		/// <returns>Игровой мир.</returns>
		public IGameWorld CreateGameWorld ( string name , IEnumerable<IDrawLevel> drawLevels ) {
			var gameWorld = new GameWorld {
				Name = name
			};
			foreach ( var drawLevel in drawLevels ) gameWorld.Add ( drawLevel );

			return gameWorld;
		}

		/// <summary>
		/// Создать графический слой.
		/// </summary>
		/// <param name="name">Имя слоя.</param>
		/// <param name="isCheckCollision">Признак того выполнять ли проверки колизий.</param>
		/// <param name="objects">Последовательность объектов графического слоя.</param>
		/// <returns>Графический слой.</returns>
		public IDrawLevel CreateDrawLevel ( string name , bool isCheckCollision , IEnumerable<IGameObjectVisual> objects ) {
			var drawLevel = new ShineDrawLevel {
				IsCheckCollision = isCheckCollision ,
				Name = name
			};
			foreach ( var @object in objects ) drawLevel.Add ( @object );

			return drawLevel;
		}

		/// <summary>
		/// Создать музыкальный трек.
		/// </summary>
		/// <param name="name">Имя музыкального трека.</param>
		/// <param name="track">Идентификатор трека.</param>
		/// <returns>Музыкальный трек.</returns>
		public IMusicTrack CreateMusicTrack ( string name , string track ) {
			return new MusicTrack {
				Name = name ,
				Track = track
			};
		}

		/// <summary>
		/// Создать музыкальный плеер.
		/// </summary>
		/// <param name="name">Имя плеера.</param>
		/// <returns>Музыкальный плеер.</returns>
		public IMusicPlayer CreateMusicPlayer ( string name ) {
			return new MusicPlayer {
				Name = name
			};
		}

		/// <summary>
		/// Создать звук.
		/// </summary>
		/// <param name="name">Имя.</param>
		/// <param name="sound">Идентификатор звука.</param>
		/// <param name="volume">Громкость.</param>
		/// <returns>Звук.</returns>
		public ISound CreateSound ( string name , string sound , int volume = 100 ) {
			return new ShineSound {
				Name = name ,
				Sound = sound ,
				Volume = volume
			};
		}
	}

}
