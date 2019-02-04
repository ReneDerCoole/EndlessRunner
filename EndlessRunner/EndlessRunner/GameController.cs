using System;
using System.Collections.Generic;
using System.Drawing;
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
		public static bool GameRun { get; set; }

		public const double jumpVelocity = -40;
		public const double gravity = 10.0;

		public static Rectangle PanelToRectangle(Panel panel)
		{
			return new Rectangle(panel.Location, panel.Size);
		}

		public static void Tick()
		{
			if (GameRun)
			{
				Runner.Tick();
			}
		}
	}
}
