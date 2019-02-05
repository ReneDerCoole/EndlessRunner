using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessRunner
{
	public abstract class Barrier
	{
		public Point Location { get; set; }
		public Size Size { get; set; }
	}
}
