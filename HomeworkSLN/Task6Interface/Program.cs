using System;

namespace Task6Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramConverter[] array =
            {
                new ProgramConverter(),
                new ProgramHelper(),
                new ProgramConverter()
            };
            
            foreach(ProgramConverter pc in array)
            {
                ICodeChecker icc = pc as ICodeChecker;
                
                if (icc != null)
                {
                    if (icc.CheckCodeSyntax("Строка", "CSharp"))
                    {
                        Console.WriteLine(pc.ConvertToVB("code"));
                        Console.WriteLine();
                    }

                    else 
                    {
                        Console.WriteLine(pc.ConvertToCSharp("code"));
                        Console.WriteLine();
                    } 
                    
                }
                else
                {
                    Console.WriteLine(pc.ConvertToCSharp("code"));
                    Console.WriteLine(pc.ConvertToVB("code"));
                    Console.WriteLine();
                }
                
                
            }

            
          
            
        }
    }
}
