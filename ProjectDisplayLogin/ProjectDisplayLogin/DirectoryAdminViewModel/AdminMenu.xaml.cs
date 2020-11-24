using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
    
namespace ProjectDisplayLogin.DirectoryadminViewModel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminMenu : MasterDetailPage
    {
        public AdminMenu()
        {
            InitializeComponent();
            Detail = new NavigationPage(new AdminPage());
        }

        private void OnButtonClickTransitionAdminPage(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new AdminPage());
            IsPresented = false;
        }

        private void OnButtonClickTransitionTest(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Test());
            IsPresented = false;
        }

        private async void OnButtonClickExit(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}