using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace LeafSoft
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            //设置启动窗体
            SetWindowRegion();
            this.Opacity = 0; // 透明界面  
            this.timer1.Interval = 10; // 设置Timer的时间间隔  
            this.timer1.Enabled = true;
            this.timer1.Start(); // 开始Timer               
        }

        public void SetWindowRegion()
        {
            System.Drawing.Drawing2D.GraphicsPath FormPath;
            FormPath = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            FormPath = GetRoundedRectPath(rect, 130);
            this.Region = new Region(FormPath);

        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();

            // 左上角  
            path.AddArc(arcRect, 180, 90);

            // 右上角  
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);

            // 右下角  
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);

            // 左下角  
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();//闭合曲线  
            return path;
        }  

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.01;  
            if (this.Opacity >= 1)  
            {
                System.Threading.Thread.Sleep(1000);//欢迎窗口停留时间2s 
                this.timer1.Stop();  
                this.Close();  
            }  
        }

        private void Welcome_FormClosed(object sender, FormClosedEventArgs e)
        {
            //关闭定时器
            this.timer1.Stop();
        }

        private void Welcome_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath oPath = new GraphicsPath();

            int x = 0;
            int y = 0;
            int w = Width;
            int h = Height;
            int a = 8;
            Graphics g = CreateGraphics();
            oPath.AddArc(x, y, a, a, 180, 90); //边框格式  
            oPath.AddArc(w - a, y, a, a, 270, 90);
            oPath.AddArc(w - a / 2, h - a / 2, a / 2, a / 2, 0, 90);
            oPath.AddArc(x, h - a, a, a, 90, 90);
            oPath.CloseAllFigures();
            Region = new Region(oPath);
        }
    }
}
