using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml;
using AbstractGameLogic;
using System.IO;
using AbstractGameLogic.GUI;

namespace GameLevel.Implementations {

	/// <summary>
	/// Данные уровня игры.
	/// </summary>
	[DataContract]
	[KnownType ( typeof ( Background ) )]
	[KnownType ( typeof ( StaticObject ) )]
	[KnownType ( typeof ( TileMap ) )]
	[KnownType ( typeof ( TileAnimatedObject ) )]
	[KnownType ( typeof ( AnimatedObject ) )]
	[KnownType ( typeof ( Text ) )]
	[KnownType ( typeof ( GameEffect ) )]
	[KnownType ( typeof ( Background ) )]
	[KnownType ( typeof ( ParallaxBackground ) )]
	[KnownType ( typeof ( DrawLevel ) )]
	[KnownType ( typeof ( Hidden ) )]
	[KnownType ( typeof ( ObjectBehaviour ) )]
	[KnownType ( typeof ( ObjectBehaviours ) )]
	[KnownType ( typeof ( EventCollection ) )]
	[KnownType ( typeof ( GameEvent ) )]
	[KnownType ( typeof ( ObjectState ) )]
	[KnownType ( typeof ( GUIManager ) )]
	public class GameLevelData : IGameLevelData {

		/// <summary>
		/// Список графических слоев.
		/// </summary>
		[DataMember]
		public List<IDrawLevel> m_DrawLevels = new List<IDrawLevel> ();

		/// <summary>
		/// Имя уровня.
		/// </summary>
		[DataMember]
		public string Name {
			get;
			set;
		}

		/// <summary>
		/// Описание уровня.
		/// </summary>
		[DataMember]
		public string Description {
			get;
			set;
		}

		/// <summary>
		/// Менеджер графического интерфейса.
		/// </summary>
		[DataMember]
		public IGUIManager GUIManager {
			get;
			set;
		}

		/// <summary>
		/// Последовательность графических слоев.
		/// </summary>
		public IEnumerable<IDrawLevel> DrawLevels {
			get {
				return m_DrawLevels;
			}
		}

		/// <summary>
		/// Добавить графический слой.
		/// </summary>
		/// <param name="drawLevel">Графический слой.</param>
		public void Add ( IDrawLevel drawLevel ) {
			m_DrawLevels.Add ( drawLevel );
		}

	}
}
