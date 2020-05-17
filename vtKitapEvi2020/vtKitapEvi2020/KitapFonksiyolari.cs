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
    class KitapFonksiyolari
    {
        static MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=kitap_evi;Uid=root;Pwd='root';");

        private static bool ayniKitapVarMi(string kitapAdi,string yazari,string yayinEvi)
        {


            string komut = "select count(kitapAdi) from kitaplar where kitapAdi='"+kitapAdi+"' and yazari='"+yazari+"' and yayinEvi='"+yayinEvi+"';";
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
        static private string kitapKoduYarat()
        {

            int sayac;
            string komut = "SELECT * FROM kitapKodlari ORDER BY Kod DESC LIMIT 1;";
            MySqlCommand command = new MySqlCommand(komut, baglanti);
            sayac = Convert.ToInt32(command.ExecuteScalar()) + 1;

            return "kitap" + sayac;

        }  // baglanti open kullanmadık çünkü yazarekle fonksiyonunda zaten kullanıyoruz.
        public static void KitapEkle(string kitapAdi,string yazari,string yayinEvi,string turu,int sayfaSayisi,string baskisi,string depoAdi,int taneFiyat,int adet)
        {
            baglanti.Open();

            string kitapKodu = kitapKoduYarat();
            string kodsayi = "";
            if (!ayniKitapVarMi(kitapAdi,yazari,yayinEvi))
            {
                //Kitaplar tablosuna kitap eklendi 
                string yazarKodu;
                string yayinEviKodu;
                string turKodu;
                string depoKodu;
                string komut1 = "select yazarKodu from yazarlar where yazarAdiSoyadi='" + yazari + "'";
                MySqlCommand command1 = new MySqlCommand(komut1,baglanti);
                yazarKodu = command1.ExecuteScalar().ToString(); // yazar kodu veritabanından çekildi

                komut1 = "select yayinEviKodu from yayin_evleri where yayinEviAdi='" + yayinEvi + "'";
                command1 = new MySqlCommand(komut1, baglanti);
                yayinEviKodu = command1.ExecuteScalar().ToString(); // yayinevi kodu veritabanından çekildi

                komut1 = "select turKodu from kitap_turleri where turAdi='" + turu + "'";
                command1 = new MySqlCommand(komut1, baglanti);
                turKodu = command1.ExecuteScalar().ToString(); // tur kodu veritabanından çekildi

                // kitaplar tablosuna veriler eklendi
                string komut = "insert into kitaplar values('" + kitapKodu + "','" + kitapAdi + "','"+yazarKodu+ "','" + yayinEviKodu + "'," + sayfaSayisi + ",'" + baskisi + "','" + turKodu + "')";
                MySqlCommand command = new MySqlCommand(komut, baglanti);
                command.ExecuteNonQuery();
                // kitap kodu kitap_kodları tablosuna eklendi
                for (int i = 5; i < kitapKodu.Length; i++)
                {
                    kodsayi += kitapKodu[i];
                }
                komut = "insert into kitapKodlari values('" + kodsayi + "');";
                command = new MySqlCommand(komut, baglanti);
                command.ExecuteNonQuery();

                //kitap_depo tablosuna kitap eklendi

                

                komut = "insert into kitap_depo values('"+kitapKodu+"','"+depoAdi+"',"+taneFiyat+","+adet+");";
                command = new MySqlCommand(komut, baglanti);
                command.ExecuteNonQuery();

                MessageBox.Show("Kitap başarıyla eklendi!!..");
            }

            baglanti.Close();
        }
        public static DataTable kitapListele()
        {
            baglanti.Open();

            string komut = "select kitaplar.kitapKodu,kitaplar.kitapAdi,yazarlar.yazarAdiSoyadi,yayin_evleri.yayinEviAdi,kitaplar.sayfaSayisi,kitaplar.baskisi,kitap_turleri.turAdi,depolar.depoAdi,kitap_depo.taneFiyat,kitap_depo.adet from kitaplar,kitap_depo,yazarlar,depolar,yayin_evleri,kitap_turleri where kitaplar.kitapKodu = kitap_depo.kitapKodu and kitap_depo.depoKodu = depolar.depoTelefon and kitaplar.turu = kitap_turleri.turKodu and kitaplar.yayinEvi = yayin_evleri.yayinEviKodu and kitaplar.yazari = yazarlar.yazarKodu";
            MySqlCommand command = new MySqlCommand(komut,baglanti);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            
            baglanti.Close();
            return dt;
        }
    }
}
