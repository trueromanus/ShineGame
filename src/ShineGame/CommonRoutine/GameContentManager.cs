using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AbstractGameLogic;
using AbstractGameLogic.Attributes;
using AbstractGameLogic.Factories;
using AbstractGameLogic.ObjectBehavior;
using GameLevel;
using GameLevel.Implementations;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProjectMercury;

namespace ShineGame.CommonRoutine {

	/// <summary>
	/// Игровой менеджер контента.
	/// </summary>
	public static class GameContentManager {

		private static ContentManager m_ContentManager;

		/// <summary>
		/// Менеджер контента.
		/// </summary>
		public static ContentManager Manager {
			get {
				return m_ContentManager;
			}
			set {
				m_ContentManager = value;
			}
		}

		/// <summary>
		/// Сборки содержащие поведения.
		/// </summary>
		public static IEnumerable<Assembly> BehaviourLibrarys {
			get;
			set;
		}

		/// <summary>
		/// Получить объект текстуры.
		/// </summary>
		/// <param name="imageName">Имя изображения.</param>
		/// <returns>Текстура в виде экземпляра <see cref="Texture2D"/>.</returns>
		public static Texture2D GetTexture ( string imageName ) {
			return m_ContentManager.Load<Texture2D> ( imageName );
		}

		/// <summary>
		/// Получить объект шрифта.
		/// </summary>
		/// <param name="fontName">Имя шрифта.</param>
		/// <returns>Объект шрифта.</returns>
		public static SpriteFont GetFont ( string fontName ) {
			return m_ContentManager.Load<SpriteFont> ( fontName );
		}

		/// <summary>
		/// Получить объект эффекта.
		/// </summary>
		/// <param name="effectName">Имя эффекта.</param>
		/// <returns>Объект эффекта.</returns>
		public static ParticleEffect GetParticleEffect ( string effectName ) {
			return m_ContentManager.Load<ParticleEffect> ( effectName );
		}

		/// <summary>
		/// Получить данные уровня.
		/// </summary>
		/// <param name="levelName">Имя уровня.</param>
		/// <returns>Данные уровня.</returns>
		public static GameLevelData GetLevelData ( string levelName ) {
			return m_ContentManager.Load<GameLevelData> ( levelName );
		}

		/// <summary>
		/// Создать мир по данным уровня.
		/// </summary>
		/// <param name="levelData">Данные уровня.</param>
		/// <param name="factoryHost">Фабрика объектов.</param>
		/// <param name="callback">Для обратного вызова завершения чтения уровня.</param>
		/// <returns>Игровой мир.</returns>
		public static IGameWorld GetGameWorld ( GameLevelData levelData , IFactoryHost factoryHost , Action<IGameWorld> callback = null ) {
			return GameLevelResource.CreateGameWorld ( levelData , factoryHost , callback );
		}

		/// <summary>
		/// Получить поведения и состояния связанные с поведениями.
		/// </summary>
		/// <param name="object">Объект в который необходимо получить поведени и состояния.</param>
		/// <param name="behaviourName">Имя поведения для внедрения в объект.</param>
		/// <param name="factoryHost">Хост всех фабрик.</param>
		/// <param name="targetObject">Опорный объект для получения данных.</param>
		public static void GetBehavoiursAndStates ( IGameObject @object , string behaviourName , IGameObject targetObject , IFactoryHost factoryHost ) {
			if ( BehaviourLibrarys == null ) throw new InvalidProgramException ( "Не установлена коллекция сборок поведений (свойство BehaviourLibrarys)" );

			var types = BehaviourLibrarys
				.SelectMany ( a => a.GetTypes () )
				.ToList ();

			IGameObjectBehaviourable behaviourObject = ( @object as IGameObjectBehaviourable );
			IObjectBehaviors targetBehaviours = ( targetObject as IGameObjectBehaviourable ).BehaviourCollection;

			if ( behaviourObject != null ) {
				behaviourObject.BehaviourCollection.AddRange (
					types
						.Where (
							a =>
								a.GetInterfaces ()
									.Any ( iface => iface.Name == "IObjectBehavior" ) &&
									a.GetCustomAttributes ( false )
										.OfType<ObjectBindBehaviourAttribute> ()
										.Any ( attribute => attribute.Name == behaviourName )
						)
						.Select ( ( a ) => {
							var behaviour = (IObjectBehavior) Activator.CreateInstance ( a );
							behaviour.Name = behaviourName;
							behaviour.EventCollection = factoryHost.States.CreateEventCollection ();

							var events = targetBehaviours.Behaviors
								.Where ( gameBehaviour => gameBehaviour.Name == behaviourName )
								.SelectMany ( gameBehaviour => gameBehaviour.EventCollection.Events )
								.ToList ();
							foreach ( var @event in events ) {
								behaviour.EventCollection.Add ( factoryHost.States.CreateEvent ( @event.Handler , @event.Name , @event.Action ) );
							}
							return behaviour;
						} )
						.ToList ()
				);
			}
		}

	}

}
