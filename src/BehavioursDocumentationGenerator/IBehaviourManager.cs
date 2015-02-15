using System.Collections.Generic;
using BehavioursDocumentationGenerator.Models;

namespace BehavioursDocumentationGenerator {

	/// <summary>
	/// Менеджер поведений.
	/// </summary>
	public interface IBehaviourManager {

		/// <summary>
		/// Получить все доступные модели в сборке.
		/// </summary>
		/// <param name="assembly">Имя сборки.</param>
		/// <returns>Последовательность моделей поведений.</returns>
		IEnumerable<BehaviourModel> GetModels ( string assembly );

	}

}
