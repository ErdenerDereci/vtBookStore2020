using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace vtKitapEvi2020
{
    class YayinEviFonksiyonlari
    {
        static MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=kitap_evi;Uid=root;Pwd='root';");

        static private string yayinEviKoduYarat()
        {
            baglanti.Open();
            int sayac;
            string komut = "SELECT * FROM yayinEviKodlari ORDER BY Kod DESC LIMIT 1;";
            MySqlCommand command = new MySqlCommand(komut, baglanti);
            sayac = Convert.ToInt32(command.ExecuteScalar()) + 1;
            baglanti.Close();
            return "yayinEvi" + sayac;

        }  // baglanti open kullanmadık çünkü yazarekle fonksiyonunda zaten kullanıyoruz.
        public static bool ayniYayinEviVarMi(string yayinEviAdi)
        {

            baglanti.Open();
            string komut = "select count(yayinEviAdi) from yayin_evleri where yayinEviAdi='" + yayinEviAdi + "'";
            MySqlCommand command = new MySqlCommand(komut, baglanti);
            if (Convert.ToInt32(command.ExecuteScalar()) == 0)
            {
                baglanti.Close();
                return false;
            }
            else
            {
                baglanti.Close();
                return true;
            }

        } // baglanti open kullanmadık çünkü yazarekle fonksiyonunda zaten kullanıyoruz.
        public static void yayinEviEkle(string yayinEviAdi)
        {
            

            string yayinEviKodu = yayinEviKoduYarat();
            string kodsayi = "";
            if (!ayniYayinEviVarMi(yayinEviAdi))
            {
                baglanti.Open();
                string komut = "insert into yayin_evleri values('" + yayinEviKodu + "','" + yayinEviAdi + "')";
                MySqlCommand command = new MySqlCommand(komut, baglanti);
                command.ExecuteNonQuery();

                for (int i = 8; i < yayinEviKodu.Length; i++)
                {
                    kodsayi += yayinEviKodu[i];
                }
                komut = "insert into yayinEviKodlari values('" + kodsayi + "');";
                command = new MySqlCommand(komut, baglanti);
                command.ExecuteNonQuery();
            }

            baglanti.Close();
        }
        public static DataTable yayinEviListele()
        {
            baglanti.Open();

            string komut = "select * from yayin_evleri";
            MySqlCommand command = new MySqlCommand(komut, baglanti);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            baglanti.Close();
            return dt;
        }
    }
}
