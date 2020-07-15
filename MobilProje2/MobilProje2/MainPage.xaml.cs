using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobilProje2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            

            using (SQLite.SQLiteConnection cn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                cn.CreateTable<Kitap>();

                var books = cn.Table<Kitap>().ToList();
                kitapListesi.ItemsSource = books;

            }
        }

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new YeniKitapSayfasi());
        }

        private void ToolbarItem_Activated_1(object sender, EventArgs e)
        {


            using (SQLite.SQLiteConnection cn = new SQLite.SQLiteConnection(App.DB_PATH))
            {

                cn.Delete(kitapListesi.SelectedItem);

                

                Navigation.PushAsync(new MainPage());

                DisplayAlert("Başarılı", "Kitap Silindi" , "Kapat");

            }
        }
    }
}

