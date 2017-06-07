using MyMoney.Service.BillingCycle.Test;
using MyMoney.View.BillingCycle;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyMoney.ViewModel.BillingCycle
{
    public class BillingCycleDetailViewModel : BaseViewModel
    {
        private INavigation _INavigation;


        private Model.BillingCycle.BillingCycle _billingCycle;

        public Model.BillingCycle.BillingCycle BillingCycle
        {
            get { return _billingCycle; }
            set { SetProperty(ref _billingCycle, value); }
        }
                
        //public ObservableCollection<Model.BillingCycle.Credit> Credits { get; }
       // public ObservableCollection<Model.BillingCycle.Debit> Debits { get; }

        // public Command<Model.BillingCycle.BillingCycle> ShowBillingCycleCommand { get; }

        public BillingCycleDetailViewModel(INavigation iNavigation, Model.BillingCycle.BillingCycle b)
        {
            Title = "Ciclo Pagamento " + b.Name;
            _INavigation = iNavigation;
            
            BillingCycle = b;
            //Credits = new ObservableCollection<Model.BillingCycle.Credit>();
            //Debits  = new ObservableCollection<Model.BillingCycle.Debit>();
        }


        void ExecuteBillingCycleCommand(Model.BillingCycle.BillingCycle b)
        {
           // PushAsync(new BillingCycleDetailView());
        }



        public async void LoadAsync()
        {
            //Credits.Clear();
            //Debits.Clear();

            //foreach (var c in BillingCycle.Credits)
            //    Credits.Add(c);

            //foreach (var d in BillingCycle.Debits)
            //    Debits.Add(d);
        }
    }
}
