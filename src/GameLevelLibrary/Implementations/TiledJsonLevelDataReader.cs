using System;
using System.Linq;
using GameLevelLibrary.Models;
using System.IO;
using AbstractGameLogic.ObjectVisual;
using AbstractGameLogic;
using GameLevelLibrary.Exceptions;
using Newtonsoft.Json;
using GameLevel;
using GameLevel.Implementations;
using System.Collections.Generic;
using AbstractGameLogic.State;

namespace GameLevelLibrary.Implementations {

	/// <summary>
	/// Чтение данных уровня и предсатавления JSON программы Tiled.
	/// </summary>
	internal class TiledJsonLevelDataReader : ILevelDataReader<JsonLevelModel> {

		private const string ObjectLayerName = "objectgroup";

		private const string TileLayerName = "tilelayer";

		private const string ImageLayerName = "imagelayer";

		private const string GuiSkinName = "GUISkin";

		/// <summary>
		/// Формируем модель из данных в файле.
		/// </summary>
		/// <param name="fileName">Имя файла.</param>
		/// <returns>Модель данных.</returns>
		public JsonLevelModel ReadModelFromFile ( string fileName ) {
			return JsonConvert.DeserializeObject<JsonLevelModel> ( File.ReadAllText ( fileName ) );
		}

		/// <summary>
		/// Читаем данные из файла с представлением JSON.
		/// </summary>
		/// <param name="fileName">Имя файла.</param>
		/// <returns>Данные уровня.</returns>
		public IGameLevelData ReadDataFromModel ( JsonLevelModel model ) {
			var result = new GameLevelData ();
			result.Description = model.Properties["Description"];
			result.Name = model.Properties["Name"];
			result.GUIManager = new GUIManager {
				Name = "Default" ,
				Skin = model.Properties.ContainsKey ( GuiSkinName ) ? model.Properties[GuiSkinName] : "Default"
			};
			//model.Properties["Title"];
			//сначала обрабатываем фоновые слои
			foreach ( var imageLayer in model.Layers.Where ( a => a.Type == ImageLayerName ).ToList () ) {
				var drawLevel = CreateDrawLevel ( imageLayer );
				drawLevel.Add ( CreateGameBackground ( imageLayer ) );
				result.Add ( drawLevel );
			}

			//потом слои с изображениями
			foreach ( var datalayer in model.Layers.Where ( a => a.Type == TileLayerName ).ToList () ) {
				var drawLevel = CreateDrawLevel ( datalayer );
				drawLevel.Name = datalayer.Name;
				var startY = datalayer.Y;
				for ( var i = 0 ; i < datalayer.Height ; i++ ) {
					var startX = datalayer.X;
					var objects = datalayer.Data
						.Skip ( datalayer.Width * i )
						.Take ( datalayer.Width )
						.Select ( ( a ) => {
							IGameObjectVisual returnObject = null;
							if ( a != 0 ) {
								var tileSet = GetTileSet ( model , a );
								if ( tileSet == null ) throw new ReadLevelException ( "" );
								returnObject = CreateGameObject ( tileSet , startX , startY , a );
							}
							startX += model.TileWidth;
							return returnObject;
						} )
						.ToList ();
					startY += model.TileHeight;
					foreach ( var @object in objects.Where ( a => a != null ).ToList () ) drawLevel.Add ( @object );
				}
				result.Add ( drawLevel );
			}

			//потом объекты для дополнительных колизий
			foreach ( var objectlayer in model.Layers.Where ( a => a.Type == ObjectLayerName ).ToList () ) {
				var drawLevel = CreateDrawLevel ( objectlayer );
				var objects = objectlayer.Objects
					.Where ( a => a.Visible )
					.AsParallel ()
					.Select ( a => CreateGameObject ( a ) )
					.ToList ();
				foreach ( var @object in objects ) drawLevel.Add ( @object );

				result.Add ( drawLevel );
			}

			return result;
		}

