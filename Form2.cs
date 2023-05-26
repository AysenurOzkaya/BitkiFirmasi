using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitkiFirmasi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Bitki Cinsi")
            {
                Form3 fr = new Form3();
                fr.ShowDialog();
            }
            if (comboBox1.Text == "Sipariş")
            {
                Form4 fr1 = new Form4();
                fr1.ShowDialog();
            }
            if (comboBox1.Text == "Bitki Üretim")
            {
                Form5 fr2 = new Form5();
                fr2.ShowDialog();
            }
            if (comboBox1.Text == "Diğer...")
            {
                Form6 fr2 = new Form6();
                fr2.ShowDialog();
            }
        }
    }
}
