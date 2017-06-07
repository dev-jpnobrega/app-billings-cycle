using MyMoney.Model;
using MyMoney.View.BillingCycle;
using MyMoney.View.MD;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyMoney.ViewModel.MasterDetail
{
    public class MasterDetailMenuViewModel: BaseViewModel
    {

        private ObservableCollection<Model.MenuItem> _menuItens;

        public ObservableCollection<Model.MenuItem> MenuItens
        {
            get { return _menuItens; }
            set { SetProperty(ref _menuItens, value); }
        }

        private string _welcome;

        public string Welcome
        {
            get { return _welcome; }
            set { SetProperty(ref _welcome, value); }
        }
        
        public ImageSource ImageUser
        {
            get { return ImageSource.FromUri(new System.Uri(User.UrlPicture)); }
        }

        public MasterDetailMenuViewModel()
        {
            Welcome = $"Bem Vindo {User.FirstName}";
            _CreateMenu();
        }

        void _CreateMenu()
        {
            MenuItens = new ObservableCollection<Model.MenuItem>();

            MenuItens.Add(new Model.MenuItem()
            {
                Title = "Home",
                Icon = "fa-home",
                TargetType = typeof(MasterDetailContainerPageDetail)
            });

            MenuItens.Add(new Model.MenuItem()
            {
                Title = "Ciclos Pagamento",
                Icon = "fa-gg-circle",
                TargetType = typeof(BillingCycleView)
            });


            MenuItens.Add(new Model.MenuItem()
            {
                Title = "Configurações",
                Icon = "fa-cogs",
                TargetType = typeof(MainPage)
            });


            MenuItens.Add(new Model.MenuItem()
            {
                Title = "Sair",
                Icon = "fa-sign-out",
                TargetType = typeof(MainPage)
            });
        }
    }
}
