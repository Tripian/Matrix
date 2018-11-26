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
    public partial class Form3 : Form
    {
        private TextBox[,] Matris;
        int satir, sutun;
        double rastgeleSayi1,rastgeleSayi2;
        string rastgele;
        Random rnd = new Random();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            while (satir == sutun)
            {
                satir = rnd.Next(1, 6);
                sutun = rnd.Next(1, 6);
            }

            groupBox1.Controls.Clear();

            Matris = new TextBox[satir, sutun];
            int boyut = groupBox1.Width / sutun;
            for (int x = 0; x < Matris.GetLength(0); x++)
            {
                for (int y = 0; y < Matris.GetLength(1); y++)
                {
                    rastgeleSayi1 = rnd.Next(1, 10);
                    rastgeleSayi2 = rnd.Next(1, 10);
                    rastgele = rastgeleSayi1.ToString() + "," + rastgeleSayi2.ToString();
                    Matris[x, y] = new TextBox();
                    Matris[x, y].Text = rastgele;
                    Matris[x, y].Top = (x * Matris[x, y].Height) + 20;
                    Matris[x, y].Left = y * boyut + 6;
                    Matris[x, y].Width = boyut;
                    groupBox1.Controls.Add(Matris[x, y]);
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
