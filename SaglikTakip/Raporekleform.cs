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

        private string connectionString = "Server=MONSTER\\SQLEXPRESS;Database=SaglikTakip;Trusted_Connection=True;";

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
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var da = new SqlDataAdapter("SELECT Tarih, Kilo, Nabiz, Notlar FROM SaglikKayitlari WHERE KullaniciId = @id", conn);
                da.SelectCommand.Parameters.AddWithValue("@id", kullaniciId);

                var dt = new DataTable();
                da.Fill(dt);
                dataSaglikKaydi.DataSource = dt;
            }
        }

        private void EgzersizKayitlariniGetir(int kullaniciId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var da = new SqlDataAdapter("SELECT EgzersizAdi, SureDakika, TekrarSayisi FROM Egzersizler WHERE KullaniciId = @id", conn);
                da.SelectCommand.Parameters.AddWithValue("@id", kullaniciId);

                var dt = new DataTable();
                da.Fill(dt);
                dataSporKaydi.DataSource = dt;
            }
        }

        private void LabelVerileriniAktar(int kullaniciId)
        {
            // Sağlık kaydı verilerini aktar
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT TOP 1 [Tarih], [Kilo], [Nabiz], [Notlar] FROM [SaglikKayitlari] WHERE [KullaniciId] = @id ORDER BY [Tarih] DESC", conn);
                cmd.Parameters.AddWithValue("@id", kullaniciId);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lblKilo.Text = reader["Kilo"] != DBNull.Value ? reader["Kilo"].ToString() : "—";
                    lblNabiz.Text = reader["Nabiz"] != DBNull.Value ? reader["Nabiz"].ToString() : "—";
                    lblNot.Text = reader["Notlar"] != DBNull.Value ? reader["Notlar"].ToString() : "—";

                    if (reader["Tarih"] != DBNull.Value)
                        lblTarih.Text = Convert.ToDateTime(reader["Tarih"]).ToString("dd MMMM yyyy");
                    else
                        lblTarih.Text = "—";
                }
                else
                {
                    // Hiç kayıt yoksa
                    lblKilo.Text = lblNabiz.Text = lblNot.Text = lblTarih.Text = "—";
                }
            }

            // Spor kaydı verilerini aktar
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT TOP 1 EgzersizAdi, SureDakika, TekrarSayisi FROM Egzersizler WHERE KullaniciId = @id ", conn);
                cmd.Parameters.AddWithValue("@id", kullaniciId);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lblEgzersiz.Text = reader["EgzersizAdi"] != DBNull.Value ? reader["EgzersizAdi"].ToString() : "—";
                    lblSure.Text = reader["SureDakika"] != DBNull.Value ? reader["SureDakika"].ToString() : "—";
                    lblTekrar.Text = reader["TekrarSayisi"] != DBNull.Value ? reader["TekrarSayisi"].ToString() : "—";
                }
                else
                {
                    lblEgzersiz.Text = lblSure.Text = lblTekrar.Text = "—";
                }
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
