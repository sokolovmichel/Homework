using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace VersionWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            textBox1.Text = "25.48,65.56";
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string s = Read();
            Convert(s);

        }

        public string Read()
        {
            
            string AllText = String.Empty;
            AllText = textBox1.Text;
                                   
            return AllText;

        }

        public void Convert(string AllText)
        {
            Decimal[] X, Y;
            //var AllText = String.Empty;
            string Text = String.Empty;

            Char[] Separator = { '\t', '\r', '\n', ' ', ',' };

            var Coordinates = AllText.Split(Separator, StringSplitOptions.RemoveEmptyEntries);
            var n = Coordinates.Length;
            var z = n % 2;
            if (z != 0)
            {
                textBox1.Text = "Количество исходных данных не кратно двум";
                
            }



            X = new Decimal[n / 2]; Y = new Decimal[n / 2];

            Boolean A, B;
            var j = 0;

            for (var i = 0; i <= n / 2 - 1; i++)
            {

                IFormatProvider culture = new CultureInfo("en-Us", useUserOverride: true);
                A = Decimal.TryParse(Coordinates[j], NumberStyles.AllowDecimalPoint, culture, out X[i]);
                j = j + 1;
                B = Decimal.TryParse(Coordinates[j], NumberStyles.AllowDecimalPoint, culture, out Y[i]);
                j = j + 1;

                if ((A && B) == false)
                    textBox1.Text = String.Format("В строке {0} - не числовой ввод!", i + 1);

            }
            textBox1.Text = "";
            for (var i = 0; i <= n / 2 - 1; i++)
            {
                textBox1.AppendText(String.Format("X: {0,-7} " + "Y: {1,-7}" + "\n", X[i], Y[i]));


            }

            
            

        }
    }


}

