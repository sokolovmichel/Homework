using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkForMoq
{
    public class FormatText
    {
       

        public virtual string FormatMyText(string OldText)
        {
            string NewText = OldText + "555.555,555.555";
            return NewText;
        }
    }
}
