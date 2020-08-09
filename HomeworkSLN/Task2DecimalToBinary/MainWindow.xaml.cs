using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task2DecimalToBinary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Title = "Преобразование десятичного числа в двочное";
            label2.Content = "Введите десятичное число: ";
            label4.Content = "Двоичное число, преобразованное по алгоритму: ";
            label5.Content = "Двоичное число, преобразованное c помощью\nстандартного метода Convert.ToString(): ";
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            button1.Content = "Преобразовать";
            

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == "") MessageBox.Show("Введите число");
            else
            {
                int value = int.Parse(textBox1.Text);
                textBox2.Text = ConvertToBinary(value);

                textBox3.Text = Convert.ToString(value, 2); //преобразованное c помощью стандартного класса
            }
        }

        public string ConvertToBinary(int value)
        {
            int t;
            string myString = string.Empty;
            for (t = 128; t > 0; t = t / 2)
            {
                if ((value & t) != 0) myString += "1 ";
                if ((value & t) == 0) myString += "0 ";
            }

            return myString;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) button1_Click(null, null); 
        }
    }
}
