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
    public partial class FrmStoklarveFaturalar : Form
    {
        public FrmStoklarveFaturalar()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-7ROAQ7M\\SQLEXPRESS;Initial Catalog=AydenizPansiyon;Integrated Security=True");

        private void veriler()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Stoklar", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["Gida"].ToString());
                ekle.SubItems.Add(oku["İcecek"].ToString());
                ekle.SubItems.Add(oku["Cerezler"].ToString());
                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }
        private void veriler2()
        {
            listView2.Items.Clear();
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select * from Faturalar", baglanti);
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku2["id"].ToString();
                ekle.SubItems.Add(oku2["Elektrik"].ToString());
                ekle.SubItems.Add(oku2["Su"].ToString());
                ekle.SubItems.Add(oku2["İnternet"].ToString());
                listView2.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Stoklar(Gida,İcecek,Cerezler) values ('" + txtGidalar.Text + "','" + txtİcecekler.Text + "','" + txtAtistirmaliklar.Text + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            veriler();
        }

      

        private void BtnKaydet2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into Faturalar(Elektrik,Su,İnternet) values ('" + txtElektrik.Text + "','" + txtSu.Text + "','" + txtİnternet.Text + "')", baglanti);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            veriler2();
        }
        int id = 0;
        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from Stoklar where id=(" + id + ")", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            veriler();
            MessageBox.Show("Kayıtlar Silindi.");
        }


        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);  //burda tür dönüşümü yaptık
            txtGidalar.Text = listView1.SelectedItems[0].SubItems[1].Text;  //burda da sql daki [0] satır [1]. sütünü aldık
            txtİcecekler.Text = listView1.SelectedItems[0].SubItems[2].Text;
            txtAtistirmaliklar.Text = listView1.SelectedItems[0].SubItems[3].Text;

        }
        
        private void btnSil2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from Faturalar where id=(" + id + ")", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            veriler2();
            MessageBox.Show("Kayıtlar Silindi.");
        }

        
        private void listView2_DoubleClick(object sender, EventArgs e)
        {
       
            id = int.Parse(listView2.SelectedItems[0].SubItems[0].Text);  //burda tür dönüşümü yaptık
            txtElektrik.Text = listView2.SelectedItems[0].SubItems[1].Text;  //burda da sql daki [0] satır [1]. sütünü aldık
            txtSu.Text = listView2.SelectedItems[0].SubItems[2].Text;
            txtİnternet.Text = listView2.SelectedItems[0].SubItems[3].Text;
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            txtGidalar.Clear();
            txtİcecekler.Clear();
            txtAtistirmaliklar.Clear();
        }

        private void BtnTemizlee_Click(object sender, EventArgs e)
        {
            txtElektrik.Clear();
            txtSu.Clear();
            txtİnternet.Clear();
        }

        private void FrmStoklarveFaturalar_Load(object sender, EventArgs e)
        {
            veriler();
            veriler2();
        }
    }
}
