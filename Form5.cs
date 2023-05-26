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
    public partial class Form5 : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da1;


        public Form5()
        {
            InitializeComponent();
        }

        void Getir()
        {
            baglanti = new SqlConnection(@"Data Source=SILVER\MSSQLSERVER01;Initial Catalog=Cicek;Integrated Security=True");
            baglanti.Open();
            da1 = new SqlDataAdapter("Select * from BitkiUretim ", baglanti);
            DataTable tablo1 = new DataTable();
            da1.Fill(tablo1);
            dataGridView1.DataSource = tablo1;
            baglanti.Close();
        }


        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'cicekDataSet.BitkiCinsi' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.bitkiCinsiTableAdapter.Fill(this.cicekDataSet.BitkiCinsi);
            // TODO: Bu kod satırı 'cicekDataSet.Sera' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.seraTableAdapter.Fill(this.cicekDataSet.Sera);
            Getir();

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "Insert into BitkiUretim (UretimNumarasi,SeraNumarasi,BitkiCinsi,UretimAdedi,Tarih) values (@UN,@SN,@BC,@UA,@T)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@UN", textBox1.Text);
            komut.Parameters.AddWithValue("@SN", comboBox1.Text);
            komut.Parameters.AddWithValue("@T", dateTimePicker1.Text);
            komut.Parameters.AddWithValue("@UA", textBox2.Text);
            komut.Parameters.AddWithValue("@BC", comboBox2.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Getir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = "Delete From BitkiUretim Where UretimNumarasi =@UN";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@UN", textBox1.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Getir();
        }
    }
}
