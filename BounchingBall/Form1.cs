using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BounchingBall
{
    public partial class Form1 : Form
    {
        private int ballWidth= 50;
        private int ballHeight=50;
        private int ballPosX = 0;
        private int ballPosY = 0;
        private int movestepX = 4;
        private int movestepY = 4;


        public Form1()
        {
            InitializeComponent();
            this.SetStyle( ControlStyles.OptimizedDoubleBuffer |
                           ControlStyles.AllPaintingInWmPaint |
                           ControlStyles.UserPaint,
                           true
                           );
            this.UpdateStyles();
        }

        private void paintcircle(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.Clear(this.BackColor);
            e.Graphics.FillEllipse(Brushes.Blue,  ballPosX, ballPosY, ballWidth, ballHeight);
            e.Graphics.DrawEllipse(Pens.Black, ballPosX, ballPosY, ballWidth, ballHeight);
        }

        private void MoveBall(object sender, EventArgs e)
        {
            //update coordinates
            ballPosX += movestepX;
            if(ballPosX<0||ballPosX+ballWidth>this.ClientSize.Width)
            {
                movestepX = -movestepX;
            }

            ballPosY += movestepY;
            if (ballPosY < 0 || ballPosY + ballHeight > this.ClientSize.Height)
            {
                movestepY = -movestepY;
            }

            //update painting
            this.Refresh();
        }
    }
}
