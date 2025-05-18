using System;
using System.Data;
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

        // Kullanıcı sınıfı
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
            DataTable dt = databaseHelper.ExecuteQuery(query);

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
                MessageBox.Show("Lütfen bir kullanıcı seçin.");
                return;
            }

            Kullanici secilmis = comboBox1.SelectedItem as Kullanici;
            int kullaniciId = secilmis.Id;
            DateTime tarih = dateTimePicker1.Value;
            float kilo = (float)numericUpDown1.Value;
            int nabiz = (int)numericUpDown2.Value;
            string not = textBox1.Text;

            string query = "INSERT INTO SaglikKayitlari (KullaniciId, Tarih, Kilo, Nabiz, Notlar) VALUES (@kullaniciId, @tarih, @kilo, @nabiz, @not)";

            SqlParameter[] parameters = {
                new SqlParameter("@kullaniciId", kullaniciId),
                new SqlParameter("@tarih", tarih),
                new SqlParameter("@kilo", kilo),
                new SqlParameter("@nabiz", nabiz),
                new SqlParameter("@not", not)
            };

            int sonuc = databaseHelper.ExecuteNonQuery(query, parameters);

            if (sonuc > 0)
                MessageBox.Show("Sağlık kaydı eklendi.");
            else
                MessageBox.Show("Kayıt eklenirken bir hata oluştu.");
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
