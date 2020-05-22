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
            dataGridView1.DataSource = KitapFonksiyolari.kitapListele();
            xx.Text = "kitap";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = YazarFonksiyonlari.yazarListele();
            xx.Text = "yazar";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DepoFonksiyonlari.depoListele();
            xx.Text = "depo";
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = YayinEviFonksiyonlari.yayinEviListele();
            xx.Text = "yayinevi";
        }

        private void personelButton_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = PersonelKodlari.personelListele();
            xx.Text = "personel";
        }

        private void kullaniciButton_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            xx.Text = "kullanici";
            string komut = "select * from kullanicilar";
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
            x.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = SiparisFonksiyonlari.siparisListele();
            xx.Text = "siparisler";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = MusteriFonksiyonlari.musteriListele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SilGuncelle form = new SilGuncelle();
            if (xx.Text == "personel")
            {
                form.personelad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                form.personeltelefon.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                form.label2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                form.personelcinsiyet.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.personeladres.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.personelmail.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.personelgorev.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.personelmaas.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                form.Show();
            }else if (xx.Text == "kullanici")
            {
                form.useridtext.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                //form.personelkodtext.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                form.personelkodtext.Enabled = false;
                form.uyari.Text = "Personel kodu \ngüncellenemez!!";
                form.kullanicisart.Text= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                form.uyari.Visible = true;
                form.passtext.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                if(Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[3].Value) == true)
                {
                    form.evet.Checked=true;
                }
                else
                {
                    form.hayir.Checked = true;
                }
                form.Show();
            }else if (xx.Text=="kitap")
            {
                form.kitapKoduLabel.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                form.sgkitapAdi.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                form.kitaplabel.Text= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                form.sgyazari.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.sgyayinEvi.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.sgsayfaSayisi.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.sgbaskisi.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.sgturu.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                form.sgdepo.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                form.sgfiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                form.sgadet.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                form.Show();
            }else if (xx.Text == "yazar")
            {
                form.label13.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                form.sgyazaryazar.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                form.label16.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                form.Show();
            }else if (xx.Text =="depo")
            {
                form.depodepo.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                form.sgdepotextbox.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                form.depoadresrich.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                form.depoadreslabel.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                form.Show();

            }else if (xx.Text == "yayinevi")
            {
                form.sgyayinevikodulabel.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                form.sgyayinevitext.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                form.sgyayineviadilabel.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                form.Show();
            }else if (xx.Text == "siparisler")
            {
                baglanti.Open();
                string urun;
                string siparisiAlan;
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "select kitapAdi from kitaplar where kitapKodu='"+ dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() + "'";
                command.Connection = baglanti;
                urun = command.ExecuteScalar().ToString();
                command.CommandText = "select personelAdiSoyadi from personel where telefon='" + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + "'"; 
                siparisiAlan = command.ExecuteScalar().ToString();

                baglanti.Close();
                form.sgsipariskodulabel.Text= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                form.sgmustreritelnotextbox.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                form.sgsiparisalancombobox.Text = siparisiAlan+"-"+dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.sgsiparisuruncombobox.Text = urun+"-"+dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                
                form.sgverilenparatextbox.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.Show();

            }
        }
    }
}
