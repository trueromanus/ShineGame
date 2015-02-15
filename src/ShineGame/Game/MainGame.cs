using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic;
using ShineGame.GameWorlds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShineGame.CommonRoutine;
using Microsoft.Xna.Framework.Input;
using AbstractGameLogic.Factories;
using System.Reflection;
using AbstractGameLogic.GUI;
using ShineGame.Factories;

namespace ShineGame.Game {

	/// <summary>
	/// Класс представляющий игру.
	/// </summary>
	public class MainGame : Microsoft.Xna.Framework.Game {

		protected GraphicsDeviceManager m_GraphicDeviceManager;

		protected SpriteBatch m_SpriteBatch;

		protected IFactoryHost m_FactoryHost = new FactoryHost ();

		private List<IGameWorld> m_Worlds = new List<IGameWorld> ();

		private List<ICamera> m_Cameras = new List<ICamera> ();

		private IGameWorld m_ActiveWorld = null;

		private Color m_BackgroundColor = Color.Black;

		private bool m_IsLoadedContent = false;

		/// <summary>
		/// Цвет заливки фона.
		/// </summary>
		public Color BackgroundColor {
			get {
				return m_BackgroundColor;
			}
			set {
				m_BackgroundColor = value;
			}
		}

		/// <summary>
		/// Текущий игровой мир.
		/// </summary>
		public IGameWorld ActiveGameWorld {
			get {
				return m_ActiveWorld;
			}
		}

		/// <summary>
		/// Графический менеджер.
		/// </summary>
		public GraphicsDeviceManager GraphicsManager {
			get {
				return m_GraphicDeviceManager;
			}
		}

		/// <summary>
		/// Хост фабрик.
		/// </summary>
		public IFactoryHost FactoryHost {
			get {
				return m_FactoryHost;
			}
		}

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="isWindowed">Признак того что необходимо запустить игру в оконном режиме.</param>
		/// <param name="isDeveloper">Признак того включен ли режим разработки.</param>
		public MainGame ( bool isWindowed , bool isDeveloper ) {
			m_GraphicDeviceManager = new GraphicsDeviceManager ( this );
			Content.RootDirectory = "Content";
			GameContentManager.Manager = Content;
			GameHost.Game = this;
			//определяем размеры буферов вывода графики
			m_GraphicDeviceManager.PreferredBackBufferWidth = 1024;
			m_GraphicDeviceManager.PreferredBackBufferHeight = 768;

			if ( isDeveloper ) IsMouseVisible = true;

			if ( !isWindowed ) {
				m_GraphicDeviceManager.IsFullScreen = true;
				m_GraphicDeviceManager.ApplyChanges ();
			}

			//меняем временные промежутки рендеринга
			//TargetElapsedTime = new TimeSpan ( 0 , 0 , 0 , 0 , 40 );
			//TimeSpan.FromTicks ( TimeSpan.TicksPerSecond / 30 );

			m_FactoryHost.Behaviour = ShineGameObjectFactories.CreateBehaviourFactory ();
			m_FactoryHost.GUI = ShineGameObjectFactories.CreateGUIFactory ();
			m_FactoryHost.Physics = ShineGameObjectFactories.CreatePhysicsFactory ();
			m_FactoryHost.GameObjects = ShineGameObjectFactories.CreateGameObjectFactory ();
			m_FactoryHost.States = ShineGameObjectFactories.CreateStateFactory ();
			m_FactoryHost.Levels = ShineGameObjectFactories.CreateLevelFactory ();
		}

		/// <summary>
		/// Загрузить содержимое.
		/// </summary>
		protected override void LoadContent () {
			m_SpriteBatch = new SpriteBatch ( GraphicsDevice );
			GameSpriteBatch.SpriteBatch = m_SpriteBatch;

			m_Worlds.AddRange ( LoadWorlds () );

			foreach ( var world in m_Worlds ) {
				world.ViewportWidth = m_GraphicDeviceManager.PreferredBackBufferWidth;
				world.ViewportHeight = m_GraphicDeviceManager.PreferredBackBufferHeight;
				LoadWorldContent ( world.Name );
			}

			m_IsLoadedContent = true;

			//var width = 800;
			//var height = 600;

			//GraphicsDevice.Viewport = new Viewport {
			//	X = GraphicsDevice.PresentationParameters.BackBufferWidth / 2 - width / 2 ,
			//	Y = GraphicsDevice.PresentationParameters.BackBufferHeight / 2 - height / 2 ,
			//	Width = width ,
			//	Height = height ,
			//	MinDepth = 0 ,
			//	MaxDepth = 1
			//};
		}

