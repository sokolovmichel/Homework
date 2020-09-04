
namespace Task10DelegatesAndEvents
{
    /// <summary>
    /// Передает обработчику события данные о событии
    /// </summary>
    class TimerEventArgs
    {
        public string Message { get; }
        public string Name { get; }
        public TimerEventArgs(string name, string message)
        {
            Message = message;
            Name = name;
        }
    }
}
