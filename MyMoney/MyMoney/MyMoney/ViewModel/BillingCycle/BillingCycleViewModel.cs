using MyMoney.Service.BillingCycle.Test;
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
    public class BillingCycleViewModel : BaseViewModel
    {
        private INavigation _INavigation;


        public ObservableCollection<Model.BillingCycle.BillingCycle> BillingCycles { get; }

        public Command<Model.BillingCycle.BillingCycle> ShowBillingCycleCommand { get; }

        public BillingCycleViewModel(INavigation iNavigation)
        {
            Title = "Ciclos Pagamento";
            _INavigation = iNavigation;

            BillingCycles = new ObservableCollection<Model.BillingCycle.BillingCycle>();
            ShowBillingCycleCommand = new Command<Model.BillingCycle.BillingCycle>(ExecuteBillingCycleCommand);
        }


        async void ExecuteBillingCycleCommand(Model.BillingCycle.BillingCycle b)
        {
            await PushAsync(_INavigation, new View.BillingCycle.BillingCycleDetailView(b), false);
        }

        public async void LoadAsync()
        {
            BillingCycles.Clear();
            foreach (var bc in BillingCycleData.BillingCycles)
                BillingCycles.Add(bc);
        }
    }
}
