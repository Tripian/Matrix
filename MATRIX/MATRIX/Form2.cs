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
        int satir, sutun;
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
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

            float[,] tempMatris = new float[Matris.GetLength(0), Matris.GetLength(1)];
            for (int x = 0; x < Matris.GetLength(0); x++)
            {
                for (int y = 0; y < Matris.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matris[x, y].Text, out n);
                    tempMatris[x, y] = n;
                }
            }

            

        }
     
    }
}
