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

		public Obstacle(ObstacleType obstacleType, Point location)
		{
			GameController.Obstacle.Add(this);

			Type = obstacleType;
			Location = location;
		}

		public Obstacle(ObstacleType obstacleType, int x, int y)
		{
			GameController.Obstacle.Add(this);

			Type = obstacleType;
			Location = new Point(x, y);
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
					return GameController.SpriteObstacle[1];
				default:
					return null;
			}
		}

		public override Rectangle GetHitbox()
		{
			switch (Type)
			{
				case ObstacleType.Box:
					return new Rectangle(Location, GameController.blockSize);
				case ObstacleType.CircularSaw:
					return new Rectangle(Location, GameController.sawSize);
				default:
					return new Rectangle();
			}
		}
	}
}
