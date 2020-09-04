

namespace Task10DelegatesAndEvents
{
    /// <summary>
    /// Реализует методы подписки на события таймера и запуска таймера
    /// </summary>
    interface ICutDownNotifier
    {
        Timer timer { get; set; }
        /// <summary>
        /// Подписывается на события таймера
        /// </summary>
        /// <param name="name">Имя таймера</param>
        void Init(string name);
        /// <summary>
        /// Запускает таймер
        /// </summary>
        /// <param name="i">Время в секундах</param>
        void Run(int i);
    }
}
