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
    public partial class Form6 : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da1;

        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox2.Text== "Hangi Bitki Cinsinden Kaç Tane Satılmış")
            {
                baglanti = new SqlConnection(@"Data Source=SILVER\MSSQLSERVER01;Initial Catalog=Cicek;Integrated Security=True");
                baglanti.Open();
                da1 = new SqlDataAdapter("Select BitkiCinsi, SUM(SiparisAdedi) From Siparis1 Group BY BitkiCinsi ", baglanti);
                DataTable data = new DataTable();
                da1.Fill(data);
                dataGridView1.DataSource = data;
                baglanti.Close();
            }
            if (comboBox2.Text == "Hangi Çalışan Kaçtane Satış Yapmış")
            {
                baglanti = new SqlConnection(@"Data Source=SILVER\MSSQLSERVER01;Initial Catalog=Cicek;Integrated Security=True");
                baglanti.Open();
                da1 = new SqlDataAdapter("Select CalisanID, SUM(SiparisAdedi) From Siparis1 Group BY CalisanID ", baglanti);
                DataTable data = new DataTable();
                da1.Fill(data);
                dataGridView1.DataSource = data;
                baglanti.Close();
            }
            if (comboBox2.Text == "Çalışanlar Ve Siparişler")
            {
                baglanti = new SqlConnection(@"Data Source=SILVER\MSSQLSERVER01;Initial Catalog=Cicek;Integrated Security=True");
                baglanti.Open();
                da1 = new SqlDataAdapter("Select * From CalisanSiparis ", baglanti);
                DataTable data = new DataTable();
                da1.Fill(data);
                dataGridView1.DataSource = data;
                baglanti.Close();
            }
            if (comboBox2.Text == "Bitkilerin İdeal Sıcaklıkları Ve Nemleriyle Bulundukları Depoların Anlık Sıcaklık Ve Nemleri")
            {
                baglanti = new SqlConnection(@"Data Source=SILVER\MSSQLSERVER01;Initial Catalog=Cicek;Integrated Security=True");
                baglanti.Open();
                da1 = new SqlDataAdapter("Select * from SicaklikVeNem ", baglanti);
                DataTable data = new DataTable();
                da1.Fill(data);
                dataGridView1.DataSource = data;
                baglanti.Close();
            }

            if (comboBox2.Text == "Diğer...")
            {
                textBox1.Visible = true;
                button2.Visible = true;
                textBox1.Enabled = true;
                button2.Enabled = true;

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti = new SqlConnection(@"Data Source=SILVER\MSSQLSERVER01;Initial Catalog=Cicek;Integrated Security=True");
            baglanti.Open();
            da1 = new SqlDataAdapter(textBox1.Text, baglanti);
            DataTable data = new DataTable();
            da1.Fill(data);
            dataGridView1.DataSource = data;
            baglanti.Close();
        }
    }
}
