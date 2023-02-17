using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ComputerVision
{
    public partial class MainForm : Form
    {
        private string sSourceFileName = "";
        private FastImage workImage;
        private FastImage originalImage;
        private FastImage workImage2;
        private Bitmap image = null;
        private Bitmap image2 = null;
        private const int maxValue = 255;
        private int teta;

        public MainForm()
        {
            InitializeComponent();
        }
        int Normalizare(int x)
        {
            if (x > 255)
                return 255;
            else if (x < 0)
                return 0;
            else
                return x;
        }
        double SumaQ(double x, double y)
        {
            double u = 0;
            if (y == 0)
            {
                if (x >= 0)
                {
                    u = Math.PI / 2;
                }
                else if (x < 0)
                {
                    u = -Math.PI / 2;
                }
            }
            else
            {
                u = Math.Atan(x / y);

                if (x < 0)
                {
                    u = u + Math.PI;
                }
            }
            return u;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            sSourceFileName = openFileDialog.FileName;
            panelSource.BackgroundImage = new Bitmap(sSourceFileName);
            panelDestination.BackgroundImage = new Bitmap(sSourceFileName);
            image = new Bitmap(sSourceFileName);


            workImage = new FastImage(image);
            image2 = new Bitmap(workImage.Width, workImage.Height);
            workImage2 = new FastImage(image2);
        }

        private void buttonGrayscale_Click(object sender, EventArgs e)
        {
            Color color;

            workImage.Lock();
            for (int i = 0; i < workImage.Width; i++)
            {
                for (int j = 0; j < workImage.Height; j++)
                {
                    color = workImage.GetPixel(i, j);
                    byte R = color.R;
                    byte G = color.G;
                    byte B = color.B;

                    byte average = (byte)((R + G + B) / 3);

                    color = Color.FromArgb(average, average, average);

                    workImage.SetPixel(i, j, color);
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage.GetBitMap();
            workImage.Unlock();

        }

        private void buttonNegative_Click(object sender, EventArgs e)
        {
            Color color;

            workImage.Lock();
            for (int i = 0; i < workImage.Width; i++)
            {
                for (int j = 0; j < workImage.Height; j++)
                {
                    color = workImage.GetPixel(i, j);
                    byte R = color.R;
                    byte G = color.G;
                    byte B = color.B;

                    byte RNegative = (byte)(maxValue - R);
                    byte GNegative = (byte)(maxValue - G);
                    byte BNegative = (byte)(maxValue - B);

                    color = Color.FromArgb(RNegative, GNegative, BNegative);

                    workImage.SetPixel(i, j, color);
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage.GetBitMap();
            workImage.Unlock();
        }

        private void trackBarLuminosity_ValueChanged(object sender, EventArgs e)
        {
            var delta = trackBarLuminosity.Value;
            panelDestination.BackgroundImage = new Bitmap(sSourceFileName);
            image = new Bitmap(sSourceFileName);
            workImage = new FastImage(image);
            Color color;

            workImage.Lock();
            for (int i = 0; i < workImage.Width; i++)
            {
                for (int j = 0; j < workImage.Height; j++)
                {
                    color = workImage.GetPixel(i, j);
                    byte R = color.R;
                    byte G = color.G;
                    byte B = color.B;

                    R = workImage.ChangeLuminosity(R, delta);
                    G = workImage.ChangeLuminosity(G, delta);
                    B = workImage.ChangeLuminosity(B, delta);

                    color = Color.FromArgb(R, G, B);

                    workImage.SetPixel(i, j, color);
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage.GetBitMap();
            workImage.Unlock();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonHistograma_Click(object sender, EventArgs e)
        {
            int[] hist = new int[256];
            int[] histc = new int[256];
            int[] transf = new int[256];
            image = new Bitmap(sSourceFileName);
            workImage = new FastImage(image);
            Color color;
            workImage.Lock();
            for (int i = 0; i < workImage.Width; i++)
            {
                for (int j = 0; j < workImage.Height; j++)
                {
                    color = workImage.GetPixel(i, j);
                    byte R = color.R;
                    byte G = color.G;
                    byte B = color.B;
                    byte average = (byte)((R + G + B) / 3);
                    hist[average] = hist[average] + 1;
                }
            }
            histc[0] = hist[0];
            for (int i = 1; i < 255; i++)
            {
                histc[i] = histc[i - 1] + hist[i];
            }
            for (int i = 0; i < 255; i++)
            {
                transf[i] = (histc[i] * 255) / (workImage.Width * workImage.Height);
            }
            for (int i = 0; i < workImage.Width; i++)
            {
                for (int j = 0; j < workImage.Height; j++)
                {
                    color = workImage.GetPixel(i, j);
                    byte R = color.R;
                    byte G = color.G;
                    byte B = color.B;
                    byte average = (byte)((R + G + B) / 3);
                    color = Color.FromArgb(transf[average], transf[average], transf[average]);

                    workImage.SetPixel(i, j, color);
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage.GetBitMap();
            workImage.Unlock();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonReflexie_Click(object sender, EventArgs e)
        {
            panelDestination.BackgroundImage = new Bitmap(sSourceFileName);
            Color color;
            workImage = new FastImage(image2);
            workImage.Lock();
            originalImage.Lock();
            int x2, y2;
            int x0 = (originalImage.Width / 2);
            int y0 = (originalImage.Height / 2);
            double delta;
            for (int x1 = 0; x1 < workImage.Width; x1++)
            {
                for (int y1 = 0; y1 < workImage.Height; y1++)
                {
                    if (comboBoxReflection.Text.Equals("Orizontal"))
                    {
                        color = originalImage.GetPixel(x1, y1);
                        y2 = -y1 + (2 * y0);
                        workImage.SetPixel(y2, x1, color);
                    }
                    else if (comboBoxReflection.Text.Equals("Vertical"))
                    {
                        color = originalImage.GetPixel(x1, y1);
                        x2 = -x1 + (2 * x0);
                        workImage.SetPixel(x2, y1, color);
                    }
                    else if (comboBoxReflection.Text.Equals("Arbitrar"))
                    {
                        color = originalImage.GetPixel(x1, y1);
                        delta = (x1 - x0) * Math.Sin(teta) - (y1 - y0) * Math.Cos(teta);
                        x2 = x1 - 2 * (int)delta * (int)Math.Sin(teta);
                        y2 = y1 - 2 * (int)delta * (int)Math.Cos(teta);
                        workImage.SetPixel(x2, y2, color);
                    }
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage.GetBitMap();
            workImage.Unlock();
            originalImage.Unlock();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonFTJ_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBoxFTJ.Text.ToString());
            int[,] H = new int[3, 3] { { 1, n, 1 }, { n, (n * n), n }, { 1, n, 1 } };
            double Srosu;
            double Sverde;
            double Salbastru;
            Color color;
            workImage.Lock();
            for (int r = 1; r < (workImage.Width) - 2; r++)
            {
                for (int c = 1; c < (workImage.Height) - 2; c++)
                {
                    Srosu = 0;
                    Sverde = 0;
                    Salbastru = 0;
                    for (int row = r - 1; row <= r + 1; row++)
                    {
                        for (int col = c - 1; col <= c + 1; col++)
                        {
                            color = workImage.GetPixel(row, col);
                            int R = color.R;
                            int G = color.G;
                            int B = color.B;
                            Srosu = Srosu + R * H[row - r + 1, col - c + 1];
                            Sverde = Sverde + G * H[row - r + 1, col - c + 1];
                            Salbastru = Salbastru + B * H[row - r + 1, col - c + 1];
                        }
                    }
                    Srosu = Srosu / Math.Pow((n + 2), 2);
                    Sverde = Sverde / Math.Pow((n + 2), 2);
                    Salbastru = Salbastru / Math.Pow((n + 2), 2);
                    color = Color.FromArgb((int)Srosu, (int)Sverde, (int)Salbastru);
                    workImage.SetPixel(r, c, color);
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage.GetBitMap();
            workImage.Unlock();
        }

        private void buttonIntensitate_Click(object sender, EventArgs e)
        {
            Color color;
            List<int> ListaRosu = new List<int>();
            List<int> ListaVerde = new List<int>();
            List<int> ListaAlbastru = new List<int>();
            workImage.Lock();
            for (int i = 1; i < workImage.Width - 1; i++)
            {
                for (int j = 1; j < workImage.Height - 1; j++)
                {
                    for (int r = i - 1; r <= i + 1; r++)
                    {
                        for (int c = j - 1; c <= j + 1; c++)
                        {
                            color = workImage.GetPixel(r, c);
                            int R = color.R;
                            int G = color.G;
                            int B = color.B;

                            ListaRosu.Add(R);
                            ListaVerde.Add(G);
                            ListaAlbastru.Add(B);
                        }
                    }
                    ListaRosu.Sort();
                    ListaVerde.Sort();
                    ListaAlbastru.Sort();
                    color = Color.FromArgb(ListaRosu[4], ListaVerde[4], ListaAlbastru[4]);
                    ListaRosu.Clear();
                    ListaVerde.Clear();
                    ListaAlbastru.Clear();
                    workImage.SetPixel(i, j, color);
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage.GetBitMap();
            workImage.Unlock();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public bool Salt_Pepper(int x, int y)
        {
            Color color;
            bool negruSauAlb = false;
            for (int i = 1; i < workImage.Width - 1; i++)
            {
                for (int j = 1; j < workImage.Height - 1; j++)
                {
                    color = workImage.GetPixel(i, j);
                    byte R = color.R;
                    byte G = color.G;
                    byte B = color.B;
                    byte average = (byte)((R + G + B) / 3);
                    if (average == 0 || average == 255)
                    {
                        negruSauAlb = true;
                    }
                    else
                    {
                        negruSauAlb = false;
                    }
                }
            }
            return negruSauAlb;
        }
        public void CBPF(int CS, int SR, int T)
        {
            for (int i = 1; i < workImage.Width - 1; i++)
            {
                for (int j = 1; j < workImage.Height - 1; j++)
                {
                    if (Salt_Pepper(i, j))
                    {
                        workImage.SetPixel(i, j, CBP(i, j, CS, SR, T));
                    }
                }
            }
        }

        public Color CBP(int x, int y, int CS, int SR, int T)
        {
            Color color;
            int[] Q = new int[256];
            for (int i = x - SR; i < x + SR; i++)
            {
                for (int j = y - SR; i < y + SR; j++)
                {
                    if (i >= 0 && i < workImage.Width && j >= 0 && j < workImage.Height)
                    {

                        if (i == x && j == y)
                        {
                            continue;
                        }
                        if (SAD(x, y, i, j, CS) < T && !Salt_Pepper(i, j))
                        {
                            color = workImage.GetPixel(i, j);
                            int R = color.R;
                            int G = color.G;
                            int B = color.B;
                            int average = (R + G + B) / 3;
                            Q[average] = Q[average] + 1;
                        }
                    }
                }
            }
            int max = Q[0];
            int pozitieMaxim = 0;
            for (int k = 0; k < Q.Length; k++)
            {
                if (Q[k] > max)
                {
                    max = Q[k];
                    pozitieMaxim = k;
                }
            }
            color = Color.FromArgb((byte)pozitieMaxim, (byte)pozitieMaxim, (byte)pozitieMaxim);

            return color;
        }

        public int SAD(int x1, int y1, int x2, int y2, int CS)
        {
            Color color1, color2;
            int S = 0;
            for (int i = -CS / 2; i < CS / 2; i++)
            {
                for (int j = -CS / 2; j < CS / 2; j++)
                {
                    if (i + x1 >= 0 && i + x1 < workImage.Width && i + x2 >= 0 && i + x2 < workImage.Width)
                    {
                        if (i == 0 && j == 0)
                        {
                            continue;
                        }
                        color1 = workImage.GetPixel(i + x1, j + y1);
                        color2 = workImage.GetPixel(i + x2, j + y2);
                        int R1 = color1.R;
                        int G1 = color1.G;
                        int B1 = color1.B;
                        int R2 = color2.R;
                        int G2 = color2.G;
                        int B2 = color2.B;
                        int average1 = (R1 + G1 + B1) / 3;
                        int average2 = (R2 + G2 + B2) / 3;
                        S = S + Math.Abs(average1 - average2);
                    }
                }
            }
            return S;
        }
        private void buttonMarkov_Click(object sender, EventArgs e)
        {
            workImage.Lock();
            int CS = 3;
            int SR = 4;
            int T = 500;
            CBPF(CS, SR, T);
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage.GetBitMap();
            workImage.Unlock();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[,] H = new int[3, 3] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } };
            Color color;
            workImage.Lock();
            workImage2.Lock();
            int SumaRosu;
            int SumaAlbastru;
            int SumaVerde;
            for (int i = 1; i < (workImage.Width) - 2; i++)
            {
                for (int j = 1; j < (workImage.Height) - 2; j++)
                {
                    SumaRosu = 0;
                    SumaAlbastru = 0;
                    SumaVerde = 0;
                    for (int r = i - 1; r <= i + 1; r++)
                    {
                        for (int c = j - 1; c <= j + 1; c++)
                        {
                            color = workImage.GetPixel(r, c);
                            int R = color.R;
                            int B = color.B;
                            int G = color.G;

                            SumaRosu = SumaRosu + R * H[r - i + 1, c - j + 1];
                            SumaAlbastru = SumaAlbastru + B * H[r - j + 1, c - i + 1];
                            SumaVerde = SumaVerde + G * H[r - j + 1, c - i + 1];
                            if (SumaRosu < 0)
                            {
                                SumaRosu = 0;
                            }
                            if (SumaRosu > 255)
                            {
                                SumaRosu = 255;
                            }
                            if (SumaAlbastru < 0)
                            {
                                SumaAlbastru = 0;
                            }
                            if (SumaAlbastru > 255)
                            {
                                SumaAlbastru = 255;
                            }
                            if (SumaVerde < 0)
                            {
                                SumaVerde = 0;
                            }
                            if (SumaVerde > 255)
                            {
                                SumaVerde = 255;
                            }
                        }
                    }
                    color = Color.FromArgb((int)SumaRosu, (int)SumaVerde, (int)SumaAlbastru);
                    workImage2.SetPixel(i, j, color);
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage2.GetBitMap();
            workImage.Unlock();
            workImage2.Unlock();
        }

        private void buttonFTS_Click(object sender, EventArgs e)
        {
            int[,] H = new int[3, 3] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } };
            Color color;
            workImage.Lock();
            workImage2.Lock();
            int SumaRosu;
            int SumaAlbastru;
            int SumaVerde;
            for (int i = 1; i < (workImage.Width) - 2; i++)
            {
                for (int j = 1; j < (workImage.Height) - 2; j++)
                {
                    SumaRosu = 0;
                    SumaAlbastru = 0;
                    SumaVerde = 0;
                    for (int r = i - 1; r <= i + 1; r++)
                    {
                        for (int c = j - 1; c <= j + 1; c++)
                        {
                            color = workImage.GetPixel(r, c);
                            int R = color.R;
                            int G = color.G;
                            int B = color.B;

                            SumaRosu = SumaRosu + R * H[r - i + 1, c - j + 1];
                            SumaVerde = SumaVerde + G * H[r - i + 1, c - j + 1];
                            SumaAlbastru = SumaAlbastru + B * H[r - i + 1, c - j + 1];
                        }
                    }
                    if (SumaRosu < 0)
                    {
                        SumaRosu = 0;
                    }
                    if (SumaRosu > 255)
                    {
                        SumaRosu = 255;
                    }
                    if (SumaAlbastru < 0)
                    {
                        SumaAlbastru = 0;
                    }
                    if (SumaAlbastru > 255)
                    {
                        SumaAlbastru = 255;
                    }
                    if (SumaVerde < 0)
                    {
                        SumaVerde = 0;
                    }
                    if (SumaVerde > 255)
                    {
                        SumaVerde = 255;
                    }
                    color = Color.FromArgb((int)SumaRosu, (int)SumaVerde, (int)SumaAlbastru);
                    workImage2.SetPixel(i, j, color);
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage2.GetBitMap();
            workImage.Unlock();
            workImage2.Unlock();
        }

        private void buttonUnsharp_Click(object sender, EventArgs e)
        {
            Color color, color1;

            workImage.Lock();
            workImage2.Lock();
            int sr, sg, sb, gr, gg, gb;
            double cr = 0.6;
            int n = 1;
            int[,] H = { { 1, -2, 1 }, { -2, 5, -2 }, { 1, -2, 1 } };

            for (int i = 1; i <= workImage.Width - 2; i++)
            {
                for (int j = 1; j <= workImage.Height - 2; j++)
                {
                    color = workImage2.GetPixel(i, j);
                    sr = 0;
                    sg = 0;
                    sb = 0;
                    for (int r = i - 1; r <= i + 1; r++)
                    {
                        for (int c = j - 1; c <= j + 1; c++)
                        {
                            color1 = workImage2.GetPixel(r, c);
                            byte R = color1.R;
                            byte G = color1.G;
                            byte B = color1.B;
                            sr += R * H[r - i + 1, c - j + 1];
                            sg += G * H[r - i + 1, c - j + 1];
                            sb += B * H[r - i + 1, c - j + 1];
                        }
                    }
                    sb = sb / ((n + 2) * (n + 2));
                    sr = sr / ((n + 2) * (n + 2));
                    sg = sg / ((n + 2) * (n + 2));

                    gr = (int)(cr / (2 * cr - 1) * color.R - (1 - cr) / (2 * cr - 1) * sr);
                    gg = (int)(cr / (2 * cr - 1) * color.G - (1 - cr) / (2 * cr - 1) * sg);
                    gb = (int)(cr / (2 * cr - 1) * color.B - (1 - cr) / (2 * cr - 1) * sb);
                    if (gr < 0)
                        gr = 0;
                    if (gr > 255)
                        gr = 255;
                    if (gg < 0)
                        gg = 0;
                    if (gg > 255)
                        gg = 255;
                    if (gb < 0)
                        gb = 0;
                    if (gb > 255)
                    {
                        gb = 255;
                    }
                    color = Color.FromArgb(gr, gg, gb);
                    workImage.SetPixel(i, j, color);
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage2.GetBitMap();
            workImage.Unlock();
            workImage2.Unlock();


        }

        private void buttonKirsch_Click(object sender, EventArgs e)
        {
            int[,] H1 = new int[3, 3] { { -1, 0, 1 }, { -1, 0, 1 }, { -1, 0, 1 } };
            int[,] H2 = new int[3, 3] { { 1, 1, 1 }, { 0, 0, 0 }, { -1, -1, -1 } };
            int[,] H3 = new int[3, 3] { { 0, 1, 1 }, { -1, 0, 1 }, { -1, -1, 0 } };
            int[,] H4 = new int[3, 3] { { 1, 1, 0 }, { 1, 0, -1 }, { 0, -1, -1 } };
            Color color;
            workImage.Lock();
            workImage2.Lock();
            int SumaRosuH1, SumaRosuH2, SumaRosuH3, SumaRosuH4;
            int SumaVerdeH1, SumaVerdeH2, SumaVerdeH3, SumaVerdeH4;
            int SumaAlbastruH1, SumaAlbastruH2, SumaAlbastruH3, SumaAlbastruH4;
            int SumaRosu = 0, SumaAlbastru = 0, SumaVerde = 0;
            for (int i = 1; i < (workImage.Width) - 2; i++)
            {
                for (int j = 1; j < (workImage.Height) - 2; j++)
                {
                    SumaRosuH1 = 0;
                    SumaRosuH2 = 0;
                    SumaRosuH3 = 0;
                    SumaRosuH4 = 0;
                    SumaVerdeH1 = 0;
                    SumaVerdeH2 = 0;
                    SumaVerdeH3 = 0;
                    SumaVerdeH4 = 0;
                    SumaAlbastruH1 = 0;
                    SumaAlbastruH2 = 0;
                    SumaAlbastruH3 = 0;
                    SumaAlbastruH4 = 0;
                    for (int r = i - 1; r <= i + 1; r++)
                    {
                        for (int c = j - 1; c <= j + 1; c++)
                        {
                            color = workImage.GetPixel(r, c);
                            int R = color.R;
                            int G = color.G;
                            int B = color.B;

                            SumaRosuH1 = SumaRosuH1 + R * H1[r - i + 1, c - j + 1];
                            SumaRosuH2 = SumaRosuH2 + R * H2[r - i + 1, c - j + 1];
                            SumaRosuH3 = SumaRosuH3 + R * H3[r - i + 1, c - j + 1];
                            SumaRosuH4 = SumaRosuH4 + R * H4[r - i + 1, c - j + 1];
                            SumaAlbastruH1 = SumaAlbastruH1 + B * H1[r - i + 1, c - j + 1];
                            SumaAlbastruH2 = SumaAlbastruH2 + B * H2[r - i + 1, c - j + 1];
                            SumaAlbastruH3 = SumaAlbastruH3 + B * H3[r - i + 1, c - j + 1];
                            SumaAlbastruH4 = SumaAlbastruH4 + B * H4[r - i + 1, c - j + 1];
                            SumaVerdeH1 = SumaVerdeH1 + G * H1[r - i + 1, c - j + 1];
                            SumaVerdeH2 = SumaVerdeH2 + G * H2[r - i + 1, c - j + 1];
                            SumaVerdeH3 = SumaVerdeH3 + G * H3[r - i + 1, c - j + 1];
                            SumaVerdeH4 = SumaVerdeH4 + G * H4[r - i + 1, c - j + 1];
                        }
                    }
                    SumaRosu = Math.Max(Math.Max(SumaRosuH1, SumaRosuH2), Math.Max(SumaRosuH3, SumaRosuH4));
                    SumaAlbastru = Math.Max(Math.Max(SumaAlbastruH1, SumaAlbastruH2), Math.Max(SumaAlbastruH3, SumaAlbastruH4));
                    SumaVerde = Math.Max(Math.Max(SumaVerdeH1, SumaVerdeH2), Math.Max(SumaVerdeH3, SumaVerdeH4));
                    SumaRosu = Normalizare(SumaRosu);
                    SumaAlbastru = Normalizare(SumaAlbastru);
                    SumaVerde = Normalizare(SumaVerde);
                    color = Color.FromArgb((int)SumaRosu, (int)SumaVerde, (int)SumaAlbastru);
                    workImage2.SetPixel(i, j, color);
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage2.GetBitMap();
            workImage.Unlock();
            workImage2.Unlock();
        }

        private void buttonPrewitt_Click(object sender, EventArgs e)
        {
            int[,] P = new int[3, 3] { { -1, -1, -1 }, { 0, 0, 0 }, { 1, 1, 1 } };
            int[,] Q = new int[3, 3] { { -1, 0, 1 }, { -1, 0, 1 }, { -1, 0, 1 } };
            Color color;
            workImage.Lock();
            workImage2.Lock();
            int SumaRosuP, SumaVerdeP, SumaAlbastruP;
            int SumaRosuQ, SumaVerdeQ, SumaAlbastruQ;
            double rR, rG, rB;
            for (int i = 1; i < (workImage.Width) - 2; i++)
            {
                for (int j = 1; j < (workImage.Height) - 2; j++)
                {
                    SumaRosuP = 0;
                    SumaVerdeP = 0;
                    SumaAlbastruP = 0;
                    SumaRosuQ = 0;
                    SumaVerdeQ = 0;
                    SumaAlbastruQ = 0;
                    for (int r = i - 1; r <= i + 1; r++)
                    {
                        for (int c = j - 1; c <= j + 1; c++)
                        {
                            color = workImage.GetPixel(r, c);
                            int R = color.R;
                            int G = color.G;
                            int B = color.B;
                            SumaRosuP = SumaRosuP + R * P[r - i + 1, c - j + 1];
                            SumaAlbastruP = SumaAlbastruP + B * P[r - i + 1, c - j + 1];
                            SumaVerdeP = SumaVerdeP + G * P[r - i + 1, c - j + 1];
                            SumaRosuQ = SumaRosuQ + R * Q[r - i + 1, c - j + 1];
                            SumaAlbastruQ = SumaAlbastruQ + B * Q[r - i + 1, c - j + 1];
                            SumaVerdeQ = SumaVerdeQ + G * Q[r - i + 1, c - j + 1];
                        }
                    }
                    rR = Math.Sqrt(SumaRosuP * SumaRosuP + SumaRosuQ * SumaRosuQ);
                    rG = Math.Sqrt(SumaVerdeP * SumaVerdeP + SumaVerdeQ * SumaVerdeQ);
                    rB = Math.Sqrt(SumaAlbastruP * SumaAlbastruP + SumaAlbastruQ * SumaAlbastruQ);
                    rR = Normalizare((int)rR);
                    rG = Normalizare((int)rG);
                    rB = Normalizare((int)rB);
                    color = Color.FromArgb((int)rR, (int)rG, (int)rB);
                    workImage2.SetPixel(i, j, color);
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage2.GetBitMap();
            workImage.Unlock();
            workImage2.Unlock();
        }

        private void buttonFreiChen_Click(object sender, EventArgs e)
        {
            double[,] F1 = new double[3, 3] { { 1, Math.Sqrt(2), 1 }, { 0, 0, 0 }, { -1, -Math.Sqrt(2), -1 } };
            double[,] F2 = new double[3, 3] { { 1, 0, -1 }, { Math.Sqrt(2), 0, -Math.Sqrt(2) }, { 1, 0, -1 } };
            double[,] F3 = new double[3, 3] { { 0, -1, Math.Sqrt(2) }, { 1, 0, -1 }, { -Math.Sqrt(2), 1, 0 } };
            double[,] F4 = new double[3, 3] { { Math.Sqrt(2), -1, 0 }, { -1, 0, 1 }, { 0, 1, -Math.Sqrt(2) } };
            double[,] F5 = new double[3, 3] { { 0, 1, 0 }, { -1, 0, -1 }, { 0, 1, 0 } };
            double[,] F6 = new double[3, 3] { { -1, 0, 1 }, { 0, 0, 0 }, { 1, 0, -1 } };
            double[,] F7 = new double[3, 3] { { 1, -2, 1 }, { -2, 4, -2 }, { 1, -2, 1 } };
            double[,] F8 = new double[3, 3] { { -2, 1, -2 }, { 1, 4, 1 }, { -2, 1, -2 } };
            double[,] F9 = new double[3, 3] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
            Color color;
            workImage.Lock();
            workImage2.Lock();
            double sumaF1R, sumaF2R, sumaF3R, sumaF4R, sumaF5R, sumaF6R, sumaF7R, sumaF8R, sumaF9R;
            double sumaF1G, sumaF2G, sumaF3G, sumaF4G, sumaF5G, sumaF6G, sumaF7G, sumaF8G, sumaF9G;
            double sumaF1B, sumaF2B, sumaF3B, sumaF4B, sumaF5B, sumaF6B, sumaF7B, sumaF8B, sumaF9B;

            double rR = 0, rG = 0, rB = 0;
            for (int i = 1; i < (workImage.Width) - 2; i++)
            {
                for (int j = 1; j < (workImage.Height) - 2; j++)
                {
                    sumaF1R = 0; sumaF2R = 0; sumaF3R = 0; sumaF4R = 0; sumaF5R = 0; sumaF6R = 0; sumaF7R = 0; sumaF8R = 0; sumaF9R = 0;
                    sumaF1G = 0; sumaF2G = 0; sumaF3G = 0; sumaF4G = 0; sumaF5G = 0; sumaF6G = 0; sumaF7G = 0; sumaF8G = 0; sumaF9G = 0;
                    sumaF1B = 0; sumaF2B = 0; sumaF3B = 0; sumaF4B = 0; sumaF5B = 0; sumaF6B = 0; sumaF7B = 0; sumaF8B = 0; sumaF9B = 0;
                    for (int r = i - 1; r <= i + 1; r++)
                    {
                        for (int c = j - 1; c <= j + 1; c++)
                        {
                            color = workImage.GetPixel(r, c);
                            int R = color.R;
                            int G = color.G;
                            int B = color.B;
                            sumaF1R = sumaF1R + R * F1[r - i + 1, c - j + 1];
                            sumaF2R = sumaF2R + R * F2[r - i + 1, c - j + 1];
                            sumaF3R = sumaF3R + R * F3[r - i + 1, c - j + 1];
                            sumaF4R = sumaF4R + R * F4[r - i + 1, c - j + 1];
                            sumaF5R = sumaF5R + R * F5[r - i + 1, c - j + 1];
                            sumaF6R = sumaF6R + R * F6[r - i + 1, c - j + 1];
                            sumaF7R = sumaF7R + R * F7[r - i + 1, c - j + 1];
                            sumaF8R = sumaF8R + R * F8[r - i + 1, c - j + 1];
                            sumaF9R = sumaF9R + R * F9[r - i + 1, c - j + 1];
                            sumaF1G = sumaF1G + G * F1[r - i + 1, c - j + 1];
                            sumaF2G = sumaF2G + G * F2[r - i + 1, c - j + 1];
                            sumaF3G = sumaF3G + G * F3[r - i + 1, c - j + 1];
                            sumaF4G = sumaF4G + G * F4[r - i + 1, c - j + 1];
                            sumaF5G = sumaF5G + G * F5[r - i + 1, c - j + 1];
                            sumaF6G = sumaF6G + G * F6[r - i + 1, c - j + 1];
                            sumaF7G = sumaF7G + G * F7[r - i + 1, c - j + 1];
                            sumaF8G = sumaF8G + G * F8[r - i + 1, c - j + 1];
                            sumaF9G = sumaF9G + G * F9[r - i + 1, c - j + 1];
                            sumaF1B = sumaF1B + B * F1[r - i + 1, c - j + 1];
                            sumaF2B = sumaF2B + B * F2[r - i + 1, c - j + 1];
                            sumaF3B = sumaF3B + B * F3[r - i + 1, c - j + 1];
                            sumaF4B = sumaF4B + B * F4[r - i + 1, c - j + 1];
                            sumaF5B = sumaF5B + B * F5[r - i + 1, c - j + 1];
                            sumaF6B = sumaF6B + B * F6[r - i + 1, c - j + 1];
                            sumaF7B = sumaF7B + B * F7[r - i + 1, c - j + 1];
                            sumaF8B = sumaF8B + B * F8[r - i + 1, c - j + 1];
                            sumaF9B = sumaF9B + B * F9[r - i + 1, c - j + 1];
                        }
                    }
                    sumaF9R = sumaF9R / 9;
                    sumaF9G = sumaF9G / 9;
                    sumaF9B = sumaF9B / 9;
                    rR = (Math.Sqrt((sumaF1R * sumaF1R + sumaF2R * sumaF2R + sumaF3R * sumaF3R + sumaF4R * sumaF4R) /
                        (sumaF1R * sumaF1R + sumaF2R * sumaF2R + sumaF3R * sumaF3R + sumaF4R * sumaF4R + sumaF5R * sumaF5R +
                        sumaF6R * sumaF6R + sumaF7R * sumaF7R + sumaF8R * sumaF8R + sumaF9R * sumaF9R))) * 255;
                    rG = (Math.Sqrt((sumaF1G * sumaF1G + sumaF2G * sumaF2G + sumaF3G * sumaF3G + sumaF4G * sumaF4G) /
 sumaF2B * sumaF2B + sumaF3B * sumaF3B + sumaF4B * sumaF4B + sumaF5B * sumaF5B + (sumaF1G * sumaF1G + sumaF2G * sumaF2G + sumaF3G * sumaF3G + sumaF4G * sumaF4G + sumaF5G * sumaF5G +
                        sumaF6G * sumaF6G + sumaF7G * sumaF7G + sumaF8G * sumaF8G + sumaF9G * sumaF9G))) * 255;
                    rB = (Math.Sqrt((sumaF1B * sumaF1B + sumaF2B * sumaF2B + sumaF3B * sumaF3B + sumaF4B * sumaF4B) /
                        (sumaF1B * sumaF1B +
                        sumaF6B * sumaF6B + sumaF7B * sumaF7B + sumaF8B * sumaF8B + sumaF9B * sumaF9B))) * 255;
                    rR = Normalizare((int)rR);
                    rG = Normalizare((int)rG);
                    rB = Normalizare((int)rB);
                    color = Color.FromArgb((int)rR, (int)rG, (int)rB);
                    workImage2.SetPixel(i, j, color);
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage2.GetBitMap();
            workImage.Unlock();
            workImage2.Unlock();
        }

        private void buttonGabor_Click(object sender, EventArgs e)
        {
            double[,] P = new double[3, 3] { { 1, 1, 1 }, { 0, 0, 0 }, { -1, -1, -1 } };
            double[,] Q = new double[3, 3] { { -1, 0, 1 }, { -1, 0, 1 }, { -1, 0, 1 } };
            double sumaPR = 0, sumaQR = 0, sumaPG = 0, sumaQG = 0, sumaPB = 0, sumaQB = 0;
            double sumaR = 0, sumaG = 0, sumaB = 0;
            double uR = 0, uG = 0, uB = 0;
            double scaleR = 0, scaleG = 0, scaleB = 0;
            double Sigma = 0.66;
            double Omega = 1.5;
            Color color;
            workImage.Lock();
            workImage2.Lock();
            for (int i = 1; i < (workImage.Width) - 2; i++)
            {
                for (int j = 1; j < (workImage.Height) - 2; j++)
                {
                    sumaPR = 0; sumaQR = 0; sumaPG = 0; sumaQG = 0; sumaPB = 0; sumaQB = 0;
                    for (int r = i - 1; r <= i + 1; r++)
                    {
                        for (int c = j - 1; c <= j + 1; c++)
                        {
                            color = workImage.GetPixel(r, c);
                            int R = color.R;
                            int G = color.G;
                            int B = color.B;

                            sumaPR = sumaPR + R * P[r - i + 1, c - j + 1];
                            sumaPG = sumaPG + G * P[r - i + 1, c - j + 1];
                            sumaPB = sumaPB + B * P[r - i + 1, c - j + 1];
                            sumaQR = sumaQR + R * Q[r - i + 1, c - j + 1];
                            sumaQG = sumaQG + G * Q[r - i + 1, c - j + 1];
                            sumaQB = sumaQB + B * Q[r - i + 1, c - j + 1];
                        }
                    }
                    uR = SumaQ(sumaPR, sumaQR);
                    uG = SumaQ(sumaPG, sumaQG);
                    uB = SumaQ(sumaPB, sumaQB);

                    uR = uR + Math.PI / 2;
                    uG = uG + Math.PI / 2;
                    uB = uB + Math.PI / 2;

                    sumaR = 0; sumaG = 0; sumaB = 0;
                    for (int r = i - 1; r <= i + 1; r++)
                    {
                        for (int c = j - 1; c <= j + 1; c++)
                        {
                            color = workImage.GetPixel(r, c);
                            int R = color.R;
                            int G = color.G;
                            int B = color.B;

                            int pozR = r - i + 1;
                            int pozC = c - j + 1;

                            scaleR = (Math.Pow(Math.E, -(pozR * pozR + pozC * pozC) / (2 * Sigma * Sigma))) * Math.Sin(Omega * (pozR * Math.Cos(uR) + pozC * Math.Sin(uR)));
                            scaleG = (Math.Pow(Math.E, -(pozR * pozR + pozC * pozC) / (2 * Sigma * Sigma))) * Math.Sin(Omega * (pozR * Math.Cos(uG) + pozC * Math.Sin(uG)));
                            scaleB = (Math.Pow(Math.E, -(pozR * pozR + pozC * pozC) / (2 * Sigma * Sigma))) * Math.Sin(Omega * (pozR * Math.Cos(uB) + pozC * Math.Sin(uB)));

                            sumaR += scaleR * R;
                            sumaG += scaleG * G;
                            sumaB += scaleB * B;

                        }
                    }
                    sumaR = Normalizare((int)sumaR);
                    sumaG = Normalizare((int)sumaG);
                    sumaB = Normalizare((int)sumaB);
                    color = Color.FromArgb((int)sumaR, (int)sumaG, (int)sumaB);
                    workImage2.SetPixel(i, j, color);
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage2.GetBitMap();
            workImage.Unlock();
            workImage2.Unlock();
        }

        private void panelSource_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelSource_MouseClick(object sender, MouseEventArgs e)
        {
            int x, y;
            int T = 50;
            int C = 0;
            int S = 0;
            workImage.Lock();
            workImage2.Lock();
            x = e.X * (workImage.Width / panelSource.Width);
            y = e.Y * (workImage.Height / panelSource.Height);
            Queue<Color> Q = new Queue<Color>();
            Queue<Color> R = new Queue<Color>();
            int[,] vizitat = new int[workImage.Width, workImage.Height];
            for (int i = 1; i < workImage.Width - 2; i++)
            {
                for (int j = 1; j < workImage.Height - 2; j++)
                {
                    vizitat[i, j] = 0;
                }
            }
            Color pixel = workImage.GetPixel(x, y);
            int average = ((pixel.R + pixel.G + pixel.B) / 3);
            while (Q.Count != 0)
            {
                int media = average / R.Count;
                if (x < workImage.Width && y < workImage.Height)
                {
                    if ((Math.Abs(average - media) < T))
                    {
                        Q.Enqueue(pixel);
                        R.Enqueue(pixel);
                        S = S + average;
                        vizitat[x, y] = 1;
                        C++;
                        workImage2.SetPixel(x, y, pixel);
                    }
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage2.GetBitMap();
            workImage.Unlock();
            workImage2.Unlock();
        }

        private int averageInt(int xini, int xfin, int yini, int yfin)
        {
            int sum = 0, count = 0;
            for (int i = xini; i < xfin; i++)
            {
                for (int j = yini; j < yfin; j++)
                {
                    Color newColor = workImage.GetPixel(i, j);
                    int R = newColor.R;
                    int G = newColor.G;
                    int B = newColor.B;

                    sum += (R + G + B) / 3;
                    count++;
                }
            }

            if (count == 0)
            {
                return -1;
            }
            int rez = sum / count;
            return rez;
        }

        private void drawLines(int xini, int xfin, int yini, int yfin)
        {
            for (int i = xini; i < xfin; i++)
            {
                workImage2.SetPixel(i, (yini + yfin) / 2, Color.Black);
            }

            for (int i = yini; i < yfin; i++)
            {
                workImage2.SetPixel((xini + xfin) / 2, i, Color.Black);
            }
        }
        private void splitting(int xini, int xfin, int yini, int yfin)
        {
            int sum = 0, count = 0;
            int averageCol = averageInt(xini, xfin, yini, yfin);

            if (averageCol == -1 || xfin - xini < 2 || yfin - yini < 2)
            {
                return;
            }

            for (int i = xini; i < xfin; i++)
            {
                for (int j = yini; j < yfin; j++)
                {
                    Color newColor = workImage.GetPixel(i, j);
                    int R = newColor.R;
                    int G = newColor.G;
                    int B = newColor.B;
                    int grCol = (R + G + B) / 3;
                    sum += (grCol - averageCol) * (grCol - averageCol);
                    count++;
                }
            }

            int dev = sum / (count);

            if (dev > prag)
            {
                drawLines(xini, xfin, yini, yfin);
                int xHalf = (xfin + xini) / 2;
                int yHalf = (yfin + yini) / 2;

                splitting(xini, xHalf, yini, yHalf);
                splitting(xHalf, xfin, yini, yHalf);
                splitting(xini, xHalf, yHalf, yfin);
                splitting(xHalf, xfin, yHalf, yfin);
            }
        }
        int prag;

        private void buttonSplit_Click(object sender, EventArgs e)
        {
            prag = 10;
            workImage.Lock();
            workImage2.Lock();

            splitting(0, workImage.Width, 0, workImage.Height);

            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage2.GetBitMap();

            workImage.Unlock();
            workImage2.Unlock();
        }
    }
}







