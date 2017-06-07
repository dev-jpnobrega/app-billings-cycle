using MyMoney.ViewModel.BillingCycle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyMoney.View.BillingCycle
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BillingCycleView : ContentPage
    {
        public BillingCycleView()
        {
            InitializeComponent();
            this.BindingContext = new BillingCycleViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            (BindingContext as BillingCycleViewModel)?.LoadAsync();

            base.OnAppearing();
        }

    }
}