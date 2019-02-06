using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EndlessRunner
{
	public class Runner : Entity
	{
		public double Velocity { get; set; }
		public int Score { get; set; }
		public int PicState { get; set; }
		public int CounterInterval { get; set; }
		public int Couter { get; set; }
		public bool InAir { get; set; }


		public Runner(Point location, Size size, int timerInterval)
		{
			GameController.Runners.Add(this);
			Location = location;
			Size = size;
			CounterInterval = timerInterval;
		}

		public Runner(int x, int y, int width, int height, int timerInterval)
		{
			GameController.Runners.Add(this);
			Location = new Point(x, y);
			Size = new Size(width, height);
			CounterInterval = timerInterval;
		}

		public override Image GetImage()
		{
				if (GameController.GameRun || Score != 0)
					if (InAir)
						return GameController.SpriteJump[PicState];
					else
						return GameController.SpriteRun[PicState];
				else
					return GameController.SpriteIdle[PicState];
			
		}

		public override Rectangle GetHitbox()
		{
			if (InAir)
				return new Rectangle(Location, Size);
			else
				return new Rectangle(Location.X, Location.Y, Size.Width, Size.Height + 5);
		}

		public void PicTick()
		{
			if (Couter >= CounterInterval)
			{
				Couter = 0;
				if (PicState >= 9)
				{
					if (!InAir)
						PicState = 0;
				}
				else
					PicState++;
			}
			else
				Couter++;
		}

		public override void Tick()
		{
			Score++;

			Velocity += GameController.gravity;

			Rectangle bodyNow = GetHitbox();
			Rectangle bodyFut = GetHitbox();

			bodyFut.Offset(0, (int)Math.Round(Velocity));

			Rectangle ground = GameController.Platform.GetHitbox();

			if (bodyFut.Bottom > ground.Top)
			{
				if (bodyNow.Bottom + 1 != ground.Top)
				{
					bodyFut.Y = ground.Top - bodyNow.Height;
					InAir = false;
				}
			}


			foreach (Obstacle box in GameController.Obstacle)
			{
				if(GameController.Intersect(box.GetHitbox(), GetHitbox()))
				{
					GameController.Runners.Remove(this);
				}
			}

			Location = bodyFut.Location;
		}

		public void Jump()
		{
			if (!InAir)
			{
				Velocity = GameController.jumpVelocity;
				InAir = true;
				PicState = 0;
			}			
		}
	}
}
