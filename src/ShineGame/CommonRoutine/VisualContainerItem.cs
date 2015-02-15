using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShineGame.CommonRoutine {
	
	/// <summary>
	/// Элемент визуального контейнера.
	/// </summary>
	internal class VisualContainerItem {

		/// <summary>
		/// Номер строки.
		/// </summary>
		public int Line {
			get;
			set;
		}

		/// <summary>
		/// Поизиция.
		/// </summary>
		public int Position {
			get;
			set;
		}

		/// <summary>
		/// Конечная позиция.
		/// </summary>
		public int? EndPosition {
			get;
			set;
		}

		/// <summary>
		/// Тип рисования.
		/// </summary>
		public VisualContainerItemFillType FillType {
			get;
			set;
		}

		/// <summary>
		/// Тип тайла контейнера.
		/// </summary>
		public ContainerTileKind Kind {
			get;
			set;
		}

	}

}
