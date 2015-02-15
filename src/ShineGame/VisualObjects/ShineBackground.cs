using AbstractGameLogic;
using Microsoft.Xna.Framework.Graphics;
using ShineGame.CommonRoutine;
using AbstractGameLogic.ObjectVisual;

namespace ShineGame.VisualObjects {

	/// <summary>
	/// Реализация по умолчанию для фона.
	/// </summary>
	public class ShineBackground : GameObjectVisualImplementation , IBackground {

		protected Texture2D m_BackgroundTexture;

		private string m_Image;

		/// <summary>
		/// Имя изображения фона.
		/// </summary>
		public string Image {
			get {
				return m_Image;
			}
			set {
				m_BackgroundTexture = GameContentManager.Manager.Load<Texture2D> ( value );
				m_Image = value;
			}
		}

		/// <summary>
		/// Обновить состояние фона.
		/// </summary>
		/// <param name="inputGamestate">Состояние устрйоств ввода.</param>
		public override void Update ( IGameState inputGamestate ) {
			RunVisualBehaviours ( inputGamestate );

			Width = inputGamestate.WorldXMax;
			Height = inputGamestate.WorldYMax;
		}

		/// <summary>
		/// Нарисовать фон.
		/// </summary>
		/// <param name="localX">Локальные координата по оси X.</param>
		/// <param name="localY">Локальные координата по оси Y.</param>
		public override void Draw () {
			GameSpriteBatch.DrawTexture ( 0 , 0 , m_BackgroundTexture );
		}

		/// <summary>
		/// Прочесть данные из стороннего объекта и
		/// заполнить их внутри себя.
		/// </summary>
		/// <param name="gameObject">Игровой объект.</param>
		public override void CloneGameObjectData ( IGameObject gameObject ) {
			base.CloneGameObjectData ( gameObject );

			var background = ( gameObject as IBackground );
			if ( background == null ) return;

			Image = background.Image;
		}

	}
}
