using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractGameLogic;

namespace ShineGame.CommonRoutine {
	
	/// <summary>
	/// Игровое состояние.
	/// </summary>
	public class GameState : IGameState {

		/// <summary>
		/// Сколько всего прошло времени с момента запуска программы.
		/// </summary>
		public TimeSpan TotalTime {
			get;
			set;
		}

		/// <summary>
		/// Cколько прошло времени с предыдущего кадра.
		/// </summary>		
		public TimeSpan ElapsedTime {
			get;
			set;
		}

		/// <summary>
		/// Состояние устройств ввода.
		/// </summary>		
		public IInputGameState InputState {
			get;
			set;
		}

		/// <summary>
		/// Ширина области вывода.
		/// </summary>
		public int ViewportWidth {
			get;
			set;
		}

		/// <summary>
		/// Высота области вывода.
		/// </summary>
		public int ViewportHeight {
			get;
			set;
		}

		/// <summary>
		/// Максимальный размер мира по оси X.
		/// </summary>
		public int WorldXMax {
			get;
			set;
		}

		/// <summary>
		/// Максимальный размер мира по оси Y.
		/// </summary>
		public int WorldYMax {
			get;
			set;
		}
	}
}
