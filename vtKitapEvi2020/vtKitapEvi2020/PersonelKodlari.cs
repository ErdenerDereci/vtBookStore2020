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
    class PersonelKodlari
    {
        static MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=kitap_evi;Uid=root;Pwd='root';");

        static private string personelKoduYarat()
        {

            int sayac;
            string komut = "SELECT * FROM personelKodlari ORDER BY kod DESC LIMIT 1;";
            MySqlCommand command = new MySqlCommand(komut, baglanti);
            sayac = Convert.ToInt32(command.ExecuteScalar()) + 1;

            return "personel" + sayac;

        }  // baglanti open kullanmadık çünkü yazarekle fonksiyonunda zaten kullanıyoruz.
        private static bool ayniPersonelVarMi(string telefon)
        {


            string komut = "select count(telefon) from personel where telefon='" + telefon + "'";
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
        public static void personelEkle(string personelAdiSoyadi,string cinsiyeti,string telefon,string adres,string mail,string gorevi,int maasi)
        {
            baglanti.Open();

            
            if (!ayniPersonelVarMi(telefon))
            {

                string komut = "insert into personel values('" + telefon + "','" + personelAdiSoyadi + "','"+cinsiyeti+"','"+adres+"','"+mail+"','"+gorevi+ "',"+maasi+",'calisiyor')";
                MySqlCommand command = new MySqlCommand(komut, baglanti);
                command.ExecuteNonQuery();

                
                MessageBox.Show("Personel eklendi..");
            }
            else
            {
                MessageBox.Show("Bu personel zaten kayıtlı!!");
            }

            baglanti.Close();
        }
        public static DataTable personelListele(string sart)
        {
            baglanti.Open();

            string komut = "select * from personel where personelAdiSoyadi like '%" + sart + "%'";
            MySqlCommand command = new MySqlCommand(komut, baglanti);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            baglanti.Close();
            return dt;
        }
    }
}
