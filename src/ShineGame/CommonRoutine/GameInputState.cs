using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic;
using Microsoft.Xna.Framework.Input;

namespace ShineGame.CommonRoutine {
	
	/// <summary>
	/// Состояние устройств ввода.
	/// </summary>
	public class GameInputState : IInputGameState {

		/// <summary>
		/// Клавиатура.
		/// </summary>
		public KeyboardState Keyboard {
			get;
			set;
		}

		/// <summary>
		/// Мышь.
		/// </summary>
		public MouseState Mouse {
			get;
			set;
		}

		/// <summary>
		/// Джойстик первого игрока.
		/// </summary>
		public GamePadState GamePadOnePlayer {
			get;
			set;
		}

		/// <summary>
		/// Джойстик второго игрока.
		/// </summary>
		public GamePadState GamePadTwoPlayer {
			get;
			set;
		}

		/// <summary>
		/// Джойстик третьего игрока.
		/// </summary>
		public GamePadState GamePadThreePlayer {
			get;
			set;
		}

		/// <summary>
		/// Джойстик четвертого игрока.
		/// </summary>
		public GamePadState GamePadFooPlayer {
			get;
			set;
		}

		/// <summary>
		/// Признак того нажата ли клавиша.
		/// </summary>
		/// <param name="key">Имя клавиши.</param>
		public bool IsKeyDown ( KeyboardButtonKey key ) {
			switch ( key ) {
				case KeyboardButtonKey.Left:
					return Keyboard.IsKeyDown ( Keys.Left );
				case KeyboardButtonKey.Right:
					return Keyboard.IsKeyDown ( Keys.Right );
				case KeyboardButtonKey.Up:
					return Keyboard.IsKeyDown ( Keys.Up );
				case KeyboardButtonKey.Down:
					return Keyboard.IsKeyDown ( Keys.Down );
				case KeyboardButtonKey.Enter:
					return Keyboard.IsKeyDown ( Keys.Enter );
				case KeyboardButtonKey.Backspace:
					return Keyboard.IsKeyDown ( Keys.Back );
				case KeyboardButtonKey.Space:
					return Keyboard.IsKeyDown ( Keys.Space );
				case KeyboardButtonKey.Esc:
					return Keyboard.IsKeyDown ( Keys.Escape );
				default:
					return false;
			}
		}

		/// <summary>
		/// Признак того были ли отпущена клавиша.
		/// </summary>
		/// <param name="key">Имя клавиши.</param>		
		public bool IsKeyUp ( KeyboardButtonKey key ) {
			switch ( key ) {
				case KeyboardButtonKey.Left:
					return Keyboard.IsKeyUp ( Keys.Left );
				case KeyboardButtonKey.Right:
					return Keyboard.IsKeyUp ( Keys.Right );
				case KeyboardButtonKey.Up:
					return Keyboard.IsKeyUp ( Keys.Up );
				case KeyboardButtonKey.Down:
					return Keyboard.IsKeyUp ( Keys.Down );
				case KeyboardButtonKey.Enter:
					return Keyboard.IsKeyUp ( Keys.Enter );
				case KeyboardButtonKey.Backspace:
					return Keyboard.IsKeyUp ( Keys.Back );
				case KeyboardButtonKey.Space:
					return Keyboard.IsKeyUp ( Keys.Space );
				case KeyboardButtonKey.Esc:
					return Keyboard.IsKeyUp ( Keys.Escape );
				default:
					return false;
			}
		}

		/// <summary>
		/// Проверка нажата ли клавиша мыши.
		/// </summary>
		/// <param name="key">Клавиша мыши для проверки.</param>
		/// <returns>Признак того нажата ли клавиша мыши.</returns>
		public bool IsMouseDown ( MouseButtonKey key ) {
			switch ( key ) {
				case MouseButtonKey.Left:
					return Mouse.LeftButton == ButtonState.Pressed;
				case MouseButtonKey.Right:
					return Mouse.RightButton == ButtonState.Pressed;
				case MouseButtonKey.Middle:
					return Mouse.MiddleButton == ButtonState.Pressed;
			}
			return false;
		}

		/// <summary>
		/// Проверка отпущена ли клавиша мыши.
		/// </summary>
		/// <param name="key">Клавиша мыши для проверки.</param>
		/// <returns>Признак того нажата ли клавиша мыши.</returns>
		public bool IsMouseUp ( MouseButtonKey key ) {
			switch ( key ) {
				case MouseButtonKey.Left:
					return Mouse.LeftButton == ButtonState.Released;
				case MouseButtonKey.Right:
					return Mouse.RightButton == ButtonState.Released;
				case MouseButtonKey.Middle:
					return Mouse.MiddleButton == ButtonState.Released;
			}
			return false;
		}

		/// <summary>
		/// Получить координаты мыши.
		/// </summary>
		/// <returns>Координаты мыши.</returns>
		public Tuple<int , int> GetMousePosition () {
			return new Tuple<int , int> ( Mouse.X , Mouse.Y );
		}
	}
}
