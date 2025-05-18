using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // SqlParameter için gerekli

namespace SaglikTakip
{
    public partial class EgzersizKayitForm : Form
    {
        public EgzersizKayitForm()
        {
            InitializeComponent();
        }

        // Kullanıcı bilgilerini tutmak için sınıf tanımı
        public class Kullanici
        {
            public int Id { get; set; }
            public string Ad { get; set; }
            public int Yas { get; set; }
            public string Cinsiyet { get; set; }

            public override string ToString()
            {
                return $"{Ad} - {Yas} Yaş - {Cinsiyet}";
            }
        }

        private void KullaniciListesiGetir()
        {
            string query = "SELECT Id, Ad, Yas, Cinsiyet FROM Kullanicilar";
            DataTable dt = databaseHelper.ExecuteQuery(query); // küçük harfle çağırıldı

            comboBox1.Items.Clear();

            foreach (DataRow row in dt.Rows)
            {
                Kullanici kullanici = new Kullanici
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Ad = row["Ad"].ToString(),
                    Yas = Convert.ToInt32(row["Yas"]),
                    Cinsiyet = row["Cinsiyet"].ToString()
                };

                comboBox1.Items.Add(kullanici);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir kullanıcı seçiniz.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Egzersiz adını giriniz.");
                return;
            }

            Kullanici secilen = comboBox1.SelectedItem as Kullanici;
            int kullaniciId = secilen.Id;
            string ad = textBox1.Text;
            int sure = (int)numericUpDown1.Value;
            int tekrar = (int)numericUpDown2.Value;

            string query = "INSERT INTO Egzersizler (KullaniciId, EgzersizAdi, SureDakika, TekrarSayisi) VALUES (@kullaniciId, @ad, @sure, @tekrar)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@kullaniciId", kullaniciId),
                new SqlParameter("@ad", ad),
                new SqlParameter("@sure", sure),
                new SqlParameter("@tekrar", tekrar)
            };

            databaseHelper.ExecuteNonQuery(query, parameters); // küçük harfle çağırıldı

            MessageBox.Show("Egzersiz kaydedildi.");

            // Form temizleme
            textBox1.Clear();
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            comboBox1.SelectedIndex = -1;
        }

        private void EgzersizKayitForm_Load_1(object sender, EventArgs e)
        {
            KullaniciListesiGetir();
        }

        private void btnkapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAsagial_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
