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
namespace ÖgrGiris
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
     SqlConnection giris = new SqlConnection ("Data Source = DESKTOP-AG2VV6V\\SQLEXPRESS;Initial Catalog = ÖgrGiris; Integrated Security = True");
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {} private void button1_Click(object sender, EventArgs e)
        {
            giris.Open();
            SqlCommand grs = new SqlCommand("Select * From TblÖgrGiris where KullaniciAdi=@p1 and Sifre=@p2", giris);
            grs.Parameters.AddWithValue("@p1", TxtKullaniciAdi.Text);
            grs.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = grs.ExecuteReader();
            if (dr.Read())
            {
                FrmGirisSayfası frm = new FrmGirisSayfası();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış. Lütfen Tekrar Deneyiniz");
            }
            giris.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmYönlendir frmyönlendir = new FrmYönlendir();
            frmyönlendir.Show();
        }

        private void TxtSifre_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
    }
}
