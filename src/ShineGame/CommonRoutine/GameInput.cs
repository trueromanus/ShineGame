using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace ShineGame.CommonRoutine {

	/// <summary>
	/// Работа с устройствами ввода.
	/// </summary>
	public static class GameInput {

		/// <summary>
		/// Получить все состояния у устройств ввода.
		/// </summary>
		/// <returns>Состояние устройств ввода.</returns>
		public static GameInputState GetGameState () {

			return new GameInputState {
				Keyboard = Keyboard.GetState () ,
				Mouse = Mouse.GetState () ,
				GamePadOnePlayer = GamePad.GetState ( PlayerIndex.One ) ,
				GamePadTwoPlayer = GamePad.GetState ( PlayerIndex.Two )
			};

		}

	}
}
