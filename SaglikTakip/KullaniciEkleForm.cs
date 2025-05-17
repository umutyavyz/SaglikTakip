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
    public partial class KullaniciEkleForm : Form
    {
        public KullaniciEkleForm()
        {
            InitializeComponent();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string ad = textBoxad.Text;
            int yas;

            // Yaş bilgisinin doğru formatta girildiğinden emin olalım
            if (!int.TryParse(textBoxyas.Text, out yas))
            {
                MessageBox.Show("Lütfen geçerli bir yaş girin.");
                return;
            }

            string cinsiyet = comboBoxcins.SelectedItem?.ToString();

            // Cinsiyetin seçilip seçilmediğini kontrol edelim
            if (string.IsNullOrEmpty(cinsiyet))
            {
                MessageBox.Show("Lütfen cinsiyet seçin.");
                return;
            }

            // MSSQL bağlantısı için SqlConnection kullanılıyor
            string connectionString = "Server=MONSTER\\SQLEXPRESS;Database=SaglikTakip;Trusted_Connection=True;";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Kullanicilar (Ad, Yas, Cinsiyet) VALUES (@ad, @yas, @cinsiyet)", conn);
                cmd.Parameters.AddWithValue("@ad", ad);
                cmd.Parameters.AddWithValue("@yas", yas);
                cmd.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kullanıcı kaydedildi.");

                // Formu temizleyelim
                textBoxad.Text = "Ad";
                textBoxyas.Text = "Yaş";
                comboBoxcins.Text = "Cinsiyet";
            }
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
