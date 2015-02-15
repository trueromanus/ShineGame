using System;
using System.Linq;
using AbstractGameLogic;
using Microsoft.Xna.Framework.Graphics;
using ShineGame.CommonRoutine;
using Microsoft.Xna.Framework;
using System.Runtime.Serialization;
using AbstractGameLogic.ObjectVisual;

namespace ShineGame.VisualObjects {

	/// <summary>
	/// Реализация интерфейса <see cref="AbstractGameLogic.IText"/> объекта содержащего текст.
	/// </summary>
	public class ShineText : GameObjectVisualImplementation , IText {

		private SpriteFont m_Font;

		private string m_FontName = "";

		/// <summary>
		/// Текст сообщения.
		/// </summary>
		public string Message {
			get;
			set;
		}

		/// <summary>
		/// Шрифт.
		/// </summary>
		public string Font {
			get {
				return m_FontName;
			}
			set {
				m_FontName = value;
				m_Font = ContentManager.GetFont ( m_FontName );
			}
		}

		/// <summary>
		/// Размер шрифта.
		/// </summary>
		public int Size {
			get;
			set;
		}

		/// <summary>
		/// Цвет текста.
		/// </summary>
		public IColor Color {
			get;
			set;
		}

		/// <summary>
		/// Конструктор.
		/// </summary>
		public ShineText () {
			Color = ColorImplementation.GetColor ( Microsoft.Xna.Framework.Color.White );
		}

		/// <summary>
		/// Нарисовать текст.
		/// </summary>
		public override void Draw () {
			var localX = WorldX - DrawLevel.Viewport.X;
			var localY = WorldY - DrawLevel.Viewport.Y;
			GameSpriteBatch.DrawText ( localX , localY , Message , m_Font , new Color ( Color.RChannel , Color.GChannel , Color.BChannel , Color.AChannel ) );
		}

		/// <summary>
		/// Обновить состояние объекта текста.
		/// </summary>
		/// <param name="inputGamestate">Состояние игры.</param>
		public override void Update ( IGameState inputGamestate ) {
			RunVisualBehaviours ( inputGamestate );
		}

		/// <summary>
		/// Прочесть данные из стороннего объекта и
		/// заполнить их внутри себя.
		/// </summary>
		/// <param name="gameObject">Игровой объект.</param>
		public override void CloneGameObjectData ( IGameObject gameObject ) {
			base.CloneGameObjectData ( gameObject );

			var text = ( gameObject as IText );
			if ( text == null ) return;

			Color = text.Color;
			Font = text.Font;
			Message = text.Message;
			Size = text.Size;
		}

	}
}
