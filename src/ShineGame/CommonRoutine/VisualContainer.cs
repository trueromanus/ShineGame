using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShineGame.CommonRoutine {

	/// <summary>
	/// Визуальный контейнер.
	/// </summary>
	internal class VisualContainer {

		private List<VisualContainerItem> m_Items = new List<VisualContainerItem> ();

		/// <summary>
		/// Элементы визуального контейнера.
		/// </summary>

		public IEnumerable<VisualContainerItem> Items {
			get {
				return m_Items;
			}
		}

		/// <summary>
		/// Левый верхний угол.
		/// </summary>
		public ContainerTileKind LeftTopAngle {
			get;
			set;
		}

		/// <summary>
		/// Правый верхний угол.
		/// </summary>
		public ContainerTileKind RightTopAngle {
			get;
			set;
		}

		/// <summary>
		/// Левый верхний угол.
		/// </summary>
		public ContainerTileKind LeftBottomAngle {
			get;
			set;
		}

		/// <summary>
		/// Правый верхний угол.
		/// </summary>
		public ContainerTileKind RightBottomAngle {
			get;
			set;
		}

		/// <summary>
		/// Горизонтальная линия.
		/// </summary>
		public ContainerTileKind HorizontalLine {
			get;
			set;
		}

		/// <summary>
		/// Вертикальная линия.
		/// </summary>
		public ContainerTileKind VerticalLine {
			get;
			set;
		}

		/// <summary>
		/// Фон окна.
		/// </summary>
		public ContainerTileKind Background {
			get;
			set;
		}

		/// <summary>
		/// Создать визуальный контейнер.
		/// </summary>
		public VisualContainer () {
			LeftTopAngle = ContainerTileKind.LeftTop;
			RightTopAngle = ContainerTileKind.RightTop;
			LeftBottomAngle = ContainerTileKind.LeftBottom;
			RightBottomAngle = ContainerTileKind.RightBottom;
			HorizontalLine = ContainerTileKind.Horizontal;
			VerticalLine = ContainerTileKind.Vertical;
			Background = ContainerTileKind.Background;
		}

		/// <summary>
		/// Установить сетку контейнера как квадрат по граням которого выставлены углы и вертикальные и горизонтальные элементы.
		/// </summary>
		/// <param name="width">Ширина.</param>
		/// <param name="height">Высота.</param>
		public void SetRectangle ( int width , int height ) {
			m_Items.Clear ();

			m_Items.AddRange (
				new List<VisualContainerItem>{
					//рисуем углы
					new VisualContainerItem{
						Kind = LeftTopAngle,
						Line = 1,
						Position = 1
					},
					new VisualContainerItem{
						Kind = RightTopAngle,
						Line = 1,
						Position = width
					},
					new VisualContainerItem{
						Kind = LeftBottomAngle,
						Line = height,
						Position = 1
					},
					new VisualContainerItem{
						Kind = LeftBottomAngle,
						Line = height,
						Position = width
					},
					//вертикальные линии
					new VisualContainerItem{
						Kind = LeftBottomAngle,
						Line = 2,
						Position = 1,
						EndPosition = height - 1,
						FillType = VisualContainerItemFillType.VerticalLine
					},
					new VisualContainerItem{
						Kind = LeftBottomAngle,
						Line = 2,
						Position = width,
						EndPosition = height - 1,
						FillType = VisualContainerItemFillType.VerticalLine
					},
					//горизонтальные линии
					new VisualContainerItem{
						Kind = LeftBottomAngle,
						Line = 1,
						Position = 2,
						EndPosition = width - 1,
						FillType = VisualContainerItemFillType.HorizontalLine
					},
					new VisualContainerItem{
						Kind = LeftBottomAngle,
						Line = height,
						Position = 2,
						EndPosition = width - 1,
						FillType = VisualContainerItemFillType.HorizontalLine
					}
				}
			);
		}


	}

}
