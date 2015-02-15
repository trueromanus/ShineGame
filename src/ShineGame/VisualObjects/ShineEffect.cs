using System;
using AbstractGameLogic;
using Microsoft.Xna.Framework;
using ProjectMercury;
using ProjectMercury.Renderers;
using ShineGame.CommonRoutine;
using GameMathHelpers;
using AbstractGameLogic.ObjectVisual;

namespace ShineGame.VisualObjects {

	/// <summary>
	/// Базовый эффект со стеком объектов для визуализации.
	/// </summary>
	internal sealed class ShineEffect : GameObjectVisualImplementation , IEffect , IDisposable {

		private ParticleEffect m_ParticleEffect;

		private SpriteBatchRenderer renderer = new SpriteBatchRenderer ();

		/// <summary>
		/// Время жизни объекта.
		/// </summary>
		private int m_TimeToLife = 20;

		/// <summary>
		/// Считчик времени.
		/// </summary>
		private int m_TimeCounter = 0;

		/// <summary>
		/// Конструктор.
		/// </summary>
		public ShineEffect () {
			Width = 400;
			Height = 400;
		}

		/// <summary>
		/// Время жизни объект эффекта.
		/// </summary>
		public int TimeToLife {
			get {
				return m_TimeToLife;
			}
			set {
				m_TimeToLife = value.LimitToRange ( 1 , 30000 );
			}
		}

		/// <summary>
		/// Прототип объекта эффекта.
		/// </summary>
		public string EffectName {
			get {
				return m_ParticleEffect.Name;
			}
			set {
				m_ParticleEffect = ContentManager.GetEffect ( value );
				m_ParticleEffect.Initialise ();
				m_ParticleEffect.LoadContent ( GameContentManager.Manager );
			}
		}

		/// <summary>
		/// Нарисовать эффект.
		/// </summary>
		public override void Draw () {
			var localX = WorldX - DrawLevel.Viewport.X;
			var localY = WorldY - DrawLevel.Viewport.Y;

			if ( m_TimeCounter < m_TimeToLife ) m_ParticleEffect.Trigger ( new Vector2 ( localX , localY ) );
			
			if ( m_ParticleEffect != null ) renderer.RenderEffect ( m_ParticleEffect , GameSpriteBatch.SpriteBatch );
		}

		/// <summary>
		/// Обновить состояние эффекта.
		/// </summary>
		/// <param name="inputGamestate">Состояние игры.</param>
		public override void Update ( IGameState inputGamestate ) {
			RunVisualBehaviours ( inputGamestate );

			m_ParticleEffect.Update ( (float) inputGamestate.ElapsedTime.TotalSeconds );
			m_TimeCounter += Convert.ToInt32 ( inputGamestate.ElapsedTime.TotalMilliseconds );
		}

		/// <summary>
		/// Чистим за собой.
		/// </summary>
		public void Dispose () {
			Dispose ( true );
			GC.SuppressFinalize ( this );
			
		}

		/// <summary>
		/// Чистим за собой.
		/// </summary>
		private void Dispose ( bool isDispose ) {
			if ( isDispose ) renderer.Dispose ();
		}

		

	}

}
