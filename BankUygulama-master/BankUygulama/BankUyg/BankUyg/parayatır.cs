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
    public partial class parayatır : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=Lenovo-PC\\SQLEXPRESS;Initial Catalog=banka;Integrated Security=True");
        public parayatır()
        {
            InitializeComponent();
        }
        int bakiyedon(int z)
        {

            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from Bilgiler", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                if (z == Convert.ToInt32(oku["KartNo"]))
                {
                    int a = Convert.ToInt32(oku["Bakiye"]);
                    baglan.Close(); return a;
                }
            }
            baglan.Close();
            return 0;
        }


        SqlConnection baglan1 = new SqlConnection("Data Source=Lenovo-PC\\SQLEXPRESS;Initial Catalog=banka;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            baglan1.Open();
            int a = bakiyedon(Form1.no);
            int b = Convert.ToInt16(textBox1.Text);
           
                SqlCommand komut = new SqlCommand("Update Bilgiler set Bakiye='" + (a + b) + "'  where KartNo=" + Form1.no + "", baglan1);
                komut.ExecuteNonQuery();
                İslemsoru i = new İslemsoru();
                i.Show();
                this.Hide();
            

            baglan1.Close();
        }

        private void parayatır_Load(object sender, EventArgs e)
        {
            label2.Text = bakiyedon(Form1.no).ToString();
        }
    }
}
