using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectDisplayLogin.DirectoryUserViewModel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        public string stud;
        public UserPage(DbDataReader reader)
        {
            InitializeComponent();
            stud = reader.GetValue(1).ToString();
            LabelFirstName.Text = reader.GetValue(3).ToString();
            LabelSecondName.Text = reader.GetValue(4).ToString();
            LabelLastName.Text = reader.GetValue(5).ToString();
        }
        private async void Graphik(object sender, EventArgs e)
        {
            
            Graphik graphik = new Graphik(stud);
            NavigationPage.SetHasNavigationBar(graphik, false);
            await Navigation.PushAsync(graphik);
        }
        
        private async void ExitButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}