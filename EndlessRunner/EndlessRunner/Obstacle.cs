using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace EndlessRunner
{
	public enum ObstacleType { Box, CircularSaw };

	public class Obstacle : Entity
	{
		public ObstacleType Type { get; set; }

		public Obstacle(ObstacleType obstacleType, Point location, Size size)
		{
			GameController.Obstacle.Add(this);

			Type = obstacleType;
			Location = location;
			Size = size;
		}

		public Obstacle(ObstacleType obstacleType, int x, int y, int width, int height)
		{
			GameController.Obstacle.Add(this);

			Type = obstacleType;
			Location = new Point(x, y);
			Size = new Size(width, height);
		}

		public override void Tick()
		{
			if(Location.X < -100)
			{
				GameController.Obstacle.Remove(this);
				return;
			}

			Location = new Point(Location.X - GameController.gameSpeed, Location.Y);
		}

		public override Image GetImage()
		{
			switch (Type)
			{
				case ObstacleType.Box:
					return GameController.SpriteObstacle[0];
				case ObstacleType.CircularSaw:
					return null;
				default:
					return null;
			}
		}
	}
}
