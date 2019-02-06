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
		private int Counter { get; set; }
		private int CounterInterval { get; set; }

		public LevelGenerator(int counterInterval)
		{
			GameController.LevelGenerator = this;
			
			this.CounterInterval = counterInterval;

			GameController.Obstacle = new List<Obstacle>();
			GameController.Runners = new List<Runner>();

			LoadImages();
			SpawnPlayer();

			GameController.runnerIdle = GameController.Resize(GameController.SpriteIdle[0].Size, 25);
			GameController.runnerJump = GameController.Resize(GameController.SpriteJump[0].Size, 25);
			GameController.runnerRun = GameController.Resize(GameController.SpriteRun[0].Size, 25);
			GameController.runnerSlide = GameController.Resize(GameController.SpriteSlide[0].Size, 25);

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

			GameController.SpriteSlide = new Image[]
			{
				Image.FromFile(GameController.ImagePath + "Slide__000.png"),
				Image.FromFile(GameController.ImagePath + "Slide__001.png"),
				Image.FromFile(GameController.ImagePath + "Slide__002.png"),
				Image.FromFile(GameController.ImagePath + "Slide__003.png"),
				Image.FromFile(GameController.ImagePath + "Slide__004.png"),
				Image.FromFile(GameController.ImagePath + "Slide__005.png"),
				Image.FromFile(GameController.ImagePath + "Slide__006.png"),
				Image.FromFile(GameController.ImagePath + "Slide__007.png"),
				Image.FromFile(GameController.ImagePath + "Slide__008.png"),
				Image.FromFile(GameController.ImagePath + "Slide__009.png"),
			};

			GameController.SpriteBlocks = new Image[]
			{
				Image.FromFile(GameController.ImagePath + "DirtBottom.png"),
				Image.FromFile(GameController.ImagePath + "DirtMiddle.png"),
			};

			GameController.SpriteObstacle = new Image[]
			{
				Image.FromFile(GameController.ImagePath + "Crate.png"),
				Image.FromFile(GameController.ImagePath + "Saw.png")
			};
		}

		private void SpawnPlayer()
		{
			new Runner(2, 50);
		}

		public void Tick()
		{
			if (Counter > CounterInterval)
			{
				Counter = 0;
				SpawnRandomObstacle();
			}
			else
				Counter++;
		}

		private void SpawnRandomObstacle()
		{
			Random r = new Random();

			switch (r.Next(1,5))
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
				case 4:
					SpawnSaw(GameController.Platform.Y - GameController.runnerSlide.Height - 4, 3);
					break;
				default:
					break;
			}
		}

		private void SpawnSaw(int height, int ammount)
		{
			for (int i = 1; i <= ammount; i++)
			{
				new Obstacle(ObstacleType.CircularSaw, GameController.spawnObjectLocation, height - GameController.sawSize.Height * i);
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
				for (int j = 1; j <= boxes[i]; j++)
				{
					new Obstacle(ObstacleType.Box, GameController.spawnObjectLocation + i * GameController.blockSize.Height, GameController.Platform.Y - GameController.blockSize.Height * j - 5);
				}
			}
		}
	}
}
