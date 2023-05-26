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
    public partial class Form4 : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da1;


        public Form4()
        {
            InitializeComponent();
        }

        void Getir()
        {
            baglanti = new SqlConnection(@"Data Source=SILVER\MSSQLSERVER01;Initial Catalog=Cicek;Integrated Security=True");
            baglanti.Open();
            da1 = new SqlDataAdapter("Select * from Siparis1 ", baglanti);
            DataTable tablo1 = new DataTable();
            da1.Fill(tablo1);
            dataGridView1.DataSource = tablo1;
            baglanti.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'cicekDataSet.Calisan' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.calisanTableAdapter.Fill(this.cicekDataSet.Calisan);
            // TODO: Bu kod satırı 'cicekDataSet.BitkiCinsi' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.bitkiCinsiTableAdapter.Fill(this.cicekDataSet.BitkiCinsi);
            // TODO: Bu kod satırı 'cicekDataSet.Musteri1' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.musteri1TableAdapter.Fill(this.cicekDataSet.Musteri1);
            Getir();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "Insert into Siparis1 (SiparisID,MusteriID,SiparisTarihi,adres,BitkiCinsi,SiparisAdedi,CalisanID) values (@SID,@MID,@ST,@A,@BC,@SA,@CID)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@SID", textBox1.Text);
            komut.Parameters.AddWithValue("@MID", comboBox1.Text);
            komut.Parameters.AddWithValue("@ST", dateTimePicker1.Text);
            komut.Parameters.AddWithValue("@A", textBox2.Text);
            komut.Parameters.AddWithValue("@BC", comboBox2.Text);
            komut.Parameters.AddWithValue("@SA", textBox3.Text);
            komut.Parameters.AddWithValue("@CID", comboBox3.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Getir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu = "Delete From Siparis1 Where SiparisID =@SID";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@SID", textBox1.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Getir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = "Update Siparis1 Set MusteriID=@MID,SiparisTarihi=@ST,adres=@A,BitkiCinsi=@BC,SiparisAdedi=@SA,CalisanID=@CID Where SiparisID=@SID";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@SID", textBox1.Text);
            komut.Parameters.AddWithValue("@MID", comboBox1.Text);
            komut.Parameters.AddWithValue("@ST", dateTimePicker1.Text);
            komut.Parameters.AddWithValue("@A", textBox2.Text);
            komut.Parameters.AddWithValue("@BC", comboBox2.Text);
            komut.Parameters.AddWithValue("@SA", textBox3.Text);
            komut.Parameters.AddWithValue("@CID", comboBox3.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Getir();
        }
    }
}
