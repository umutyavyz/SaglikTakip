using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

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
            string connectionString = "Server=MONSTER\\SQLEXPRESS;Database=SaglikTakip;Trusted_Connection=True;";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Id, Ad, Yas, Cinsiyet FROM Kullanicilar", conn);
                var reader = cmd.ExecuteReader();

                comboBox1.Items.Clear();

                while (reader.Read())
                {
                    Kullanici kullanici = new Kullanici
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Ad = reader["Ad"].ToString(),
                        Yas = Convert.ToInt32(reader["Yas"]),
                        Cinsiyet = reader["Cinsiyet"].ToString()
                    };

                    comboBox1.Items.Add(kullanici);
                }
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

            string connectionString = "Server=MONSTER\\SQLEXPRESS;Database=SaglikTakip;Trusted_Connection=True;";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Egzersizler (KullaniciId, EgzersizAdi, SureDakika, TekrarSayisi) VALUES (@kullaniciId, @ad, @sure, @tekrar)", conn);
                cmd.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                cmd.Parameters.AddWithValue("@ad", ad);
                cmd.Parameters.AddWithValue("@sure", sure);
                cmd.Parameters.AddWithValue("@tekrar", tekrar);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Egzersiz kaydedildi.");

                // Form temizleme
                textBox1.Clear();
                numericUpDown1.Value = 0;
                numericUpDown2.Value = 0;
                comboBox1.SelectedIndex = -1;
            }
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
