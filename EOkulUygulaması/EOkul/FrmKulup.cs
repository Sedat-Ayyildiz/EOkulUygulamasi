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
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=;Initial Catalog=EOkul;Integrated Security=True");

        void Listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TblKulupler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void FrmKulup_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutEkle = new SqlCommand("insert into TblKulupler(KulupAd) values(@p1)",baglanti);
            komutEkle.Parameters.AddWithValue("@p1", TxtKulupAd.Text);
            komutEkle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulup Listeye Başarılı Bir Şekilde Eklendi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Listele();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)//Mouse ile üzerine gelince rengini değiştirdik.
        {
            pictureBox6.BackColor = Color.Red;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)//Mouse üzerinde ayrılınca rengini değiştirdik.
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)//Verileri Textbox'a taşıdık.
        {
            TxtKulupid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtKulupAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutSil = new SqlCommand("delete from TblKulupler where Kulupid=@p1",baglanti);
            komutSil.Parameters.AddWithValue("@p1",TxtKulupid.Text);
            komutSil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulup Silme İşlemi Başarılı Bir Şekilde Gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komulGuncelle = new SqlCommand("update TblKulupler set KulupAd=@p1 where Kulupid=@p2",baglanti);
            komulGuncelle.Parameters.AddWithValue("@p1", TxtKulupAd.Text);
            komulGuncelle.Parameters.AddWithValue("@p2", TxtKulupid.Text);
            komulGuncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulup Güncelleme İşlemi Başarılı Bir Şekilde Gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            FrmOgretmen fro = new FrmOgretmen();
            fro.Show();
            this.Close();
        }
    }
}
