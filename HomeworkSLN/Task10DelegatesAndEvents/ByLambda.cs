﻿using System;


namespace Task10DelegatesAndEvents
{
    /// <summary>
    /// Обрабатывает события с помощью лямбда выражений
    /// </summary>
    class ByLambda : ICutDownNotifier
    {
        public delegate void TaskStartTime(string taskName, int taskTime);
        TaskStartTime TST;
        Action<string, int> TaskEndTime;

        public Timer timer { get; set; }

        public ByLambda(TaskStartTime tst, Action<string, int> taskEndTime)
        {
            TST = tst;
            TaskEndTime = taskEndTime;
        }

        public void Init(string name)
        {
            timer = new Timer(name);
            timer.Notify += (object sender, TimerEventArgs e) =>  Console.WriteLine(e.Name + ": " + e.Message); 
        }

        public void Run(int i)
        {
            TST?.Invoke(timer.Name, i);
            timer.RunTimer(i);
            TaskEndTime?.Invoke(timer.Name, i);
        }
    }
}
