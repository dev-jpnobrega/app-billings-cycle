using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.Model.BillingCycle
{
    public class BillingCycle
    {
        public string Name { get; set; }
        public int Mounth { get; set; }
        public int Year { get; set; }
        public List<Credit> Credits { get; set; }
        public List<Debit> Debits { get; set; }
        
        public BillingCycle()
        {
            Credits = new List<Credit>();
            Debits = new List<Debit>();
        }

    }
}
