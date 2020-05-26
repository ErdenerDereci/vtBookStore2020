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
using MySqlX.XDevAPI.Relational;

namespace vtKitapEvi2020
{
    class SiparisFonksiyonlari
    {
        static MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=kitap_evi;Uid=root;Pwd='root';");

      
        static public string siparisKoduYarat()
        {
            
            baglanti.Open();

            int sayac;
            string komut = "SELECT * FROM sipariskodlari ORDER BY Kod DESC LIMIT 1;";
            MySqlCommand command = new MySqlCommand(komut, baglanti);
            sayac = Convert.ToInt32(command.ExecuteScalar()) + 1;
            baglanti.Close();
            
            return "siparis" + sayac;
            
        }  
        public static void siparisEkle(string siparisiAlan,string urunKodu, int tutar, int verilenPara,int paraustu,int rowCount)
        {
            

            
            string siparisKod = siparisKoduYarat();
            string kodsayi = "";
            string x = "";
            int j = 0;



            baglanti.Open();
            string komut = "insert into siparis values('" + siparisKod + "','" + siparisiAlan + "','" + urunKodu + "','" + tutar + "'," + verilenPara + ",'" + paraustu + "','" + DateTime.Now.ToString() + "','satildi');";
            MySqlCommand command = new MySqlCommand(komut, baglanti);
            command.ExecuteNonQuery();

                for (int i = 7; i < siparisKod.Length; i++)
                {
                    kodsayi += siparisKod[i];
                }
                komut = "insert into siparisKodlari values('" + kodsayi + "');";
                command = new MySqlCommand(komut, baglanti);
                command.ExecuteNonQuery();
                baglanti.Close();

            for (int i =0; i<rowCount; i++)
                {
                    while(true)
                    {
                        if (urunKodu[j] == ',')
                        {
                            j++;
                            break;
                        }
                        else
                        {
                            x += urunKodu[j];
                            j++;
                        }
                    }
                    adetSil(x);
                    x = "";
                }

                MessageBox.Show("Siparis eklendi. Para üstü " + paraustu + " tl. ");
            
            
            

            
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
        private static void  adetSil(string kitapKodu)
        {
            baglanti.Open();
            MySqlCommand adetcek = new MySqlCommand();
            adetcek.CommandText = "select adet from kitap_depo where kitapKodu='" + kitapKodu + "'";
            adetcek.Connection = baglanti;
            int adet = Convert.ToInt32(adetcek.ExecuteScalar());
            adet--;
            adetcek.CommandText = "update kitap_depo set adet='" + adet + "' where kitapKodu='" + kitapKodu + "'";
            adetcek.Connection = baglanti;
            adetcek.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}
