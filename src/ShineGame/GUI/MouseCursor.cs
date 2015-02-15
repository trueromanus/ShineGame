using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic;
using AbstractGameLogic.GUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShineGame.CommonRoutine;

namespace ShineGame.GUI {

	/// <summary>
	/// Курсор мыши.
	/// </summary>
	internal sealed class MouseCursor : Element , IMouseCursor {

		private const int SensitiveCursor = 2;

		private const int WidthCursor = 16;

		private const int HeightCursor = 16;

		private Texture2D m_Texture;

		private bool IsLeftMouseClick = false;

		/// <summary>
		/// Включен ли курсор.
		/// </summary>
		public bool IsEnabled {
			get;
			set;
		}

		/// <summary>
		/// Получить элемент с котором пересекается курсор мыши.
		/// </summary>
		/// <returns>Визуальный элемент с которым пересекся курсор мыши.</returns>
		public Tuple<IGUIWindow , IGUIElement> GetHitCursor () {
			var rectangle = new Rectangle {
				X = WorldX ,
				Y = WorldY ,
				Width = SensitiveCursor ,
				Height = SensitiveCursor
			};
			var window = Manager.Windows
				.OrderByDescending ( a => a.ZIndex )
				.FirstOrDefault (
					a =>
						rectangle.Intersects (
							new Rectangle {
								X = a.WorldX ,
								Y = a.WorldY ,
								Width = a.Width ,
								Height = a.Height
							}
						)
				);
			if ( window == null ) return null;
			var element = window.Elements
				.OrderByDescending ( a => a.ZIndex )
				.FirstOrDefault (
					a =>
						rectangle.Intersects (
							new Rectangle {
								X = a.WorldX ,
								Y = a.WorldY ,
								Width = a.Width ,
								Height = a.Height
							}
						)
				);

			return new Tuple<IGUIWindow , IGUIElement> ( window , element );
		}

		/// <summary>
		/// Обновить состояние курсора мыши.
		/// </summary>
		/// <param name="gameState">Игровое состояние.</param>
		public override void Update ( IGameState gameState ) {
			var mousePosition = gameState.InputState.GetMousePosition ();
			WorldX = mousePosition.Item1;
			WorldY = mousePosition.Item2;

			if ( IsLeftMouseClick && gameState.InputState.IsMouseUp ( MouseButtonKey.Left ) && IsEnabled ) {
				var hitCursor = GetHitCursor ();
				if ( hitCursor != null ) {
					Manager.ActivateWindow ( hitCursor.Item1 );
					if ( hitCursor.Item2 != null ) hitCursor.Item1.Focus ( hitCursor.Item2 );
				}
				IsLeftMouseClick = false;
			}
			if ( gameState.InputState.IsMouseDown ( MouseButtonKey.Left ) ) IsLeftMouseClick = true;
		}

		/// <summary>
		/// Нарисовать курсор мыши.
		/// </summary>
		public override void Draw () {
			if ( !IsVisible ) return;

			GameSpriteBatch.DrawTexture (
				WorldX ,
				WorldY ,
				m_Texture ,
				new ShineRectangle {
					X = 0 ,
					Y = 0 ,
					Width = WidthCursor ,
					Height = HeightCursor
				}
			);
		}

		/// <summary>
		/// Инициализация элемента.
		/// </summary>
		public override void Initialize () {
			m_Texture = ( Manager as ISkinResources ).Resources.MouseCursorTexture;
		}

	}

}
