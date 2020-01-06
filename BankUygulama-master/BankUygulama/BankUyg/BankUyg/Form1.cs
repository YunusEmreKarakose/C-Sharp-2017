using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BankUyg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        SqlConnection baglan = new SqlConnection("Data Source=Lenovo-PC\\SQLEXPRESS;Initial Catalog=banka;Integrated Security=True");

        public static int no;//Diğer formlarda parametre olarak kullanmak için kartno ve şifre 
        public static int sifre;
        public static int bakiye;
        private int tara(int a, int b)//Bu fonksiyona klavyeden girilen kartno ve şifre gönderilerek veritabanıyla karşılaştırılır.
        {
            baglan.Open();

            SqlCommand komut = new SqlCommand("Select *from Bilgiler", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                if (Convert.ToInt32(oku["KartNo"]) == a && Convert.ToInt32(oku["Sifre"]) == b)//kartno ve sifre kontrol
                {
                    no = Convert.ToInt32(oku["KartNo"]);//Diğer formlarda parametre olarak kullanmak için kartno ve şifre değerleri atanır
                    sifre = Convert.ToInt32(oku["Sifre"]);
                    bakiye = Convert.ToInt32(oku["Bakiye"]);
                    return 1;
                }

            }
            baglan.Close();
            return 0;

        }


        

        private void button1_Click_1(object sender, EventArgs e)
        {if (tara(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)) == 1)//kartno şifre uyuşuyorsa işlemler formuna geçiş
            {
                islemler a = new islemler();
                a.Show();
                this.Hide();
            }
            else
            {
                label3.Text = "hata";
                textBox2.Clear();
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
