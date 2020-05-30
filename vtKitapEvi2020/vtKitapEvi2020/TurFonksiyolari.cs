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
    class TurFonksiyolari
    {
        static MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=kitap_evi;Uid=root;Pwd='root';");

        static private string turKoduYarat()
        {

            int sayac;
            string komut = "SELECT tur FROM kodlar ORDER BY tur DESC LIMIT 1;";
            MySqlCommand command = new MySqlCommand(komut, baglanti);
            sayac = Convert.ToInt32(command.ExecuteScalar()) + 1;

            return "tur" + sayac;

        }  // baglanti open kullanmadık çünkü yazarekle fonksiyonunda zaten kullanıyoruz.
        private static bool ayniTurVarMi(string turAdi)
        {


            string komut = "select count(turAdi) from kitap_turleri where turAdi='" + turAdi + "'";
            MySqlCommand command = new MySqlCommand(komut, baglanti);
            if (Convert.ToInt32(command.ExecuteScalar()) == 0)
            {

                return false;
            }
            else
            {

                return true;
            }

        } // baglanti open kullanmadık çünkü yazarekle fonksiyonunda zaten kullanıyoruz.
        public static void turEkle(string turAdi)
        {
            baglanti.Open();

            string turKodu = turKoduYarat();
            string kodsayi = "";
            if (!ayniTurVarMi(turAdi))
            {

                string komut = "insert into kitap_turleri values('" + turKodu + "','" + turAdi + "')";
                MySqlCommand command = new MySqlCommand(komut, baglanti);
                command.ExecuteNonQuery();

                for (int i = 3; i < turKodu.Length; i++)
                {
                    kodsayi += turKodu[i];
                }
                komut = "insert into kodlar values(0,0,0,'" + kodsayi + "',0);";
                command = new MySqlCommand(komut, baglanti);
                command.ExecuteNonQuery();
            }

            baglanti.Close();
        }
    }
}
