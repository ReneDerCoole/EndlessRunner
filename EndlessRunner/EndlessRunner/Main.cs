using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EndlessRunner
{
	public partial class Main : Form
	{
		public Main()
		{
			InitializeComponent();

			GameController.Main = this;

			new LevelGenerator(new Point(10, 100), 100);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics g = e.Graphics;

			foreach (Point point in GameController.Platform.GetBottomImagePoints())
			{
				g.DrawImage(GameController.SpriteBlocks[0], point.X, point.Y, GameController.SpriteBlocks[0].Width, GameController.SpriteBlocks[0].Height);
			}

			foreach (Point point in GameController.Platform.GetTopImagePoints())
			{
				g.DrawImage(GameController.SpriteBlocks[1], point.X, point.Y, GameController.SpriteBlocks[1].Width, GameController.SpriteBlocks[1].Height);
			}

			foreach (Obstacle box in GameController.Obstacle)
			{
				g.DrawImage(GameController.SpriteObstacle[0], new Rectangle(box.Location, box.Size));
			}

			foreach (Runner runner in GameController.Runners)
			{
				g.DrawImage(runner.GetImage(), runner.Location);
			}

			if (GameController.Runners.Count > 0)
				g.DrawRectangle(Pens.Blue, GameController.Runners[0].GetHitbox());
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void ButtonPlay_Click(object sender, EventArgs e)
		{
			foreach (Runner runner in GameController.Runners)
			{
				runner.CounterInterval = 1;
			}
			Play();
		}

		private void ButtonStop_Click(object sender, EventArgs e)
		{
			Stop();
		}

		private void GameTimer_Tick(object sender, EventArgs e)
		{
			GameController.PicTick();
			GameController.Tick();
			Invalidate();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (GameController.Runners.Count != 0)
			{
				GameController.Runners[0].Jump();
			}
		}

		public void Play()
		{


			GameController.GameRun = true;
			buttonPlay.Lock();
			buttonStop.Unlock();
		}

		public void Stop()
		{
			GameController.GameRun = false;
			buttonStop.Lock();
			buttonPlay.Unlock();
		}

		public void End()
		{
			GameController.GameRun = false;
			buttonStop.Lock();
			buttonPlay.Lock();
		}
	}
}
