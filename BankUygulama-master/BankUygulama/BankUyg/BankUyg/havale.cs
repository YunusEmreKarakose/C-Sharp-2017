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
    public partial class havale : Form
    {
        public havale()
        {
            InitializeComponent();
        }

        SqlConnection baglan1 = new SqlConnection("Data Source=Lenovo-PC\\SQLEXPRESS;Initial catalog=Banka;Integrated Security=True");

        int hedefBakiye(int a)
        {
            baglan1.Open();
            SqlCommand komut1 = new SqlCommand("Select *from Bilgiler", baglan1);
            SqlDataReader oku = komut1.ExecuteReader();

            while (oku.Read())
            {
                if (a == Convert.ToInt32( oku["KartNo"]))
                {
                    int x = Convert.ToInt32(oku["Bakiye"]);
                    baglan1.Close();
                    return x;
                }
            }
            baglan1.Close();
            return 0;
        }


        SqlConnection baglan = new SqlConnection("Data Source=Lenovo-PC\\SQLEXPRESS;Initial catalog=Banka;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            if ((Form1.bakiye - Convert.ToInt32(textBox2.Text)) < 0)
            {
                label3.Text = "hata"; baglan.Close();
            }
            else {
                int x;
                x = hedefBakiye(Convert.ToInt32(textBox1.Text))+Convert.ToInt32(textBox2.Text);
                SqlCommand komut = new SqlCommand("Update Bilgiler set Bakiye='" +x +"' where KartNo=" +textBox1.Text +"",baglan);
                komut.ExecuteNonQuery();
                SqlCommand komut2 = new SqlCommand("Update Bilgiler set Bakiye='"+(Form1.bakiye-Convert.ToInt32(textBox2.Text))+"' where Kartno=" + Form1.no + "",baglan);
                komut2.ExecuteNonQuery();

                İslemsoru a = new İslemsoru();
                a.Show();
                this.Hide();
                baglan.Close();

            }
        }

        private void havale_Load(object sender, EventArgs e)
        {

        }
    }
}
