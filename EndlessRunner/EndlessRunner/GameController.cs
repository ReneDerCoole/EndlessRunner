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

		static public Image[] SpriteIdle { get; set; }
		static public Image[] SpriteRun { get; set; }
		static public Image[] SpriteJump { get; set; }
		static public Image[] SpriteBlocks { get; set; }
		static public Image[] SpriteObstacle { get; set; }

		public static bool GameRun { get; set; }

		public const double jumpVelocity = -50;
		public const double gravity = 3;
		public static int gameSpeed = 16;
		public static int score = 0;
		public static int spawnBarrierX = 2000;
		public static int boxSize = 64;

		public static string ImagePath
		{
			get { return Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\")) + @"Images\"; }
		}

		public static Rectangle PanelToRectangle(Panel panel)
		{
			return new Rectangle(panel.Location, panel.Size);
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
							if (runner.CounterInterval > 0)
								runner.CounterInterval--;
						}
				}

				if(Runners.Count == 0)
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
			string debug = "";

			foreach (Obstacle box in Obstacle)
			{
				debug += box.Location.X + "; ";
			}

			Main.button1.Text = debug;
		}
	}
}
