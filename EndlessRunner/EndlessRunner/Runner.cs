using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EndlessRunner
{
	public class Runner : Panel
	{
		public int Score { get; set; }
		public double Velocity { get; set; }
		public int PicState { get; set; }
		
		public Runner()
		{
			GameController.Runner = this;
		}

		public void Tick()
		{
			Velocity += GameController.gravity; 


			Rectangle bodyNow = GameController.PanelToRectangle(this);
			Rectangle bodyFut = GameController.PanelToRectangle(this);
			bodyFut.Offset(0, (int)Math.Round(Velocity));

			Rectangle ground = GameController.PanelToRectangle(GameController.Main.panelTop);


			if(bodyFut.Bottom > ground.Top)
			{
				if(bodyNow.Bottom + 1 != ground.Top)
				{
					bodyFut.Y = ground.Top - bodyNow.Height;
				}
			}

			Location = bodyFut.Location;
		}

		public void Jump()
		{
			Rectangle bodyNow = GameController.PanelToRectangle(this);

			Rectangle ground = GameController.PanelToRectangle(GameController.Main.panelTop);

			if (bodyNow.Bottom == ground.Top)
				Velocity = GameController.jumpVelocity;
		}
	}
}
