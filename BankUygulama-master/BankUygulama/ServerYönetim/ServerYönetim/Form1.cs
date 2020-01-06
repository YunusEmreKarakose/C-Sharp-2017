using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ServerYönetim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=Lenovo-PC\\SQLEXPRESS;Initial catalog=Banka;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();

            SqlCommand komut = new SqlCommand("insert into Bilgiler (AdSoyad,KartNo,Sifre,Bakiye) values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString()+"' )", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            label8.Text = "Kullanıcı Eklendi";
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();

            SqlCommand komut = new SqlCommand("Delete From Bilgiler where KartNo=" + textBox5.Text.ToString() + "",baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            textBox5.Clear();
            label8.Text = "Kullanıcı Silindi";
        }
    }
}
