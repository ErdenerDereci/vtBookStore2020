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
    public partial class Ekle : Form
    {
        public Ekle()
        {
            InitializeComponent();
        }



        MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=kitap_evi;Uid=root;Pwd='root';");


        private void Ekle_Load(object sender, EventArgs e)
        {
            Giris x = new Giris();
            if (label21.Text=="ADMİN")
            {
                personelPanel.Enabled = true;
            }
           
            
            depoComboboxLoad();
            turComboboxLoad();
            yayinEviComboboxLoad();
            yazarComboboxLoad();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); // sadece sayı girişi

        }  //sadece sayi telno

        private void kaydet_Click(object sender, EventArgs e)
        {
            veriTabaniEkle();

            //if (kontrol())
            //{
            //    MessageBox.Show("Alanlar boş geçilemez!");
            //}
            //else
            //{
            //    if (depoKontrol())
            //    {
            //        DialogResult secim = new DialogResult();
            //        secim = MessageBox.Show("İlgili veriler veritabanına eklenecek!! Devam etmek istediğinizden emin misiniz ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            //        if (secim == DialogResult.Yes) // Kaydetme işlemi yapılır
            //        {
            //            //comboboxlara yazılan elemanlar comboboxların içinde ise veya boşsa eklemiyor

            //            if (!turu.Items.Contains(turu.Text) && turu.Text != "")
            //            {
            //                turu.Items.Add(turu.Text);
            //            }
            //            if (!yayinEvi.Items.Contains(yayinEvi.Text) && yayinEvi.Text != "")
            //            {
            //                yayinEvi.Items.Add(yayinEvi.Text);
            //            }
            //            veriTabaniEkle(); // veritabanına eklendi
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Kaydetme gerçekleştirilemedi. Önce depo ekleyiniz..!");
            //    }
            //}
        } //kaydet butonu

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            kitapAdi.Text = "";

            sayfaSayisi.Text = "";
            yazari.Text = "";
            baskisi.Text = "";
            adet.Text = "";
            fiyat.Text = "";
            depo.Text = "";
            turu.Text = "";
            yayinEvi.Text = "";
        } // tablar arası geçişte textboxlar temizleniyor
        private bool kontrol()
        {
            if (kitapAdi.Text == "" || sayfaSayisi.Text == "" || turu.Text == "" || yazari.Text == "" || baskisi.Text == "" || yayinEvi.Text == "" || fiyat.Text == "" || adet.Text == "" || depo.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private void veriTabaniEkle()
        {
            YazarFonksiyonlari.yazarEkle(yazari.Text);
            YayinEviFonksiyonlari.yayinEviEkle(yayinEvi.Text);
            TurFonksiyolari.turEkle(turu.Text);
            KitapFonksiyolari.KitapEkle(kitapAdi.Text,yazari.Text,yayinEvi.Text,turu.Text,Convert.ToInt32(sayfaSayisi.Text),baskisi.Text,depo.Text,Convert.ToInt32(fiyat.Text), Convert.ToInt32(adet.Text));
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            if(ekleDepoAdi.Text=="" || ekleDepoAdresi.Text=="" || ekleTelefonNo.Text == "")
            {
                MessageBox.Show("Alanlar doldurulmak zorundadır!!!");
            }
            else
            {
                DepoFonksiyonlari.depoEkle(ekleDepoAdi.Text, ekleDepoAdresi.Text, ekleTelefonNo.Text);
                MessageBox.Show("Depo başarıyla eklendi..");
            }
           
        }

        private void yazarComboboxLoad()
        {
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand();

            komut.CommandText = "select  yazarAdiSoyadi from yazarlar";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            MySqlDataReader read;

            read = komut.ExecuteReader();
            while (read.Read())
            {
                yazari.Items.Add(read["yazarAdiSoyadi"]);
            }

            baglanti.Close();
        }
        private void turComboboxLoad()
        {
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand();

            komut.CommandText = "select  turAdi from kitap_turleri";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            MySqlDataReader read;

            read = komut.ExecuteReader();
            while (read.Read())
            {
                turu.Items.Add(read["turAdi"]);
            }

            baglanti.Close();
        }
        private void depoComboboxLoad()
        {
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand();

            komut.CommandText = "select  depoAdi from depolar";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            MySqlDataReader read;

            read = komut.ExecuteReader();
            while (read.Read())
            {
                depo.Items.Add(read["depoAdi"]);
            }

            baglanti.Close();
        }
        private void yayinEviComboboxLoad()
        {
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand();

            komut.CommandText = "select  yayinEviAdi from yayin_evleri";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            MySqlDataReader read;

            read = komut.ExecuteReader();
            while (read.Read())
            {
                yayinEvi.Items.Add(read["yayinEviAdi"]);
            }

            baglanti.Close();
        }
    } 
    
}
