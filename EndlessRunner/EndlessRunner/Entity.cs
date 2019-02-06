using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace EndlessRunner
{
	public abstract class Entity
	{
		public Point Location { get; set; }

		public abstract Rectangle GetHitbox();

		public abstract void Tick();

		public abstract Image GetImage();
	}
}
