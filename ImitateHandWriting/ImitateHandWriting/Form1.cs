using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImitateHandWriting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap b1 = new Bitmap(200, 200);
        string[] allSymbols = { "}","a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "'", "(", ")", ".", "{", "}", ":", ";", "+", "/", "*", "-", "&", "^", "$", "#", "@", "!" };

        int x = 0;
        SolidBrush brush = new SolidBrush(Color.Black);
       

        Bitmap btmp = new Bitmap(200, 200);

        List<Bitmap> allBitmaps = new List<Bitmap>();

        private void Form1_Load(object sender, EventArgs e)
        {

            textBox1.Text = allSymbols[x]; 
            
        }
   

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                allBitmaps.Add(btmp);
                btmp = new Bitmap(200, 200);
                pictureBox1.Image = btmp;
                Bitmap bip = new Bitmap(pictureBox2.Width, pictureBox2.Height);

                Graphics g = Graphics.FromImage(btmp);
                Graphics g2 = Graphics.FromImage(bip);

                x += 1;

                if (x > allSymbols.Length - 1)
                {
                    textBox1.Text = "Please enter your text";

                }
                else
                {
                    textBox1.Text = allSymbols[x];
                }

            }catch(Exception g)
            {

            }
            
            
        }

        Point lastPoint = Point.Empty;
        bool isMouseDown;

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (lastPoint != null && isMouseDown)
            {
                if (pictureBox1.Image == null)   
                {                                         
                    Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox2.Height);

                    pictureBox1.Image = bmp;
                }

                Graphics g = Graphics.FromImage(pictureBox1.Image);

                g.DrawLine(new Pen(Color.Black, 20), lastPoint, e.Location);
                

                pictureBox1.Invalidate();

                lastPoint = e.Location;

            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;

            isMouseDown = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;

            lastPoint = Point.Empty;
        }

        Bitmap btmp3; 

        private void printHandWriting (int size)
        {
            try
            {
                if (size == 0)
                {
                    btmp3 = new Bitmap(30, 100);
                }
                else
                    btmp3 = new Bitmap(size * 30, 100); 

                pictureBox2.Width = size * 30;

                Graphics g = Graphics.FromImage(btmp3);

                string hello = richTextBox1.Text;
                int xpos = 0;

                for (int x = 0; x <= richTextBox1.Text.Length - 1; x++)
                {

                    for (int y = 0; y <= allSymbols.Length - 1; y++)
                    {
                        if (hello.Substring(x, 1) == allSymbols[y])
                        {
                            allBitmaps[y] = new Bitmap(allBitmaps[y], 20, 20);
                            g.DrawImage(allBitmaps[y], xpos, 30);
                            break;
                        }

                    }
                    xpos += 15;

                }

                pictureBox2.Image = btmp3;
            }
            catch(Exception e)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int size = richTextBox1.Text.Length; 
            printHandWriting(size); 
        }


    }
}
