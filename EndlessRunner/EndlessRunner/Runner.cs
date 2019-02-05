using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EndlessRunner
{
	public class Runner
	{
		public Point Location { get; set; }
		public Size Size { get; set; }
		public int Score { get; set; }
		public double Velocity { get; set; }
		public int PicState { get; set; }
		public int TimerInterval { get; set; }
		public int TimerCouter { get; set; }

		public bool InAir { get; set; }


		public Runner(Point location, Size size, int timerInterval)
		{
			GameController.Runner = this;
			Location = location;
			Size = size;
			TimerInterval = timerInterval;
		}

		public Runner(int x, int y, int width, int height, int timerInterval)
		{
			GameController.Runner = this;
			Location = new Point(x, y);
			Size = new Size(width, height);
			TimerInterval = timerInterval;
		}

		public Image Image
		{
			get
			{
				if (GameController.GameRun || Score != 0)
					if (InAir)
						return GameController.SpriteJump[PicState];
					else
						return GameController.SpriteRun[PicState];
				else
					return GameController.SpriteIdle[PicState];
			}
		}

		public void PicTick()
		{
			TimerCouter++;
			if (TimerCouter >= TimerInterval)
			{
				TimerCouter = 0;

				if (PicState >= 9)
				{
					if (!InAir)
						PicState = 0;
				}
				else
					PicState++;
			}
		}

		public void Tick()
		{
			Score++;

			Velocity += GameController.gravity;
			
			Rectangle bodyNow = new Rectangle(Location, Size);
			Rectangle bodyFut = new Rectangle(Location, Size);
			bodyFut.Offset(0, (int)Math.Round(Velocity));

			Rectangle ground = GameController.PanelToRectangle(GameController.Main.panelTop);
			ground.Offset(0, 5);

			if (bodyFut.Bottom > ground.Top)
			{
				if (bodyNow.Bottom + 1 != ground.Top)
				{
					bodyFut.Y = ground.Top - bodyNow.Height;
					InAir = false;
				}
			}

			Location = bodyFut.Location;
		}

		public void Jump()
		{
			Rectangle bodyNow = new Rectangle(Location, Size);

			Rectangle ground = GameController.PanelToRectangle(GameController.Main.panelTop);

			if (!InAir)
				Velocity = GameController.jumpVelocity;

			InAir = true;
		}
	}
}
