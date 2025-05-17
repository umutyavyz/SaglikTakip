namespace SaglikTakip
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnKullaniciEkle = new System.Windows.Forms.Button();
            this.btnSaglikKaydi = new System.Windows.Forms.Button();
            this.btnEgzersizEkle = new System.Windows.Forms.Button();
            this.Raporgor = new System.Windows.Forms.Button();
            this.cikis = new System.Windows.Forms.Button();
            this.btnkapat = new System.Windows.Forms.Button();
            this.btnAsagial = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnKullaniciEkle
            // 
            this.btnKullaniciEkle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnKullaniciEkle.Location = new System.Drawing.Point(70, 63);
            this.btnKullaniciEkle.Name = "btnKullaniciEkle";
            this.btnKullaniciEkle.Size = new System.Drawing.Size(116, 57);
            this.btnKullaniciEkle.TabIndex = 0;
            this.btnKullaniciEkle.Text = "Kullanıcı Ekle";
            this.btnKullaniciEkle.UseVisualStyleBackColor = true;
            this.btnKullaniciEkle.Click += new System.EventHandler(this.btnKullaniciEkle_Click);
            // 
            // btnSaglikKaydi
            // 
            this.btnSaglikKaydi.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnSaglikKaydi.Location = new System.Drawing.Point(237, 63);
            this.btnSaglikKaydi.Name = "btnSaglikKaydi";
            this.btnSaglikKaydi.Size = new System.Drawing.Size(116, 57);
            this.btnSaglikKaydi.TabIndex = 1;
            this.btnSaglikKaydi.Text = "Sağlık Kaydı Ekle";
            this.btnSaglikKaydi.UseVisualStyleBackColor = true;
            this.btnSaglikKaydi.Click += new System.EventHandler(this.btnSaglikKaydi_Click);
            // 
            // btnEgzersizEkle
            // 
            this.btnEgzersizEkle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnEgzersizEkle.Location = new System.Drawing.Point(237, 145);
            this.btnEgzersizEkle.Name = "btnEgzersizEkle";
            this.btnEgzersizEkle.Size = new System.Drawing.Size(116, 57);
            this.btnEgzersizEkle.TabIndex = 2;
            this.btnEgzersizEkle.Text = "Egzersiz Planla";
            this.btnEgzersizEkle.UseVisualStyleBackColor = true;
            this.btnEgzersizEkle.Click += new System.EventHandler(this.btnEgzersizEkle_Click);
            // 
            // Raporgor
            // 
            this.Raporgor.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.Raporgor.Location = new System.Drawing.Point(70, 145);
            this.Raporgor.Name = "Raporgor";
            this.Raporgor.Size = new System.Drawing.Size(116, 57);
            this.Raporgor.TabIndex = 3;
            this.Raporgor.Text = "Rapor Görüntüle";
            this.Raporgor.UseVisualStyleBackColor = true;
            this.Raporgor.Click += new System.EventHandler(this.Raporgor_Click);
            // 
            // cikis
            // 
            this.cikis.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.cikis.Location = new System.Drawing.Point(150, 240);
            this.cikis.Name = "cikis";
            this.cikis.Size = new System.Drawing.Size(121, 32);
            this.cikis.TabIndex = 4;
            this.cikis.Text = "Çıkış";
            this.cikis.UseVisualStyleBackColor = true;
            this.cikis.Click += new System.EventHandler(this.cikis_Click);
            // 
            // btnkapat
            // 
            this.btnkapat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnkapat.FlatAppearance.BorderSize = 0;
            this.btnkapat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkapat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnkapat.ForeColor = System.Drawing.Color.White;
            this.btnkapat.Location = new System.Drawing.Point(362, 0);
            this.btnkapat.Name = "btnkapat";
            this.btnkapat.Size = new System.Drawing.Size(58, 27);
            this.btnkapat.TabIndex = 23;
            this.btnkapat.Text = "X";
            this.btnkapat.UseVisualStyleBackColor = false;
            this.btnkapat.Click += new System.EventHandler(this.btnkapat_Click);
            // 
            // btnAsagial
            // 
            this.btnAsagial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnAsagial.FlatAppearance.BorderSize = 0;
            this.btnAsagial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsagial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAsagial.ForeColor = System.Drawing.Color.White;
            this.btnAsagial.Location = new System.Drawing.Point(304, 0);
            this.btnAsagial.Name = "btnAsagial";
            this.btnAsagial.Size = new System.Drawing.Size(58, 27);
            this.btnAsagial.TabIndex = 22;
            this.btnAsagial.Text = "-";
            this.btnAsagial.UseVisualStyleBackColor = false;
            this.btnAsagial.Click += new System.EventHandler(this.btnAsagial_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(419, 301);
            this.Controls.Add(this.btnkapat);
            this.Controls.Add(this.btnAsagial);
            this.Controls.Add(this.cikis);
            this.Controls.Add(this.Raporgor);
            this.Controls.Add(this.btnEgzersizEkle);
            this.Controls.Add(this.btnSaglikKaydi);
            this.Controls.Add(this.btnKullaniciEkle);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Saglik Gov TR";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKullaniciEkle;
        private System.Windows.Forms.Button btnSaglikKaydi;
        private System.Windows.Forms.Button btnEgzersizEkle;
        private System.Windows.Forms.Button Raporgor;
        private System.Windows.Forms.Button cikis;
        private System.Windows.Forms.Button btnkapat;
        private System.Windows.Forms.Button btnAsagial;
    }
}

