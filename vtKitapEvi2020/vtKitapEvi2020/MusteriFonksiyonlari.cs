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
    class MusteriFonksiyonlari
    {
        static MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=kitap_evi;Uid=root;Pwd='root';");

        private static bool ayniMusteriVarMi(string telNo)
        {


            string komut = "select count(musteriTelNo) from musteri where musteriTelNo='" + telNo + "';";
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
        static private string musteriKoduYarat()
        {

            int sayac;
            string komut = "SELECT * FROM musteriKodlari ORDER BY Kod DESC LIMIT 1;";
            MySqlCommand command = new MySqlCommand(komut, baglanti);
            sayac = Convert.ToInt32(command.ExecuteScalar()) + 1;

            return "musteri" + sayac;

        }  // baglanti open kullanmadık çünkü yazarekle fonksiyonunda zaten kullanıyoruz.
        public static void musteriEkle(string telNo,string musteriAdSoyad)
        {
            baglanti.Open();

            string musteriKod = musteriKoduYarat();
            string kodsayi = "";
            if (!ayniMusteriVarMi(telNo))
            {
                string komut = "insert into musteri values('"+telNo+"','"+musteriAdSoyad+"');";
                MySqlCommand command = new MySqlCommand(komut,baglanti);
                command.ExecuteNonQuery();
                
                for (int i = 7; i < musteriKod.Length; i++)
                {
                    kodsayi += musteriKod[i];
                }
                komut = "insert into musteriKodlari values('" + kodsayi + "');";
                command = new MySqlCommand(komut, baglanti);
                command.ExecuteNonQuery();

                //kitap_depo tablosuna kitap eklendi

               

                MessageBox.Show("Musteri eklendi.");
            }

            baglanti.Close();
        }
        public static DataTable musteriListele()
        {
            baglanti.Open();

            string komut = "select * from musteri";
            MySqlCommand command = new MySqlCommand(komut, baglanti);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            baglanti.Close();
            return dt;
        }
    }
}
