using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrisonerLevelBehaviours.Models {

	/// <summary>
	/// Модель управлением движения.
	/// </summary>
	public class MovingControllerModel {

		private bool m_IsLeft;
		private bool m_IsRight;
		private bool m_IsTop;
		private bool m_IsBottom;

		/// <summary>
		/// Влево.
		/// </summary>
		public bool IsLeft {
			get {
				return m_IsLeft;
			}
			set {
				m_IsLeft = value;
				if ( m_IsLeft ) m_IsRight = false;
			}
		}

		/// <summary>
		/// Вправо.
		/// </summary>
		public bool IsRight {
			get {
				return m_IsRight;
			}
			set {
				m_IsRight = value;
				if ( m_IsRight ) m_IsLeft = false;
			}
		}

		/// <summary>
		/// Вверх.
		/// </summary>
		public bool IsTop {
			get {
				return m_IsTop;
			}
			set {
				m_IsTop = value;
				if ( m_IsTop ) m_IsBottom = false;
			}
		}

		/// <summary>
		/// Вниз.
		/// </summary>
		public bool IsBottom {
			get {
				return m_IsBottom;
			}
			set {
				m_IsBottom = value;
				if ( m_IsBottom ) m_IsTop = false;
			}
		}

		/// <summary>
		/// Сбросить значения.
		/// </summary>
		public void Reset () {
			m_IsLeft = false;
			m_IsRight = false;
			m_IsTop = false;
			m_IsBottom = false;
		}

	}

}
