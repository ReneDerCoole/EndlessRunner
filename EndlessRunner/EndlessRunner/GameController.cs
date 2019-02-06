using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EndlessRunner
{

	public static class GameController
	{
		public static Main Main { get; set; }
		public static LevelGenerator LevelGenerator { get; set; }
		public static List<Runner> Runners { get; set; }
		public static Platform Platform { get; set; }
		public static List<Obstacle> Obstacle { get; set; }

		public static Image[] SpriteIdle { get; set; }
		public static Image[] SpriteRun { get; set; }
		public static Image[] SpriteJump { get; set; }
		public static Image[] SpriteSlide { get; set; }
		public static Image[] SpriteBlocks { get; set; }
		public static Image[] SpriteObstacle { get; set; }

		public static bool GameRun { get; set; }

		public const double jumpVelocity = -50;
		public const double gravity = 3;
		public static int gameSpeed = 16;
		public static int score = 0;
		public static int spawnObjectLocation = 2000;

		public static Size blockSize = new Size(64, 64);
		public static Size sawSize = new Size(128, 128);
		public static Size runnerIdle = new Size(0, 0);
		public static Size runnerRun = new Size(0, 0);
		public static Size runnerJump = new Size(0, 0);
		public static Size runnerSlide = new Size(0, 0);

		public static Point spawnPoint = new Point(50, 300);

		public static string[] debugString = new string[10];

		public static string ImagePath
		{
			get { return Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\")) + @"Images\"; }
		}

		public static Rectangle PanelToRectangle(Panel panel)
		{
			return new Rectangle(panel.Location, panel.Size);
		}

		public static Size Resize(Size size, double percent)
		{
			double mod = percent / 100;

			double width = size.Width * mod;
			double height = size.Height * mod;

			return new Size((int)width, (int)height);
		}

		public static bool Intersect(Rectangle r1, Rectangle r2)
		{
			if (r1.Bottom < r2.Top || r1.Top > r2.Bottom)
				return false;
			else
			{
				if (r1.Left > r2.Right || r1.Right < r2.Left)
					return false;
				else
					return true;
			}
		}

		public static void Tick()
		{
			if (GameRun)
			{
				score++;

				LevelGenerator.Tick();
				Platform.Tick();

				if (Runners != null)
				{
					for (int i = Runners.Count - 1; i >= 0; i--)
					{
						Runners[i].Tick();
					}
				}

				if (Obstacle != null)
				{
					for (int i = Obstacle.Count - 1; i >= 0; i--)
					{
						Obstacle[i].Tick();
					}
				}


				if (score % 500 == 0)
				{
					gameSpeed++;
					if (gameSpeed % 10 == 0)
						foreach (Runner runner in Runners)
						{
							if (runner.PicCounterInterval > 0)
								runner.PicCounterInterval--;
						}
				}

				if (Runners.Count == 0)
				{
					Main.End();
				}
			}
		}

		public static void PicTick()
		{
			foreach (Runner runner in Runners)
			{
				runner.PicTick();
			}

			//DEBUG
			//-----------
			for (int i = 0; i < debugString.Length; i++)
			{
				debugString[i] = i + ": bla";
			}

			//if (Runners.Count > 0)
			//	debugString[0] = Runners[0].GetHitbox().ToString();
			//else
			//	debugString[0] = "Tot";

			//if (Runners.Count > 0)
			//	debugString[1] = Runners[0].State.ToString();
			//else
			//	debugString[1] = "Tot";


			//-----------
			
		}
	}
}
