using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractGameLogic {
	
	/// <summary>
	/// Текущее состояние игры.
	/// </summary>
	public interface IGameState {

		/// <summary>
		/// Сколько всего прошло времени с момента запуска программы.
		/// </summary>
		TimeSpan TotalTime {
			get;
			set;
		}

		/// <summary>
		/// Cколько прошло времени с предыдущего кадра.
		/// </summary>
		TimeSpan ElapsedTime {
			get;
			set;
		}

		/// <summary>
		/// Состояние устройств ввода.
		/// </summary>
		IInputGameState InputState {
			get;
			set;
		}

		/// <summary>
		/// Ширина области вывода.
		/// </summary>
		int ViewportWidth {
			get;
			set;
		}

		/// <summary>
		/// Высота области вывода.
		/// </summary>
		int ViewportHeight {
			get;
			set;
		}

		/// <summary>
		/// Максимальный размер мира по оси X.
		/// </summary>
		int WorldXMax {
			get;
			set;
		}

		/// <summary>
		/// Максимальный размер мира по оси Y.
		/// </summary>
		int WorldYMax {
			get;
			set;
		}

	}
}
