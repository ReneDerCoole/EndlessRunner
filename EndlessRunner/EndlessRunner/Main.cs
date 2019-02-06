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

			new LevelGenerator(100);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics g = e.Graphics;

			foreach (Point point in GameController.Platform.GetBottomImagePoints())
			{
				g.DrawImage(GameController.SpriteBlocks[0], new Rectangle(point, GameController.blockSize));
			}

			foreach (Point point in GameController.Platform.GetTopImagePoints())
			{
				g.DrawImage(GameController.SpriteBlocks[1], new Rectangle(point, GameController.blockSize));
			}

			foreach (Entity entity in GameController.Obstacle)
			{
				g.DrawImage(entity.GetImage(), entity.GetHitbox());
			}

			foreach (Runner runner in GameController.Runners)
			{
				g.DrawImage(runner.GetImage(), runner.GetHitbox());
			}

			//if (GameController.Runners.Count > 0)
			//g.DrawRectangle(Pens.Blue, GameController.Runners[0].GetHitbox());


			for (int i = 0; i < GameController.debugString.Length; i++)
			{
				g.DrawString(GameController.debugString[i], new Font(new FontFamily("Comic Sans MS"), 12), Brushes.DarkRed, new Point(300, 10 + 15 * i));
			}
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void ButtonPlay_Click(object sender, EventArgs e)
		{
			foreach (Runner runner in GameController.Runners)
			{
				runner.PicCounterInterval = 1;
				runner.PicState = 9;
				runner.State = State.Jump;
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

		private void Main_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (GameController.Runners.Count > 0)
				switch (e.KeyChar)
				{
					case 'w':
						GameController.Runners[0].Jump();
						break;
					case 's':
						GameController.Runners[0].Slide();
						break;
					default:
						break;
				}
		}
	}
}
