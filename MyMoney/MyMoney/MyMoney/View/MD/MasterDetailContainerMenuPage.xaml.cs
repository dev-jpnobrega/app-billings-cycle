using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyMoney.View.MD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailContainerMenuPage : ContentPage
    {
        public ListView ListMenu { get { return ListViewMenu; } }

        public MasterDetailContainerMenuPage()
        {
            InitializeComponent();
            this.BindingContext = new ViewModel.MasterDetail.MasterDetailMenuViewModel();
        }
    }
}