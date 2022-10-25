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
    public partial class FrmYönlendir : Form
    {
        public FrmYönlendir()
        {
            InitializeComponent();
        }
        SqlConnection giris = new SqlConnection("Data Source = DESKTOP-AG2VV6V\\SQLEXPRESS;Initial Catalog = ÖgrGiris; Integrated Security = True");
        private void button1_Click(object sender, EventArgs e)
        {
            giris.Open();
            SqlCommand ynlndr = new SqlCommand("Select * From TblYönlendir where EPosta=@k1", giris);
            ynlndr.Parameters.AddWithValue("@k1", TxtEPosta.Text);
            SqlDataReader dr = ynlndr.ExecuteReader();
            if (dr.Read())
            {
               
                SqlCommand giris2 = new SqlCommand ("Update TblYönlendir Set From where YeniSifre=@k2", giris);
                giris2.Parameters.AddWithValue("@k2", TxtYeniSifre.Text);
               
                MessageBox.Show("Şifreniz sıfırlandı.Lütfen yeni şifrenizle tekrar giriş yapınız");
                 
                Form1 frm1 = new Form1();
                frm1.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Tekrar Deneyin.");
            }
            giris.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Form1 frm1 = new Form1();
            frm1.Show();
        }
        private void txttC_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); // sadece rakam girilebilir.
            
               
            }
        }
    }
        
  
