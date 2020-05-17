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
    class DepoFonksiyonlari
    {
        static MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=kitap_evi;Uid=root;Pwd='root';");

        private static bool AyniDepoVarMi(string depoTelefon)
        {


            string komut = "select count(depoTelefon) from depolar where depoTelefon='" + depoTelefon + "'";
            MySqlCommand command = new MySqlCommand(komut, baglanti);
            if (Convert.ToInt32(command.ExecuteScalar()) == 0)
            {
                
                return false;
            }
            else
            {
                MessageBox.Show("Bu depo zaten var!! Depo eklenmedi");
                return true;
            }

        } // baglanti open kullanmadık çünkü yazarekle fonksiyonunda zaten kullanıyoruz.
        public static void depoEkle(string depoAdi, string depoAdresi,string depoTelefon)
        {
            baglanti.Open();

           
           
            if (!AyniDepoVarMi(depoTelefon))
            {

                string komut = "insert into depolar values('" + depoAdi + "','" + depoAdresi + "','"+depoTelefon+"')";
                MySqlCommand command = new MySqlCommand(komut, baglanti);
                command.ExecuteNonQuery();
                MessageBox.Show("Depo başarıyla eklendi..");

            }

            baglanti.Close();
        } // Depo eklendi
        public static DataTable depoListele()
        {
            baglanti.Open();

            string komut = "select * from depolar";
            MySqlCommand command = new MySqlCommand(komut, baglanti);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            baglanti.Close();
            return dt;
        }
    }
}
