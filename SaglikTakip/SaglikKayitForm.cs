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
    public partial class SaglikKayitForm : Form
    {
        public SaglikKayitForm()
        {
            InitializeComponent();
        }

        // Kullanici sınıfı
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
                MessageBox.Show("Lütfen bir kullanıcı seçin.");
                return;
            }

            Kullanici secilmis = comboBox1.SelectedItem as Kullanici;
            int kullaniciId = secilmis.Id;
            DateTime tarih = dateTimePicker1.Value;
            float kilo = (float)numericUpDown1.Value;
            int nabiz = (int)numericUpDown2.Value;
            string not = textBox1.Text;

            string connectionString = "Server=MONSTER\\SQLEXPRESS;Database=SaglikTakip;Trusted_Connection=True;";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO SaglikKayitlari (KullaniciId, Tarih, Kilo, Nabiz, Notlar) VALUES (@kullaniciId, @tarih, @kilo, @nabiz, @not)", conn);
                cmd.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                cmd.Parameters.AddWithValue("@tarih", tarih);
                cmd.Parameters.AddWithValue("@kilo", kilo);
                cmd.Parameters.AddWithValue("@nabiz", nabiz);
                cmd.Parameters.AddWithValue("@not", not);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sağlık kaydı eklendi.");
            }
        }

        private void SaglikKayitForm_Load(object sender, EventArgs e)
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
