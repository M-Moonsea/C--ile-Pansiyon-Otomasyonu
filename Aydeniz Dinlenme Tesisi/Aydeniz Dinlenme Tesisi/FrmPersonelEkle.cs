using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Aydeniz_Dinlenme_Tesisi
{
    public partial class FrmPersonelEkle : Form
    {
        public FrmPersonelEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-7ROAQ7M\\SQLEXPRESS;Initial Catalog=AydenizPansiyon;Integrated Security=True");

  

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into PersonelKayit (Ad, Soyad, Departman, Maas, DogumTarihi, Cinsiyet, MedeniHali, Adres, Telefon) values ('" + txtad.Text + "','" + txtsoyad.Text + "','" + txtdepartman.Text + "','" + txtmaas.Text + "','" + mskDogumTarihi.Text + "','" + cmbCinsiyet.Text + "','" + cmbMedeniHal.Text + "','" + txtAdres.Text + "','" + mskTelefon.Text + "')", baglanti);
            komut.ExecuteNonQuery();   //parametreler üzerinde değişiklikler yapıyor (ekle sil güncelle)
            baglanti.Close();
            MessageBox.Show("Müşteri Kaydı Yapıldı.");
        }

       
    }
}
