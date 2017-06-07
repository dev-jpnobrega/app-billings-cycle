using MyMoney.Model.BillingCycle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.Service.BillingCycle.Test
{
    public static class BillingCycleData
    {
        public static List<Model.BillingCycle.BillingCycle> BillingCycles;

        public static void InitializeData()
        {
            BillingCycles = new List<Model.BillingCycle.BillingCycle>();

            BillingCycles.Add(new Model.BillingCycle.BillingCycle()
            {
                Name = "Janeiro",
                Mounth = 1,
                Year = 2017,
                Credits = new List<Model.BillingCycle.Credit>()
                {
                    new Model.BillingCycle.Credit()
                    {
                        Name = "Freelancer",
                        Value = 2500.00
                    },
                    new Model.BillingCycle.Credit()
                    {
                        Name = "CLT",
                        Value = 7000
                    }
                },
                Debits = new List<Model.BillingCycle.Debit>()
                {
                    new Model.BillingCycle.Debit()
                    {
                        Name = "Conta luz",
                        Value = 155.50,
                        Status = Model.BillingCycle.Status.PAGO
                    },
                    new Model.BillingCycle.Debit()
                    {
                        Name = "Conta agua",
                        Value = 100,
                        Status = Model.BillingCycle.Status.PAGO
                    }
                }
            });

            BillingCycles.Add(new Model.BillingCycle.BillingCycle()
            {
                Name = "Fevereiro",
                Mounth = 2,
                Year = 2017,
                Credits = new List<Model.BillingCycle.Credit>()
                {
                    new Model.BillingCycle.Credit()
                    {
                        Name = "Freelancer",
                        Value = 2000.00
                    },
                    new Model.BillingCycle.Credit()
                    {
                        Name = "CLT",
                        Value = 7000
                    }
                },
                Debits = new List<Model.BillingCycle.Debit>()
                {
                    new Model.BillingCycle.Debit()
                    {
                        Name = "Conta luz",
                        Value = 150.50,
                        Status = Model.BillingCycle.Status.PAGO
                    },
                    new Model.BillingCycle.Debit()
                    {
                        Name = "Conta agua",
                        Value = 120,
                        Status = Model.BillingCycle.Status.PAGO
                    },
                    new Model.BillingCycle.Debit()
                    {
                        Name = "Caixas de som",
                        Value = 150,
                        Status = Model.BillingCycle.Status.PAGO
                    },
                    new Model.BillingCycle.Debit()
                    {
                        Name = "Microsoft store",
                        Value = 100,
                        Status = Model.BillingCycle.Status.PAGO
                    }
                }
            });
        }


        public static Tuple<Credit, Debit, double> Summary()
        {
            double sumCredits = BillingCycles.Sum(x => x.Credits.Sum(y => y.Value));
            double sumDebits = BillingCycles.Sum(x => x.Debits.Sum(y => y.Value));

            return new Tuple<Credit, Debit, double>(new Credit()
            {
                Name = "Summary (SUM)",
                Value = sumCredits
            },
            new Debit()
            {
                Name = "Summary (SUM)",
                Value = sumDebits
            }, 
            (sumCredits - sumDebits));
        }
    }
}
