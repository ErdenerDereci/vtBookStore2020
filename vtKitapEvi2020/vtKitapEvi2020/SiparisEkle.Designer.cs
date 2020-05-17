namespace vtKitapEvi2020
{
    partial class SiparisEkle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.musteriTelNo = new System.Windows.Forms.TextBox();
            this.musteriAdSoyad = new System.Windows.Forms.TextBox();
            this.siparisUrun = new System.Windows.Forms.ComboBox();
            this.siparisiAlan = new System.Windows.Forms.ComboBox();
            this.musteriEkle = new System.Windows.Forms.Button();
            this.verilenPara = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Müşteri telefon no : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Müşteri adi soyaadi :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ürün :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Siparisişi alan :";
            // 
            // musteriTelNo
            // 
            this.musteriTelNo.Location = new System.Drawing.Point(153, 46);
            this.musteriTelNo.Name = "musteriTelNo";
            this.musteriTelNo.Size = new System.Drawing.Size(114, 20);
            this.musteriTelNo.TabIndex = 7;
            this.musteriTelNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mlusteriTelNo_KeyPress);
            // 
            // musteriAdSoyad
            // 
            this.musteriAdSoyad.Location = new System.Drawing.Point(153, 88);
            this.musteriAdSoyad.Name = "musteriAdSoyad";
            this.musteriAdSoyad.Size = new System.Drawing.Size(114, 20);
            this.musteriAdSoyad.TabIndex = 8;
            // 
            // siparisUrun
            // 
            this.siparisUrun.FormattingEnabled = true;
            this.siparisUrun.Location = new System.Drawing.Point(152, 134);
            this.siparisUrun.Name = "siparisUrun";
            this.siparisUrun.Size = new System.Drawing.Size(114, 21);
            this.siparisUrun.TabIndex = 10;
            // 
            // siparisiAlan
            // 
            this.siparisiAlan.FormattingEnabled = true;
            this.siparisiAlan.Location = new System.Drawing.Point(153, 179);
            this.siparisiAlan.Name = "siparisiAlan";
            this.siparisiAlan.Size = new System.Drawing.Size(114, 21);
            this.siparisiAlan.TabIndex = 12;
            // 
            // musteriEkle
            // 
            this.musteriEkle.Location = new System.Drawing.Point(192, 289);
            this.musteriEkle.Name = "musteriEkle";
            this.musteriEkle.Size = new System.Drawing.Size(75, 23);
            this.musteriEkle.TabIndex = 13;
            this.musteriEkle.Text = "Ekle";
            this.musteriEkle.UseVisualStyleBackColor = true;
            this.musteriEkle.Click += new System.EventHandler(this.musteriEkle_Click);
            // 
            // verilenPara
            // 
            this.verilenPara.Location = new System.Drawing.Point(152, 223);
            this.verilenPara.Name = "verilenPara";
            this.verilenPara.Size = new System.Drawing.Size(114, 20);
            this.verilenPara.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(61, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Verilen para :";
            // 
            // SiparisEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 360);
            this.Controls.Add(this.verilenPara);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.musteriEkle);
            this.Controls.Add(this.siparisiAlan);
            this.Controls.Add(this.siparisUrun);
            this.Controls.Add(this.musteriAdSoyad);
            this.Controls.Add(this.musteriTelNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SiparisEkle";
            this.Text = "SiparisEkle";
            this.Load += new System.EventHandler(this.SiparisEkle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox musteriTelNo;
        private System.Windows.Forms.TextBox musteriAdSoyad;
        private System.Windows.Forms.ComboBox siparisUrun;
        private System.Windows.Forms.ComboBox siparisiAlan;
        private System.Windows.Forms.Button musteriEkle;
        private System.Windows.Forms.TextBox verilenPara;
        private System.Windows.Forms.Label label7;
    }
}