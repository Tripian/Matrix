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
        public TextBox[,] Matris;
        public TextBox[,] Matris1;
        public TextBox[,] Matris2;
        public TextBox[,] Matris3;
        //private TextBox[,] Matris4;
        int satir, sutun;
        double rastgeleSayi1,rastgeleSayi2;
        string rastgele;
        Random rnd = new Random();

        public double determinant(double[,] tempMatris2,int size)
        {
            double s = 1, det = 0;
            size = tempMatris2.GetLength(0);
            double[,] minorMatris = new double[tempMatris2.GetLength(0),tempMatris2.GetLength(1)];
            int m, c;
            if (size == 1)
            {
                det = (tempMatris2[0, 0]);

            }
            else
            {
                det = 0;
                for (c = 0; c < size; c++)
                {
                    m = 0;
                    int n = 0;
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            minorMatris[i, j] = 0;
                            if (i != 0 && j != c)
                            {
                                minorMatris[m, n] = minorMatris[i, j];
                                if (n < (size - 2))
                                    n++;
                                else
                                {
                                    n = 0;
                                    m++;
                                }
                            }
                        }
                    }
                    det = det + s * (tempMatris2[0, c] * determinant(minorMatris, size - 1));
                    s = -1 * s;
                }
            }
            return (det);
        }

        public void kofaktor(double[,] tempMatris2, int size)
        {
            
            double[,] m_kofaktor = new double[size, size]; 
            double[,] matris_kofaktor = new double[size, size];
            int p, q, m, n, i, j;
            for (q=0;q<size;q++)
            {
                for (p=0;p<size;p++)
                {
                    m=0;
                    n=0;
                    for (i=0;i<size;i++)
                    {
                        for (j=0;j<size;j++)
                        {
                            if (i != q && j != p)
                            {
                                m_kofaktor[m,n]= tempMatris2[i,j];
                                if (n<(size-2))
                                    n++;
                                else
                                {
                                    n=0;
                                    m++;
                                }
                            }
                        }
                    }                       
                    matris_kofaktor[q,p]=Math.Pow(-1, q + p) * determinant(m_kofaktor, size-1);
                 }
               }
            transpoz(tempMatris2, matris_kofaktor, size);
        }

        public void transpoz(double[,] tempMatris2, double[,] matris_kofaktor, int size)
        {
            int i, j;
            double[,] m_transpoz = new double[size, size];
            double[,] m_ters = new double[size, size];
            double d;

            for (i=0;i<size;i++)
            {
                for (j=0;j<size;j++)
                {
                    m_transpoz[i,j]= matris_kofaktor[j,i];
                }
            }
            d=determinant(tempMatris2, size);
            for (i=0;i<size;i++)
            {
                for (j=0;j<size;j++)
                {
                        m_ters[i,j]=m_transpoz[i,j] / d;
                }
            }
            //printf("\n\n\t* * * * * * * * * * * * * * * * * * * * * * * \n\n\tThe inverse of matrix is : \n\n");

            /*for (i=0;i<size;i++)
            {
                for (j=0;j<size;j++)
                {
                    printf("\t%3.2f", m_inverse[i][j]);
                }
                printf("\n\n");
            }*/
            /*int boyut3 = groupBox4.Width / m_ters.GetLength(1);
            Matris3 = new TextBox[m_ters.GetLength(0), m_ters.GetLength(1)];
            groupBox4.Controls.Clear();
            for (int x = 0; x < Matris3.GetLength(0); x++)
            {
                for (int y = 0; y < Matris3.GetLength(1); y++)
                {
                    Matris3[x, y] = new TextBox();
                    Matris3[x, y].Text = m_ters[x, y].ToString();
                    Matris3[x, y].Top = (x * Matris3[x, y].Height) + 20;
                    Matris3[x, y].Left = y * boyut3 + 6;
                    Matris3[x, y].Width = boyut3;
                    groupBox4.Controls.Add(Matris3[x, y]);
                }
            }*/
            MessageBox.Show(Convert.ToString(m_ters[0, 0]));
            /*int boyut1 = groupBox2.Width / transpoz.GetLength(1);
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
            }*/

        }


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

            //Determinant Başlangıç

            double[,] tempMatris3 = new double[tempMatris2.GetLength(0), tempMatris2.GetLength(1)];
            double d;

            d = determinant(tempMatris2, tempMatris2.GetLength(0));
            if (d == 0)
            {
                MessageBox.Show("Determinantı yoktur.Çünkü 0 çıkıyor.");
            }
            else
                kofaktor(tempMatris2, tempMatris2.GetLength(0));
           
        }
            
       }

        //MessageBox.Show(Convert.ToString(tempMatris[0, 1]));
        //MessageBox.Show(Convert.ToString(tempMatris1[0, 1]));
        //MessageBox.Show(Convert.ToString(tempMatris2[0, 0]));
    }


