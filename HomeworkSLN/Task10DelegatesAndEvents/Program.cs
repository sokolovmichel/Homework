using System;


namespace Task10DelegatesAndEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите имя таймера: ");
            string timerName = Console.ReadLine();
            Console.Write("Введите количество секунд обратного отсчета: ");
            int i = int.Parse(Console.ReadLine());

            Timer myTimer = new Timer(timerName);
            myTimer.Notify += DisplayMessage;
            myTimer.RunTimer(i);
            


            ByMethods timer1 = new ByMethods(StartTimeMessage, EndTimeMessage);
            timer1.Init("Чтение задания");
                      
            ByAnonymousMethods timer2 = new ByAnonymousMethods(StartTimeMessage, EndTimeMessage);
            timer2.Init("Выполнение задания");
            
            ByLambda timer3 = new ByLambda(StartTimeMessage, EndTimeMessage);
            timer3.Init("Проверка задания перед отправкой");
            

            ICutDownNotifier [] timers = { timer1, timer2, timer3};

            foreach (ICutDownNotifier tm in timers)
            {
                tm.Run(5);
            }
           
        }

        public static void StartTimeMessage(string taskName, int taskTime)
        {
            Console.WriteLine();
            Console.WriteLine($"Началось время выполнения задания \"{taskName}\". Время на задание: {taskTime} секунд");
        }

        public static void EndTimeMessage(string taskName, int taskTime)
        {
            Console.WriteLine($"Закончилось время выполнения задания \"{taskName}\". Время на задание: {taskTime} секунд");
        }

        public static void DisplayMessage(object sender, TimerEventArgs e)
        {
            Console.WriteLine(e.Name + " " + e.Message);
        }







    }

    
}
