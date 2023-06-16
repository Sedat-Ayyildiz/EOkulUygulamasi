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

namespace EOkul
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FrmOgretmen fro = new FrmOgretmen();
            fro.Show();
            this.Close();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=;Initial Catalog=EOkul;Integrated Security=True");
        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            baglanti.Open();//Burada FrmÖğrenci formunda KULÜPLERE TABLODA ki verileri taşıdık.
            SqlCommand komut = new SqlCommand("select * from TblKulupler",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);            
            CmbKulup.DisplayMember = "KulupAd";
            CmbKulup.ValueMember = "Kulupid";
            CmbKulup.DataSource = dt;            
            baglanti.Close();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();//Üstteki kod satırı ile datasetten verileri çektik.            
        }

        string c = "";
        private void BtnEkle_Click(object sender, EventArgs e)
        {            
            ds.OgrenciEkle(TxtAd.Text, TxtSoyad.Text, byte.Parse(CmbKulup.SelectedValue.ToString()), c);
            MessageBox.Show("Öğrenci Ekleme İşlemi Başarılı Bir Şekilde Gerçekleşti.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);            TxtAd.Clear();            
        }

        private void CmbKulup_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtOgrid.Text = CmbKulup.SelectedValue.ToString();//CmbKulup'te kulüp seçince Kulüpid'lerini TxtOgrid bölümünde gösterdik.
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(TxtOgrid.Text));
            MessageBox.Show("Öğrenci Silme İşlemi Başarılı Bir Şekilde Gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            TxtOgrid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            // !!!!! CİNSİYETİ DGV' e TIKLAYINCA RADİOBUTTON'a AKTARAMADIM !!!!!            
            /*if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "True")
            {
                RbKız.Checked = true;
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "False")
            {
                RbErkek.Checked = true;
            }*/
            //CmbKulup.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelle(TxtAd.Text, TxtSoyad.Text, byte.Parse(CmbKulup.SelectedValue.ToString()), c, int.Parse(TxtOgrid.Text));
            MessageBox.Show("Güncelleme İşlemi Başarılı Bir Şekilde Gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);            
        }

        private void RbKız_CheckedChanged(object sender, EventArgs e)
        {
            //İF-ELSE VARSA C'ye BOŞ DEĞER ATAMAYA GEREK YOK.ANCAK İF-İF ise C'ye BOŞ DEĞER ATMAMIZ LAZIM !
            if (RbKız.Checked == true)
            {
                c = "KIZ";
            }
        }

        private void RbErkek_CheckedChanged(object sender, EventArgs e)
        {
            //İF-ELSE VARSA C'ye BOŞ DEĞER ATAMAYA GEREK YOK.ANCAK İF-İF ise C'ye BOŞ DEĞER ATMAMIZ LAZIM !            
            if (RbErkek.Checked == true)
            {
                c = "ERKEK";
            }
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciGetir(TxtAra.Text);
        }        
    }
}
