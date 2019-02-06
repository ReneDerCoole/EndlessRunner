using System.Collections.Generic;
using System.Drawing;
namespace EndlessRunner
{
	public class Platform
	{
		public int X { get; set; }
		public int Y { get; set; }

		public Platform(int y)
		{
			GameController.Platform = this;
			X = 0;
			Y = y;
		}

		public void Tick()
		{
			X -= GameController.gameSpeed;
			while (X < -200)
				X += 64;
		}

		public List<Point> GetTopImagePoints()
		{
			List<Point> list = new List<Point>();

			for (int i = X; i < 1800; i += GameController.blockSize.Width)
			{
				list.Add(new Point(i, Y - 7));
			}

			return list;
		}

		public List<Point> GetBottomImagePoints()
		{
			List<Point> list = new List<Point>();

			for (int j = Y + GameController.blockSize.Height; j < GameController.Main.Size.Height; j += GameController.blockSize.Height)
			{
				for (int i = X; i < GameController.spawnObjectLocation; i += GameController.blockSize.Height)
				{
					list.Add(new Point(i, j - 7));
				}
			}

			return list;
		}

		public Rectangle GetHitbox()
		{
			return new Rectangle(0, Y, GameController.Main.Width, GameController.Main.Height - Y);
		}
	}
}
