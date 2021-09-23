using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsAirplane
{
	class AirPlane
	{
		private float startPosX;
		private float startPosY;
		private int pictureWidth;
		private int pictureHeight;
		private const int planeWidth = 130;
		private const int planeHeight = 140;


		public int MaxSpeed
		{
			private set;
			get;
		}

		public float Weight
		{
			private set;
			get;
		}

		public Color MainColor
		{
			private set;
			get;
		}

		public Color DopColor
		{
			private set;
			get;
		}

		public bool Screw
		{
			private set;
			get;
		}

		public bool Cab
		{
			private set;
			get;
		}

		public void Init(int maxSpeed, float weight, Color mainColor, Color dopColor, bool screw, bool cab)
		{
			MaxSpeed = maxSpeed;
			Weight = weight;
			MainColor = mainColor;
			DopColor = dopColor;
			Screw = screw;
			Cab = cab;
		}

		public void SetPosition(int x, int y, int width, int height)
		{
			startPosX = x;
			startPosY = y;
			pictureWidth = width;
			pictureHeight = height;
		}

		public void movePlane(Direction direction)
		{
			float step = MaxSpeed * 100 / Weight;
			switch (direction)
			{
				case Direction.Right:
					if(startPosX+step < pictureWidth - planeWidth)
					{
						startPosX += step;
					}
					break;

				case Direction.Left:
					if(startPosX - step > 0 )
					{
						startPosX -= step;
					}
					break;

				case Direction.Up:
					if(startPosY-step > 0)
					{
						startPosY -= step;
					}
					break;

				case Direction.Down:
					if(startPosY+step < pictureHeight-planeHeight)
					{
						startPosY += step;
					}
					break;
			}
		}

		public void DrawTransport(Graphics g)
		{
			Pen pen = new Pen(Color.Black);

			if(Screw)
			{
				Brush vint = new SolidBrush(DopColor);

				g.FillEllipse(vint, startPosX + 45, startPosY + 15, 10, 5);
				g.FillEllipse(vint, startPosX + 45, startPosY + 45, 10, 5);
				g.FillEllipse(vint, startPosX + 45, startPosY + 90, 10, 5);
				g.FillEllipse(vint, startPosX + 45, startPosY + 120, 10, 5);

				g.FillRectangle(vint, startPosX + 53, startPosY + 10, 7, 15);
				g.FillRectangle(vint, startPosX + 53, startPosY + 40, 7, 15);
				g.FillRectangle(vint, startPosX + 53, startPosY + 85, 7, 15);
				g.FillRectangle(vint, startPosX + 53, startPosY + 115, 7, 15);
			}

			if(Cab)
			{
				
			}



			g.DrawLine(pen, startPosX + 0, startPosY + 70, startPosX + 20, startPosY + 60);
			g.DrawLine(pen, startPosX + 20, startPosY + 60, startPosX + 60, startPosY + 60);
			g.DrawLine(pen, startPosX + 60, startPosY + 60, startPosX + 60, startPosY + 0);
			g.DrawLine(pen, startPosX + 60, startPosY + 0, startPosX + 70, startPosY + 0);
			g.DrawLine(pen, startPosX + 70, startPosY + 0, startPosX + 80, startPosY + 60);
			g.DrawLine(pen, startPosX + 80, startPosY + 60, startPosX + 130, startPosY + 60);
			g.DrawLine(pen, startPosX + 130, startPosY + 60, startPosX + 130, startPosY + 30);
			g.DrawLine(pen, startPosX + 130, startPosY + 30, startPosX + 110, startPosY + 50);
			g.DrawLine(pen, startPosX + 110, startPosY + 50, startPosX + 110, startPosY + 60);
			g.DrawLine(pen, startPosX + 110, startPosY + 80, startPosX + 110, startPosY + 90);
			g.DrawLine(pen, startPosX + 110, startPosY + 90, startPosX + 130, startPosY + 110);
			g.DrawLine(pen, startPosX + 130, startPosY + 110, startPosX + 130, startPosY + 60);
			g.DrawLine(pen, startPosX + 130, startPosY + 80, startPosX + 80, startPosY + 80);
			g.DrawLine(pen, startPosX + 80, startPosY + 80, startPosX + 70, startPosY + 140);
			g.DrawLine(pen, startPosX + 70, startPosY + 140, startPosX + 60, startPosY + 140);
			g.DrawLine(pen, startPosX + 60, startPosY + 140, startPosX + 60, startPosY + 80);
			g.DrawLine(pen, startPosX + 60, startPosY + 80, startPosX + 20, startPosY + 80);
			g.DrawLine(pen, startPosX + 20, startPosY + 80, startPosX + 0, startPosY + 70);

			Point[] h = new Point[3];
			h[0] = new Point((int)startPosX + 20,(int)startPosY + 60);
			h[1] = new Point((int)startPosX + 20, (int)startPosY + 80);
			h[2] = new Point((int)startPosX + 0, (int)startPosY + 70);
			g.FillPolygon(Brushes.Black, h);
		}
	}
}
