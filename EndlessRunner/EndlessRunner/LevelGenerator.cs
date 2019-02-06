using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessRunner
{
	public class LevelGenerator
	{
		public Point Spawnpoint { get; set; }

		private int Counter { get; set; }
		private int CounterInterval { get; set; }

		public LevelGenerator(Point spawnpoint, int counterInterval)
		{
			GameController.LevelGenerator = this;

			Spawnpoint = spawnpoint;
			this.CounterInterval = counterInterval;

			GameController.Obstacle = new List<Obstacle>();
			GameController.Runners = new List<Runner>();

			LoadImages();
			SpawnPlayer();

			
			new Platform(660);
		}

		private void LoadImages()
		{
			GameController.SpriteIdle = new Image[]
{
				Image.FromFile(GameController.ImagePath + "Idle__000.png"),
				Image.FromFile(GameController.ImagePath + "Idle__001.png"),
				Image.FromFile(GameController.ImagePath + "Idle__002.png"),
				Image.FromFile(GameController.ImagePath + "Idle__003.png"),
				Image.FromFile(GameController.ImagePath + "Idle__004.png"),
				Image.FromFile(GameController.ImagePath + "Idle__005.png"),
				Image.FromFile(GameController.ImagePath + "Idle__006.png"),
				Image.FromFile(GameController.ImagePath + "Idle__007.png"),
				Image.FromFile(GameController.ImagePath + "Idle__008.png"),
				Image.FromFile(GameController.ImagePath + "Idle__009.png")
};

			GameController.SpriteRun = new Image[]
			{
				Image.FromFile(GameController.ImagePath + "Run__000.png"),
				Image.FromFile(GameController.ImagePath + "Run__001.png"),
				Image.FromFile(GameController.ImagePath + "Run__002.png"),
				Image.FromFile(GameController.ImagePath + "Run__003.png"),
				Image.FromFile(GameController.ImagePath + "Run__004.png"),
				Image.FromFile(GameController.ImagePath + "Run__005.png"),
				Image.FromFile(GameController.ImagePath + "Run__006.png"),
				Image.FromFile(GameController.ImagePath + "Run__007.png"),
				Image.FromFile(GameController.ImagePath + "Run__008.png"),
				Image.FromFile(GameController.ImagePath + "Run__009.png")
			};

			GameController.SpriteJump = new Image[]
			{
				Image.FromFile(GameController.ImagePath + "Jump__000.png"),
				Image.FromFile(GameController.ImagePath + "Jump__001.png"),
				Image.FromFile(GameController.ImagePath + "Jump__002.png"),
				Image.FromFile(GameController.ImagePath + "Jump__003.png"),
				Image.FromFile(GameController.ImagePath + "Jump__004.png"),
				Image.FromFile(GameController.ImagePath + "Jump__005.png"),
				Image.FromFile(GameController.ImagePath + "Jump__006.png"),
				Image.FromFile(GameController.ImagePath + "Jump__007.png"),
				Image.FromFile(GameController.ImagePath + "Jump__008.png"),
				Image.FromFile(GameController.ImagePath + "Jump__009.png")
			};

			GameController.SpriteBlocks = new Image[]
			{
				Image.FromFile(GameController.ImagePath + "DirtBottom.png"),
				Image.FromFile(GameController.ImagePath + "DirtMiddle.png"),
			};

			GameController.SpriteObstacle = new Image[]
			{
				Image.FromFile(GameController.ImagePath + "Crate.png")
			};
		}

		private void SpawnPlayer()
		{
			new Runner(Spawnpoint, new Size(79, 90), 2);
		}

		public void Tick()
		{
			if (Counter > CounterInterval)
			{
				Counter = 0;
				SpawnRandomBox();
			}
			else
				Counter++;
		}

		private void SpawnRandomBox()
		{
			Random r = new Random();

			switch (r.Next(1,4))
			{
				case 1:
					SpawnBoxPile(3, 5);
					break;
				case 2:
					SpawnBoxPile(4, 4);
					break;
				case 3:
					SpawnBoxPile(5, 3);
					break;
				default:
					break;
			}
		}

		private void SpawnBoxPile(int width, int height)
		{
			Random r = new Random();

			int[] boxes = new int[width];
			boxes[boxes.Length / 2] = height;

			int temp = height;
			for (int i = boxes.Length / 2 - 1; i >= 0; i--)
			{
				temp = r.Next(temp / 2, temp);
				boxes[i] = temp;
			}

			temp = height;
			for (int i = boxes.Length / 2 + 1; i < boxes.Length; i++)
			{
				temp = r.Next(temp / 2, temp);
				boxes[i] = temp; 
			}

			for (int i = 0; i < boxes.Length; i++)
			{
				SpawnBoxStack(GameController.spawnBarrierX + i * GameController.boxSize, boxes[i]);
			}
		}

		private void SpawnBoxStack(int x, int height)
		{
			for (int i = 1; i <= height; i++)
			{
				new Obstacle(ObstacleType.Box ,x, GameController.Platform.Y - GameController.boxSize * i, GameController.boxSize, GameController.boxSize);
			}
		}
	}
}
