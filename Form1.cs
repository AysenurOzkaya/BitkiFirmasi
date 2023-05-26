using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitkiFirmasi
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=SILVER\MSSQLSERVER01;Initial Catalog=Cicek;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string Password;
            string ID;
            ID = textBox1.Text;
            Password = textBox2.Text;
            SqlCommand komut = new SqlCommand("select*from Calisan where KullaniciSifresi='" + Password + "' and CalisanID='" + ID + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {

                Form2 fr = new Form2();
                fr.ShowDialog();


            }
            else
            {
                MessageBox.Show("Hatalı Giriş");
            }

            baglanti.Close();
        }
    }
}
