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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        //PROJECT->ADD NEW ITEM->DATA->DATASET projemize ekledik.İstediğimiz tabloyu seçip otomatik sorgularını hazırlattık.
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmOgrenciNotlar frn = new FrmOgrenciNotlar();
            frn.numara = textBox1.Text;//Öğrenci numarayı form başlığına taşıdık.
            frn.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmOgretmen fro = new FrmOgretmen();
            fro.Show();
            this.Hide();
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
