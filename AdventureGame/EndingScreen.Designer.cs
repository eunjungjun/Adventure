namespace AdventureGame
{
    partial class EndingScreen
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
            this.dd = new System.Windows.Forms.Button();
            this.aa = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dd
            // 
            this.dd.Location = new System.Drawing.Point(12, 12);
            this.dd.Name = "dd";
            this.dd.Size = new System.Drawing.Size(115, 55);
            this.dd.TabIndex = 0;
            this.dd.Text = "Eat Again!";
            this.dd.UseVisualStyleBackColor = true;
            this.dd.Click += new System.EventHandler(this.playAgainButton_Click);
            // 
            // aa
            // 
            this.aa.AutoSize = true;
            this.aa.BackColor = System.Drawing.Color.Transparent;
            this.aa.Font = new System.Drawing.Font("Algerian", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aa.ForeColor = System.Drawing.Color.DarkRed;
            this.aa.Location = new System.Drawing.Point(390, 9);
            this.aa.Name = "aa";
            this.aa.Size = new System.Drawing.Size(110, 26);
            this.aa.TabIndex = 1;
            this.aa.Text = "FLOOR 1";
            // 
            // EndingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AdventureGame.Properties.Resources.EndScreen;
            this.ClientSize = new System.Drawing.Size(512, 512);
            this.Controls.Add(this.aa);
            this.Controls.Add(this.dd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EndingScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EndingScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button dd;
        private System.Windows.Forms.Label aa;
    }
}