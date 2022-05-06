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
    public partial class FrmPersoneller : Form
    {
        public FrmPersoneller()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-7ROAQ7M\\SQLEXPRESS;Initial Catalog=AydenizPansiyon;Integrated Security=True");
        private void verilergoster() // erişim belirleyicim (istediğim zaman çağırmam için)
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from PersonelKayit", baglanti); //verileri çekiyom musteri ekle tablosundan

            SqlDataReader oku = komut.ExecuteReader(); //sql verilerini oku

            while (oku.Read()) //okudukça bunlar yap
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString(); //kök düğümümü yazdım
                ekle.SubItems.Add(oku["Ad"].ToString()); //cocuklarını oluşturdum alt öğe (oku komudum çalıştığı sürece adini yazdır
                ekle.SubItems.Add(oku["Soyad"].ToString());
                ekle.SubItems.Add(oku["Departman"].ToString());
                ekle.SubItems.Add(oku["Maas"].ToString());
                ekle.SubItems.Add(oku["DogumTarihi"].ToString());
                ekle.SubItems.Add(oku["Cinsiyet"].ToString());
                ekle.SubItems.Add(oku["MedeniHali"].ToString());
                ekle.SubItems.Add(oku["Adres"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());

                listView1.Items.Add(ekle);

            }
            baglanti.Close();
        }
        private void btnAra_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from PersonelKayit where Ad like '%" + txtara.Text + "%'", baglanti); //textbox1 deki veriye göre arama yapıyor

            SqlDataReader oku = komut.ExecuteReader(); //sql verilerini oku

            while (oku.Read()) //okudukça bunlar yap
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString(); //kök düğümümü yazdım
                ekle.SubItems.Add(oku["Ad"].ToString()); //cocuklarını oluşturdum alt öğe (oku komudum çalıştığı sürece adini yazdır
                ekle.SubItems.Add(oku["Soyad"].ToString());
                ekle.SubItems.Add(oku["Departman"].ToString());
                ekle.SubItems.Add(oku["Maas"].ToString());
                ekle.SubItems.Add(oku["DogumTarihi"].ToString());
                ekle.SubItems.Add(oku["Cinsiyet"].ToString());
                ekle.SubItems.Add(oku["MedeniHali"].ToString());
                ekle.SubItems.Add(oku["Adres"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());

                listView1.Items.Add(ekle);

            }
            baglanti.Close();
        }

        private void BtnVerileriGoster_Click(object sender, EventArgs e)
        {
            verilergoster();
        }

        int id = 0;
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);  //burda tür dönüşümü yaptık
            txtad.Text = listView1.SelectedItems[0].SubItems[1].Text;  //burda da sql daki [0] satır [1]. sütünü aldık
            txtsoyad.Text = listView1.SelectedItems[0].SubItems[2].Text;
            txtdepartman.Text = listView1.SelectedItems[0].SubItems[3].Text;
            txtmaas.Text = listView1.SelectedItems[0].SubItems[4].Text;
            mskDogumTarihi.Text = listView1.SelectedItems[0].SubItems[5].Text;
            cmbCinsiyet.Text = listView1.SelectedItems[0].SubItems[6].Text;
            cmbMedeniHal.Text = listView1.SelectedItems[0].SubItems[7].Text;
            txtAdres.Text = listView1.SelectedItems[0].SubItems[8].Text;
            mskTelefon.Text = listView1.SelectedItems[0].SubItems[9].Text;

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("update PersonelKayit set Ad='" + txtad.Text + "', Soyad ='" + txtsoyad.Text + "',Departman='" + txtdepartman.Text + "',Maas='" + txtmaas.Text + "',DogumTarihi='" + mskDogumTarihi.Text + "', Cinsiyet='" + cmbCinsiyet.Text + "',MedeniHali='" + cmbMedeniHal.Text + "',Adres='" + txtAdres.Text + "', Telefon='" + mskTelefon.Text + "' where id=" + id + "", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilergoster();
            MessageBox.Show("Güncellendi.");
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from PersonelKayit where id=(" + id + ")", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilergoster();
            MessageBox.Show("Personel Kaydı Silindi.");
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            txtad.Clear();
            txtsoyad.Clear();
            txtdepartman.Clear();
            txtmaas.Clear();
            mskDogumTarihi.Text = "";
            cmbCinsiyet.Text = "";
            cmbMedeniHal.Text = "";
            txtAdres.Clear();
            mskTelefon.Clear();
        }

        private void FrmPersoneller_Load(object sender, EventArgs e)
        {

        }
    }
}
