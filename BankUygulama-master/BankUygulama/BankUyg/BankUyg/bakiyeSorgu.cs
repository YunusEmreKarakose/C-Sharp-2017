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
    public partial class bakiyeSorgu : Form
    {
        public bakiyeSorgu()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=Lenovo-PC\\SQLEXPRESS;Initial catalog=Banka;Integrated Security=True");


        int tara(int a)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from Bilgiler", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (a == Convert.ToInt16(oku["KartNo"]))
                {
                    int i = Convert.ToInt16(oku["Bakiye"]);
                    baglan.Close();
                    return i;
                }
                
                
            }
            baglan.Close();
            return 0;

        }
        private void bakiyeSorgu_Load(object sender, EventArgs e)
        {
            label2.Text = tara(Form1.no).ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            İslemsoru a = new İslemsoru();
            a.Show();
            this.Hide();
        }
    }
}
