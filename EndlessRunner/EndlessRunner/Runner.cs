using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EndlessRunner
{
	public enum State { Idle, Jump, Run, Slide };

	public class Runner : Entity
	{
		public double Velocity { get; set; }
		public int Score { get; set; }
		public int PicState { get; set; }
		public int SlideCounterInterval { get; set; }
		public int SlideCounter { get; set; }
		public int PicCounterInterval { get; set; }
		public int PicCouter { get; set; }
		public State State { get; set; }


		public Runner(int picInterval, int slideInterval)
		{
			GameController.Runners.Add(this);
			Location = GameController.spawnPoint;
			PicCounterInterval = picInterval;
			SlideCounterInterval = slideInterval;
		}

		public override Image GetImage()
		{
			switch (State)
			{
				case State.Idle:
					return GameController.SpriteIdle[PicState];
				case State.Jump:
					return GameController.SpriteJump[PicState];
				case State.Run:
					return GameController.SpriteRun[PicState];
				case State.Slide:
					return GameController.SpriteSlide[PicState];
				default:
					return null;
			}
		}

		public override Rectangle GetHitbox()
		{
			switch (State)
			{
				case State.Idle:
					return new Rectangle(Location, GameController.runnerIdle);
				case State.Jump:
					return new Rectangle(Location, GameController.runnerJump);
				case State.Run:
					return new Rectangle(Location, GameController.runnerRun);
				case State.Slide:
					return new Rectangle(Location, GameController.runnerSlide);
				default:
					return new Rectangle();
			}
		}

		public void PicTick()
		{
			if (PicCouter >= PicCounterInterval)
			{
				PicCouter = 0;
				if (PicState >= 9)
				{
					if (State != State.Jump)
						PicState = 0;
				}
				else
				{
					if (GameController.GameRun || State == State.Idle)
						PicState++;
				}
			}
			else
				PicCouter++;
		}

		public override void Tick()
		{
			Score++;

			//Gravity
			if(GetHitbox().Bottom != GameController.Platform.Y)
			{
				Rectangle bodyNow = GetHitbox();
				Rectangle bodyFut = GetHitbox();
				Rectangle ground = GameController.Platform.GetHitbox();

				Velocity += GameController.gravity;

				bodyFut.Offset(0, (int)Math.Round(Velocity));

				if (bodyFut.Bottom > ground.Top)
				{
					if (bodyNow.Bottom + 1 != ground.Top)
					{
						bodyFut.Y = ground.Top - bodyNow.Height;
						if(State == State.Jump || State == State.Idle)
							State = State.Run;
					}
				}
				Location = bodyFut.Location;
			}

			//Collision
			foreach (Obstacle box in GameController.Obstacle)
			{
				if (GameController.Intersect(box.GetHitbox(), GetHitbox()))
				{
					GameController.Runners.Remove(this);
				}
			}

			//Slidetimer
			if (State == State.Slide)
			{
				if (SlideCounter >= SlideCounterInterval)
				{
					SlideCounter = 0;
					State = State.Run;
				}
				else
					SlideCounter++;
			}
		}

		public void Jump()
		{
			if (State != State.Jump)
			{
				Velocity = GameController.jumpVelocity;
				State = State.Jump;
				PicState = 0;
			}
		}

		public void Slide()
		{
			
			if (State == State.Run)
			{
				PicState = 0;
				State = State.Slide;
			}
		}
	}
}
