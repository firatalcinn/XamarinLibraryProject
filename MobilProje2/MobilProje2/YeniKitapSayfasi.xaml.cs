using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;


namespace MobilProje2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class YeniKitapSayfasi : ContentPage
	{
		public YeniKitapSayfasi ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            Kitap kitap = new Kitap()
            {
                İsim = isimEntry.Text,
                Yazar = yazarEntry.Text
            };

            using (SQLite.SQLiteConnection cn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                cn.CreateTable<Kitap>();

                if (isimEntry.Text == null)
                    DisplayAlert("Başarısız", "Lütfen kitap adı giriniz", "Kapat");
                else if (yazarEntry.Text == null)
                    DisplayAlert("Başarısız", "Lütfen yazar adı giriniz", "Kapat");
                else if (isimEntry.Text == null && yazarEntry.Text == null)
                    DisplayAlert("Başarısız", "Lütfen tekrar kontrol ediniz", "Kapat");
                else
                {
                    cn.Insert(kitap);
                    DisplayAlert("Başarılı", "Yeni kitap eklendi", "Kapat");

                    Navigation.PushAsync(new MainPage());
                }
            }
        }
    }
}