using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SaglikTakip
{
    public partial class Raporekleform : Form
    {
        public Raporekleform()
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

        private void Raporekleform_Load(object sender, EventArgs e)
        {
            lblTarih.Text = " ";
            lblKilo.Text = " ";
            lblNabiz.Text = " ";
            lblNot.Text = " ";
            lblEgzersiz.Text = " ";
            lblSure.Text = " ";
            lblTekrar.Text = " ";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            KullaniciListesiGetir();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) return;

            Kullanici secilen = comboBox1.SelectedItem as Kullanici;
            if (secilen != null)
            {
                SaglikKayitlariniGetir(secilen.Id);
                EgzersizKayitlariniGetir(secilen.Id);
                LabelVerileriniAktar(secilen.Id);
            }
        }

        private void SaglikKayitlariniGetir(int kullaniciId)
        {
            string query = "SELECT Tarih, Kilo, Nabiz, Notlar FROM SaglikKayitlari WHERE KullaniciId = @id";
            SqlParameter[] parameters = {
                new SqlParameter("@id", kullaniciId)
            };

            DataTable dt = databaseHelper.ExecuteQuery(query, parameters);
            dataSaglikKaydi.DataSource = dt;
        }

        private void EgzersizKayitlariniGetir(int kullaniciId)
        {
            string query = "SELECT EgzersizAdi, SureDakika, TekrarSayisi FROM Egzersizler WHERE KullaniciId = @id";
            SqlParameter[] parameters = {
                new SqlParameter("@id", kullaniciId)
            };

            DataTable dt = databaseHelper.ExecuteQuery(query, parameters);
            dataSporKaydi.DataSource = dt;
        }

        private void LabelVerileriniAktar(int kullaniciId)
        {
            // Sağlık kaydı verilerini al
            string saglikQuery = "SELECT TOP 1 [Tarih], [Kilo], [Nabiz], [Notlar] FROM [SaglikKayitlari] WHERE [KullaniciId] = @id ORDER BY [Tarih] DESC";
            SqlParameter[] parameters = {
                new SqlParameter("@id", kullaniciId)
            };

            DataTable dtSaglik = databaseHelper.ExecuteQuery(saglikQuery, parameters);

            if (dtSaglik.Rows.Count > 0)
            {
                DataRow row = dtSaglik.Rows[0];
                lblKilo.Text = row["Kilo"] != DBNull.Value ? row["Kilo"].ToString() : "—";
                lblNabiz.Text = row["Nabiz"] != DBNull.Value ? row["Nabiz"].ToString() : "—";
                lblNot.Text = row["Notlar"] != DBNull.Value ? row["Notlar"].ToString() : "—";
                lblTarih.Text = row["Tarih"] != DBNull.Value ? Convert.ToDateTime(row["Tarih"]).ToString("dd MMMM yyyy") : "—";
            }
            else
            {
                lblKilo.Text = lblNabiz.Text = lblNot.Text = lblTarih.Text = "—";
            }

            // Egzersiz kaydı verilerini al
            string egzersizQuery = "SELECT TOP 1 EgzersizAdi, SureDakika, TekrarSayisi FROM Egzersizler WHERE KullaniciId = @id";
            DataTable dtEgzersiz = databaseHelper.ExecuteQuery(egzersizQuery, parameters);

            if (dtEgzersiz.Rows.Count > 0)
            {
                DataRow row = dtEgzersiz.Rows[0];
                lblEgzersiz.Text = row["EgzersizAdi"] != DBNull.Value ? row["EgzersizAdi"].ToString() : "—";
                lblSure.Text = row["SureDakika"] != DBNull.Value ? row["SureDakika"].ToString() : "—";
                lblTekrar.Text = row["TekrarSayisi"] != DBNull.Value ? row["TekrarSayisi"].ToString() : "—";
            }
            else
            {
                lblEgzersiz.Text = lblSure.Text = lblTekrar.Text = "—";
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
