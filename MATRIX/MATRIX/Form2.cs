using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MATRIX
{
    public partial class Form2 : Form
    {
        private TextBox[,] Matris;
        private TextBox[,] Matris1;
        private TextBox[,] Matris2;
        private TextBox[,] Matris3;
        //private TextBox[,] Matris4;
        float[,] tempMatris;

        int satir, sutun;
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[,] tempMatris = new double[Matris.GetLength(0), Matris.GetLength(1)];
            for (int x = 0; x < Matris.GetLength(0); x++)
            {
                for (int y = 0; y < Matris.GetLength(1); y++)
                {
                    double n = 0;
                    double.TryParse(Matris[x, y].Text, out n);
                    tempMatris[x, y] = n;
                }
            }

            int w = tempMatris.GetLength(0);
            int h = tempMatris.GetLength(1);

            double[,] transpoz = new double[h, w];

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    transpoz[j, i] = tempMatris[i, j];
                }
            }


            int boyut1 = groupBox2.Width / transpoz.GetLength(1);
            Matris1 = new TextBox[transpoz.GetLength(0), transpoz.GetLength(1)];
            groupBox2.Controls.Clear();
            for (int x = 0; x < Matris1.GetLength(0); x++)
            {
                for (int y = 0; y < Matris1.GetLength(1); y++)
                {
                    Matris1[x, y] = new TextBox();
                    Matris1[x, y].Text = transpoz[x, y].ToString();
                    Matris1[x, y].Top = (x * Matris1[x, y].Height) + 20;
                    Matris1[x, y].Left = y * boyut1 + 6;
                    Matris1[x, y].Width = boyut1;
                    groupBox2.Controls.Add(Matris1[x, y]);
                }
            }

            double[,] tempMatris1 = new double[Matris1.GetLength(0), Matris1.GetLength(1)];
            for (int x = 0; x < Matris1.GetLength(0); x++)
            {
                for (int y = 0; y < Matris1.GetLength(1); y++)
                {
                    double n = 0;
                    double.TryParse(Matris1[x, y].Text, out n);
                    tempMatris1[x, y] = n;
                }
            }

            double[,] tempMatris2 = new double[Matris.GetLength(0), Matris1.GetLength(1)];
            for (int i = 0; i < Matris.GetLength(0); i++)
            {
                for (int j = 0; j < Matris1.GetLength(1); j++)
                {
                    tempMatris2[i, j] = 0;
                    for (int k = 0; k < 2; k++)
                    {
                        tempMatris2[i, j] += tempMatris[i, k] * tempMatris1[k, j];
                    }
                }
            }

            int boyut2 = groupBox3.Width / tempMatris2.GetLength(1);
            Matris2 = new TextBox[tempMatris2.GetLength(0), tempMatris2.GetLength(1)];
            groupBox3.Controls.Clear();
            for (int x = 0; x < Matris2.GetLength(0); x++)
            {
                for (int y = 0; y < Matris2.GetLength(1); y++)
                {
                    Matris2[x, y] = new TextBox();
                    Matris2[x, y].Text = tempMatris2[x, y].ToString();
                    Matris2[x, y].Top = (x * Matris2[x, y].Height) + 20;
                    Matris2[x, y].Left = y * boyut2 + 6;
                    Matris2[x, y].Width = boyut2;
                    groupBox3.Controls.Add(Matris2[x, y]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="" || textBox2.Text == "")
            {
                MessageBox.Show("LÜTFEN BOŞ BIRAKMAYINIZ.");
            }
            else if (textBox1.Text == textBox2.Text)
            {
                MessageBox.Show("FARKLI RAKAMLAR GİRİNİZ.");
                textBox1.Clear();
                textBox2.Clear();
            }
            else if (int.Parse(textBox1.Text)<1 || int.Parse(textBox2.Text)<1 || int.Parse(textBox1.Text)>5 || int.Parse(textBox2.Text) > 5)
            {
                MessageBox.Show("1-5 ARASINDA SAYILAR GİRİNİZ.");
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                satir = int.Parse(textBox1.Text);
                sutun = int.Parse(textBox2.Text);

                groupBox1.Controls.Clear();

                Matris = new TextBox[satir, sutun];
                int boyut = groupBox1.Width / sutun;
                for (int x = 0; x < Matris.GetLength(0); x++)
                {
                    for (int y = 0; y < Matris.GetLength(1); y++)
                    {
                        Matris[x, y] = new TextBox();
                        Matris[x, y].Text = "0";
                        Matris[x, y].Top = (x * Matris[x, y].Height) + 20;
                        Matris[x, y].Left = y * boyut + 6;
                        Matris[x, y].Width = boyut;
                        groupBox1.Controls.Add(Matris[x, y]);
                    }
                }  
            }

            tempMatris = new float[Matris.GetLength(0), Matris.GetLength(1)];
            for (int x = 0; x < Matris.GetLength(0); x++)
            {
                for (int y = 0; y < Matris.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matris[x, y].Text, out n);
                    tempMatris[x, y] = n;
                }
            }
            //MessageBox.Show(Convert.ToString(tempMatris[0, 1]));


        }
     
    }
}
