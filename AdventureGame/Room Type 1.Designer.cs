namespace AdventureGame
{
    partial class Adventure
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.sprTimer = new System.Windows.Forms.Timer(this.components);
            this.eneTimer = new System.Windows.Forms.Timer(this.components);
            this.healthBar = new System.Windows.Forms.ProgressBar();
            this.colTimer = new System.Windows.Forms.Timer(this.components);
            this.healthLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sprTimer
            // 
            this.sprTimer.Enabled = true;
            this.sprTimer.Tick += new System.EventHandler(this.sprTimer_Tick);
            // 
            // eneTimer
            // 
            this.eneTimer.Enabled = true;
            this.eneTimer.Tick += new System.EventHandler(this.eneTimer_Tick);
            // 
            // healthBar
            // 
            this.healthBar.Location = new System.Drawing.Point(407, 5);
            this.healthBar.Name = "healthBar";
            this.healthBar.Size = new System.Drawing.Size(100, 23);
            this.healthBar.TabIndex = 0;
            // 
            // colTimer
            // 
            this.colTimer.Enabled = true;
            this.colTimer.Tick += new System.EventHandler(this.colTimer_Tick);
            // 
            // healthLabel
            // 
            this.healthLabel.AutoSize = true;
            this.healthLabel.BackColor = System.Drawing.Color.Transparent;
            this.healthLabel.Location = new System.Drawing.Point(362, 9);
            this.healthLabel.Name = "healthLabel";
            this.healthLabel.Size = new System.Drawing.Size(41, 13);
            this.healthLabel.TabIndex = 1;
            this.healthLabel.Text = "Health:";
            // 
            // Adventure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::AdventureGame.Properties.Resources.FloorBigStoneBrown;
            this.ClientSize = new System.Drawing.Size(512, 512);
            this.Controls.Add(this.healthLabel);
            this.Controls.Add(this.healthBar);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Gold;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Adventure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adventure";
            this.Load += new System.EventHandler(this.Adventure_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Adventure_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Adventure_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer sprTimer;
        private System.Windows.Forms.Timer eneTimer;
        private System.Windows.Forms.ProgressBar healthBar;
        private System.Windows.Forms.Timer colTimer;
        private System.Windows.Forms.Label healthLabel;
    }
}

