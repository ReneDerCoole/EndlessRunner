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
		public Size Size { get; set; }

		public virtual Rectangle GetHitbox()
		{
			return new Rectangle(Location, Size);
		}

		public abstract void Tick();

		public abstract Image GetImage();
	}
}
