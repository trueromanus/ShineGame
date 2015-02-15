using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic;

namespace PrisonerLevelBehaviours {

	/// <summary>
	/// Помошник для работы с состоянием ввода.
	/// </summary>
	public class StateInputHelper {

		private List<KeyboardButtonKey> m_KeyboardStates = new List<KeyboardButtonKey> ();

		private List<MouseButtonKey> m_MouseStates = new List<MouseButtonKey> ();

		private Dictionary<int , bool> m_LastStates = new Dictionary<int , bool> ();

		/// <summary>
		/// Состояния клавиатуры.
		/// </summary>
		public ICollection<KeyboardButtonKey> KeyboardStates {
			get {
				return m_KeyboardStates;
			}
		}

		/// <summary>
		/// Состояния мыши.
		/// </summary>
		public ICollection<MouseButtonKey> MouseStates {
			get {
				return m_MouseStates;
			}
		}

		/// <summary>
		/// Сохранить текущее состояние.
		/// </summary>
		/// <param name="inputState">Состояние ввода.</param>
		public void SaveCurrentState ( IInputGameState inputState ) {
			foreach ( var keyState in m_KeyboardStates ) m_LastStates[(int) keyState] = inputState.IsKeyDown ( keyState );
			foreach ( var mouseState in m_MouseStates ) m_LastStates[(int) mouseState] = inputState.IsMouseDown ( mouseState );
		}

		/// <summary>
		/// Нажата ли клавиша.
		/// </summary>
		/// <param name="key">Клавиша.</param>
		/// <returns>Признак того что клавиша была нажата и отпущена.</returns>
		public bool IsKeyPress ( KeyboardButtonKey key ) {
			return m_LastStates[(int) key];
		}

	}

}
