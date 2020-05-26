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
        private bool kullaniciBosMu()
        {
            if (useridtext.Text == "" || passtext.Text == "") {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool personelBosMu()
        {
            if(personelad.Text=="" || personelcinsiyet.Text == "" || personeladres.Text == "" || personelmail.Text == "" || personelmaas.Text == "" || personelgorev.Text == "" || personeltelefon.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            if (personelBosMu())
            {
                MessageBox.Show("Alanlar doldurulmak zorundadır!");
            }
            else
            {
                if (personeltelefon.Text == label2.Text || !ayniPersonelTelefonVarMi(personeltelefon.Text))
                {
                    if (personelemaillabel.Text == personelmail.Text || !ayniPersonelMailVarMi(personelmail.Text))
                    {
                        DialogResult secenek = MessageBox.Show("Emin misiniz? (Personel telefon numarasını değiştirdiyseniz bütün tablolar etkilenecek!)", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (secenek == DialogResult.Yes)
                        {
                            MySqlCommand command = new MySqlCommand();
                            command.CommandText = "update personel set personelAdiSoyadi='" + personelad.Text + "',telefon='" + personeltelefon.Text + "',cinsiyeti='" + personelcinsiyet.Text + "',adres='" + personeladres.Text + "',email='" + personelmail.Text + "',gorevi='" + personelgorev.Text + "',maas=" + Convert.ToInt32(personelmaas.Text) + " where telefon='" + label2.Text + "'";
                            command.Connection = baglanti;
                            command.ExecuteNonQuery();
                            MessageBox.Show("Güncelleme başarılı!!");
                            personelemaillabel.Text = personelmail.Text;
                            label2.Text = personeltelefon.Text;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu e-mail zaten veritabanında mevcut!! Güncelleme başarısız.");
                    }
                }
                else
                {
                    MessageBox.Show("Bu telefon zaten veritabanında mevcut!! Güncelleme başarısız.");
                }
            }
            
            
            //if (personeltelefon.Text != label2.Text)
            //{
            //    if (sart == "1")
            //    {
            //        MessageBox.Show("Bu telefon zaten veritabanında mevcut!!");
            //    }
            //    else
            //    {
            //        DialogResult secenek = MessageBox.Show("Personel kodunu değiştirdiniz. Bütün tablolar güncellenecek!! Devam edilsin mi?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //        if (secenek == DialogResult.Yes)
            //        {
            //            command.CommandText = "update personel set personelAdiSoyadi='" + personelad.Text + "',telefon='" + personeltelefon.Text + "',cinsiyeti='" + personelcinsiyet.Text + "',adres='" + personeladres.Text + "',email='" + personelmail.Text + "',gorevi='" + personelgorev.Text + "',maas=" + Convert.ToInt32(personelmaas.Text) + " where telefon='" + label2.Text + "'";
            //            command.Connection = baglanti;
            //            command.ExecuteNonQuery();
            //            MessageBox.Show("Güncelleme başarılı!!");
            //        }
            //    }
                
            //}
            //else
            //{
            //    DialogResult secenek = MessageBox.Show("Emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //    if (secenek == DialogResult.Yes)
            //    {
            //        command.CommandText = "update personel set personelAdiSoyadi='" + personelad.Text + "',telefon='" + personeltelefon.Text + "',cinsiyeti='" + personelcinsiyet.Text + "',adres='" + personeladres.Text + "',email='" + personelmail.Text + "',gorevi='" + personelgorev.Text + "',maas=" + Convert.ToInt32(personelmaas.Text) + " where telefon='" + label2.Text + "'";
            //        command.Connection = baglanti;
            //        command.ExecuteNonQuery();
            //        MessageBox.Show("Güncelleme başarılı!!");
            //    }
            //}


            baglanti.Close();

            

        }
        private bool ayniPersonelTelefonVarMi(string tel)
        {
            MySqlCommand command2 = new MySqlCommand();
            command2.CommandText = "select count(telefon) from personel where telefon='" + tel + "'";
            command2.Connection = baglanti;
            string sart = command2.ExecuteScalar().ToString();
            if (sart == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool ayniPersonelMailVarMi(string mail)
        {
            MySqlCommand command2 = new MySqlCommand();
            command2.CommandText = "select count(email) from personel where email='" + mail + "'";
            command2.Connection = baglanti;
            string sart = command2.ExecuteScalar().ToString();
            if (sart == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool ayniKullaniciVarMi(string userid)
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "select count(userId) from kullanicilar where userId='" + userid + "'";
            command.Connection = baglanti;
            string sart = command.ExecuteScalar().ToString();
            if (sart == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            bool adminmi;
            if (kullaniciBosMu())
            {
                MessageBox.Show("Alanlar doldurulmak zorundadır!");
            }
            else
            {
                if (useridlabel.Text==useridtext.Text || !ayniKullaniciVarMi(useridtext.Text))
                {
                    if (evet.Checked == true)
                    {
                        adminmi = true;
                    }
                    else
                    {
                        adminmi = false;
                    }
                    DialogResult secenek = MessageBox.Show("Emin misiniz ?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (secenek == DialogResult.Yes)
                    {
                        MySqlCommand command = new MySqlCommand();
                        command.CommandText = "update kullanicilar set userId='" + useridtext.Text + "',pass='" + passtext.Text + "',adminMi=" + adminmi + " where personelKodu='" + kullanicisart.Text + "'";
                        command.Connection = baglanti;
                        command.ExecuteNonQuery();

                        MessageBox.Show("Güncelleme başarılı!!");
                        useridlabel.Text = useridtext.Text;
                    }
                }
                else
                {
                    MessageBox.Show("Bu kullanıcı adı veri tabanında kayıtlı. Farklı bir kullanıcı adı seçin!");
                }


            }
            baglanti.Close();
        }

        private void SilGuncelle_Load(object sender, EventArgs e)
        {
            yazarComboboxLoad();
            turComboboxLoad();
            depoComboboxLoad();
            yayinEviComboboxLoad();
           
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
            if (sgkitapAdi.Text == "" || sgturu.Text == "" || sgyayinEvi.Text == "" || sgyazari.Text == "" || sgfiyat.Text == "" || sgadet.Text == "" || sgdepo.Text == "")
            {
                MessageBox.Show("Alanlar doldurulmak zorundadır!");
            }
            else
            {
                baglanti.Open();
                MySqlCommand command = new MySqlCommand();
                MySqlCommand command2 = new MySqlCommand();
                command2.CommandText = "select count(kitapAdi) from kitaplar where kitapAdi='" + sgkitapAdi.Text + "'";
                command2.Connection = baglanti;
                int sart = Convert.ToInt32(command2.ExecuteScalar());
                if (sgkitapAdi.Text == kitaplabel.Text && sgyazari.Text==sgyazarilabel.Text && sgyayinEvi.Text==sgyayinevilabel.Text)
                {
                    DialogResult secenek = MessageBox.Show("Emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (secenek == DialogResult.Yes)
                    {
                        YazarFonksiyonlari.yazarEkle(sgyazari.Text);
                        YayinEviFonksiyonlari.yayinEviEkle(sgyayinEvi.Text);
                        TurFonksiyolari.turEkle(sgturu.Text);

                        command.CommandText = "update kitaplar set kitapAdi='" + sgkitapAdi.Text + "',yazari='" + yazarKoduCek(sgyazari.Text) + "',yayinEvi='" + yayinEviKoduCek(sgyayinEvi.Text) + "',turu='" + turKoduCek(sgturu.Text) + "' where kitapKodu='" + kitapKoduLabel.Text + "'";
                        command.Connection = baglanti;
                        command.ExecuteNonQuery();
                        command.CommandText = "update kitap_depo set depoKodu='" + depoKoduCek(sgdepo.Text) + "',satisFiyati=" + Convert.ToInt32(sgfiyat.Text) + ",adet=" + Convert.ToInt32(sgadet.Text) + " where kitapKodu='" + kitapKoduLabel.Text + "'";
                        command.ExecuteNonQuery();
                        MessageBox.Show("Güncelleme başarılı!!");
                    }
                }
                else if(!KitapFonksiyolari.ayniKitapVarMi(sgkitapAdi.Text, yazarKoduCek(sgyazari.Text),yayinEviKoduCek(sgyayinEvi.Text)))
                {



                    if (sgkitapAdi.Text!=kitaplabel.Text && sart > 0)
                    {
                        DialogResult secenek = MessageBox.Show("Bu kitap adi zaten veritabanında mevcut!! Yine de değiştirmek istediğinizden emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (secenek == DialogResult.Yes)
                        {
                            YazarFonksiyonlari.yazarEkle(sgyazari.Text);
                            YayinEviFonksiyonlari.yayinEviEkle(sgyayinEvi.Text);
                            TurFonksiyolari.turEkle(sgturu.Text);

                            command.CommandText = "update kitaplar set kitapAdi='" + sgkitapAdi.Text + "',yazari='" + yazarKoduCek(sgyazari.Text) + "',yayinEvi='" + yayinEviKoduCek(sgyayinEvi.Text) + "',turu='" + turKoduCek(sgturu.Text) + "' where kitapKodu='" + kitapKoduLabel.Text + "'";
                            command.Connection = baglanti;
                            command.ExecuteNonQuery();
                            command.CommandText = "update kitap_depo set depoKodu='" + depoKoduCek(sgdepo.Text) + "',satisFiyati=" + Convert.ToInt32(sgfiyat.Text) + ",adet=" + Convert.ToInt32(sgadet.Text) + " where kitapKodu='" + kitapKoduLabel.Text + "'";
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

                            command.CommandText = "update kitaplar set kitapAdi='" + sgkitapAdi.Text + "',yazari='" + yazarKoduCek(sgyazari.Text) + "',yayinEvi='" + yayinEviKoduCek(sgyayinEvi.Text) + "',turu='" + turKoduCek(sgturu.Text) + "' where kitapKodu='" + kitapKoduLabel.Text + "'";
                            command.Connection = baglanti;
                            command.ExecuteNonQuery();
                            command.CommandText = "update kitap_depo set depoKodu='" + depoKoduCek(sgdepo.Text) + "',satisFiyati=" + Convert.ToInt32(sgfiyat.Text) + ",adet=" + Convert.ToInt32(sgadet.Text) + " where kitapKodu='" + kitapKoduLabel.Text + "'";
                            command.ExecuteNonQuery();
                            MessageBox.Show("Güncelleme başarılı!!");
                        }
                    }

                }
               


                baglanti.Close();
            }
           



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
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            if (depotelno.Text == "" || depoadresrich.Text == "" || sgdepotextbox.Text == "")
            {
                MessageBox.Show("Alanlar doldurulmak zorundadır.");
            }
            else
            {
                if (depotelno.Text == dtlnolabel.Text || !depoTelVarMi(depotelno.Text))
                {
                    //telno değişir
                    if (depoadreslabel.Text == depoadresrich.Text || !depoAdresiVarMi(depoadresrich.Text))
                    {
                        //telno ve adresi değişir
                        if (sgdepotextbox.Text == depodepo.Text || !depoAdiVarMi(sgdepotextbox.Text))
                        {
                            DialogResult secenek = MessageBox.Show("Emin misiniz ?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (secenek == DialogResult.Yes)
                            {
                                MySqlCommand command = new MySqlCommand();
                                command.CommandText = "update depolar set depoAdi='" + sgdepotextbox.Text + "',depoAdresi='" + depoadresrich.Text + "',depoTelefon='" + depotelno.Text + "' where depoTelefon='" + dtlnolabel.Text + "'";
                                command.Connection = baglanti;
                                command.ExecuteNonQuery();

                                MessageBox.Show("Güncelleme başarılı!!");
                            }
                        }
                        else
                        {
                            DialogResult secenek = MessageBox.Show("Bu depo adi veri tabanında mevcut yine de eklensin mi?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (secenek == DialogResult.Yes)
                            {
                                MySqlCommand command = new MySqlCommand();
                                command.CommandText = "update depolar set depoAdi='" + sgdepotextbox.Text + "',depoAdresi='" + depoadresrich.Text + "',depoTelefon='" + depotelno.Text + "' where depoTelefon='" + dtlnolabel.Text + "'";
                                command.Connection = baglanti;
                                command.ExecuteNonQuery();

                                MessageBox.Show("Güncelleme başarılı!!");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Depo adresi mevcut güncelleme başarısız.");
                    }
                }
                else
                {
                    MessageBox.Show("Depo telno  mevcut güncelleme başarısız.");
                }
            }
            

            //if (depoadresrich.Text != depoadreslabel.Text)
            //{
            //    if (depoAdresiVarMi(depoadresrich.Text))
            //    {
                  
            //            MessageBox.Show("Bu depo adresi zaten veritabanında mevcut! Veri eklenmedi..");
                    
            //    }else if (depoTelVarMi(depotelno.Text) && dtlnolabel.Text!=depotelno.Text)
            //    {
            //            MessageBox.Show("Bu depo telefon numarası zaten veritabanında mevcut! Veri eklenmedi..");
            //    }
            //    else
            //    {
            //        if (depoAdiVarMi(sgdepotextbox.Text) && sgdepotextbox.Text!=depodepo.Text)
            //        {
            //            DialogResult secenek = MessageBox.Show("Bu depo adi veri tabanında mevcut yine de eklensin mi?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //            if (secenek == DialogResult.Yes)
            //            {
            //                MySqlCommand command = new MySqlCommand();
            //                command.CommandText = "update depolar set depoAdi='" + sgdepotextbox.Text + "',depoAdresi='"+depoadresrich.Text+ "',depoTelefon='"+depotelno.Text+"' where depoAdresi='" + depoadreslabel.Text + "'";
            //                command.Connection = baglanti;
            //                command.ExecuteNonQuery();

            //                MessageBox.Show("Güncelleme başarılı!!");
            //            }
            //        }else
            //        {
            //            DialogResult secenek = MessageBox.Show("Emin misiniz ?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //            if (secenek == DialogResult.Yes)
            //            {
            //                MySqlCommand command = new MySqlCommand();
            //                command.CommandText = "update depolar set depoAdi='" + sgdepotextbox.Text + "',depoAdresi='" + depoadresrich.Text + "',depoTelefon='" + depotelno.Text + "' where depoAdresi='" + depoadreslabel.Text + "'";
            //                command.Connection = baglanti;
            //                command.ExecuteNonQuery();

            //                MessageBox.Show("Güncelleme başarılı!!");
            //            }
            //        }
                    
            //    }

            //}
            //else
            //{
            //    if(sgdepotextbox.Text == depodepo.Text)
            //    {
            //        MessageBox.Show("Değişiklik yapılmadı.");
            //    }
            //    else
            //    {
            //        if (sart2 > 0)
            //        {
            //            DialogResult secenek = MessageBox.Show("Bu depo adi veri tabanında mevcut yine de eklensin mi?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //            if (secenek == DialogResult.Yes)
            //            {
            //                MySqlCommand command = new MySqlCommand();
            //                command.CommandText = "update depolar set depoAdi='" + sgdepotextbox.Text + "' where depoAdresi='" + depoadreslabel.Text + "'";
            //                command.Connection = baglanti;
            //                command.ExecuteNonQuery();

            //                MessageBox.Show("Depo adı güncellendi..");
            //            }
            //        }
            //        else
            //        {
            //            MySqlCommand command = new MySqlCommand();
            //            command.CommandText = "update depolar set depoAdi='" + sgdepotextbox.Text + "' where depoAdresi='" + depoadreslabel.Text + "'";
            //            command.Connection = baglanti;
            //            command.ExecuteNonQuery();

            //            MessageBox.Show("Depo adı güncellendi.");
            //        }
                    
            //    }
                

                    
                
            //}


            baglanti.Close();
        }
        private bool depoAdresiVarMi(string adres)
        {
            
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "select count(depoAdresi) from depolar where depoAdresi='" + adres + "'";
            command.Connection = baglanti;
            int sart = Convert.ToInt32(command.ExecuteScalar());
            
            if (sart == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool depoAdiVarMi(string ad)
        {
            
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "select count(depoAdi) from depolar where depoAdi='" + ad + "'";
            command.Connection = baglanti;
            int sart = Convert.ToInt32(command.ExecuteScalar());
            
            if (sart == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool depoTelVarMi(string tel)
        {
            
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "select count(depoTelefon) from depolar where depoTelefon='" + tel + "'";
            command.Connection = baglanti;
            int sart = Convert.ToInt32(command.ExecuteScalar());
            
            if (sart == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            


        }
        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void kitapsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            DialogResult secenek = MessageBox.Show("Dikkat!! Kitabın silinmesi bütün tabloları etkileyecek devam edilsin mi?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "delete from kitaplar where kitapkodu='" + silKitapKodu.Text + "'";
                command.Connection = baglanti;
                command.ExecuteNonQuery();

                MessageBox.Show("Kitap silindi!");
                this.Close();
                baglanti.Close();
            }
           

            baglanti.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();

            DialogResult secenek = MessageBox.Show("Kullanıcı silinecek emin misiniz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "delete from kullanicilar where personelKodu='" + silpersonelKoduUser.Text + "'";
                command.Connection = baglanti;
                command.ExecuteNonQuery();

                MessageBox.Show("Kullanici silindi!");
                this.Close();
                baglanti.Close();
            }


            baglanti.Close();

        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            baglanti.Open();

            DialogResult secenek = MessageBox.Show("Dikkat!! Bu depoyu silerseniz bağlı olan bütün tablolardan da silienecek. Silinsin mi?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "delete from depolar where depoTelefon='" + silDepoKodu.Text + "'";
                command.Connection = baglanti;
                command.ExecuteNonQuery();

                MessageBox.Show("Depo silindi!");
                this.Close();
                baglanti.Close();
            }


            baglanti.Close();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();

            DialogResult secenek = MessageBox.Show("Dikkat!! Bu personeli silerseniz bağlı olan bütün tablolardan da silienecek. Silinsin mi?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "delete from personel where telefon='" + silpersonelKodu.Text + "'";
                command.Connection = baglanti;
                command.ExecuteNonQuery();

                MessageBox.Show("Personel silindi!");
                this.Close();
                baglanti.Close();
            }


            baglanti.Close();
        }

        private void guncellerdbutton_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void silrdbutton_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }
    }
}
