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
                panel1.Enabled = true;
            }

           
            depoComboboxLoad();
            turComboboxLoad();
            yayinEviComboboxLoad();
            yazarComboboxLoad();
            kullaniciLoad();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); // sadece sayı girişi

        }  //sadece sayi telno

        private void kaydet_Click(object sender, EventArgs e)
        {
            
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

            depoComboboxLoad();
            turComboboxLoad();
            yayinEviComboboxLoad();
            yazarComboboxLoad();
            kullaniciLoad();


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
            if(kitapAdi.Text==""|| yazari.Text == "" || yayinEvi.Text == "" || turu.Text == "" || sayfaSayisi.Text == "" || baskisi.Text == "" || depo.Text == "" || fiyat.Text == "" || adet.Text == "")
            {
                MessageBox.Show("Alanlar doldurulmak zorundadır!! Depo eklemediyseniz önce depo eklemeniz gerekmektedir.");
            }
            else
            {
                YazarFonksiyonlari.yazarEkle(yazari.Text);
                YayinEviFonksiyonlari.yayinEviEkle(yayinEvi.Text);
                TurFonksiyolari.turEkle(turu.Text);
                KitapFonksiyolari.KitapEkle(kitapAdi.Text, yazari.Text, yayinEvi.Text, turu.Text, Convert.ToInt32(sayfaSayisi.Text), baskisi.Text, depoKoduCek(depo.Text), Convert.ToInt32(fiyat.Text), Convert.ToInt32(adet.Text));
            }

            
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            
           
        }

        private void yazarComboboxLoad()
        {
            yazari.Items.Clear();
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
            turu.Items.Clear();
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
            depo.Items.Clear();
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand();

            komut.CommandText = "select  depoAdi,depoTelefon from depolar";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            MySqlDataReader read;

            read = komut.ExecuteReader();
            while (read.Read())
            {
                depo.Items.Add(read["depoTelefon"] + "-" + read["depoAdi"]);
            }

            baglanti.Close();
        }
        private void yayinEviComboboxLoad()
        {
            yayinEvi.Items.Clear();
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

        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void personeltelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void personelmaas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void personelyas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void personelad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
               && !char.IsSeparator(e.KeyChar); // sadece harf 
        }

        private void personelcinsiyet_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
               && !char.IsSeparator(e.KeyChar);
        }
        private void kullaniciLoad()
        {
            kullaniciComboBox.Items.Clear();
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand();
            MySqlCommand komut2 = new MySqlCommand();
            
            komut.CommandText = "select  personelAdiSoyadi,telefon from personel";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            MySqlDataReader read;
            

            read = komut.ExecuteReader();
            
            
            while (read.Read())
            {
                kullaniciComboBox.Items.Add(read["personelAdiSoyadi"] + " - " + read["telefon"]);
            }

            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            
        }
        private string telNoCek(string veri)
        {
            string x="";
            int i;
            for(i=0; i<veri.Length; i++)
            {
                if (veri[i] == '-')
                {
                    for (int j = i + 2; j < veri.Length; j++)
                    {
                        x += veri[j];
                    }
                }
                

            }
            return x;
            
        }
        private string depoKoduCek(string veri)
        {
            string x = "";
            for (int i = 0; i < veri.Length; i++)
            {
                if (veri[i] == '-')
                {
                    break;
                }
                x += veri[i];

            }
            return x;
        }

        private void sayfaSayisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void adet_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void fiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void kaydet_Click_1(object sender, EventArgs e)
        {
            veriTabaniEkle();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (ekleDepoAdi.Text == "" || ekleDepoAdresi.Text == "" || ekleTelefonNo.Text == "")
            {
                MessageBox.Show("Alanlar doldurulmak zorundadır!!!");
            }
            else
            {
                DepoFonksiyonlari.depoEkle(ekleDepoAdi.Text, ekleDepoAdresi.Text, ekleTelefonNo.Text);

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (personelad.Text == "" || personelcinsiyet.Text == "" || personeltelefon.Text == "" || personeladres.Text == "" || personelmail.Text == "" || personelgorev.Text == "" || personelmaas.Text == "")
            {
                MessageBox.Show("Alanlar doldurulmak zorundadır!!");
            }
            else
            {
                PersonelKodlari.personelEkle(personelad.Text, personelcinsiyet.Text, personeltelefon.Text, personeladres.Text, personelmail.Text, personelgorev.Text, Convert.ToInt32(personelmaas.Text));


            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            bool adminMi = false;
            string telno = telNoCek(kullaniciComboBox.Text);
            if (evet.Checked)
            {
                adminMi = true;
            }
            if (kullaniciAdi.Text == "" || sifre.Text == "" || sifreTekrari.Text == "" || kullaniciComboBox.Text == "")
            {
                MessageBox.Show("Alanlar doldurulmak zorundadır.!!");
            }
            else
            {
                baglanti.Open();

                MySqlCommand command2 = new MySqlCommand("select count(personelKodu) from kullanicilar where kullanicilar.personelKodu='" + telno + "'", baglanti);
                if (command2.ExecuteScalar().ToString() != "0")
                {
                    MessageBox.Show("Bu kullanici zaten atanmış!!");
                }
                else
                {
                    if (sifre.Text != sifreTekrari.Text)
                    {
                        MessageBox.Show("Şifreler eşleşmedi yeniden deneyiniz..");
                    }
                    else
                    {
                        MySqlCommand command = new MySqlCommand("insert into kullanicilar values('" + kullaniciAdi.Text + "','" + telno + "','" + sifre.Text + "'," + adminMi + ")", baglanti);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Kullanici eklendi..");
                    }

                }

                baglanti.Close();
            }
        }

        private void fiyat_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void adet_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ekleTelefonNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void personeltelefon_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void sayfaSayisi_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void personelmaas_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void personelad_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }
    } 
    
}
