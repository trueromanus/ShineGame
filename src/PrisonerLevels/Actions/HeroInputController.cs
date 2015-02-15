using System;
using System.Collections.Generic;
using System.Linq;
using AbstractGameLogic;
using AbstractGameLogic.Attributes;

namespace PrisonerLevelBehaviours.Actions {

	/// <summary>
	/// Контролер управления.
	/// </summary>
	[GameEvent ( Name = HeroInputController.PressEnterEvent , Description = "Клавиша ввод нажата и отпущена." )]
	[GameEvent ( Name = HeroInputController.PressLeftEvent , Description = "Клавиша влево нажата и отпущена." )]
	[GameEvent ( Name = HeroInputController.PressRightEvent , Description = "Клавиша вправо нажата и отпущена." )]
	[GameEvent ( Name = HeroInputController.PressUpEvent , Description = "Клавиша вверх нажата и отпущена." )]
	[GameEvent ( Name = HeroInputController.PressDownEvent , Description = "Клавиша вниз нажата и отпущена." )]
	[GameEvent ( Name = HeroInputController.KeydownLeftEvent , Description = "Клавиша влево нажата." )]
	[GameEvent ( Name = HeroInputController.KeydownRightEvent , Description = "Клавиша вправо нажата." )]
	[GameEvent ( Name = HeroInputController.KeydownUpEvent , Description = "Клавиша вверх нажата." )]
	[GameEvent ( Name = HeroInputController.KeydownDownEvent , Description = "Клавиша вниз нажата." )]
	[GameEvent ( Name = HeroInputController.PressSpaceEvent , Description = "Клавиша пробел нажата и отпущена." )]
	[GameEvent ( Name = HeroInputController.PressBackspaceEvent , Description = "Клавиша backspace нажата и отпущена." )]
	[ObjectBindBehaviour ( Name = HeroInputController.NameBehaviour , Description = "Поведения обрабатывающее ввод от пользователя." )]
	public class HeroInputController : ObjectBehaviour {

		public const string PressEnterEvent = "pressEnter";

		public const string PressLeftEvent = "pressLeft";

		public const string PressRightEvent = "pressRight";

		public const string PressUpEvent = "pressUp";

		public const string PressDownEvent = "pressDown";

		public const string KeydownLeftEvent = "keydownLeft";

		public const string KeydownRightEvent = "keydownRight";

		public const string KeydownUpEvent = "keydownUp";

		public const string KeydownDownEvent = "keydownDown";

		public const string PressSpaceEvent = "pressSpace";

		public const string PressBackspaceEvent = "pressBackSpace";

		public const string NameBehaviour = "HeroInputController";

		private IDictionary<KeyboardButtonKey , bool> m_KeyboardKeys = new Dictionary<KeyboardButtonKey , bool> ();

		/// <summary>
		/// Обновляем состояние ввода.
		/// </summary>
		private void RefreshKeyboardStateInput ( IGameState gameState ) {
			var values = Enum.GetValues ( typeof ( KeyboardButtonKey ) )
				.OfType<KeyboardButtonKey> ();
			foreach ( var value in values ) {
				KeyboardButtonKey currentKey = (KeyboardButtonKey) value;
				m_KeyboardKeys[currentKey] = IsKeyDown ( (KeyboardButtonKey) value , gameState );
			}
		}

		/// <summary>
		/// Инициализация визуального объекта.
		/// </summary>
		public override void InitializeVisualObject () {
			var keyStates = Enum.GetValues ( typeof ( KeyboardButtonKey ) )
				.OfType<KeyboardButtonKey> ();
			foreach ( var keyState in keyStates ) m_KeyboardKeys.Add ( keyState , false );
		}

		/// <summary>
		/// Признак того была ли нажата клавиша/кнопка.
		/// </summary>
		/// <param name="gameState">Игровое состояние.</param>
		/// <param name="key">Обрабатываемая клавиша.</param>
		private bool IsKeyPressed ( KeyboardButtonKey key , IGameState gameState ) {
			return m_KeyboardKeys[key] && !gameState.InputState.IsKeyDown ( key );
		}

		/// <summary>
		/// Признак того нажата ли клавиша/кнопка в данный момент.
		/// </summary>
		/// <param name="gameState">Игровое состояние.</param>
		/// <param name="key">Обрабатываемая клавиша.</param>
		private bool IsKeyDown ( KeyboardButtonKey key , IGameState gameState ) {
			return gameState.InputState.IsKeyDown ( key );
		}

		/// <summary>
		/// Обновить состояние объекта.
		/// </summary>
		/// <param name="object">Объект чье поведение необходимо обновить.</param>
		/// <param name="gameState">Игровое состояние.</param>
		public override void Update ( IGameState gameState ) {
			if ( IsKeyPressed ( KeyboardButtonKey.Left , gameState ) ) ThrowedEvent = HeroInputController.PressLeftEvent;
			if ( IsKeyPressed ( KeyboardButtonKey.Right , gameState ) ) ThrowedEvent = HeroInputController.PressRightEvent;
			if ( IsKeyPressed ( KeyboardButtonKey.Up , gameState ) ) ThrowedEvent = HeroInputController.PressUpEvent;
			if ( IsKeyPressed ( KeyboardButtonKey.Down , gameState ) ) ThrowedEvent = HeroInputController.PressDownEvent;

			if ( IsKeyDown ( KeyboardButtonKey.Left , gameState ) ) ThrowedEvent = HeroInputController.KeydownLeftEvent;
			if ( IsKeyDown ( KeyboardButtonKey.Right , gameState ) ) ThrowedEvent = HeroInputController.KeydownRightEvent;
			if ( IsKeyDown ( KeyboardButtonKey.Up , gameState ) ) ThrowedEvent = HeroInputController.KeydownUpEvent;
			if ( IsKeyDown ( KeyboardButtonKey.Down , gameState ) ) ThrowedEvent = HeroInputController.KeydownDownEvent;

			if ( IsKeyPressed ( KeyboardButtonKey.Space , gameState ) ) ThrowedEvent = HeroInputController.PressSpaceEvent;
			if ( IsKeyPressed ( KeyboardButtonKey.Enter , gameState ) ) ThrowedEvent = HeroInputController.PressEnterEvent;
			if ( IsKeyPressed ( KeyboardButtonKey.Backspace , gameState ) ) ThrowedEvent = HeroInputController.PressBackspaceEvent;

			RefreshKeyboardStateInput ( gameState );
		}

	}

}
