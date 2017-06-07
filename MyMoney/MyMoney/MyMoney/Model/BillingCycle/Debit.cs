using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.Model.BillingCycle
{
    public class Debit
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public Status Status { get; set; }
    }

    public enum Status
    {
        PAGO = 1,
        PENDENTE = 2,
        AGENDADO = 3
    }
}
