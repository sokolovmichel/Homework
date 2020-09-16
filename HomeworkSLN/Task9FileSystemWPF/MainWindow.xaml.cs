using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Task9FileSystemWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isTextModified; // определяет был ли текст изменен при закрытии приложения
        string fileName; 
        public MainWindow()
        {
            InitializeComponent();
            
           
        }
        /// <summary>
        /// Срабатывает при выборе пункта меню "Открыть".
        /// Загружает выбранный текстовый файл в приложение через OpenFileDialog
        /// </summary>
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = false; // отключение в диалоговом окне предупреждения, если пользователь указывает несуществующее имя файла
            ofd.Filter = "Text Files(*.txt)|*.txt*|RichText Files(*.rtf)|*.rtf*|All files(*.*)|*.*"; 
            if (ofd.ShowDialog() == true) 
            {
                // Создание контейнера TextRange для всего документа
                TextRange doc = new TextRange(docBox.Document.ContentStart, docBox.Document.ContentEnd);
                try
                {
                    
                    using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                    {
                        
                        if (System.IO.Path.GetExtension(ofd.FileName).ToLower() == ".rtf")
                            doc.Load(fs, DataFormats.Rtf);
                        else
                            doc.Load(fs, DataFormats.Text);
                    }
                    isTextModified = false;
                    fileName = ofd.FileName;
                }
                catch(FileNotFoundException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            
            
        }
        /// <summary>
        ///  Сохраняет измененния при выборе пункта меню "Сохранить"
        /// </summary>
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            
            // Если был открыт текстовый файл вызывается метод Savedata()
            // если файл не был открыт и пользователь хочет создать новый - вызывается SaveAs()
            if (fileName != null) SaveData();
            else
            {
                fileName = "example.txt";
                SaveAs();
                
            }

        }
        /// <summary>
        /// Пункт меню "Сохранить как"
        /// </summary>
        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveAs();
        }

        /// <summary>
        /// Сохраняет изменения с возможностью выбора другого места/имени файла.
        /// </summary>
        private void SaveAs()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "(*.txt)|*.txt*|(*.rtf)|*.rtf";

            sfd.FileName = fileName;
            if (sfd.ShowDialog() == true)
            {
                fileName = sfd.FileName;
                SaveData();
            }
        }
        /// <summary>
        /// Закрывает приложение. Пункт меню "Выход".
        /// </summary>
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Срабатывает при изменении текста в RichTextBox (name: docBox)
        /// </summary>
        private void docBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            isTextModified = true;
           
        }
        /// <summary>
        /// Проверяет, был ли изменен и не сохранен текст в RichTextBox при закрытии приложения.
        /// В случае измененния текста и отсутсвия сохранения выводит диалоговое окно для сохранения.
        /// </summary>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (isTextModified == false) return;
            else
            {
                
                var MBox = MessageBox.Show("Текст был изменен.\n" +
                    "Сохранить изменения?", "Простой редактор", MessageBoxButton.YesNoCancel,
                    MessageBoxImage.Exclamation);
                if (MBox == MessageBoxResult.No) return;
                if (MBox == MessageBoxResult.Cancel) e.Cancel = true;
                if (MBox == MessageBoxResult.Yes)
                {

                    if (fileName != null)
                    {
                        SaveData(); return;
                    }
                    else
                    {
                        fileName = "example.txt";
                        SaveAs();

                    }

                }
            }
        }
        /// <summary>
        /// Сохраняет изменения.
        /// </summary>
        private void SaveData()
        {
            try
            {
                // Создание контейнера TextRange для всего документа
                TextRange doc = new TextRange(docBox.Document.ContentStart, docBox.Document.ContentEnd);
                // Если такой файл существует, он перезаписывается
                using (FileStream fs = File.Create(fileName)) //sfd.FileName
                {
                    if (System.IO.Path.GetExtension(fileName).ToLower() == ".rtf")
                        doc.Save(fs, DataFormats.Rtf);
                    else
                        doc.Save(fs, DataFormats.Text);
                }
                isTextModified = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            
        }

        
    }
}
