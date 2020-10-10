using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> myList = new List<string>() { "one", "two", "three", "four", "five" };
            string myString = myList.GetElement(1);
            Console.WriteLine(myString);

            Console.WriteLine();

            string str = "seven";
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            Search(path, str);

            

            

        }

        static void Search(string path, string str)
        {
            
            string[] directories = Directory.GetDirectories(path);
            

            foreach (var d in directories)
            {
                string[] files = Directory.GetFiles(d, "*.txt");
                foreach (var f in files)
                {
                    var Reader = new StreamReader(f);
                    string text = Reader.ReadToEnd();
                    char[] Separator = { '\t', '\r', '\n', ' ', ',' };

                    var newText = text.Split(Separator, StringSplitOptions.RemoveEmptyEntries);

                    int i = newText.Where(t => t.Equals(str)).Count();
                  
                   
                    if (newText.Contains(str))
                    {
                        Console.WriteLine(i);

                        FileInfo fi = new FileInfo(f);
                        Console.WriteLine(fi.Length);
                        Console.WriteLine(fi.Name);
                        Console.WriteLine(fi.DirectoryName);

                    }
                    
                   
                }
                Search(d, str);

            }
        }
    }
}
