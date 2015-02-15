using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic;
using AbstractGameLogic.Audio;
using AbstractGameLogic.ObjectVisual;

namespace AbstractGameLogic.Factories {

	/// <summary>
	/// Фабрика игровых объектов.
	/// </summary>
	public interface IGameObjectFactory {

		/// <summary>
		/// Создать игровой мир.
		/// </summary>
		/// <returns>Игровой мир.</returns>
		IGameWorld CreateGameWorld ();

		/// <summary>
		/// Создать игровой мир с параметрами.
		/// </summary>
		/// <param name="name">Имя мира.</param>
		/// <param name="drawLevels">Графические слои.</param>
		/// <returns>Игровой мир.</returns>
		IGameWorld CreateGameWorld ( string name , IEnumerable<IDrawLevel> drawLevels );

		/// <summary>
		/// Создать графический слой.
		/// </summary>
		/// <returns>Графический слой.</returns>
		IDrawLevel CreateDrawLevel ();

		/// <summary>
		/// Создать графический слой.
		/// </summary>
		/// <param name="name">Имя слоя.</param>
		/// <param name="isCheckCollision">Выполнять ли проверки колизий.</param>
		/// <param name="objects">Объекты с слое.</param>
		/// <returns>Графический слой.</returns>
		IDrawLevel CreateDrawLevel ( string name , bool isCheckCollision , IEnumerable<IGameObjectVisual> objects );

		/// <summary>
		/// Создать камеру.
		/// </summary>
		/// <returns>Камера.</returns>
		ICamera CreateCamera ();

		/// <summary>
		/// Создать анимированный объект.
		/// </summary>
		/// <returns>Анимированный объект.</returns>
		IAnimatedObject CreateAnimatedObject ();

		/// <summary>
		/// Создать тайловый анимированный объект.
		/// </summary>
		/// <returns>Тайловый анимированный объект.</returns>
		ITileAnimatedObject CreateTileAnimatedObject ();

		/// <summary>
		/// Создать фоновый объект.
		/// </summary>
		/// <returns>Фоновый объект.</returns>
		IBackground CreateBackground ();

		/// <summary>
		/// Создать фоновый паралакс.
		/// </summary>
		/// <returns>Фоновый паралакс.</returns>
		IParallaxBackground CreateParallaxBackground ();

		/// <summary>
		/// Создать эффект.
		/// </summary>
		/// <returns>Эффект.</returns>
		IEffect CreateEffect ();

		/// <summary>
		/// Создать статический объект.
		/// </summary>
		/// <returns>Статический объект.</returns>
		IStaticObject CreateStaticObject ();

		/// <summary>
		/// Создать скрытый объект.
		/// </summary>
		/// <returns>Скрытый объект.</returns>
		IHidden CreateHidden ();

		/// <summary>
		/// Создать тайловую карту.
		/// </summary>
		/// <returns>Тайловая карта.</returns>
		ITileMap CreateTileMap ();

		/// <summary>
		/// Создать текстовый объект.
		/// </summary>
		/// <returns>Текстовый объект.</returns>
		IText CreateText ();

		/// <summary>
		/// Создать музыкальный трек.
		/// </summary>
		/// <param name="name">Имя музыкального трека.</param>
		/// <param name="track">Идентификатор трека.</param>
		/// <returns>Музыкальный трек.</returns>
		IMusicTrack CreateMusicTrack ( string name , string track );

		/// <summary>
		/// Создать музыкальный плеер.
		/// </summary>
		/// <param name="name">Имя плеера.</param>
		/// <returns>Музыкальный плеер.</returns>
		IMusicPlayer CreateMusicPlayer ( string name );

		/// <summary>
		/// Создать звук.
		/// </summary>
		/// <param name="name">Имя звука.</param>
		/// <param name="sound">Идентификатор звука.</param>
		/// <param name="volume">Громкость.</param>
		/// <returns>Звук.</returns>
		ISound CreateSound ( string name , string sound , int volume = 100 );

	}

}
