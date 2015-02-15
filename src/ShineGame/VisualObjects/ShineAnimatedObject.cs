using System;
using System.Collections.Generic;
using System.Linq;
using AbstractGameLogic;
using ShineGame.CommonRoutine;
using Microsoft.Xna.Framework.Graphics;
using GameMathHelpers;
using AbstractGameLogic.ObjectVisual;

namespace ShineGame.VisualObjects {

	/// <summary>
	/// Реализация интерфейса <see cref="AbstractGameLogic.IAnimatedObject"/>.
	/// Класс для анимированного объекта.
	/// </summary>
	public class ShineAnimatedObject : GameObjectVisualImplementation , IAnimatedObject {

		protected List<Texture2D> m_Textures = new List<Texture2D> ();

		protected int m_StartFrame = 0;

		protected int m_EndFrame = 0;

		protected int m_AnimateSpeed = 2;

		protected int m_CurrentFrame = 0;

		protected TimeSpan m_PreviousTime = new TimeSpan ( 0 );

		/// <summary>
		/// Кадры анимации.
		/// </summary>
		public IEnumerable<string> Frames {
			get {
				return m_Textures.Select ( a => a.Name ).ToList ();
			}
		}

		/// <summary>
		/// Диапазон кадров.
		/// </summary>
		public Tuple<int , int> AnimationRange {
			get {
				return new Tuple<int , int> ( m_StartFrame , m_EndFrame );
			}
			set {
				m_StartFrame = value.Item1;
				m_CurrentFrame = m_StartFrame;
				m_EndFrame = value.Item2;
			}
		}

		/// <summary>
		/// Начальный кадр анимации.
		/// </summary>
		public int StartFrame {
			get {
				return m_StartFrame;
			}
			set {
				if ( m_StartFrame < 0 ) throw new ArgumentOutOfRangeException ( "value" );
				m_StartFrame = value;
			}
		}

		/// <summary>
		/// Начальный кадр анимации.
		/// </summary>
		public int EndFrame {
			get {
				return m_EndFrame;
			}
			set {
				if ( m_EndFrame < 0 || m_EndFrame >= m_Textures.Count ) throw new ArgumentOutOfRangeException ( "value" );
				m_EndFrame = value;
			}
		}

		/// <summary>
		/// Скорость анимации.
		/// </summary>
		public int AnimateSpeed {
			get {
				return m_AnimateSpeed;
			}
			set {
				m_AnimateSpeed = value.LimitToRange ( 1 , 6000 );
			}
		}

		/// <summary>
		/// Список кадров анимации.
		/// </summary>
		public string FramesInText {
			get {
				return string.Join ( "," , Frames );
			}
			set {
				m_Textures.Clear ();
				AddFrames ( value.Split ( ',' ) );
			}
		}

		/// <summary>
		/// Добавить кадры.
		/// </summary>
		/// <param name="frames">Последовательность имен кадров.</param>
		public void AddFrames ( IEnumerable<string> frames ) {
			m_Textures = frames
				.Select ( frame => GameContentManager.GetTexture ( frame ) )
				.ToList ();
			var firstTexture = m_Textures.First ();
			Width = firstTexture.Width;
			Height = firstTexture.Height;
		}

		/// <summary>
		/// Нарисовать анимированный объект.
		/// </summary>
		public sealed override void Draw () {
			GameSpriteBatch.DrawTexture ( WorldX - DrawLevel.Viewport.X , WorldY - DrawLevel.Viewport.Y , m_Textures[m_CurrentFrame] );
		}

		/// <summary>
		/// Обновление состояния анимации.
		/// </summary>
		/// <param name="gamestate">Игровое состояние.</param>
		public override void Update ( IGameState gamestate ) {
			RunVisualBehaviours ( gamestate );

			if ( ( gamestate.TotalTime.TotalMilliseconds - m_PreviousTime.TotalMilliseconds ) >= m_AnimateSpeed ) {
				if ( m_CurrentFrame == m_EndFrame ) {
					m_CurrentFrame = m_StartFrame;
				}
				else {
					m_CurrentFrame++;
				}
				m_PreviousTime = gamestate.TotalTime;
			}
		}

		/// <summary>
		/// Прочесть данные из стороннего объекта и
		/// заполнить их внутри себя.
		/// </summary>
		/// <param name="gameObject">Игровой объект.</param>
		public override void CloneGameObjectData ( IGameObject gameObject ) {
			base.CloneGameObjectData ( gameObject );

			var animatedObject = ( gameObject as IAnimatedObject );
			if ( animatedObject == null ) return;

			AnimateSpeed = animatedObject.AnimateSpeed;
			m_Textures = animatedObject.Frames
				.Select ( frame => ContentManager.GetTexture ( frame ) )
				.ToList ();
			AnimationRange = animatedObject.AnimationRange;
		}

	}

}
