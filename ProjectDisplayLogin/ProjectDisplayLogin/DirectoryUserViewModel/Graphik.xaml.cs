using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using ProjectDisplayLogin.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectDisplayLogin.DirectoryUserViewModel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Graphik : ContentPage
    {
        private string log;
        private string curDate;
        public ObservableCollection<Phone> Phones { get; set; }
        
        
        public string[][] TempStroki = {new string[]{"14:00:00", "music", "teach two"}, 
                                        new string[]{"16:00:00", "math", "teach one"}
        };
        public Graphik(string log)
        {
            InitializeComponent();
            this.log = log;
            // curDate = DateTime.Now.ToString("yyyy-MM-dd");
            // Label1.Text = curDate;
            Phones = new ObservableCollection<Phone> { };
            // DatePicke.Date = new DateTime(2020, 11, 21);
            this.BindingContext = this;
        }
        private void RemoveItem(object sender, EventArgs e)
        {
            int CountPhone = Phones.Count;
            while (CountPhone > 0)
            {
                Phones.Remove(Phones.First());
                CountPhone--;
            }
        }
        private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            Label2.Text="Вы выбрали "+e.NewDate.ToString("dd/MM/yyyy");
            string tmp = e.NewDate.ToString("dd/MM/yyyy");
            // Phones.Clear();
            Connection.Connect.Close();
            Connection.SqlRequest = "DELETE FROM tmp_val_for_grafik;" +
                                "INSERT INTO tmp_val_for_grafik(FLT_NAME, FLT_DATE)" +
                                "VALUES('"+log+"' , '"+tmp+"');"+
                                "SELECT * FROM graphik_views";
            NpgsqlCommand npgsql = new NpgsqlCommand(Connection.SqlRequest, Connection.Connect);
            try{
                Connection.Connect.Open();
            }catch(Exception ex){ 
                Console.WriteLine("Error!");
            }
            DbDataReader Reader = npgsql.ExecuteReader();
            if (!Reader.HasRows)
                Label4.Text = "ERROR";
            else
            {
                Label4.Text = "NORM";
            }
            // Phone p = Phones.First();
            /*int CountPhone = 2;
            while (CountPhone > 0)
            {
                if (Phones.First() != null)Phones.Remove(Phones.First());
                CountPhone--;
            }*/
            while (Reader.Read())
            {    
                Phones.Add(new Phone
                {
                    Time = Reader.GetValue(0).ToString(),
                    NameSubject = Reader.GetValue(1).ToString(),
                    Teacher = Reader.GetValue(2).ToString()
                });
            }
            Connection.Connect.Close();
        }
    }
}