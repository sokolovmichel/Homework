
namespace Task6Interface
{
    public class ProgramHelper : ProgramConverter, ICodeChecker
    {
        public bool CheckCodeSyntax(string convertedCode, string language)
        {
            return true;
        }

      
    }
}
