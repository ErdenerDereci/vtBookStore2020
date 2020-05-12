﻿using System;
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
    class YazarFonksiyonlari
    {
       static  MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=kitap_evi;Uid=root;Pwd='root';");

        static private string yazarKoduYarat()
        {
            
            int sayac;
            string komut = "SELECT * FROM yazarKodlari ORDER BY kod DESC LIMIT 1;";
            MySqlCommand command = new MySqlCommand(komut,baglanti);
            sayac = Convert.ToInt32(command.ExecuteScalar()) + 1;
           
            return "yazar" + sayac;

        }  // baglanti open kullanmadık çünkü yazarekle fonksiyonunda zaten kullanıyoruz.
        private static bool ayniYazarVarMi(string yazarAdi)
        {


            string komut = "select count(yazarAdiSoyadi) from yazarlar where yazarAdiSoyadi='"+ yazarAdi+"'";
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
        public static void yazarEkle(string yazarAdi)
        {
            baglanti.Open();

            string yazarKodu = yazarKoduYarat();
            string kodsayi = "";
            if (!ayniYazarVarMi(yazarAdi))
            {

                string komut = "insert into yazarlar values('" + yazarKodu + "','" + yazarAdi + "')";
                MySqlCommand command = new MySqlCommand(komut, baglanti);
                command.ExecuteNonQuery();

                for(int i=5; i < yazarKodu.Length; i++)
                {
                    kodsayi += yazarKodu[i];
                }
                komut = "insert into yazarKodlari values('" + kodsayi + "');";
                command = new MySqlCommand(komut, baglanti);
                command.ExecuteNonQuery();
            }
           
            baglanti.Close();
        }
        public static DataTable yazarListele()
        {
            baglanti.Open();

            string komut = "select * from yazarlar";
            MySqlCommand command = new MySqlCommand(komut, baglanti);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            baglanti.Close();
            return dt;
        }

    }
}
