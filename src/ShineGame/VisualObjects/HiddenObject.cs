using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic.ObjectVisual;
using AbstractGameLogic;
using AbstractGameLogic.ObjectBehavior;

namespace ShineGame.VisualObjects {

	/// <summary>
	/// Скрытый объект.
	/// </summary>
	public class HiddenObject : GameObjectVisualImplementation , IHidden {

		/// <summary>
		/// Нарисовать объект.
		/// </summary>
		public override void Draw () {
			//скрытые объекты не рисуются
		}

		/// <summary>
		/// Обновление состояния объекта.
		/// </summary>
		/// <param name="inputGamestate"></param>
		public override void Update ( IGameState inputGamestate ) {
			RunVisualBehaviours ( inputGamestate );
		}

		/// <summary>
		/// Клонировать данные из другого объекта.
		/// </summary>
		/// <param name="gameObject">Игровой объект для клонирования данных.</param>
		public override void CloneGameObjectData ( IGameObject gameObject ) {
			base.CloneGameObjectData ( gameObject );

			var hidden = ( gameObject as IHidden );
			if ( hidden == null ) return;

			Width = hidden.Width;
			Height = hidden.Height;

		}

	}

}
