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
    public partial class FrmSınavNotlar : Form
    {
        public FrmSınavNotlar()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.TblNotlarTableAdapter ds = new DataSet1TableAdapters.TblNotlarTableAdapter();
        SqlConnection baglanti = new SqlConnection(@"Data Source=;Initial Catalog=EOkul;Integrated Security=True");
        private void FrmSınavNotlar_Load(object sender, EventArgs e)//DersCombobox'ına Dersleri Taşıdık.
        {
            dataGridView1.DataSource = null;
            baglanti.Open();//Burada FrmÖğrenci formunda KULÜPLERE TABLODA ki verileri taşıdık.
            SqlCommand komut = new SqlCommand("select * from TblDersler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbDers.DisplayMember = "DersAd";
            CmbDers.ValueMember = "Dersid";
            CmbDers.DataSource = dt;
            baglanti.Close();
        }

        int Notid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Notid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            TxtOgrid.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtSınav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtSınav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtSınav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            TxtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            TxtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        int sinav1, sinav2, sinav3, proje;
        double ortalama;
        private void BtnHesapla_Click(object sender, EventArgs e)
        {            
            //string durum;
            sinav1 = Convert.ToInt16(TxtSınav1.Text);
            sinav2 = Convert.ToInt16(TxtSınav2.Text);
            sinav3 = Convert.ToInt16(TxtSınav3.Text);
            proje = Convert.ToInt16(TxtProje.Text);
            ortalama = (sinav1+sinav2+sinav3+proje) / 4;
            TxtOrtalama.Text = ortalama.ToString();
            if (ortalama >= 50)
            {
                TxtDurum.Text = "True";
            }
            else
            {
                TxtDurum.Text = "False";
            }
            MessageBox.Show("Notlar Başarılı Bir Şekilde Hesaplandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }        

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.NotGuncelle(byte.Parse(CmbDers.SelectedValue.ToString()),int.Parse(TxtOgrid.Text),byte.Parse(TxtSınav1.Text),
            byte.Parse(TxtSınav2.Text), byte.Parse(TxtSınav3.Text), byte.Parse(TxtProje.Text), decimal.Parse(TxtOrtalama.Text),
            bool.Parse(TxtDurum.Text),Notid);
            MessageBox.Show("Notlar Başarılı Bir Şekilde Güncellendi.\nTekrar Aarayarak Yeni Notlarınızı Görebilirisniz !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtOgrid.Clear();
            CmbDers.Text = null;
            TxtSınav1.Clear();
            TxtSınav2.Clear();
            TxtSınav3.Clear();
            TxtProje.Clear();
            TxtOrtalama.Clear();
            TxtDurum.Clear();
            MessageBox.Show("Alanlar Başarılı Bir Şekilde Temizlendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(TxtOgrid.Text));
            MessageBox.Show("Aranan Kişi Başarılı Bir Şekilde Bulundu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FrmOgretmen fro = new FrmOgretmen();
            fro.Show();
            this.Close();
        }
    }
}
