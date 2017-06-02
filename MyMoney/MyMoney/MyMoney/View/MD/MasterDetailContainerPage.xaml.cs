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
    public partial class MasterDetailContainerPage : MasterDetailPage
    {
        readonly MasterDetailContainerMenuPage _masterDetailMenuPage;
        
        public MasterDetailContainerPage()
        {
            InitializeComponent();
            
            _masterDetailMenuPage = new MasterDetailContainerMenuPage();

            Master = _masterDetailMenuPage;
            Detail = new NavigationPage(new MasterDetailContainerPageDetail());

            _masterDetailMenuPage.ListMenu.ItemSelected += _OnSelected;
        }

        private void _OnSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Model.MenuItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                _masterDetailMenuPage.ListMenu.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}