		/// <summary>
		/// Создать коллекцию поведений используя словарь со свойствами.
		/// </summary>
		/// <param name="properties">Словарь со свойствами.</param>
		/// <returns>Коллекция поведений.</returns>
		private static ObjectBehaviours CreateBehavioursCollection ( IDictionary<string , string> properties ) {
			if ( properties == null ) return null;

			var behaviourCollection = new ObjectBehaviours ();
			behaviourCollection.AddRange (
				properties
					.Where ( a => a.Key.StartsWith ( "Behaviour" ) )
					.Select ( ( a ) => {
						var result = new ObjectBehaviour {
							Name = a.Value ,
							Order = Convert.ToInt32 ( a.Key.Replace ( "Behaviour" , "" ) ) ,
							EventCollection = new EventCollection ()
						};
						var suffixEvent = "Event" + result.Order;
						var requestEvents = properties
								.Where ( property => property.Key.EndsWith ( suffixEvent ) )
								.Select ( property => property.Value );
						foreach ( var eventProperty in requestEvents ) {
							var values = eventProperty.Split ( ',' );
							if ( values.Count () != 3 ) throw new ReadLevelException ();
							result.EventCollection.Add (
								new GameEvent {
									Handler = values.First () ,
									Name = values.ElementAt ( 1 ) ,
									Action = values.Last ()
								}
							);
						}
						return result;
					}
					)
					.OrderBy ( a => a.Order )
					.ToList ()
			);
			return behaviourCollection;
		}

		/// <summary>
		/// Создать коллекцию состояний.
		/// </summary>
		/// <param name="properties">Словарь со свойствами.</param>
		/// <returns></returns>
		private static List<IObjectState> CreateStatesCollection ( IDictionary<string , string> properties ) {
			if ( properties == null ) return null;

			List<IObjectState> result = new List<IObjectState> ();
			result.AddRange (
				properties
					.Where ( a => a.Key.StartsWith ( "State" ) )
					.Select ( a => new ObjectState {
						Name = a.Key.Replace ( "State" , "" ) ,
						Value = a.Value
					} )
					.ToList ()
			);
			return result;
		}

		/// <summary>
		/// Создать графический слой.
		/// </summary>
		/// <param name="layer">Данные о слое.</param>
		/// <returns></returns>
		private IDrawLevel CreateDrawLevel ( Layer layer ) {
			return new DrawLevel {
				Name = layer.Name ,
				IsCheckCollision = layer.Properties != null && layer.Properties.Any ( a => a.Key == "IsCheckCollision" && a.Value == "True" )
			};
		}

		/// <summary>
		/// Создать игровой фон.
		/// </summary>
		/// <param name="imageLayer"></param>
		/// <returns></returns>
		private IGameObjectVisual CreateGameBackground ( Layer imageLayer ) {
			if ( imageLayer.Properties != null && imageLayer.Properties.Any ( a => a.Key == "Type" && a.Value == "Parallax" ) ) {
				var position = imageLayer.Properties.Where ( a => a.Key == "Position" ).Select ( a => a.Value ).FirstOrDefault ();
				var speed = imageLayer.Properties.Where ( a => a.Key == "Speed" ).Select ( a => a.Value ).FirstOrDefault ();
				var backgroundParallax = new ParallaxBackground {
					Name = imageLayer.Name + Guid.NewGuid ().ToString () ,
					Image = CorrectImagePath ( imageLayer.Image ) ,
					IsScrollable = imageLayer.Properties.Any ( a => a.Key == "IsScrollable" && a.Value == "True" ) ,
					Position = position != null ? Convert.ToInt32 ( position ) : 0 ,
					Speed = speed != null ? Convert.ToInt32 ( speed ) : 0 ,
					BehaviourCollectionMember = CreateBehavioursCollection ( imageLayer.Properties ) ,
					m_States = CreateStatesCollection ( imageLayer.Properties )
				};
				//TODO:что-то сделать с direction
				return backgroundParallax;
			}
			return new Background {
				Name = GetUniqie ( imageLayer.Name ) ,
				Image = CorrectImagePath ( imageLayer.Image ) ,
				BehaviourCollectionMember = CreateBehavioursCollection ( imageLayer.Properties ) ,
				m_States = CreateStatesCollection ( imageLayer.Properties )
			};
		}

		/// <summary>
		/// Коррекция пути к изображению.
		/// </summary>
		/// <param name="imagePath">Путь к изображению.</param>
		/// <returns>Откорректированный путь к изображению.</returns>
		private string CorrectImagePath ( string imagePath ) {
			return imagePath.Replace ( '/' , '\\' ).Replace ( Path.GetExtension ( imagePath ) , "" );
		}

