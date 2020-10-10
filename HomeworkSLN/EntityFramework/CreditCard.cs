using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class CreditCard
    {
        public int ID { get; set; }
        public int CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CardHolder { get; set; }
        public Employee Employee { get; set; }
    }
}
