using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic;
using AbstractGameLogic.GUI;
using GameMathHelpers;
using Microsoft.Xna.Framework.Graphics;
using ShineGame.CommonRoutine;

namespace ShineGame.GUI {

	/// <summary>
	/// Окно.
	/// </summary>
	internal class Window : Element , IGUIWindow {

		private const int DefaultBorderWidth = 8;

		private const int DefaultBorderHeight = 8;

		private const int CountVisualItems = 7;

		private List<IGUIElement> m_Elements = new List<IGUIElement> ();

		private TileManager m_TileManager = new TileManager ();

		private Texture2D m_Texture;

		private VisualContainer m_VisualContainer = new VisualContainer ();

		private int m_TileWidth = DefaultBorderWidth;

		private int m_TileHeight = DefaultBorderHeight;

		/// <summary>
		/// Текст заголовка.
		/// </summary>
		public string CaptionText {
			get;
			set;
		}

		/// <summary>
		/// Последовательность элементов.
		/// </summary>
		public IEnumerable<IGUIElement> Elements {
			get {
				return m_Elements;
			}
		}

		/// <summary>
		/// Добавить элемент.
		/// </summary>
		/// <param name="element">Элемент пользовательского интерфейса.</param>
		public void AddElement ( IGUIElement element ) {
			element.Parent = element;
			m_Elements.Add ( element );
		}

		/// <summary>
		/// Удалить элемент.
		/// </summary>
		/// <param name="element">Элемент пользовательского интерфейса.</param>
		/// <exception cref="ArgumentException"></exception>
		public void RemoveElement ( IGUIElement element ) {
			if ( !m_Elements.Contains ( element ) ) throw new ArgumentException ( "Указанный элемент не привязан к окну." , "element" );

			m_Elements.Remove ( element );
		}

		/// <summary>
		/// Сфокусироваться на элементе.
		/// </summary>
		/// <param name="element">Элемент пользовательского интерфейса.</param>
		/// <exception cref="ArgumentException"></exception>
		public void Focus ( IGUIElement element ) {
			if ( !m_Elements.Contains ( element ) ) throw new ArgumentException ( "Указанный элемент не привязан к окну." , "element" );

			foreach ( var currentElement in m_Elements ) currentElement.IsFocused = false;

			element.IsFocused = true;
		}

		/// <summary>
		/// Добавить элемент в уже существующий элемент окна.
		/// </summary>
		/// <param name="container">Элемент который выступит в роли контейнера.</param>
		/// <param name="innerElement">Вложенный элемент.</param>
		public void AddElementToElement ( IGUIElement container , IGUIElement innerElement ) {
			if ( !m_Elements.Contains ( container ) ) throw new ArgumentException ( "Указанный элемент не привязан к окну." , "element" );

			innerElement.Parent = container;
			m_Elements.Add ( innerElement );
		}

		/// <summary>
		/// Нарисовать окно.
		/// </summary>
		public override void Draw () {
			var pointItems = m_VisualContainer.Items
				.Where ( a => a.FillType == VisualContainerItemFillType.Point );
			var lineItems = m_VisualContainer.Items
				.Where ( a => a.FillType == VisualContainerItemFillType.VerticalLine || a.FillType == VisualContainerItemFillType.HorizontalLine );
			foreach ( var pointItem in pointItems ) {
				var kind = IsFocused ? (int) pointItem.Kind + CountVisualItems : (int) pointItem.Kind;
				GameSpriteBatch.DrawTexture (
					WorldX + ( pointItem.Position * m_TileWidth ) ,
					WorldY + ( pointItem.Line * m_TileHeight ) ,
					m_Texture ,
					m_TileManager.GetTileCoodinates ( kind )
				);
			}
		}

		/// <summary>
		/// Обновить состояние окна.
		/// </summary>
		/// <param name="gamestate">Игровое состояние.</param>
		public override void Update ( IGameState gamestate ) {
		}

		/// <summary>
		/// Инициализация окна.
		/// </summary>
		public override void Initialize () {
			m_Texture = ( Manager as ISkinResources ).Resources.ContainerTexture;

			m_TileManager.Width = m_Texture.Width;
			m_TileManager.Height = m_Texture.Height;
			m_TileManager.TileHeight = DefaultBorderHeight;
			m_TileManager.TileWidth = DefaultBorderWidth;
			m_TileManager.Calculate ();

			m_VisualContainer.SetRectangle ( Width / m_TileManager.TileWidth , Height / m_TileManager.TileHeight );
		}

	}

}

