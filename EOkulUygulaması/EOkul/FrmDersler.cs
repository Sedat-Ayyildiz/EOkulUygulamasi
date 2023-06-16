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
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }


        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        //DATASET'e YENİ TABLO EKLEMEK için VAROLAN TABLO ÜSTÜNE GELİP SAĞ TIK->QUERY YAPARAK EKLEYEBİLİRİZ.
        //DATASET PROJE'de KULLANILIRSA KOD FAZLALIĞINDA KURTULURUZ !

        DataSet1TableAdapters.TblDerslerTableAdapter ds = new DataSet1TableAdapters.TblDerslerTableAdapter();
        private void FrmDersler_Load(object sender, EventArgs e)//BAGLANTI ADRESİ EKLEMEDİK ÇÜNKÜ DATASET OTOMATİK APPCONFİG içinde ADRESİ TUTUYOR.
        {   //BÖYLECE PROJEMİZE EKLEDİĞİMİZ DATASET'i DGV'E BAĞLADIK !            
            dataGridView1.DataSource = null;
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            ds.DersEkle(TxtDersAd.Text);//DATASET SAYESİNDE BİR SÜRÜ SQL KOMUTUNDAN KURTULUP 2 SATIRLA EKLEME İŞLEMİ YAPTIK !!!
            MessageBox.Show("Ders Ekleme İşlemi Başarılı Bir Şekilde Gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse(TxtDersid.Text));//Sql'de Tinyint tanımlamıştık burada string yapınca hata verdi dönüştürdük.
            MessageBox.Show("Ders Silme İşlemi Başarılı Bir Şekilde Gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.DersGuncelle(TxtDersAd.Text,byte.Parse(TxtDersid.Text));
            MessageBox.Show("Ders Güncelleme İşlemi Başarılı Bir Şekilde Gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtDersid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtDersAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            FrmOgretmen fro = new FrmOgretmen();
            fro.Show();
            this.Close();
        }
    }
}
