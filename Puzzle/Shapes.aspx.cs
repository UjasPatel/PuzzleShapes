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
using System.Text.RegularExpressions;

namespace Puzzle
{
    public partial class Shapes : System.Web.UI.Page
    {
        int x_0 = 500;
        int y_0 = 400;

        protected void Page_Load(object sender, EventArgs e)
        {
            Button1.Click += new EventHandler(this.Submit_Click);
            string shapesAllowed = "SHAPES ALLOWED : Square, Scalene, Triangle, Parallelogram, Equilateral Triangle, Pentagon, Rectangle, Hexagon, Heptagon, Octagon, Circle, Oval";
            string formatAllowed = "FORMAT ALLOWED : Draw a(n) <shape> with a(n) <measurement> of <amount> (and a(n) <measurement> of <amount>)";
            TextBox1.ToolTip = $"{shapesAllowed} {System.Environment.NewLine} {formatAllowed}";
        }

        void Submit_Click(Object sender, EventArgs e)
        {
            var numbers = (from Match m in Regex.Matches(TextBox1.Text, @"\d+") select int.Parse(m.Value)).ToArray();
            string shape = FindShape(TextBox1.Text.ToLower());

            if (String.IsNullOrEmpty(TextBox1.Text) || numbers.Length == 0 || shape == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "String is not in expected format" + "');", true);
                TextBox1.Focus();
            }
            else
            {
                int width = numbers[0];
                int height = numbers.Length > 1 ? numbers[1] : 0;
               
                Bitmap bmp = new Bitmap(x_0 * 2, y_0 * 2);
                Graphics graphics = Graphics.FromImage(bmp);

                graphics.Clear(Color.Black);
                Pen pen = new Pen(Color.White, 2);

                switch (shape)
                {
                    case "rectangle":
                        drawRectangleOrSquare(width, ref graphics, ref pen, height);
                        break;
                    case "square":
                        drawRectangleOrSquare(width, ref graphics, ref pen);
                        break;
                    case "pentagon":
                        drawPolygon("pentagon", width, ref graphics, ref pen);
                        break;
                    case "hexagon":
                        drawPolygon("hexagon", width, ref graphics, ref pen);
                        break;
                    case "heptagon":
                        drawPolygon("heptagon", width, ref graphics, ref pen);
                        break;
                    case "octagon":
                        drawPolygon("octagon", width, ref graphics, ref pen);
                        break;
                    case "equilateral":
                        drawEquilateral(width, ref graphics, ref pen);
                        break;
                    case "circle":
                        drawCircleOrOval("circle", width, ref graphics, ref pen);
                        break;
                    case "oval":
                        drawCircleOrOval("oval", width, ref graphics, ref pen, height);
                        break;
                    case "scalene":
                        drawScalene(width, ref graphics, ref pen);
                        break;
                    case "parallelogram":
                        drawParallelogram(width, ref graphics, ref pen, height);
                        break;

                }

                string virtualPath = "~/Image/img.jpg";
                string path = Server.MapPath(virtualPath);

                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
                bmp.Save(path, ImageFormat.Jpeg);

                Image1.ImageUrl = virtualPath;

                graphics.Dispose();
                bmp.Dispose();
            }
        }

        private string FindShape(string txt)
        {
            string shape = "";
            if (txt.Contains("circle"))
                shape = "circle";
            else if (txt.Contains("oval"))
                shape = "oval";
            else if (txt.Contains("rectangle"))
                shape = "rectangle";
            else if (txt.Contains("square"))
                shape = "square";
            else if (txt.Contains("pentagon"))
                shape = "pentagon";
            else if (txt.Contains("hexagon"))
                shape = "hexagon";
            else if (txt.Contains("heptagon"))
                shape = "heptagon";
            else if (txt.Contains("octagon"))
                shape = "octagon";
            else if (txt.Contains("equilateral"))
                shape = "equilateral";
            else if (txt.Contains("scalene"))
                shape = "scalene";
            else if (txt.Contains("parallelogram"))
                shape = "parallelogram";

            return shape;
        }

        private void drawPolygon(string shape, int width, ref Graphics graphics, ref Pen pen)
        {   
            int numOfSides = 0;

            if (shape == "pentagon")
                numOfSides = 5;
            else if (shape == "hexagon")
                numOfSides = 6;
            else if (shape == "heptagon")
                numOfSides = 7;
            else if (shape == "octagon")
                numOfSides = 8;                       
           
            var points = new PointF[numOfSides];                      
                        
            for (int a = 0; a < numOfSides; a++)
            {
                points[a] = new PointF(
                    x_0 + width * (float)Math.Cos(a * (360 / numOfSides) * Math.PI / 180f),
                    y_0 + width * (float)Math.Sin(a * (360 / numOfSides) * Math.PI / 180f));
            }
            graphics.DrawPolygon(pen, points);
        }

        private void drawCircleOrOval(string shape, int width, ref Graphics graphics, ref Pen pen, int height = 0)
        {           
            if (shape == "circle")
            {
                graphics.DrawEllipse(pen, x_0 - width, y_0 - width,
                          width + width, width + width);
            }
            else if (shape == "oval")
            {
                Rectangle rect = new Rectangle(x_0, y_0, width, height);
                graphics.DrawEllipse(pen, rect);
            }
        }

        private void drawEquilateral(int width, ref Graphics graphics, ref Pen pen)
        {
            var points = new PointF[3];

            points[0].X = (float)(x_0 + width * Math.Sin(0 + Math.PI / 3));

            points[0].Y = (float)(y_0 + width * Math.Cos(0 + Math.PI / 3));

            points[1].X = (float)(x_0 + width * Math.Sin(0));

            points[1].Y = (float)(y_0 + width * Math.Cos(0));

            points[2].X = x_0;

            points[2].Y = y_0;

            graphics.DrawPolygon(pen, points);
        }

        private void drawRectangleOrSquare(int width, ref Graphics graphics, ref Pen pen, int height = 0)
        {          
            graphics.DrawRectangle(pen, x_0, y_0, width, height == 0 ? width : height);
        }

        private void drawParallelogram(int width, ref Graphics graphics, ref Pen pen, int height)
        {
            var points = new PointF[4];

            points[0].X = x_0;

            points[0].Y = y_0;

            points[1].X = x_0 + width;

            points[1].Y = y_0;

            points[2].X = x_0 + width + (width / 3);

            points[2].Y = y_0 + height;

            points[3].X = x_0 + (width / 3);

            points[3].Y = y_0 + height;
            graphics.DrawPolygon(pen, points);
        }

        private void drawScalene(int width, ref Graphics graphics, ref Pen pen)
        {   
            var shape = new PointF[3];            

            shape[0].X = (float)(x_0 + width * Math.Sin(0 + Math.PI / 3));

            shape[1].Y = (float)(y_0 + width * Math.Cos(0 + Math.PI / 3));

            shape[1].X = (float)(x_0 + width * Math.Sin(0));

            shape[0].Y = (float)(y_0 + width * Math.Cos(0));

            shape[2].X = x_0;

            shape[2].Y = y_0;

            graphics.DrawPolygon(pen, shape);
        }
    }
}