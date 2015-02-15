using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AbstractGameLogic.Attributes;
using BehavioursDocumentationGenerator.Models;

namespace BehavioursDocumentationGenerator.Implementation {

	/// <summary>
	/// Менеджер поведений на основе метаданных сборки.
	/// </summary>
	internal sealed class MetadataBehaviourManager : IBehaviourManager {

		/// <summary>
		/// Получить модели поведений.
		/// </summary>
		/// <param name="assembly">Файл сборки.</param>
		/// <returns>Последовательность моделей поведений.</returns>
		public IEnumerable<BehaviourModel> GetModels ( string assembly ) {
			var classes = Assembly.LoadFile ( assembly ).GetTypes ()
				.Where ( a => a.GetCustomAttributes ().Any ( attribute => attribute is ObjectBindBehaviourAttribute ) )
				.ToList ();
			var models = new List<BehaviourModel> ();
			foreach ( var @class in classes ) {
				var behaviour = @class.GetCustomAttributes ()
					.OfType<ObjectBindBehaviourAttribute> ()
					.First ();
				models.Add ( new BehaviourModel {
					Name = behaviour.Name ,
					Description = behaviour.Description ,
					Actions = @class.GetCustomAttributes ()
						.OfType<GameActionAttribute> ()
						.Select ( a => new GameMetaDataModel {
							Name = a.Name ,
							Description = a.Description
						} )
						.ToList () ,
					Events = @class.GetCustomAttributes ()
						.OfType<GameEventAttribute> ()
						.Select ( a => new GameMetaDataModel {
							Name = a.Name ,
							Description = a.Description
						} )
						.ToList () ,
					States = @class.GetCustomAttributes ()
						.OfType<GameStateAttribute> ()
						.Select ( a => new GameMetaDataModel {
							Name = a.Name ,
							Description = a.Description
						} )
						.ToList ()
				} );
			}
			return models;
		}
	}
}
