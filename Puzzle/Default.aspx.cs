using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Puzzle
{
    public partial class Default : Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                int height = 100;
                int width = 200;
                Random r = new Random();
                int x = r.Next(75);

                Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);
                Graphics g = Graphics.FromImage(bmp);

                g.TextRenderingHint = TextRenderingHint.AntiAlias;
                g.Clear(Color.Orange);
                g.DrawRectangle(Pens.White, 1, 1, width - 3, height - 3);
                g.DrawRectangle(Pens.Gray, 2, 2, width - 3, height - 3);
                g.DrawRectangle(Pens.Black, 0, 0, width, height);
                g.DrawString("The Code Project", new Font("Arial", 12, FontStyle.Italic),
                SystemBrushes.WindowText, new PointF(x, 50));

                bmp.Save(Response.OutputStream, ImageFormat.Jpeg);
                g.Dispose();
                bmp.Dispose();
            }
        }  
    }
}

