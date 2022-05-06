using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aydeniz_Dinlenme_Tesisi
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmYoneticiGiris fr = new FrmYoneticiGiris();
            fr.Show();
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmPersonelGiris fr = new FrmPersonelGiris();
            fr.Show();
            
        }
    }
}
