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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=kitap_evi;Uid=root;Pwd='root';");


       

        private void Giris_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = KitapFonksiyolari.kitapListele("");
            xx.Text = "Kitaplar";
            if (label1.Text != "ADMİN")
            {
                personelButton.Enabled = false;
                kullaniciButton.Enabled = false;
            }
        }

        private void Giris_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            Ekle x = new Ekle();
            x.label21.Text = label1.Text;
            x.ShowDialog();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            SilveyaGuncelle x = new SilveyaGuncelle();
            x.label2.Text = "----------SİL----------";
            x.ShowDialog();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            SilveyaGuncelle x = new SilveyaGuncelle();
            x.label2.Text = "--------GÜNCELLE-------";
            x.ShowDialog();
        }

        private void kitapListele1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = KitapFonksiyolari.kitapListele("");
            xx.Text = "Kitaplar";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = YazarFonksiyonlari.yazarListele(searcbargiris.Text);
            xx.Text = "Yazarlar";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = DepoFonksiyonlari.depoListele("");
            xx.Text = "Depolar";
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = YayinEviFonksiyonlari.yayinEviListele("");
            xx.Text = "Yayinevleri";
        }

        private void personelButton_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = PersonelKodlari.personelListele("");
            xx.Text = "Personeller";
        }

        private void kullaniciButton_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            baglanti.Open();
            xx.Text = "Kullanicilar";
            string komut = "select personelKodu,personelAdiSoyadi,userId,pass,adminMi from kullanicilar,personel where personel.telefon=kullanicilar.personelKodu ";
            MySqlCommand command = new MySqlCommand(komut, baglanti);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void siparisGir_Click(object sender, EventArgs e)
        {
            
            SiparisEkle x = new SiparisEkle();
            x.iadeMi.Text = "degil";
            x.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = SiparisFonksiyonlari.siparisListele("");
            xx.Text = "Siparisler";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = MusteriFonksiyonlari.musteriListele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

     

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SilGuncelle form = new SilGuncelle();
                if (xx.Text == "Personeller")
                {
                    form.personelad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    form.silpersoneladi.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    form.personeltelefon.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    form.silpersonelKodu.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    form.label2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    form.personelcinsiyet.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    form.personeladres.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    form.personelmail.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    form.personelemaillabel.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    form.personelgorev.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    form.personelmaas.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                    form.guncelledurum.Text= dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                    
                    form.depopanel.Visible = false;
                    form.kullanicipanel.Visible = false;
                    form.kitappanel.Visible = false;
                    form.personelGuncellePanel.Visible = true;

                    form.sildepopanel.Visible = false;
                    form.silkullanicipanel.Visible = false;
                    form.silkitappanel.Visible = false;
                    form.silpersonelpanel.Visible = true;

                    form.silyayinevipanel.Visible = false;
                    form.yazarsilpanel.Visible = false;
                    form.guncelleyayinevipanel.Visible = false;
                    form.yazarguncellepanel.Visible = false;

                    form.Show();

                }
                else if (xx.Text == "Kullanicilar")
                {
                    form.useridtext.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    form.silUserId.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    form.useridlabel.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    //form.personelkodtext.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    form.personelkodtext.Enabled = false;

                    form.kullanicisart.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    form.silpersonelKoduUser.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                    form.passtext.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    form.silpass.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    if (Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[4].Value) == true)
                    {
                        form.evet.Checked = true;
                    }
                    else
                    {
                        form.hayir.Checked = true;
                    }
                    form.depopanel.Visible = false;
                    form.kullanicipanel.Visible = true;
                    form.kitappanel.Visible = false;
                    form.personelGuncellePanel.Visible = false;

                    form.sildepopanel.Visible = false;
                    form.silkullanicipanel.Visible = true;
                    form.silkitappanel.Visible = false;
                    form.silpersonelpanel.Visible = false;

                    form.silyayinevipanel.Visible = false;
                    form.yazarsilpanel.Visible = false;
                    form.guncelleyayinevipanel.Visible = false;
                    form.yazarguncellepanel.Visible = false;

                    form.Show();
                }
                else if (xx.Text == "Kitaplar")
                {
                    form.kitapKoduLabel.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    form.silKitapKodu.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    form.sgkitapAdi.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    form.kitaplabel.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    form.silKitapAdi.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    form.sgyazari.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    form.silYaazari.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    form.sgyazarilabel.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    form.sgyayinEvi.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    form.silYayinEvi.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    form.sgyayinevilabel.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    form.sgturu.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                    form.sgdepo.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                    form.sgfiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                    form.sgadet.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();

                    form.depopanel.Visible = false;
                    form.kullanicipanel.Visible = false;
                    form.kitappanel.Visible = true;
                    form.personelGuncellePanel.Visible = false;

                    form.sildepopanel.Visible = false;
                    form.silkullanicipanel.Visible = false;
                    form.silkitappanel.Visible = true;
                    form.silpersonelpanel.Visible = false;

                    form.silyayinevipanel.Visible = false;
                    form.yazarsilpanel.Visible = false;
                    form.guncelleyayinevipanel.Visible = false;
                    form.yazarguncellepanel.Visible = false;
                    form.Show();
                }
                else if (xx.Text == "Depolar")
                {
                    form.depodepo.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    form.silDepoAdi.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    form.sgdepotextbox.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    form.depoadresrich.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    form.depoadreslabel.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    form.sildepoAdres.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    form.dtlnolabel.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    form.depotelno.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    form.silDepoKodu.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                    form.depopanel.Visible = true;
                    form.kullanicipanel.Visible = false;
                    form.kitappanel.Visible = false;
                    form.personelGuncellePanel.Visible = false;
                    form.silyayinevipanel.Visible = false;
                    form.yazarsilpanel.Visible = false;
                    form.guncelleyayinevipanel.Visible = false;
                    form.yazarguncellepanel.Visible = false;
                    form.sildepopanel.Visible = true;
                    form.silkullanicipanel.Visible = false;
                    form.silkitappanel.Visible = false;
                    form.silpersonelpanel.Visible = false;

                    form.Show();

                }
                else if (xx.Text == "Siparisler")
                {



                    SiparisEkle x = new SiparisEkle();
                    if (dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString() == "iade")
                    {
                        MessageBox.Show("Bu fişle işlem yapılmış. İşlem tekrarlanamaz!");
                    }
                    else
                    {
                        x.kitapkodlarilabel.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        x.sipariskodulabel.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                        x.iadeMi.Text = "iade";
                        x.sipariskodulabel.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                        x.Show();
                    }
                }
                else if (xx.Text=="Yazarlar")
                {
                    form.guncelletextboxyazar.Text= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    form.silyazarkodulabel.Text= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    form.yazarAdiLabel.Text= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    
                    form.depopanel.Visible = false;
                    form.kullanicipanel.Visible = false;
                    form.kitappanel.Visible = false;
                    form.personelGuncellePanel.Visible = false;
                    form.silyayinevipanel.Visible = false;
                    form.yazarsilpanel.Visible = true;
                    form.guncelleyayinevipanel.Visible = false;
                    form.yazarguncellepanel.Visible = true;
                    form.sildepopanel.Visible = false;
                    form.silkullanicipanel.Visible = false;
                    form.silkitappanel.Visible = false;
                    form.silpersonelpanel.Visible = false;
                    
                    form.Show();
                }else if (xx.Text == "Yayinevleri")
                {
                    form.yayineviaditextbox.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    form.silyayinevikodulabel.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    form.silyayineviadilabel.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    
                    form.depopanel.Visible = false;
                    form.kullanicipanel.Visible = false;
                    form.kitappanel.Visible = false;
                    form.personelGuncellePanel.Visible = false;
                    form.silyayinevipanel.Visible = true;
                    form.yazarsilpanel.Visible = false;
                    form.guncelleyayinevipanel.Visible = true;
                    form.yazarguncellepanel.Visible = false;
                    form.sildepopanel.Visible = false;
                    form.silkullanicipanel.Visible = false;
                    form.silkitappanel.Visible = false;
                    form.silpersonelpanel.Visible = false;
                    
                    form.Show();
                }




            }
        }

        private void yazarlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = YazarFonksiyonlari.yazarListele("");
            xx.Text = "Yazarlar";
        }

        private void yayinevilistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = YayinEviFonksiyonlari.yayinEviListele("");
            xx.Text = "Yayinevleri";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
            
            
            if (xx.Text == "Kitaplar")
            {
               dataGridView1.DataSource= KitapFonksiyolari.kitapListele(searcbargiris.Text);
            }else if (xx.Text == "Yazarlar")
            {
                dataGridView1.DataSource = YazarFonksiyonlari.yazarListele(searcbargiris.Text);
            }else if (xx.Text == "Yayinevleri")
            {
                dataGridView1.DataSource = YayinEviFonksiyonlari.yayinEviListele(searcbargiris.Text);
            }else if (xx.Text == "Depolar")
            {
                dataGridView1.DataSource = DepoFonksiyonlari.depoListele(searcbargiris.Text);
            }else if (xx.Text == "Siparisler")
            {
                dataGridView1.DataSource = SiparisFonksiyonlari.siparisListele(searcbargiris.Text);
            }else if (xx.Text == "Personeller")
            {
                dataGridView1.DataSource = PersonelKodlari.personelListele(searcbargiris.Text);
            }
            else
            {
                dataGridView1.DataSource = null;
                baglanti.Open();
                
                string komut = "select personelKodu,personelAdiSoyadi,userId,pass,adminMi from kullanicilar,personel where kullanicilar.personelKodu=personel.telefon and personel.personelAdiSoyadi like '%" + searcbargiris.Text + "%'";
                MySqlCommand command = new MySqlCommand(komut, baglanti);
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
            
        }

       
    }
}
