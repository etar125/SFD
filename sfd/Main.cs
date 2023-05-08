using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SFD
{
	public static class SFD
	{
		public static List<object> queue = new List<object>
		{
			
		};
		
		#region Objects
		
		public struct SLine
		{
			public Pen p;
			public float[] pos;
		}
		public struct SImage
		{
			public Image p;
			public Point pos;
		}
		public struct SBox
		{
			public Pen p;
			public float[] pos;
			public float[] size;
		}
		
		#endregion
		
		public static void Request(Form f)
		{
			Bitmap bmp = new Bitmap(f.Width, f.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
			Graphics a = Graphics.FromImage(bmp);
			foreach(object o in queue)
			{
				if(o is SImage)
				{
					SImage m = (SImage)o;
					a.DrawImage(m.p, m.pos);
				}
				else if(o is SLine)
				{
					SLine m = (SLine)o;
					a.DrawLine(m.p, m.pos[0], m.pos[1], m.pos[2], m.pos[3]);
				}
				else if(o is SBox)
				{
					SBox m = (SBox)o;
					a.DrawRectangle(m.p, m.pos[0], m.pos[1], m.size[0], m.size[1]);
				}
			}
			f.BackgroundImageLayout = ImageLayout.None;
			f.BackgroundImage = bmp;
		}
		
		#region Functions
		
		public static void AddImage(Image img, Point pos)
		{
			SImage g = new SImage();
			g.p = img;
			g.pos = pos;
			queue.Add(g);
		}
		public static void AddLine(Pen p, float[] pos)
		{
			SLine g = new SLine();
			g.p = p;
			g.pos = pos;
			queue.Add(g);
		}
		public static void AddBox(Pen p, float[] pos, float[] size)
		{
			SBox g = new SBox();
			g.p = p;
			g.pos = pos;
			g.size = size;
			queue.Add(g);
		}
		
		#endregion
		
		/* g.DrawImage(img, pos)
		 * g.DrawLine(Pen, float x1, float y1, float x2,float y2)
		 * g.DrawRectangle(pen, rectangle)
		 * 
		 */
	}
}