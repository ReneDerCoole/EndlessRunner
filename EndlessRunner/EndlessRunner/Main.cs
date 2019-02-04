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
		}

		private void buttonQuit_Click_1(object sender, EventArgs e)
		{
			Close();
		}

		private void buttonPlay_Click(object sender, EventArgs e)
		{
			GameController.GameRun = true;
			buttonPlay.Lock();
			buttonStop.Unlock();
		}

		private void buttonStop_Click(object sender, EventArgs e)
		{
			GameController.GameRun = false;
			buttonStop.Lock();
			buttonPlay.Unlock();
		}

		private void gameTimer_Tick(object sender, EventArgs e)
		{
			GameController.Tick();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			GameController.Runner.Jump();
		}
	}
}
