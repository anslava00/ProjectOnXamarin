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
        public UserPage(DbDataReader reader)
        {
            InitializeComponent();
            LabelFirstName.Text = reader.GetValue(3).ToString();
            LabelSecondName.Text = reader.GetValue(4).ToString();
            LabelLastName.Text = reader.GetValue(5).ToString();
        }

        private async void ExitButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}