		/// <summary>
		/// Создать анимированный объект основанный на тайлах.
		/// </summary>
		/// <param name="name">Имя.</param>
		/// <param name="startX">Начальная координата по оси X.</param>
		/// <param name="startY">Начальная координата по оси Y.</param>
		/// <param name="image">Изображение.</param>
		/// <param name="properties">Словарь со свойствами.</param>
		private IGameObjectVisual CreateTileAnimatedObject ( string image , string name , int startX , int startY , IDictionary<string , string> properties ) {
			return new TileAnimatedObject {
				WorldX = startX ,
				WorldY = startY ,
				ImageName = CorrectImagePath ( image ) ,
				TileHeight = properties.Where ( a => a.Key == "TileHeight" ).Select ( a => Convert.ToInt32 ( a.Value ) ).FirstOrDefault () ,
				TileWidth = properties.Where ( a => a.Key == "TileWidth" ).Select ( a => Convert.ToInt32 ( a.Value ) ).FirstOrDefault () ,
				AnimateSpeed = properties.Where ( a => a.Key == "AnimateSpeed" ).Select ( a => Convert.ToInt32 ( a.Value ) ).FirstOrDefault () ,
				AnimationRange =
					new Tuple<int , int> (
						properties.Where ( a => a.Key == "StartFrame" ).Select ( a => Convert.ToInt32 ( a.Value ) ).FirstOrDefault () ,
						properties.Where ( a => a.Key == "EndFrame" ).Select ( a => Convert.ToInt32 ( a.Value ) ).FirstOrDefault ()
					) ,
				Name = GetUniqie ( name ) ,
				IsLoop = properties.Any ( a => a.Key == "IsLoop" && a.Value == "True" ) ,
				BehaviourCollectionMember = CreateBehavioursCollection ( properties ) ,
				m_States = CreateStatesCollection ( properties )
			};
		}

		/// <summary>
		/// Создать анимированный объект основанный на отдельных изображениях.
		/// </summary>
		/// <param name="name">Имя.</param>
		/// <param name="startX">Начальная координата по оси X.</param>
		/// <param name="startY">Начальная координата по оси Y.</param>
		/// <param name="properties">Словарь со свойствами.</param>
		private IGameObjectVisual CreateAnimatedObject ( string name , int startX , int startY , IDictionary<string , string> properties ) {
			return new AnimatedObject {
				WorldX = startX ,
				WorldY = startY ,
				m_Frames = properties.Where ( a => a.Key.StartsWith ( "AnimFrame" ) ).OrderBy ( a => a.Key ).Select ( a => a.Value ).ToList () ,
				AnimateSpeed = properties.Where ( a => a.Key == "AnimateSpeed" ).Select ( a => Convert.ToInt32 ( a.Value ) ).FirstOrDefault () ,
				Name = GetUniqie ( name ) ,
				BehaviourCollectionMember = CreateBehavioursCollection ( properties ) ,
				m_States = CreateStatesCollection ( properties )
			};
		}

		/// <summary>
		/// Создать статический объект.
		/// </summary>
		/// <param name="image">Изображение.</param>
		/// <param name="name">Имя.</param>
		/// <param name="startX">Координата по оси X.</param>
		/// <param name="startY">Координата по оси Y.</param>
		/// <param name="properties">Свойства объекта.</param>
		private IGameObjectVisual CreateStaticObject ( string image , string name , int startX , int startY , IDictionary<string , string> properties ) {
			return new StaticObject {
				WorldX = startX ,
				WorldY = startY ,
				Image = CorrectImagePath ( image ) ,
				Name = GetUniqie ( name ) ,
				BehaviourCollectionMember = CreateBehavioursCollection ( properties ) ,
				m_States = CreateStatesCollection ( properties )
			};
		}

