using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyMoney.View.BillingCycle
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BillingCycleDetailView : ContentPage
    {
        public BillingCycleDetailView(Model.BillingCycle.BillingCycle b)
        {
            InitializeComponent();
            this.BindingContext = new ViewModel.BillingCycle.BillingCycleDetailViewModel(Navigation, b);
        }

        protected override void OnAppearing()
        {
            (BindingContext as ViewModel.BillingCycle.BillingCycleDetailViewModel)?.LoadAsync();

            base.OnAppearing();
        }
    }
}