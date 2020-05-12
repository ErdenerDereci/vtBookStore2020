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
            baglanti.Open();

            
            baglanti.Close();
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
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = YazarFonksiyonlari.yazarListele();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DepoFonksiyonlari.depoListele();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = YayinEviFonksiyonlari.yayinEviListele();
        }
    }
}
