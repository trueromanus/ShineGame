using System;
using System.Linq;
using AbstractGameLogic;
using AbstractGameLogic.Attributes;
using AbstractGameLogic.State;

namespace PrisonerLevelBehaviours.World {

	/// <summary>
	/// Поведение для камеры.
	/// </summary>
	[GameState ( Name = Camera.WorldXState , Description = "Мировая координата камеры по оси X." )]
	[GameState ( Name = Camera.WorldYState , Description = "Мировая координата камеры по оси Y." )]
	[GameState ( Name = Camera.NameAttachedObjectState , Description = "Имя привязанного к камере объекта." )]
	[GameAction ( Name = Camera.SetActiveCameraAction , Description = "Установить эту камеру как активную." )]
	[ObjectBindBehaviour ( Name = Camera.NameBehaviour , Description = "Поведение для обработки событий на уровне мира вне зависимости от объекта к которому привязано." )]
	public class Camera : ObjectBehaviour {

		public const string NameBehaviour = "Camera";

		public const string SetActiveCameraAction = "setActiveCamera";

		public const string WorldXState = "WorldX";

		public const string WorldYState = "WorldY";

		public const string NameAttachedObjectState = "AttachedObject";

		private ICamera m_Camera;

		/// <summary>
		/// Обработчик событий.
		/// </summary>
		/// <param name="event"></param>
		public override void EventHandler ( IEvent @event ) {
			if ( @event.Action == SetActiveCameraAction ) {
				VisualObject.DrawLevel.GameWorld.ActiveCamera = m_Camera;
			}
		}

		/// <summary>
		/// Инициализация визуального объекта.
		/// </summary>
		/// <exception cref="InvalidOperationException"></exception>
		public override void InitializeVisualObject () {
			m_Camera = m_FactoryHost.GameObjects.CreateCamera ();
			m_Camera.X = VisualObject.States
				.Where ( a => a.Name == WorldXState )
				.Select ( a => Convert.ToInt32 ( a.Value ) )
				.FirstOrDefault ();
			m_Camera.Y = VisualObject.States
				.Where ( a => a.Name == WorldYState )
				.Select ( a => Convert.ToInt32 ( a.Value ) )
				.FirstOrDefault ();
			m_Camera.Name = VisualObject.Name;
			var nameAttachedObject = VisualObject.States
				.Where ( a => a.Name == NameAttachedObjectState )
				.Select ( a => a.Value.ToString () )
				.FirstOrDefault ();
			m_Camera.Mode = nameAttachedObject == null ? CameraMode.Free : CameraMode.AttachedWithObject;

			if ( !string.IsNullOrEmpty ( nameAttachedObject ) ) {
				m_Camera.AttachedMode = CameraAttachedMode.Center;
				var attachedObject = VisualObject.DrawLevel.Objects.FirstOrDefault ( a => a.Name == nameAttachedObject );
				if ( attachedObject == null ) throw new InvalidOperationException ( string.Format ( "Камера привязана к объекту {0} который не существует." , nameAttachedObject ) );
				m_Camera.AttachObject = attachedObject;
			}

			m_Camera.World = VisualObject.DrawLevel.GameWorld;
			VisualObject.DrawLevel.GameWorld.Cameras.Add ( m_Camera );
		}

	}
}