		/// <summary>
		/// Получить игровой объект.
		/// </summary>
		/// <param name="tileSet">Тайлсет.</param>
		/// <returns>Игровой визуальный объект.</returns>
		private IGameObjectVisual CreateGameObject ( TileSet tileSet , int startX , int startY , long tilePosition ) {
			string typeObject = tileSet.Properties
				.Where ( a => a.Key == "Type" )
				.Select ( a => a.Value )
				.FirstOrDefault ();
			switch ( typeObject ) {
				case "tileanimated":
					return CreateTileAnimatedObject ( tileSet.Image , tileSet.Name , startX , startY , tileSet.Properties );
				case "animated":
					return CreateAnimatedObject ( tileSet.Name , startX , startY , tileSet.Properties );
				default:
					return new StaticObject {
						WorldX = startX ,
						WorldY = startY ,
						Image = CorrectImagePath ( tileSet.Image ) ,
						Name = GetUniqie ( tileSet.Name ) ,
						Width = tileSet.TileWidth ,
						Height = tileSet.TileHeight ,
						TilePosition = GetTileSetTilePosition ( tileSet , tilePosition ) ,
						BehaviourCollectionMember = CreateBehavioursCollection ( tileSet.Properties ) ,
						m_States = CreateStatesCollection ( tileSet.Properties )
					};
			}
		}

		/// <summary>
		/// Получить игровой объект.
		/// </summary>
		/// <param name="layerObject">Объект слоя.</param>
		/// <returns>Игровой объект согласно данным объекта слоя.</returns>
		private IGameObjectVisual CreateGameObject ( LayerObject layerObject ) {
			string typeObject = layerObject.Properties
				.Where ( a => a.Key == "Type" )
				.Select ( a => a.Value )
				.FirstOrDefault ();
			switch ( typeObject ) {
				case "tileanimated":
					return
						CreateTileAnimatedObject (
							layerObject.Properties
								.Where ( a => a.Key == "Image" )
								.Select ( a => a.Value )
								.FirstOrDefault () ,
							layerObject.Name ,
							layerObject.X ,
							layerObject.Y ,
							layerObject.Properties
						);
				case "animated":
					return CreateAnimatedObject ( layerObject.Name , layerObject.X , layerObject.Y , layerObject.Properties );
				case "static":
					return
						CreateStaticObject (
							layerObject.Properties
								.Where ( a => a.Key == "Image" )
								.Select ( a => a.Value )
								.FirstOrDefault () ,
							layerObject.Name ,
							layerObject.X ,
							layerObject.Y ,
							layerObject.Properties
						);
				default:
					return new Hidden {
						Name = layerObject.Name ,
						WorldX = layerObject.X ,
						WorldY = layerObject.Y ,
						Width = layerObject.Width ,
						Height = layerObject.Height ,
						BehaviourCollectionMember = CreateBehavioursCollection ( layerObject.Properties ) ,
						m_States = CreateStatesCollection ( layerObject.Properties )
					};
			}
		}

		/// <summary>
		/// Получить позицию тайла а тайловом множестве.
		/// </summary>
		/// <param name="tileSet">Тайловое множество.</param>
		/// <param name="position">Позиция в общем списке.</param>
		/// <returns>Тайловая позиция.</returns>
		private int GetTileSetTilePosition ( TileSet tileSet , long position ) {
			if ( tileSet.Firstgid == tileSet.Lastgid ) return 1;

			var gids = ( tileSet.Lastgid + 1 ) - tileSet.Firstgid;
			var result = Convert.ToInt32 ( gids - ( tileSet.Lastgid - position ) );
			return result;
		}

		/// <summary>
		/// Получить тайлсет по начальному номеру в карте.
		/// </summary>
		/// <param name="model">Модель с данными.</param>
		/// <param name="number">Начальный номер тайла.</param>
		/// <returns>Объект содержащий данные о тайлсете.</returns>
		private TileSet GetTileSet ( JsonLevelModel model , long number ) {
			return model.TileSets
				.Where ( a => number >= a.Firstgid && number <= a.Lastgid )
				.FirstOrDefault ();
		}

		/// <summary>
		/// Получить уникальный идентификатор на основе имени сущности.
		/// </summary>
		/// <param name="name">Имя сущности.</param>
		/// <returns>Уникальный идентификатор.</returns>
		private string GetUniqie ( string name ) {
			return string.IsNullOrEmpty ( name ) ? Guid.NewGuid ().ToString () : name;
		}

	}
}