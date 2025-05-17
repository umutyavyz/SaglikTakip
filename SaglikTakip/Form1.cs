using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaglikTakip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKullaniciEkle_Click(object sender, EventArgs e)
        {
            new KullaniciEkleForm().ShowDialog();
        }

        private void btnSaglikKaydi_Click(object sender, EventArgs e)
        {
            new SaglikKayitForm().ShowDialog();
        }

        private void btnEgzersizEkle_Click(object sender, EventArgs e)
        {
            new EgzersizKayitForm().ShowDialog();
        }

        private void cikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Raporgor_Click(object sender, EventArgs e)
        {
            new Raporekleform().ShowDialog();
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
