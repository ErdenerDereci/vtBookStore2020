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
    public partial class SilGuncelle : Form
    {
        public SilGuncelle()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=kitap_evi;Uid=root;Pwd='root';");

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            personelGuncellePanel.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand command = new MySqlCommand();
            MySqlCommand command2 = new MySqlCommand();
            command2.CommandText = "select count(telefon) from personel where telefon='" + personeltelefon.Text + "'";
            command2.Connection = baglanti;
            string sart = command2.ExecuteScalar().ToString();
            if (personeltelefon.Text != label2.Text)
            {
                if (sart == "1")
                {
                    MessageBox.Show("Bu telefon zaten veritabanında mevcut!!");
                }
                else
                {
                    DialogResult secenek = MessageBox.Show("Personel kodunu değiştirdiniz. Bütün tablolar güncellenecek!! Devam edilsin mi?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (secenek == DialogResult.Yes)
                    {
                        command.CommandText = "update personel set personelAdiSoyadi='" + personelad.Text + "',telefon='" + personeltelefon.Text + "',cinsiyeti='" + personelcinsiyet.Text + "',adres='" + personeladres.Text + "',email='" + personelmail.Text + "',gorevi='" + personelgorev.Text + "',maas=" + Convert.ToInt32(personelmaas.Text) + " where telefon='" + label2.Text + "'";
                        command.Connection = baglanti;
                        command.ExecuteNonQuery();
                        MessageBox.Show("Güncelleme başarılı!!");
                    }
                }
                
            }
            else
            {
                DialogResult secenek = MessageBox.Show("Emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (secenek == DialogResult.Yes)
                {
                    command.CommandText = "update personel set personelAdiSoyadi='" + personelad.Text + "',telefon='" + personeltelefon.Text + "',cinsiyeti='" + personelcinsiyet.Text + "',adres='" + personeladres.Text + "',email='" + personelmail.Text + "',gorevi='" + personelgorev.Text + "',maas=" + Convert.ToInt32(personelmaas.Text) + " where telefon='" + label2.Text + "'";
                    command.Connection = baglanti;
                    command.ExecuteNonQuery();
                    MessageBox.Show("Güncelleme başarılı!!");
                }
            }


            baglanti.Close();

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            bool adminmi;
            if (evet.Checked == true)
            {
                adminmi = true;
            }
            else
            {
                adminmi = false;
            }
            MySqlCommand command = new MySqlCommand();
            command.CommandText ="update kullanicilar set userId='"+useridtext.Text+"',pass='"+passtext.Text+"',adminMi=" + adminmi + " where personelKodu='"+kullanicisart.Text+"'";
            command.Connection = baglanti;
            command.ExecuteNonQuery();
            MessageBox.Show("Güncelleme başarılı!!");
            baglanti.Close();
        }

        private void SilGuncelle_Load(object sender, EventArgs e)
        {
            yazarComboboxLoad();
            turComboboxLoad();
            depoComboboxLoad();
            yayinEviComboboxLoad();
            personelLoad();
            urunLoad();
            //kullaniciLoad();
        }
        private void yazarComboboxLoad()
        {
            sgyazari.Items.Clear();
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand();

            komut.CommandText = "select  yazarAdiSoyadi from yazarlar";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            MySqlDataReader read;

            read = komut.ExecuteReader();
            while (read.Read())
            {
                sgyazari.Items.Add(read["yazarAdiSoyadi"]);
            }

            baglanti.Close();
        }
        private void turComboboxLoad()
        {
            sgturu.Items.Clear();
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand();

            komut.CommandText = "select  turAdi from kitap_turleri";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            MySqlDataReader read;

            read = komut.ExecuteReader();
            while (read.Read())
            {
                sgturu.Items.Add(read["turAdi"]);
            }

            baglanti.Close();
        }
        private void depoComboboxLoad()
        {
            sgdepo.Items.Clear();
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand();

            komut.CommandText = "select  depoAdi,depoTelefon from depolar";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            MySqlDataReader read;

            read = komut.ExecuteReader();
            while (read.Read())
            {
                sgdepo.Items.Add(read["depoAdi"]);
            }

            baglanti.Close();
        }
        private void yayinEviComboboxLoad()
        {
            sgyayinEvi.Items.Clear();
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand();

            komut.CommandText = "select  yayinEviAdi from yayin_evleri";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            MySqlDataReader read;

            read = komut.ExecuteReader();
            while (read.Read())
            {
                sgyayinEvi.Items.Add(read["yayinEviAdi"]);
            }

            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand command = new MySqlCommand();
            MySqlCommand command2 = new MySqlCommand();
            command2.CommandText = "select count(kitapAdi) from kitaplar where kitapAdi='" + sgkitapAdi.Text + "'";
            command2.Connection = baglanti;
            string sart = command2.ExecuteScalar().ToString();
            if (sgkitapAdi.Text != kitaplabel.Text)
            {
                if (sart == "1")
                {
                    DialogResult secenek = MessageBox.Show("Bu kitap adi zaten veritabanında mevcut!! Yine de değiştirmek istediğinizden emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (secenek == DialogResult.Yes)
                    {
                        YazarFonksiyonlari.yazarEkle(sgyazari.Text);
                        YayinEviFonksiyonlari.yayinEviEkle(sgyayinEvi.Text);
                        TurFonksiyolari.turEkle(sgturu.Text);

                        command.CommandText = "update kitaplar set kitapAdi='" + sgkitapAdi.Text + "',yazari='" + yazarKoduCek(sgyazari.Text) + "',yayinEvi='" + yayinEviKoduCek(sgyayinEvi.Text) + "',sayfaSayisi='" + Convert.ToInt32(sgsayfaSayisi.Text) + "',baskisi='" + sgbaskisi.Text + "',turu='" + turKoduCek(sgturu.Text) + "' where kitapKodu='" + kitapKoduLabel.Text + "'";
                        command.Connection = baglanti;
                        command.ExecuteNonQuery();
                        command.CommandText = "update kitap_depo set depoKodu='" + depoKoduCek(sgdepo.Text) + "',taneFiyat=" + Convert.ToInt32(sgfiyat.Text) + ",adet=" + Convert.ToInt32(sgadet.Text) + " where kitapKodu='" + kitapKoduLabel.Text + "'";
                        command.ExecuteNonQuery();
                        MessageBox.Show("Güncelleme başarılı!!");
                    }
                }
                else
                {
                    DialogResult secenek = MessageBox.Show("Emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (secenek == DialogResult.Yes)
                    {
                        YazarFonksiyonlari.yazarEkle(sgyazari.Text);
                        YayinEviFonksiyonlari.yayinEviEkle(sgyayinEvi.Text);
                        TurFonksiyolari.turEkle(sgturu.Text);

                        command.CommandText = "update kitaplar set kitapAdi='" + sgkitapAdi.Text + "',yazari='" + yazarKoduCek(sgyazari.Text) + "',yayinEvi='" + yayinEviKoduCek(sgyayinEvi.Text) + "',sayfaSayisi='" + Convert.ToInt32(sgsayfaSayisi.Text) + "',baskisi='" + sgbaskisi.Text + "',turu='" + turKoduCek(sgturu.Text) + "' where kitapKodu='" + kitapKoduLabel.Text + "'";
                        command.Connection = baglanti;
                        command.ExecuteNonQuery();
                        command.CommandText = "update kitap_depo set depoKodu='" + depoKoduCek(sgdepo.Text) + "',taneFiyat=" + Convert.ToInt32(sgfiyat.Text) + ",adet=" + Convert.ToInt32(sgadet.Text) + " where kitapKodu='" + kitapKoduLabel.Text + "'";
                        command.ExecuteNonQuery();
                        MessageBox.Show("Güncelleme başarılı!!");
                    }
                }

            }
            else
            {
                DialogResult secenek = MessageBox.Show("Emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (secenek == DialogResult.Yes)
                {
                    YazarFonksiyonlari.yazarEkle(sgyazari.Text);
                    YayinEviFonksiyonlari.yayinEviEkle(sgyayinEvi.Text);
                    TurFonksiyolari.turEkle(sgturu.Text);

                    command.CommandText = "update kitaplar set kitapAdi='" + sgkitapAdi.Text + "',yazari='" + yazarKoduCek(sgyazari.Text) + "',yayinEvi='" + yayinEviKoduCek(sgyayinEvi.Text) + "',sayfaSayisi='" + Convert.ToInt32(sgsayfaSayisi.Text) + "',baskisi='" + sgbaskisi.Text + "',turu='" + turKoduCek(sgturu.Text) + "' where kitapKodu='" + kitapKoduLabel.Text + "'";
                    command.Connection = baglanti;
                    command.ExecuteNonQuery();
                    command.CommandText = "update kitap_depo set depoKodu='" + depoKoduCek(sgdepo.Text) + "',taneFiyat=" + Convert.ToInt32(sgfiyat.Text) + ",adet=" + Convert.ToInt32(sgadet.Text) + " where kitapKodu='" + kitapKoduLabel.Text + "'";
                    command.ExecuteNonQuery();
                    MessageBox.Show("Güncelleme başarılı!!");
                }
            }


            baglanti.Close();



        }
        //private void kullaniciLoad()
        //{
        //    kullaniciComboBox.Items.Clear();
        //    baglanti.Open();
        //    MySqlCommand komut = new MySqlCommand();
        //    MySqlCommand komut2 = new MySqlCommand();

        //    komut.CommandText = "select  personelAdiSoyadi,telefon from personel";
        //    komut.Connection = baglanti;
        //    komut.CommandType = CommandType.Text;
        //    MySqlDataReader read;


        //    read = komut.ExecuteReader();


        //    while (read.Read())
        //    {
        //        kullaniciComboBox.Items.Add(read["personelAdiSoyadi"] + " - " + read["telefon"]);
        //    }

        //    baglanti.Close();
        //}
        private string yazarKoduCek(string veri)
        {
            string yazarKodu;
            string komut1 = "select yazarKodu from yazarlar where yazarAdiSoyadi='" + veri + "'";
            MySqlCommand command1 = new MySqlCommand(komut1, baglanti);
            yazarKodu = command1.ExecuteScalar().ToString(); // yazar kodu veritabanından çekildi

            return yazarKodu;
            
        }
        private string turKoduCek(string veri)
        {

            string turKodu;
            string komut1 = "select turKodu from kitap_turleri where turAdi='" + veri + "'";
            MySqlCommand command1 = new MySqlCommand(komut1, baglanti);
            turKodu = command1.ExecuteScalar().ToString();

            return turKodu;
        }

        private string yayinEviKoduCek(string veri)
        {
            string yayinEviKodu;
            string komut1 = "select yayinEviKodu from yayin_evleri where yayinEviAdi='" + veri + "'";
            MySqlCommand command1 = new MySqlCommand(komut1, baglanti);
            yayinEviKodu = command1.ExecuteScalar().ToString();

            return yayinEviKodu;
        }
        private string depoKoduCek(string veri)
        {
            string yayinEviKodu;
            string komut1 = "select depoTelefon from depolar where depoAdi='" + veri + "'";
            MySqlCommand command1 = new MySqlCommand(komut1, baglanti);
            yayinEviKodu = command1.ExecuteScalar().ToString();

            return yayinEviKodu;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand command = new MySqlCommand();
            MySqlCommand command2 = new MySqlCommand();
            command2.CommandText = "select count(yazarAdiSoyadi) from yazarlar where yazarAdiSoyadi='" +sgyazaryazar.Text + "'";
            command2.Connection = baglanti;
            string sart = command2.ExecuteScalar().ToString();
            if (sgyazaryazar.Text != label16.Text)
            {
                if (sart == "1")
                {
                    MessageBox.Show("Bu yazar adi zaten veritabanında mevcut! Veri eklenmedi..");
                }
                else
                {
                    DialogResult secenek = MessageBox.Show("Emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (secenek == DialogResult.Yes)
                    {
                        
                        command.CommandText = "update yazarlar set yazarAdiSoyadi='" + sgyazaryazar.Text + "' where yazarKodu='" + label13.Text + "'";
                        command.Connection = baglanti;
                        command.ExecuteNonQuery();
                        
                        MessageBox.Show("Güncelleme başarılı!!");
                    }
                }

            }
            else
            {
                DialogResult secenek = MessageBox.Show("Emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (secenek == DialogResult.Yes)
                {

                    command.CommandText = "update yazarlar set yazarAdiSoyadi='" + sgyazaryazar.Text + "' where yazarKodu='" + label13.Text + "'";
                    command.Connection = baglanti;
                    command.ExecuteNonQuery();

                    MessageBox.Show("Güncelleme başarılı!!");
                }
            }


            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand command = new MySqlCommand();
            MySqlCommand command2 = new MySqlCommand();
            
            command2.CommandText = "select count(depoAdresi) from depolar where depoAdresi='" + depoadresrich.Text + "'";
            command2.Connection = baglanti;
            int sart = Convert.ToInt32(command2.ExecuteScalar());
            command2.CommandText = "select count(depoAdi) from depolar where depoAdi='" + sgdepotextbox.Text + "'";
            int sart2 = Convert.ToInt32(command2.ExecuteScalar());
            if (depoadresrich.Text != depoadreslabel.Text)
            {
                if (sart >0 )
                {
                  
                        MessageBox.Show("Bu depo adresi zaten veritabanında mevcut! Veri eklenmedi..");
                    
                }
                else
                {
                    if (sart2 >0 && sgdepotextbox.Text!=depodepo.Text)
                    {
                        DialogResult secenek = MessageBox.Show("Bu depo adi veri tabanında mevcut yine de eklensin mi?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (secenek == DialogResult.Yes)
                        {

                            command.CommandText = "update depolar set depoAdi='" + sgdepotextbox.Text + "',depoAdresi='"+depoadresrich.Text+ "' where depoAdresi='" + depoadreslabel.Text + "'";
                            command.Connection = baglanti;
                            command.ExecuteNonQuery();

                            MessageBox.Show("Güncelleme başarılı!!");
                        }
                    }else
                    {
                        DialogResult secenek = MessageBox.Show("Emin misiniz ?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (secenek == DialogResult.Yes)
                        {

                            command.CommandText = "update depolar set depoAdi='" + sgdepotextbox.Text + "',depoAdresi='" + depoadresrich.Text + "' where depoAdresi='" + depoadreslabel.Text + "'";
                            command.Connection = baglanti;
                            command.ExecuteNonQuery();

                            MessageBox.Show("Güncelleme başarılı!!");
                        }
                    }
                    
                }

            }
            else
            {
                if(sgdepotextbox.Text == depodepo.Text)
                {
                    MessageBox.Show("Değişiklik yapılmadı.");
                }
                else
                {
                    if (sart2 > 0)
                    {
                        DialogResult secenek = MessageBox.Show("Bu depo adi veri tabanında mevcut yine de eklensin mi?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (secenek == DialogResult.Yes)
                        {

                            command.CommandText = "update depolar set depoAdi='" + sgdepotextbox.Text + "' where depoAdresi='" + depoadreslabel.Text + "'";
                            command.Connection = baglanti;
                            command.ExecuteNonQuery();

                            MessageBox.Show("Depo adı güncellendi..");
                        }
                    }
                    else
                    {
                        command.CommandText = "update depolar set depoAdi='" + sgdepotextbox.Text + "' where depoAdresi='" + depoadreslabel.Text + "'";
                        command.Connection = baglanti;
                        command.ExecuteNonQuery();

                        MessageBox.Show("Depo adı güncellendi.");
                    }
                    
                }
                

                    
                
            }


            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand command = new MySqlCommand();
            MySqlCommand command2 = new MySqlCommand();

            command2.CommandText = "select count(yayinEviAdi) from yayin_evleri where yayinEviAdi='" + sgyayinevitext.Text + "'";
            command2.Connection = baglanti;
            int sart = Convert.ToInt32(command2.ExecuteScalar());
            
            if (sgyayinevitext.Text != sgyayineviadilabel.Text)
            {
                if (sart > 0)
                {
                    DialogResult secenek = MessageBox.Show("Bu yayinevi adı zaten veritabanında mevcut! Yine de eklensin mi?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (secenek == DialogResult.Yes)
                    {

                        command.CommandText = "update yayin_evleri set yayinEviAdi='" + sgyayinevitext.Text + "' where yayinEviKodu='" + sgyayinevikodulabel.Text + "'";
                        command.Connection = baglanti;
                        command.ExecuteNonQuery();

                        MessageBox.Show("Güncelleme başarılı!!");
                    }

                }
                else
                {

                    DialogResult secenek = MessageBox.Show("Emin misiniz ?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (secenek == DialogResult.Yes)
                    {

                        command.CommandText = "update yayin_evleri set yayinEviAdi='" + sgyayinevitext.Text + "' where yayinEviKodu='" + sgyayinevikodulabel.Text + "'";
                        command.Connection = baglanti;
                        command.ExecuteNonQuery();

                        MessageBox.Show("Güncelleme başarılı!!");
                    }

                }

            }
            else
            {
                MessageBox.Show("Değişiklik yapılmadı..");
            }


            baglanti.Close();
        }
        private void personelLoad()
        {
            sgsiparisalancombobox.Items.Clear();
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand();

            komut.CommandText = "select  personelAdiSoyadi,telefon from personel";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            MySqlDataReader read;

            read = komut.ExecuteReader();
            while (read.Read())
            {
                sgsiparisalancombobox.Items.Add(read["personelAdiSoyadi"]+"-"+ read["telefon"]);
            }

            baglanti.Close();
        }
        private void urunLoad()
        {
            sgsiparisuruncombobox.Items.Clear();
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand();

            komut.CommandText = "select  kitapAdi,kitapKodu from kitaplar";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            MySqlDataReader read;

            read = komut.ExecuteReader();
            while (read.Read())
            {
                sgsiparisuruncombobox.Items.Add(read["kitapAdi"] + "-" + read["kitapKodu"]);
            }

            baglanti.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
