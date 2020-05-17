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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=kitap_evi;Uid=root;Pwd='root';");

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand command = new MySqlCommand();
            MySqlCommand command2 = new MySqlCommand();
            command.CommandText = "select adminMi from kullanicilar where userId='" + id.Text + "' and pass='" + sifre.Text + "'";
            command.Connection = baglanti;
            command2.CommandText = "select personelAdiSoyadi from kullanicilar,personel where userId='" + id.Text + "' and pass='" + sifre.Text + "' and kullanicilar.personelKodu=personel.telefon";
            command2.Connection = baglanti;
                string sart = Convert.ToString(command.ExecuteScalar());
                Giris x = new Giris();
            
            x.label2.Text = Convert.ToString(command2.ExecuteScalar());
            if (sart == "True")
            {
                
                x.label1.Text = "ADMİN";
                x.Show();
                this.Hide();
            }
            else if(sart =="False")
            {
                
                x.label1.Text = "KULLANICI";
                x.label1.BackColor = Color.Blue;
                x.Show();
                this.Hide();
            }
            else
            {
                label3.Text = "Kullanıcı adı veya şifre yanlış..";
            }
                
            

            
            
            
            baglanti.Close();
        }
    }
}
