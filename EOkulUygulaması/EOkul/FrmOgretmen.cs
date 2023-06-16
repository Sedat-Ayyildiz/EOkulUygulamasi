using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EOkul
{
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmKulup frk = new FrmKulup();
            frk.Show();
            this.Close();
        }

        private void BtnDers_Click(object sender, EventArgs e)
        {
            FrmDersler frd = new FrmDersler();
            frd.Show();
            this.Close();
        }

        private void BtnOgrenci_Click(object sender, EventArgs e)
        {
            FrmOgrenci fro = new FrmOgrenci();
            fro.Show();
            this.Close();
        }

        private void BtnSınavNot_Click(object sender, EventArgs e)
        {
            FrmSınavNotlar frn = new FrmSınavNotlar();
            frn.Show();
            this.Close();
        }

        private void BtnAnaSayfa_Click(object sender, EventArgs e)
        {
            FrmGiris frg = new FrmGiris();
            frg.Show();
            this.Close();
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
