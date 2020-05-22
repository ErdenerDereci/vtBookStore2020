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
            dataGridView2.ColumnCount = 2;
            dataGridView2.Columns[0].Name = "KitapAdi";
            dataGridView2.Columns[1].Name = "Tutar";
            personelLoad();
            //urunLoad();
            veriAyikla("kitap,erdener", "once");
            veriAyikla("kitap,erdener", "sonra");
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
        //private void urunLoad()
        //{
        //    siparisUrun.Items.Clear();
        //    baglanti.Open();
        //    MySqlCommand komut = new MySqlCommand();

        //    komut.CommandText = "select  kitapAdi,kitapKodu from kitaplar";
        //    komut.Connection = baglanti;
        //    komut.CommandType = CommandType.Text;
        //    MySqlDataReader read;

        //    read = komut.ExecuteReader();
        //    while (read.Read())
        //    {
        //        siparisUrun.Items.Add(read["kitapAdi"]+"-"+ read["kitapKodu"]);
        //    }

        //    baglanti.Close();
        //}

        //private void musteriEkle_Click(object sender, EventArgs e)
        //{
        //    if(musteriTelNo.Text=="" || musteriAdSoyad.Text=="" || siparisUrun.Text =="" || siparisiAlan.Text=="" || verilenPara.Text == "")
        //    {
        //        MessageBox.Show("Alanlar doldurulmak zorundadır!!");
        //    }
        //    else
        //    {
        //        MusteriFonksiyonlari.musteriEkle(musteriTelNo.Text, musteriAdSoyad.Text);
        //        SiparisFonksiyonlari.siparisEkle(musteriTelNo.Text, siparisiAlan.Text, urunKoduCek(siparisUrun.Text), Convert.ToInt32(verilenPara.Text));
        //    }     
        //}
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

        private void button2_Click(object sender, EventArgs e)
        {
            listView2.Clear();
            int x = 0;
            int sayac = 0;
            int sayac2 = 0;
            int j = 0;
            int listecount;
            int tutar = 0;
            string temp;
            listView2.Items.Add("");           
            listView2.Items.Add("***KitapKurdu***");
            listView2.Items.Add("");
            List<string> liste = new List<string>();
            List<int> tutarlist = new List<int>();
            for(int i=0; i<dataGridView2.Rows.Count; i++)
            {
                liste.Add(dataGridView2.Rows[i].Cells[0].Value.ToString());
                tutarlist.Add(Convert.ToInt32(dataGridView2.Rows[i].Cells[1].Value));
            }
            while (liste.Count != 0)
            {
                listecount = liste.Count();
                
                j = 0;
                temp = liste[0];
                sayac = 0;
                while(liste.Count!=0)
                {
                    if (sayac2==listecount)
                    {
                        break;
                    }
                    if (temp == liste[j])
                    {
                        sayac++;
                        liste.RemoveAt(j);
                        tutar = tutarlist[j];
                    }
                    else 
                    {
                        j++;
                    }
                    sayac2++;
                }
                listView2.Items.Add(temp+" x"+sayac+"  -  "+tutar*sayac+" TL");
                listView2.Items.Add("");
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            if (veriAyikla(searchbar.Text, "once") == "kitap")
            {
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "select kitapKodu,kitapAdi from kitaplar where kitapAdi like '%" + veriAyikla(searchbar.Text, "sonra") + "%'";
                command.Connection = baglanti;
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            baglanti.Close();
        }
        private string veriAyikla(string veri,string sart)
        {
            string x = "";
            if(sart =="once")
            {
                for(int i =0; i<veri.Length; i++)
                {
                    if (veri[i] == ',')
                    {
                        break;
                    }
                    x = x + veri[i];
                    
                }
                return x;
            }else if (sart=="sonra")
            {
                int i = 0;
                while (veri[i] != ',')
                {
                    i++;
                }
                i++;
                for (int j=i; j < veri.Length; j++)
                {
                    x = x + veri[j];
                }
                return x;
            }
            return "";
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView2.Rows.RemoveAt(e.RowIndex);
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            baglanti.Open();
            string kitapKodu = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string kitapAdi = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            int tutar = 0;
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "select taneFiyat from kitap_depo where kitapKodu = '" + kitapKodu + "'";
            command.Connection = baglanti;
            tutar = Convert.ToInt32(command.ExecuteScalar());
            dataGridView2.Rows.Add(kitapAdi,tutar);

            baglanti.Close();
        }

        
    }
}
