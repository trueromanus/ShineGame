
namespace AbstractGameLogic.GameLevel {
	
	/// <summary>
	/// Загрузчик уровня. Специальный интерфейс обслуживающий средства вывода пока загружается уровень.
	/// </summary>
	public interface ILevelLoader {

		/// <summary>
		/// Получить игровой мир который будет отображаться во время загрузки уровня.
		/// </summary>
		/// <returns>Игровой мир во время загрузки.</returns>
		IGameWorld GetLoaderWorld ();

	}

}
