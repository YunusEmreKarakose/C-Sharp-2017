using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatriceMultiplation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[,] m1;//1. matris
        int[,] m2;//2. matris
        int[,] m3;//ikisinin çarpımı

        private void button1_Click(object sender, EventArgs e)
        {
            oku();
        }

        void oku()
        {
            string[] satir1 = textBox1.Text.Split('\n');//1. matrisin satırları
            string[] satir2 = textBox2.Text.Split('\n');//2. matrisin satırları
            int sa1, sa2, su1, su2;//satir sutun sayilari
            string[] c1 = satir1[0].Split(' ');//1. matrisin sutun sayısı 1. satira göre
            string[] c2 = satir2[0].Split(' ');//2. matrisin sutun sayısı 1. satıra göre

            sa1 = satir1.Length;
            sa2 = satir2.Length;
            su1 = c1.Length;
            su2 = c2.Length;
            if(su1==sa2)//1.nin sutun sayısı 2.nin satir sayisina eşite çarpım yapılabilir
            {
                m1 = new int[sa1, su1];
                m2 = new int[sa2, su2];
                for(int i = 0; i < satir1.Length; i++)
                {
                   string[] e1 = satir1[i].Split(' ');//satirdaki sutun elemanlari

                   for(int j=0;j<e1.Length;j++)
                   {
                         m1[i, j] = Convert.ToInt32(e1[j]);
                   }
                }
                for(int k=0;k<satir2.Length;k++)
                {
                    string[] e2 = satir2[k].Split(' ');

                    for(int l = 0; l < e2.Length; l++)
                    {
                        m2[k, l] = Convert.ToInt32(e2[l]);
                    }
                }
                carp(sa1, sa2, su1, su2);
            }
           
            
        }


        void carp(int sa1,int sa2,int su1,int su2)
        {
            m3 = new int[sa1, su2];

            for(int i=0;i<sa1;i++)
            {
                for(int j=0;j<su2;j++)
                {
                    int tamp = 0;
                    for(int k=0;k<su1;k++)
                    {
                        tamp = tamp +( m1[i, k] * m2[k, j]);
                    }
                    m3[i, j] = tamp;
                }
            }
            yaz(sa1, su2);
        }

        void yaz(int sa1,int su2)
        {
            textBox3.Clear();
            for(int i=0;i<sa1;i++)
            {
                for(int j=0;j<su2; j++)
                {
                    textBox3.Text = textBox3.Text+ m3[i, j].ToString()+" ";
                }
                textBox3.Text =textBox3.Text+ "\r\n";
            }
        }
    }
}
