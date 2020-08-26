

namespace Task6Interface
{
    public class ProgramConverter : IConvertible
    {
        public string ConvertToCSharp(string myString)
        {
            return "Code converted to CSharp";
        }

        public string ConvertToVB(string myString)
        {
            return "Code converted to VB";
        }

       
    }
}
