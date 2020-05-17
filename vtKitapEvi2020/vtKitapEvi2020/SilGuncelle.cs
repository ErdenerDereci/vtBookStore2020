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
    }
}
