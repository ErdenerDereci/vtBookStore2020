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
    class SiparisFonksiyonlari
    {
        static MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=kitap_evi;Uid=root;Pwd='root';");

      
        static private string siparisKoduYarat()
        {

            int sayac;
            string komut = "SELECT * FROM sipariskodlari ORDER BY Kod DESC LIMIT 1;";
            MySqlCommand command = new MySqlCommand(komut, baglanti);
            sayac = Convert.ToInt32(command.ExecuteScalar()) + 1;

            return "siparis" + sayac;

        }  // baglanti open kullanmadık çünkü yazarekle fonksiyonunda zaten kullanıyoruz.
        public static void siparisEkle(string musteritelNo, string siparisiAlan,string urunKodu,int verilenPara)
        {
            baglanti.Open();

            string komut2 = "select taneFiyat from kitap_depo where kitapKodu='" + urunKodu + "'";
            MySqlCommand command2 = new MySqlCommand(komut2, baglanti);
            string komut3 = "select telefon from personel where personelAdiSoyadi='" + siparisiAlan + "'";
            MySqlCommand command3 = new MySqlCommand(komut3, baglanti);
            string siparisalan = command3.ExecuteScalar().ToString();
            int tutar = Convert.ToInt32(command2.ExecuteScalar());
            string siparisKod = siparisKoduYarat();
            string kodsayi = "";
            int paraüstü = verilenPara - tutar;

            if (paraüstü < 0)
            {
                MessageBox.Show("Tutardan daha küçük para girişi yaptınız!!");
            }
            else
            {
                string komut = "insert into siparis values('" + siparisKod + "','" + musteritelNo + "','" + siparisalan + "','" + urunKodu + "'," + tutar + ",'" + DateTime.Now.ToString() + "');";
                MySqlCommand command = new MySqlCommand(komut, baglanti);
                command.ExecuteNonQuery();

                for (int i = 7; i < siparisKod.Length; i++)
                {
                    kodsayi += siparisKod[i];
                }
                komut = "insert into siparisKodlari values('" + kodsayi + "');";
                command = new MySqlCommand(komut, baglanti);
                command.ExecuteNonQuery();



             



                MessageBox.Show("Siparis eklendi. Para üstü " + paraüstü + " tl. ");
            }
            
            

            baglanti.Close();
        }
        public static DataTable siparisListele()
        {
            baglanti.Open();

            string komut = "select * from siparis";
            MySqlCommand command = new MySqlCommand(komut, baglanti);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            baglanti.Close();
            return dt;
        }
    }
}
