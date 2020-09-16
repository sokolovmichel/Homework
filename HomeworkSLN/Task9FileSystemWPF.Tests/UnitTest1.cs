using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task9FileSystemWPF;


namespace Task9FileSystemWPF.Tests
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Тестирует 
        /// </summary>
        [TestMethod]
        public void TestStartup()
        {
            // путь к исполняемому exe-файлу
            var appPath =
                Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                @"C:\Users\Миша\source\repos\Homework\HomeworkSLN\Task9FileSystemWPF\bin\Debug\Task9FileSystemWPF.exe");
            
            // запуск приложения
            var process = Process.Start(appPath);

            try
            {
                Thread.Sleep(5000);
                // установка CacheRequest (кэширование дочерних элементов объекта)
                CacheRequest cacheRequest = new CacheRequest();
                cacheRequest.Add(AutomationElement.NameProperty);
                cacheRequest.TreeScope = TreeScope.Element | TreeScope.Children;

                // активация CacheRequest
                using (cacheRequest.Activate())
                {
                    // ссылку на главное окно приложения получаем из процесса
                    var mainWindow = AutomationElement.FromHandle(process.MainWindowHandle);

                    // получаем ссылку на элемент управления RichTextBox
                    Condition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);
                    var richTextBoxControl = mainWindow.FindFirst(TreeScope.Children, cond);

                    // получаем объект шаблона для RichTextBox
                    TextPattern richTextBox = (TextPattern)richTextBoxControl.GetCurrentPattern(TextPattern.Pattern);
                   
                    // сравниваем текст указанный в элементе управления с заданным.
                    Assert.AreEqual("Hello", richTextBox.DocumentRange.GetText(-1));
                    
                }
            }
            finally
            {
                process.Kill();
            }
        }
    }
}
