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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.label6 = new System.Windows.Forms.Label();
            this.siparisiAlan = new System.Windows.Forms.ComboBox();
            this.verilenPara = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.searchbar = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.toplamtext = new System.Windows.Forms.Label();
            this.kitapkodlarilabel = new System.Windows.Forms.Label();
            this.kitapTutarLabel = new System.Windows.Forms.Label();
            this.kitapAdiLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Siparisişi alan :";
            // 
            // siparisiAlan
            // 
            this.siparisiAlan.FormattingEnabled = true;
            this.siparisiAlan.Location = new System.Drawing.Point(90, 264);
            this.siparisiAlan.Name = "siparisiAlan";
            this.siparisiAlan.Size = new System.Drawing.Size(114, 21);
            this.siparisiAlan.TabIndex = 12;
            // 
            // verilenPara
            // 
            this.verilenPara.Location = new System.Drawing.Point(89, 294);
            this.verilenPara.Name = "verilenPara";
            this.verilenPara.Size = new System.Drawing.Size(115, 20);
            this.verilenPara.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 297);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Verilen para   :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(241, 195);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // searchbar
            // 
            this.searchbar.Location = new System.Drawing.Point(12, 24);
            this.searchbar.Name = "searchbar";
            this.searchbar.Size = new System.Drawing.Size(162, 20);
            this.searchbar.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(180, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "ara";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(349, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "Sepet";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(575, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Fiş";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(323, 262);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 23);
            this.button2.TabIndex = 23;
            this.button2.Text = "Siparişi Gir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(532, 262);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(121, 23);
            this.button3.TabIndex = 24;
            this.button3.Text = "Fişi Yazdır";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.GridColor = System.Drawing.Color.White;
            this.dataGridView2.Location = new System.Drawing.Point(259, 53);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(241, 195);
            this.dataGridView2.TabIndex = 25;
            this.dataGridView2.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_CellMouseDoubleClick);
            // 
            // listView2
            // 
            this.listView2.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HideSelection = false;
            this.listView2.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView2.Location = new System.Drawing.Point(506, 53);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(172, 195);
            this.listView2.TabIndex = 21;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.List;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Toplam :";
            // 
            // toplamtext
            // 
            this.toplamtext.AutoSize = true;
            this.toplamtext.Location = new System.Drawing.Point(272, 299);
            this.toplamtext.Name = "toplamtext";
            this.toplamtext.Size = new System.Drawing.Size(13, 13);
            this.toplamtext.TabIndex = 27;
            this.toplamtext.Text = "0";
            // 
            // kitapkodlarilabel
            // 
            this.kitapkodlarilabel.AutoSize = true;
            this.kitapkodlarilabel.Location = new System.Drawing.Point(465, 9);
            this.kitapkodlarilabel.Name = "kitapkodlarilabel";
            this.kitapkodlarilabel.Size = new System.Drawing.Size(35, 13);
            this.kitapkodlarilabel.TabIndex = 28;
            this.kitapkodlarilabel.Text = "label2";
            // 
            // kitapTutarLabel
            // 
            this.kitapTutarLabel.AutoSize = true;
            this.kitapTutarLabel.Location = new System.Drawing.Point(465, 27);
            this.kitapTutarLabel.Name = "kitapTutarLabel";
            this.kitapTutarLabel.Size = new System.Drawing.Size(35, 13);
            this.kitapTutarLabel.TabIndex = 29;
            this.kitapTutarLabel.Text = "label2";
            // 
            // kitapAdiLabel
            // 
            this.kitapAdiLabel.AutoSize = true;
            this.kitapAdiLabel.Location = new System.Drawing.Point(503, 9);
            this.kitapAdiLabel.Name = "kitapAdiLabel";
            this.kitapAdiLabel.Size = new System.Drawing.Size(35, 13);
            this.kitapAdiLabel.TabIndex = 30;
            this.kitapAdiLabel.Text = "label2";
            // 
            // SiparisEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 353);
            this.Controls.Add(this.kitapAdiLabel);
            this.Controls.Add(this.kitapTutarLabel);
            this.Controls.Add(this.kitapkodlarilabel);
            this.Controls.Add(this.toplamtext);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.searchbar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.verilenPara);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.siparisiAlan);
            this.Controls.Add(this.label6);
            this.Name = "SiparisEkle";
            this.Text = "SiparisEkle";
            this.Load += new System.EventHandler(this.SiparisEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox siparisiAlan;
        private System.Windows.Forms.TextBox verilenPara;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox searchbar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label toplamtext;
        public System.Windows.Forms.Label kitapkodlarilabel;
        public System.Windows.Forms.Label kitapTutarLabel;
        public System.Windows.Forms.Label kitapAdiLabel;
    }
}