namespace EndlessRunner
{
	partial class Main
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.gameTimer = new System.Windows.Forms.Timer(this.components);
			this.panelTop = new System.Windows.Forms.Panel();
			this.panelBottum = new System.Windows.Forms.Panel();
			this.runner1 = new EndlessRunner.Runner();
			this.buttonStop = new EndlessRunner.CustomButton();
			this.buttonPlay = new EndlessRunner.CustomButton();
			this.buttonQuit = new EndlessRunner.CustomButton();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// gameTimer
			// 
			this.gameTimer.Enabled = true;
			this.gameTimer.Interval = 17;
			this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
			// 
			// panelTop
			// 
			this.panelTop.BackgroundImage = global::EndlessRunner.Properties.Resources.DirtMiddle;
			this.panelTop.Location = new System.Drawing.Point(0, 658);
			this.panelTop.Name = "panelTop";
			this.panelTop.Size = new System.Drawing.Size(1500, 64);
			this.panelTop.TabIndex = 1;
			// 
			// panelBottum
			// 
			this.panelBottum.BackgroundImage = global::EndlessRunner.Properties.Resources.DirtBottum;
			this.panelBottum.Location = new System.Drawing.Point(0, 721);
			this.panelBottum.Name = "panelBottum";
			this.panelBottum.Size = new System.Drawing.Size(1500, 29);
			this.panelBottum.TabIndex = 2;
			// 
			// runner1
			// 
			this.runner1.Location = new System.Drawing.Point(96, 379);
			this.runner1.Name = "runner1";
			this.runner1.PicState = 0;
			this.runner1.Score = 0;
			this.runner1.Size = new System.Drawing.Size(77, 180);
			this.runner1.TabIndex = 8;
			this.runner1.Velocity = 0D;
			// 
			// buttonStop
			// 
			this.buttonStop.BackgroundImage = global::EndlessRunner.Properties.Resources.ButtonStopLocked;
			this.buttonStop.Enable = false;
			this.buttonStop.Location = new System.Drawing.Point(83, 13);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.PicClick = global::EndlessRunner.Properties.Resources.ButtonStopClick;
			this.buttonStop.PicHover = global::EndlessRunner.Properties.Resources.ButtonStopHover;
			this.buttonStop.PicLocked = global::EndlessRunner.Properties.Resources.ButtonStopLocked;
			this.buttonStop.PicNormal = global::EndlessRunner.Properties.Resources.ButtonStopNormal;
			this.buttonStop.Size = new System.Drawing.Size(64, 64);
			this.buttonStop.TabIndex = 7;
			this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
			// 
			// buttonPlay
			// 
			this.buttonPlay.BackColor = System.Drawing.Color.Transparent;
			this.buttonPlay.BackgroundImage = global::EndlessRunner.Properties.Resources.ButtonPlayNormal;
			this.buttonPlay.Enable = true;
			this.buttonPlay.Location = new System.Drawing.Point(12, 12);
			this.buttonPlay.Name = "buttonPlay";
			this.buttonPlay.PicClick = global::EndlessRunner.Properties.Resources.ButtonPlayClick;
			this.buttonPlay.PicHover = global::EndlessRunner.Properties.Resources.ButtonPlayHover;
			this.buttonPlay.PicLocked = global::EndlessRunner.Properties.Resources.ButtonPlayLocked;
			this.buttonPlay.PicNormal = global::EndlessRunner.Properties.Resources.ButtonPlayNormal;
			this.buttonPlay.Size = new System.Drawing.Size(64, 64);
			this.buttonPlay.TabIndex = 6;
			this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
			// 
			// buttonQuit
			// 
			this.buttonQuit.BackColor = System.Drawing.Color.Transparent;
			this.buttonQuit.BackgroundImage = global::EndlessRunner.Properties.Resources.ButtonQuitNormal;
			this.buttonQuit.Enable = true;
			this.buttonQuit.Location = new System.Drawing.Point(924, 12);
			this.buttonQuit.Name = "buttonQuit";
			this.buttonQuit.PicClick = global::EndlessRunner.Properties.Resources.ButtonQuitClick;
			this.buttonQuit.PicHover = global::EndlessRunner.Properties.Resources.ButtonQuitHover;
			this.buttonQuit.PicLocked = global::EndlessRunner.Properties.Resources.ButtonQuitLocked;
			this.buttonQuit.PicNormal = global::EndlessRunner.Properties.Resources.ButtonQuitNormal;
			this.buttonQuit.Size = new System.Drawing.Size(64, 64);
			this.buttonQuit.TabIndex = 3;
			this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click_1);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(153, 13);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 9;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(1000, 750);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.runner1);
			this.Controls.Add(this.buttonStop);
			this.Controls.Add(this.buttonPlay);
			this.Controls.Add(this.buttonQuit);
			this.Controls.Add(this.panelBottum);
			this.Controls.Add(this.panelTop);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Main";
			this.Text = "NinjaEscape";
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Timer gameTimer;
		private CustomButton buttonQuit;
		private CustomButton buttonPlay;
		private CustomButton buttonStop;
		public System.Windows.Forms.Panel panelTop;
		public System.Windows.Forms.Panel panelBottum;
		private Runner runner1;
		private System.Windows.Forms.Button button1;
	}
}

