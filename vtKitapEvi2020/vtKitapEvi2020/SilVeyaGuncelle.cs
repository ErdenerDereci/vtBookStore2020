using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vtKitapEvi2020
{
    public partial class SilveyaGuncelle : Form
    {
        public SilveyaGuncelle()
        {
            InitializeComponent();
        }

        private void SilveyaGuncelle_Load(object sender, EventArgs e)
        {
            if(label2.Text== "----------SİL----------")
            {
                label1.Text = "    Silme işlemi yapmak için ilgili veriyi listeden seçip çift tıklayın.\nAçılan formda silme işlemi yapabilirsiniz.";
            }
            else
            {
                label1.Text = "    Güncelleme işlemi yapmak için ilgili veriyi listeden seçip çift tıklayınız.\nAçılan formda güncelleme işlemi yapabilirsiniz";
            }
        }
    }
}
