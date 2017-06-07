using MyMoney.Service.BillingCycle.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyMoney
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new ViewModel.MainPageViewModel();


            BillingCycleData.InitializeData();

        }
    }
}
