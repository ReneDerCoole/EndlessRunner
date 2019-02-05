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
		public static Runner Runner { get; set; }

		static public Image[] SpriteIdle { get; set; }
		static public Image[] SpriteRun { get; set; }
		static public Image[] SpriteJump { get; set; }

		public static bool GameRun { get; set; }
		
		public const double jumpVelocity = -40;
		public const double gravity = 2;
		public static double gameSpeed = 8;

		public static string MainPath
		{
			get { return Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\")); }
		}

		public static Rectangle PanelToRectangle(Panel panel)
		{
			return new Rectangle(panel.Location, panel.Size);
		}

		public static void Tick()
		{
			if (GameRun)
			{
				Runner.Tick();
				if(Runner.Score % 100 == 0)
				{
					gameSpeed++;
				}
			}
		}

		public static void PicTick()
		{
			Runner.PicTick();
			Main.button1.Text = Runner.Score.ToString() + "; Speed: " + GameController.gameSpeed;
		}
	}
}