		/// <summary>
		/// Загрузить миры игры.
		/// </summary>
		/// <returns>Последовательность миров.</returns>
		protected virtual IEnumerable<IGameWorld> LoadWorlds () {
			throw new NotImplementedException ();
		}

		/// <summary>
		/// Загрузить содержимое для игрового мира.
		/// </summary>
		/// <param name="worldName">Имя игрового мира.</param>
		private void LoadWorldContent ( string worldName ) {
			var drawLevels = LoadDrawLevels ( worldName );
			foreach ( var drawLevel in drawLevels ) {
				m_ActiveWorld.Add ( drawLevel );
			}
		}

		/// <summary>
		/// Загрузка графических слоев в игровой мир.
		/// </summary>
		public virtual IEnumerable<IDrawLevel> LoadDrawLevels ( string worldName ) {
			throw new NotImplementedException ();
		}

		/// <summary>
		/// Обновление состояния игры.
		/// </summary>
		protected override void Update ( GameTime gameTime ) {
			if ( m_ActiveWorld != null ) m_ActiveWorld.Update ( gameTime.TotalGameTime , gameTime.ElapsedGameTime );

			base.Update ( gameTime );
		}


		/// <summary>
		/// Метод рисования на экране текущего состояния игры.
		/// </summary>		
		protected override void Draw ( GameTime gameTime ) {
			GraphicsDevice.Clear ( m_BackgroundColor );
			//var matrix = Matrix.CreateScale ( 0.8f , 1 , 1 ) * Matrix.CreateTranslation ( 100 , 0 , 0 );
			//m_SpriteBatch.Begin ( SpriteSortMode.Deferred , BlendState.AlphaBlend , SamplerState.LinearClamp , DepthStencilState.Default , RasterizerState.CullNone , null , matrix );
			m_SpriteBatch.Begin ();
			if ( m_ActiveWorld != null ) m_ActiveWorld.Draw ( gameTime.TotalGameTime , gameTime.ElapsedGameTime );
			DrawSprites ( gameTime );
			m_SpriteBatch.End ();

			DrawAdditional ( gameTime );

			base.Draw ( gameTime );
		}

		/// <summary>
		/// Дополнительное рисование вне спрайтового контекста.
		/// </summary>
		/// <param name="gameTime">Сведения об игровом времени.</param>
		public virtual void DrawAdditional ( GameTime gameTime ) {
		}

		/// <summary>
		/// Дополнительное рисование внутри спрайтового контекста.
		/// </summary>
		/// <param name="gameTime">Сведения об игровом времени.</param>
		public virtual void DrawSprites ( GameTime gameTime ) {
		}

		/// <summary>
		/// Добавить игровой мир.
		/// </summary>
		/// <param name="gameWorld">Игровой мир.</param>
		public void AddWorld ( IGameWorld gameWorld ) {
			if ( string.IsNullOrEmpty ( gameWorld.Name ) ) throw new ArgumentException ( "Имя мира не может быть пустым." , "gameWorld.Name" );

			gameWorld.ViewportWidth = m_GraphicDeviceManager.PreferredBackBufferWidth;
			gameWorld.ViewportHeight = m_GraphicDeviceManager.PreferredBackBufferHeight;

			m_Worlds.Add ( gameWorld );

			if ( m_IsLoadedContent ) LoadWorldContent ( gameWorld.Name );
		}

		/// <summary>
		/// Удалить игровой мир.
		/// </summary>
		/// <param name="name">Имя игрового мира.</param>
		public void DeleteWorld ( string name ) {
			var world = m_Worlds.Where ( a => a.Name == name ).FirstOrDefault ();
			if ( world != null ) {
				world.FreeResources ();
				m_Worlds.Remove ( world );
			}
		}

		/// <summary>
		/// Установить активный игровой мир.
		/// </summary>
		/// <param name="name">Имя игрового мира.</param>
		public void SetActiveWorld ( string name ) {
			var world = m_Worlds.Where ( a => a.Name == name ).FirstOrDefault ();
			if ( world != null ) {
				m_ActiveWorld = world;
			}
			else {
				m_ActiveWorld = null;
			}
		}

		/// <summary>
		/// Добавить сборки с поведениями.
		/// </summary>
		/// <param name="behaviourAssemblys">Последовательность сборок с поведениями.</param>
		public void AddBehavoiurAssemblys ( IEnumerable<Assembly> behaviourAssemblys ) {
			GameContentManager.BehaviourLibrarys = behaviourAssemblys;
		}

	}

}
