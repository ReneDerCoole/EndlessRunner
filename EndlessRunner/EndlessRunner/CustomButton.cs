using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EndlessRunner
{
	public partial class CustomButton : Panel
	{
		public Image PicNormal { get; set; }
		public Image PicHover { get; set; }
		public Image PicClick { get; set; }
		public Image PicLocked { get; set; }
		public bool Enable { get; set; }


		public CustomButton()
		{
			InitializeComponent();
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			if (!Enable)
				return;
			BackgroundImage = PicHover;
			base.OnMouseEnter(e);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			if (!Enable)
				return;
			BackgroundImage = PicNormal;
			base.OnMouseLeave(e);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (!Enable)
				return;
			BackgroundImage = PicClick;
			base.OnMouseClick(e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (!Enable)
				return;

			BackgroundImage = PicHover;
			base.OnMouseUp(e);
		}

		public void Lock()
		{
			Enable = false;
			BackgroundImage = PicLocked;
		}

		public void Unlock()
		{
			Enable = true;
			BackgroundImage = PicNormal;
		}

		public void Toggle()
		{
			if (Enable)
				Lock();
			else
				Unlock();
		}
	}
}
