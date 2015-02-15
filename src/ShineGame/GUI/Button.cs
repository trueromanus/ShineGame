using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic;
using AbstractGameLogic.GUI;

namespace ShineGame.GUI {

	/// <summary>
	/// Кнопка.
	/// </summary>
	internal class Button : Element , IGUIButton {

		/// <summary>
		/// Признак того нажата ли кнопка.
		/// </summary>
		public bool IsPressed {
			get;
			set;
		}

		/// <summary>
		/// Текст кнопки.
		/// </summary>
		public string Text {
			get;
			set;
		}

		/// <summary>
		/// Нарисовать элемент.
		/// </summary>
		public override void Draw () {
			
		}

		/// <summary>
		/// Обновить состояние элемента.
		/// </summary>
		/// <param name="inputGamestate">Игровое состояние.</param>
		public override void Update ( IGameState inputGamestate ) {
			if ( IsFocused ) {
				if ( inputGamestate.InputState.IsKeyDown ( KeyboardButtonKey.Enter ) && !IsPressed ) IsPressed = true;
				if ( inputGamestate.InputState.IsKeyUp ( KeyboardButtonKey.Enter ) ) IsPressed = false;

				if ( inputGamestate.InputState.IsMouseDown ( MouseButtonKey.Left ) && !IsPressed ) IsPressed = true;
				if ( inputGamestate.InputState.IsMouseUp ( MouseButtonKey.Left ) ) IsPressed = false;
			}
		}

	}
}
