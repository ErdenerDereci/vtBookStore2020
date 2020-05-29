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
        List<string> liste = new List<string>();

        private void SiparisEkle_Load(object sender, EventArgs e)
        {
            
            ColumnHeader header = new ColumnHeader();
            header.Text = "";
            header.Name = "col1";
            header.Width = 170;
            this.listView2.Columns.AddRange(new ColumnHeader[] { header });
           
            listView2.Scrollable = true;
            listView2.View = View.Details;
            
            dataGridView2.ColumnCount = 3;
            searchbar.Text = "kitap,";
            dataGridView2.Columns[0].Name = "KitapKodu";
            dataGridView2.Columns[1].Name = "KitapAdi";
            dataGridView2.Columns[2].Name = "Tutar";
            personelLoad();
            sepetGuncelle(kitapkodlarilabel.Text);
            //urunLoad();
            veriAyikla("kitap,erdener", "once");
            veriAyikla("kitap,erdener", "sonra");
            if (iadeMi.Text == "iade")
            {
                datagrid1load();
            }
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                liste.Add(dataGridView2.Rows[i].Cells[0].Value.ToString());
            }
        }
        private void sepetGuncelle(string veri)
        {
            string kitapAdi;
            int tutar;
            MySqlCommand command = new MySqlCommand();
            command.Connection = baglanti;
            string x = "";
            for(int i=0; i<veri.Length; i++)
            {
                if (veri[i] == ',')
                {
                    baglanti.Open();
                    command.CommandText = "select kitapAdi from kitaplar where kitapKodu='" + x + "'";
                    kitapAdi = command.ExecuteScalar().ToString();
                    command.CommandText= "select satisFiyati from kitap_depo where kitapKodu='" + x + "'";
                    tutar = Convert.ToInt32(command.ExecuteScalar());
                    dataGridView2.Rows.Add(x,kitapAdi,tutar);
                    baglanti.Close();
                    x = "";
                }
                else
                {
                    x += veri[i];
                }
                
                
            }
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

            komut.CommandText = "select telefon,personelAdiSoyadi from personel";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            MySqlDataReader read;

            read = komut.ExecuteReader();
            while (read.Read())
            {
                siparisiAlan.Items.Add(read["telefon"]+"-"+ read["personelAdiSoyadi"]);
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
        private string personelKoduCek(string veri)
        {
            string x = "";
            int i;
            for (i = 0; i < veri.Length; i++)
            {
                if (veri[i] == '-')
                {
                    break;
                }
                x += veri[i];

            }
            return x;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string siparisKodu;
            if (iadeMi.Text == "iade")
            {
                siparisKodu = sipariskodulabel.Text;
            }
            else
            {
                siparisKodu = SiparisFonksiyonlari.siparisKoduYarat();
            }
            if(dataGridView2.Rows.Count == 0 && iadeMi.Text!="iade")
            {
                MessageBox.Show("Kitap seçiniz!");
            }else if (sepetAyniMi())
            {
                MessageBox.Show("Sepette değişiklik yapılmadı!");
            }
            else if (siparisiAlan.Text == "" || verilenPara.Text == "")
            {
                MessageBox.Show("Alanlar doldurulmak zorundadır!"); 

            }else if(Convert.ToInt32(verilenPara.Text) < Convert.ToInt32(toplamtext.Text))
            {
                MessageBox.Show("Toplam tutardan daha düşük para değeri girdiniz!");
            }
            else
            {
                listView2.Items.Clear();
                int toplam = 0;
                int sayac = 0;
                int sayac2 = 0;
                int j = 0;
                int listecount;
                int tutar = 0;
                string temp;
                listView2.Items.Add("");
                listView2.Items.Add("***KitapKurdu***");
                listView2.Items.Add("");
                listView2.Items.Add("Tarih: "+ DateTime.Now);
                listView2.Items.Add("");
                List<string> liste = new List<string>();
                List<int> tutarlist = new List<int>();
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    liste.Add(dataGridView2.Rows[i].Cells[1].Value.ToString());
                    tutarlist.Add(Convert.ToInt32(dataGridView2.Rows[i].Cells[2].Value));
                }
                while (liste.Count != 0)
                {
                    listecount = liste.Count();

                    j = 0;
                    temp = liste[0];
                    tutar = tutarlist[0];
                    sayac = 0;
                    while (liste.Count != 0)
                    {
                        if (sayac2 == listecount)
                        {
                            break;
                        }
                        if (temp == liste[j])
                        {
                            sayac++;
                            liste.RemoveAt(j);
                            tutarlist.RemoveAt(j);

                        }
                        else
                        {
                            j++;
                        }
                        sayac2++;
                    }
                    
                    listView2.Items.Add(temp + " x" + sayac + "  -  " + tutar * sayac + " TL");
                    listView2.Items.Add("");

                }
                listView2.Items.Add("Toplam: " + toplamtext.Text);
                listView2.Items.Add("");
                listView2.Items.Add("Verilen para: "+verilenPara.Text);
                listView2.Items.Add("");
                listView2.Items.Add("Para üstü: " +(Convert.ToInt32(verilenPara.Text)-Convert.ToInt32(toplamtext.Text)));
                listView2.Items.Add("");
                listView2.Items.Add("sp_no: "+siparisKodu);
                listView2.Items.Add("");
                listView2.Items.Add("Siparisi alan: " + siparisiAlan.Text);
                listView2.Items.Add("");
                listView2.Items.Add("***İdae işlemleri için ");
                listView2.Items.Add("fişinizi kaybetmeyiniz.***");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            if (veriAyikla(searchbar.Text, "once") == "kitap")
            {
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "select  kitaplar.kitapKodu,kitapAdi,yazari,adet from kitaplar,kitap_depo where kitapAdi like '%" + veriAyikla(searchbar.Text, "sonra") + "%' and kitaplar.kitapKodu=kitap_depo.kitapKodu";
                command.Connection = baglanti;
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            baglanti.Close();
        }
        private void datagrid1load()
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "select  kitaplar.kitapKodu,kitapAdi,yazari,adet from kitaplar,kitap_depo where kitapAdi like '%" + veriAyikla(searchbar.Text, "sonra") + "%' and kitaplar.kitapKodu=kitap_depo.kitapKodu";
            command.Connection = baglanti;
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
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
            if (e.RowIndex >= 0)
            {
                toplamtext.Text = (Convert.ToInt32(toplamtext.Text) - (Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString()))).ToString();
                adetArttir(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
                dataGridView2.Rows.RemoveAt(e.RowIndex);

                datagrid1load();
            }
            
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                baglanti.Open();
                if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "0")
                {
                    MessageBox.Show("Ürün stokta yok!");
                }
                else
                {
                    if (eklenebilirMi(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value)))
                    {
                        string kitapKodu = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                        string kitapAdi = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                        int tutar = 0;
                        MySqlCommand command = new MySqlCommand();
                        command.CommandText = "select satisFiyati from kitap_depo where kitapKodu = '" + kitapKodu + "'";
                        command.Connection = baglanti;
                        tutar = Convert.ToInt32(command.ExecuteScalar());
                        dataGridView2.Rows.Add(kitapKodu, kitapAdi, tutar);
                        toplamtext.Text = (Convert.ToInt32(toplamtext.Text) + tutar).ToString();
                        adettAzalt(kitapKodu);
                        datagrid1load();

                    }
                    else
                    {
                        MessageBox.Show("Daha fazla bu üründen ekleyemezsiniz. Stokta kalmıyor.");
                    }

                }

                baglanti.Close();
            }
            
        }
        private void adettAzalt(string kitapKodu)
        {
            
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "select adet from kitap_depo where kitapKodu='" + kitapKodu + "'";
            command.Connection = baglanti;

            int adet = Convert.ToInt32(command.ExecuteScalar());
            command.CommandText = "update kitap_depo set adet=" + (adet - 1) + " where kitapKodu='" + kitapKodu + "'";
            command.ExecuteNonQuery();
            
        }
        private void adetArttir(string kitapKodu)
        {
            baglanti.Open();
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "select adet from kitap_depo where kitapKodu='" + kitapKodu + "'";
            command.Connection = baglanti;

            int adet = Convert.ToInt32(command.ExecuteScalar());
            command.CommandText = "update kitap_depo set adet=" + (adet + 1) + " where kitapKodu='" + kitapKodu + "'";
            command.ExecuteNonQuery();
            baglanti.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            if (listView2.Items.Count == 1)
            {
                MessageBox.Show("Fiş boş!");
                baglanti.Close();
            }
            else
            {
                DialogResult emin = new DialogResult();
                emin = MessageBox.Show("Emin misiniz ?", "Uyari", MessageBoxButtons.YesNo);
                if (emin == DialogResult.Yes)
                {
                    SiparisFonksiyonlari.siparisEkle(personelKoduCek(siparisiAlan.Text), kitapKodlariniDondur(), Convert.ToInt32(toplamtext.Text), Convert.ToInt32(verilenPara.Text), Convert.ToInt32(verilenPara.Text) - Convert.ToInt32(toplamtext.Text), dataGridView2.Rows.Count,iadeMi.Text,sipariskodulabel.Text);
                }
                if (iadeMi.Text == "iade")
                {
                    MySqlCommand command = new MySqlCommand();
                    command.CommandText = "update siparis set durum='iade' where siparisNo='" + sipariskodulabel.Text + "'";
                    command.Connection = baglanti;
                    command.ExecuteNonQuery();
                }
                baglanti.Close();
                button1_Click(sender, e);
                listView2.Items.Clear();
                dataGridView2.Rows.Clear();
            }
            
        }
        //private string siparisKoduCek()
        //{
        //    baglanti.Open();
        //    MySqlCommand command = new MySqlCommand();
        //    command.CommandText = "select siparisKodu from siparisler desc limit 1";
        //    command.Connection = baglanti;
            

        //    baglanti.Close();
        //    return command.ExecuteScalar().ToString();
        //}
        private string kitapKodlariniDondur()
        {
            string donecek = "";
            for(int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                donecek = donecek + dataGridView2.Rows[i].Cells[0].Value.ToString()+",";
            }
            return donecek;
        }
        
        private bool eklenebilirMi(string kitapKodu,int adet)
        {
            int sayac = 0;
            for(int i=0; i<dataGridView2.Rows.Count; i++)
            {
                if (kitapKodu == dataGridView2.Rows[i].Cells[0].Value.ToString())
                {
                    sayac++;
                }
            }
            if (sayac == adet)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool sepetAyniMi()
        {
            List<string> temp = new List<string>();
            foreach(string xz in liste)
            {
                temp.Add(xz);
            }
            List<string> temp2 = new List<string>();
            for(int i=0; i< dataGridView2.Rows.Count; i++)
            {
                temp2.Add(dataGridView2.Rows[i].Cells[0].Value.ToString());
            }

            int sayac = 0;
            if (temp2.Count == temp.Count)
            {
                for(int i=0; i < temp.Count; i++)
                {
                    for(int j = 0; j < temp2.Count; j++)
                    {
                        if (temp2[i]==temp[j] && temp[i]!="")
                        {
                            sayac++;
                            temp2[i] = "";
                            temp[j] = "";
                        }
                    }
                }
            }
            if (sayac == temp2.Count && sayac==temp.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
           
            
            
             
        }
    }
}
