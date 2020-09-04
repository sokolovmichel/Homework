using System.Threading;

namespace Task10DelegatesAndEvents
{
    /// <summary>
    /// Имитация часов с обратным отсчетом (таймер), передающая сообщение
    /// об истечении назначенного времени. 
    /// </summary>
    class Timer
    {
       

        public delegate void TimerHandler(object sender, TimerEventArgs e);
        public event TimerHandler Notify;
        public string Name { get; set; } //имя таймера
        public Timer(string name)
        {
            this.Name = name;

        }
        /// <summary>
        /// Запускает таймер
        /// </summary>
        /// <param name="time">Время в секундах</param>
        public void RunTimer(int time)
        {
            Notify?.Invoke(this, new TimerEventArgs(this.Name, "Старт обратного отсчета"));

            for (int i = time; i > 0; i--)
            {
                Notify?.Invoke(this, new TimerEventArgs(this.Name, $"Осталось {i} секунд."));
                Thread.Sleep(1000);
                
            }
            Notify?.Invoke(this, new TimerEventArgs(this.Name, "Обратный отсчет завершен."));
        }
    }
}
