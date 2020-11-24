using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using Npgsql;
using ProjectDisplayLogin.DirectoryadminViewModel;
using ProjectDisplayLogin.DirectoryUserViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectDisplayLogin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private async void EnterButtonClicked(object sender, System.EventArgs e)
        {
            if (LoginEntry.Text == "admin" && PasswordEntry.Text == "admin")
            {
                AdminMenu AdminMenu = new AdminMenu();
                NavigationPage.SetHasNavigationBar(AdminMenu, false);
                await Navigation.PushAsync(AdminMenu);
                return;
            }
            
            if (LoginEntry.Text == "")
            {
                await DisplayAlert("Ошибка ввода логина", "Введите логин ", "Ок");
                return;
            }
            
            if (PasswordEntry.Text == "")
            {
                await DisplayAlert("Ошибка ввода пароля", "Введите пароль", "Ок");
                return;
            }
            
            NpgsqlConnection Connect = new NpgsqlConnection("Server=10.0.2.2;" +
                                                            "Port=5432; " +
                                                            "User Id=postgres;" +
                                                            "Password=Ctvtqrf55@;" +
                                                            "Database=University;");
             string SqlRequest = "SELECT * FROM public.students WHERE login = '" + LoginEntry.Text + "';";
            
             NpgsqlCommand npgsql = new NpgsqlCommand(SqlRequest, Connect);
             Connect.Open();
            
             DbDataReader Reader = npgsql.ExecuteReader();
             if (!Reader.HasRows)
             {
                 await DisplayAlert("Ошибка логина", "Не существует такого пользователя ", "Ок");
                 Connect.Close();
                 return;
             }
             Reader.Read();
             if(Reader.GetValue(2).ToString() != PasswordEntry.Text)
             {
                 await DisplayAlert("Ошибка Пароля", "Не правильный пароль ", "Ок");
                 Connect.Close();
                 return;
             }
             else
             {
                 UserPage UserPage = new UserPage(Reader);
                 NavigationPage.SetHasNavigationBar(UserPage, false);
                 await Navigation.PushAsync(UserPage);
             }
            Connect.Close();
        } 
    }
}