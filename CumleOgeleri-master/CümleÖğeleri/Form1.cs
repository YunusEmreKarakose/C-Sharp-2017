using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CümleÖğeleri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int sayiHece(String a)
        {
            int tamp = Convert.ToInt16(a);
            int hece = 0; int i = 1;
            int x = 0;
            while (tamp > 0)
            {
                int tamp1 = tamp * i;

                if ((tamp1 % 10 == 1 || tamp % 10 == 1) && i != x) { hece = hece + 1; }//"bir" 1 hece
                if ((tamp1 % 10 == 2 || tamp % 10 == 2) && i != 10) { hece = hece + 2; }//"iki" 2 hece
                if ((tamp1 % 10 == 3 || tamp % 10 == 3) && i != 10) { hece = hece + 1; }
                if ((tamp1 % 10 == 4 || tamp % 10 == 4) && i != 10) { hece = hece + 1; }
                if ((tamp1 % 10 == 5 || tamp % 10 == 5) && i != 10) { hece = hece + 1; }
                if ((tamp1 % 10 == 6 || tamp % 10 == 6) && i != 10) { hece = hece + 2; }
                if ((tamp1 % 10 == 7 || tamp % 10 == 7) && i != 10) { hece = hece + 2; }
                if ((tamp1 % 10 == 8 || tamp % 10 == 8) && i != 10) { hece = hece + 2; }
                if ((tamp1 % 10 == 9 || tamp % 10 == 9) && i != 10) { hece = hece + 2; }
                if ((tamp % 10) * i == 10) { hece = hece + 1; }
                if ((tamp % 10) * i == 20) { hece = hece + 2; }
                if ((tamp % 10) * i == 30) { hece = hece + 2; }
                if ((tamp % 10) * i == 40) { hece = hece + 1; }
                if ((tamp % 10) * i == 50) { hece = hece + 2; }
                if ((tamp % 10) * i == 60) { hece = hece + 2; }
                if ((tamp % 10) * i == 70) { hece = hece + 2; }
                if ((tamp % 10) * i == 80) { hece = hece + 2; }
                if ((tamp % 10) * i == 90) { hece = hece + 2; }
                if (i == 100 || tamp == 100) { hece = hece + 1; }
                if (i == 1000 || tamp == 1000) { hece = hece + 1; }


                i = i * 10;
                x = i;
                tamp = tamp / 10;

            }

            return hece;
        }

        int harfSay(String a)
        {
            string cumle = a;
            char[] sesliHarf = { 'a', 'e', 'ı', 'i', 'o', 'ö', 'u', 'ü' };
            int i, say = 0;



            foreach (char harf in cumle)
            {
                for (i = 0; i < 8; i++)
                {
                    if (harf == sesliHarf[i]) { say++; }
                }
            }
            return say;
        }

        int kelimeSay(String a)
        {
            String cumle = a;
            Char[] ayrac = { ' ', ',', ';', '.', ':', '?', '!' };
            int say = 0;

            for (int i = 0; i < cumle.Length; i++)
            {
                for (int j = 0; j < ayrac.GetLength(0); j++)
                {
                    if (cumle[i] == ayrac[j]) { say++; }
                }
            }


            return say;
        }  

        int kontrol(String a)
        {
            String kelime = a;
            foreach(char c in a)
            {
                if (char.IsNumber(c)) { rakamCevir(a); return sayiHece(a);  } //3.deneme
                
            }
            return harfSay(a);


            //if (String.IsNullOrEmpty(kelime) == true)
            //{
            //    return harfSay(a);
            //}
            //else                                                      2. deneme
            //{
            //    rakamCevir(a);
            //    return sayiHece(a);
            //}

            //int x = 0;
            //char[] rakam = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };            
            //for (int i = 0; i < kelime.Length; i++)
            //{
            //    for (int j = 0; j < 10; j++)                        1.deneme
            //    {
            //        if (kelime[i] == rakam[i]) { x = sayiHece(a); rakamCevir(a); }
            //        else { x = harfSay(a); }
            //    }
            //}
            //return x;
        }

        void rakamCevir(string a)
        {
            int tamp = Convert.ToInt32(a);
            string yeni = "";
            int i = 1, x = 0;

            while (tamp > 0)
            {
                int tamp1 = tamp * i;
                if (i == 100 || tamp == 100) { yeni = " yüz" + yeni; }
                if (i == 1000 || tamp == 1000) { yeni = " bin" + yeni; }
                if ((tamp1 % 10 == 1 || tamp % 10 == 1) && i != x) { yeni = " bir" + yeni; }
                if ((tamp1 % 10 == 2 || tamp % 10 == 2) && i != 10) { yeni = " iki" + yeni; }
                if ((tamp1 % 10 == 3 || tamp % 10 == 3) && i != 10) { yeni = " üç" + yeni; }
                if ((tamp1 % 10 == 4 || tamp % 10 == 4) && i != 10) { yeni = " dört" + yeni; }
                if ((tamp1 % 10 == 5 || tamp % 10 == 5) && i != 10) { yeni = " beş" + yeni; }
                if ((tamp1 % 10 == 6 || tamp % 10 == 6) && i != 10) { yeni = " altı" + yeni; }
                if ((tamp1 % 10 == 7 || tamp % 10 == 7) && i != 10) { yeni = " yedi" + yeni; }
                if ((tamp1 % 10 == 8 || tamp % 10 == 8) && i != 10) { yeni = " sekiz" + yeni; }
                if ((tamp1 % 10 == 9 || tamp % 10 == 9) && i != 10) { yeni = " dokuz" + yeni; }
                if ((tamp % 10) * i == 10) { yeni = " on" + yeni; }
                if ((tamp % 10) * i == 20) { yeni = " yirmi" + yeni; }
                if ((tamp % 10) * i == 30) { yeni = " otuz" + yeni; }
                if ((tamp % 10) * i == 40) { yeni = " kırk" + yeni; }
                if ((tamp % 10) * i == 50) { yeni = " elli" + yeni; }
                if ((tamp % 10) * i == 60) { yeni = " altmış" + yeni; }
                if ((tamp % 10) * i == 70) { yeni = " yetmiş" + yeni; }
                if ((tamp % 10) * i == 80) { yeni = " seksen" + yeni; }
                if ((tamp % 10) * i == 90) { yeni = " doksan" + yeni; }


                i = i * 10;
                x = i;
                tamp = tamp / 10;
            }
            label6.Text +=" /"+ yeni;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String cumle = textBox1.Text;

            String[] kelime = cumle.Split(' ', ',', ';', '.', ':', '?', '!');
            int a = 0;

            for (int i = 0; i <= kelime.Length - 1; i++)
            {

                a = a + kontrol(kelime[i]);
            }

            label2.Text = kelimeSay(textBox1.Text).ToString();
            label3.Text = a.ToString();
        }
       


    }
}
