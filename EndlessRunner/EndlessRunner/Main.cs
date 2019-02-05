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

			GameController.SpriteIdle = new Image[]
			{
				Image.FromFile(GameController.MainPath + @"Images\Idle__000.png"),
				Image.FromFile(GameController.MainPath + @"Images\Idle__001.png"),
				Image.FromFile(GameController.MainPath + @"Images\Idle__002.png"),
				Image.FromFile(GameController.MainPath + @"Images\Idle__003.png"),
				Image.FromFile(GameController.MainPath + @"Images\Idle__004.png"),
				Image.FromFile(GameController.MainPath + @"Images\Idle__005.png"),
				Image.FromFile(GameController.MainPath + @"Images\Idle__006.png"),
				Image.FromFile(GameController.MainPath + @"Images\Idle__007.png"),
				Image.FromFile(GameController.MainPath + @"Images\Idle__008.png"),
				Image.FromFile(GameController.MainPath + @"Images\Idle__009.png")
			};

			GameController.SpriteRun = new Image[]
			{
				Image.FromFile(GameController.MainPath + @"Images\Run__000.png"),
				Image.FromFile(GameController.MainPath + @"Images\Run__001.png"),
				Image.FromFile(GameController.MainPath + @"Images\Run__002.png"),
				Image.FromFile(GameController.MainPath + @"Images\Run__003.png"),
				Image.FromFile(GameController.MainPath + @"Images\Run__004.png"),
				Image.FromFile(GameController.MainPath + @"Images\Run__005.png"),
				Image.FromFile(GameController.MainPath + @"Images\Run__006.png"),
				Image.FromFile(GameController.MainPath + @"Images\Run__007.png"),
				Image.FromFile(GameController.MainPath + @"Images\Run__008.png"),
				Image.FromFile(GameController.MainPath + @"Images\Run__009.png")
			};

			GameController.SpriteJump = new Image[]
			{
				Image.FromFile(GameController.MainPath + @"Images\Jump__000.png"),
				Image.FromFile(GameController.MainPath + @"Images\Jump__001.png"),
				Image.FromFile(GameController.MainPath + @"Images\Jump__002.png"),
				Image.FromFile(GameController.MainPath + @"Images\Jump__003.png"),
				Image.FromFile(GameController.MainPath + @"Images\Jump__004.png"),
				Image.FromFile(GameController.MainPath + @"Images\Jump__005.png"),
				Image.FromFile(GameController.MainPath + @"Images\Jump__006.png"),
				Image.FromFile(GameController.MainPath + @"Images\Jump__007.png"),
				Image.FromFile(GameController.MainPath + @"Images\Jump__008.png"),
				Image.FromFile(GameController.MainPath + @"Images\Jump__009.png")
			};

			new Runner(50, 558, 100, 100, 1); 
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics g = e.Graphics;

			g.DrawImage(GameController.Runner.Image, GameController.Runner.Location);
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void ButtonPlay_Click(object sender, EventArgs e)
		{
			GameController.GameRun = true;
			buttonPlay.Lock();
			buttonStop.Unlock();
		}

		private void ButtonStop_Click(object sender, EventArgs e)
		{
			GameController.GameRun = false;
			buttonStop.Lock();
			buttonPlay.Unlock();
		}

		private void GameTimer_Tick(object sender, EventArgs e)
		{
			GameController.PicTick();
			GameController.Tick();

			if (GameController.GameRun)
			{
				panelBottum.Location = new Point(panelBottum.Location.X - 12, panelBottum.Location.Y);
				panelTop.Location = new Point(panelTop.Location.X - 12, panelTop.Location.Y);

				if(panelBottum.Location.X < -128)
					panelBottum.Location = new Point(panelBottum.Location.X + 128, panelBottum.Location.Y);
				if (panelTop.Location.X < -128)
					panelTop.Location = new Point(panelTop.Location.X + 128, panelTop.Location.Y);
			}

			Invalidate();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			GameController.Runner.Jump();
		}
	}
}
