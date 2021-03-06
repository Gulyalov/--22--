using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAirplane
{
	public partial class FormPlane : Form
	{
		private AirPlane plane;

		public FormPlane()
		{
			InitializeComponent();
		}

		private void Draw()
		{
			Bitmap bmp = new Bitmap(pictureBoxPlane.Width, pictureBoxPlane.Height);
			Graphics gr = Graphics.FromImage(bmp);
			plane.DrawTransport(gr);
			pictureBoxPlane.Image = bmp;
		}

		private void buttonCreate_Click(object sender, EventArgs e)
		{
			Random rnd = new Random();
			plane = new AirPlane();
			plane.Init(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Black, Color.Brown, true, true);
			plane.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxPlane.Width, pictureBoxPlane.Height);
			Draw();
		}

		private void buttonMove_Click(object sender, EventArgs e)
		{
			string name = (sender as Button).Name;
			switch(name)
			{
				case "buttonUp":
					plane.movePlane(Direction.Up);
					break;

				case "buttonDown":
					plane.movePlane(Direction.Down);
					break;

				case "buttonLeft":
					plane.movePlane(Direction.Left);
					break;

				case "buttonRight":
					plane.movePlane(Direction.Right);
					break;
			}
			Draw();
		}
	}
}
