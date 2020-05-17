using System;
using System.Collections.Generic;
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
    public partial class SiparisEkle : Form
    {
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=kitap_evi;Uid=root;Pwd='root';");

        public SiparisEkle()
        {
            InitializeComponent();
        }

        private void SiparisEkle_Load(object sender, EventArgs e)
        {
            personelLoad();
            urunLoad();
        }

        private void mlusteriTelNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void personelLoad()
        {
            siparisiAlan.Items.Clear();
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand();

            komut.CommandText = "select  personelAdiSoyadi from personel";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            MySqlDataReader read;

            read = komut.ExecuteReader();
            while (read.Read())
            {
                siparisiAlan.Items.Add(read["personelAdiSoyadi"]);
            }

            baglanti.Close();
        }
        private void urunLoad()
        {
            siparisUrun.Items.Clear();
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand();

            komut.CommandText = "select  kitapAdi,kitapKodu from kitaplar";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            MySqlDataReader read;

            read = komut.ExecuteReader();
            while (read.Read())
            {
                siparisUrun.Items.Add(read["kitapAdi"]+"-"+ read["kitapKodu"]);
            }

            baglanti.Close();
        }

        private void musteriEkle_Click(object sender, EventArgs e)
        {
            if(musteriTelNo.Text=="" || musteriAdSoyad.Text=="" || siparisUrun.Text =="" || siparisiAlan.Text=="" || verilenPara.Text == "")
            {
                MessageBox.Show("Alanlar doldurulmak zorundadır!!");
            }
            else
            {
                MusteriFonksiyonlari.musteriEkle(musteriTelNo.Text, musteriAdSoyad.Text);
                SiparisFonksiyonlari.siparisEkle(musteriTelNo.Text, siparisiAlan.Text, urunKoduCek(siparisUrun.Text), Convert.ToInt32(verilenPara.Text));
            }     
        }
        private string urunKoduCek(string veri)
        {
            string x = "";
            int i;
            for (i = 0; i < veri.Length; i++)
            {
                if (veri[i] == '-')
                {
                    for (int j = i + 1; j < veri.Length; j++)
                    {
                        x += veri[j];
                    }
                }


            }
            return x;

        }
    }
}
