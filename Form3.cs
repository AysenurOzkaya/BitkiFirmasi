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
    public partial class Form3 : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;


        public Form3()
        {
            InitializeComponent();
        }


        void Getir()
        {
            baglanti = new SqlConnection(@"Data Source=SILVER\MSSQLSERVER01;Initial Catalog=Cicek;Integrated Security=True");
            baglanti.Open();
            da = new SqlDataAdapter("Select *From BitkiCinsi ", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }




        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'cicekDataSet.DEPO' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.dEPOTableAdapter.Fill(this.cicekDataSet.DEPO);
            Getir();

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "Insert into BitkiCinsi (BitkiCinsi,DepoID,IdealOrtamSicakligi,IdealOrtamNemi,MevcutAdet,LatinceIsmi) values (@BC,@DID,@IOS,@ION,@MA,@L)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@BC", textBox1.Text);
            komut.Parameters.AddWithValue("@IOS", textBox4.Text);
            komut.Parameters.AddWithValue("@ION", textBox3.Text);
            komut.Parameters.AddWithValue("@MA", textBox5.Text);
            komut.Parameters.AddWithValue("@DID",comboBox1.Text);
            komut.Parameters.AddWithValue("@L", textBox2.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Getir();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sorgu = "Delete From BitkiCinsi Where BitkiCinsi=@BC";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@BC", textBox1.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Getir();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sorgu = "Update BitkiCinsi Set LatinceIsmi=@L,DepoID=@DID,MevcutAdet=@MA,IdealOrtamSicakligi=@IOS,IdealOrtamNemi=@ION Where BitkiCinsi=@BC";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@BC", textBox1.Text);
            komut.Parameters.AddWithValue("@IOS", textBox4.Text);
            komut.Parameters.AddWithValue("@ION", textBox3.Text);
            komut.Parameters.AddWithValue("@MA", textBox5.Text);
            komut.Parameters.AddWithValue("@DID", comboBox1.Text);
            komut.Parameters.AddWithValue("@L", textBox2.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Getir();
        }
    }
}
