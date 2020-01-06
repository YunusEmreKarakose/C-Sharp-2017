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

namespace BankUyg
{
    public partial class islemler : Form
    {
        public islemler()
        {
            InitializeComponent();
        }

        
        SqlConnection baglan = new SqlConnection("Data Source=Lenovo-PC\\SQLEXPRESS;Initial Catalog=banka;Integrated Security=True");
        private int tara(int a, int b)
        {
            baglan.Open();

            SqlCommand komut = new SqlCommand("Select *from Bilgiler", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                if (Convert.ToInt32(oku["KartNo"]) == a && Convert.ToInt32(oku["Sifre"]) == b)
                {                    
                    return 1;
                }                
            }
            baglan.Close();
            return 0;
        }
        SqlConnection baglan1 = new SqlConnection("Data Source=Lenovo-PC\\SQLEXPRESS;Initial Catalog=banka;Integrated Security=True");
        private string isimbul(int x)
        {
            baglan1.Open();

            SqlCommand komut1 = new SqlCommand("Select *from Bilgiler", baglan1);
            SqlDataReader oku1 = komut1.ExecuteReader();
            while (oku1.Read())
            {
              if (Convert.ToInt32(oku1["KartNo"]) == x) { return oku1["AdSoyad"].ToString();
            }
             }
            baglan1.Close();
            return 0.ToString();
        }
        private void islemler_Load(object sender, EventArgs e)
        {
            if (tara(Form1.no, Form1.sifre)==1){ label1.Text = "hosgeldiniz "+isimbul(Form1.no);  }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            paracek i = new paracek();
            i.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parayatır i = new parayatır();
            i.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bakiyeSorgu a = new bakiyeSorgu();
            a.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            havale a = new havale();
            a.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }
    }
}
