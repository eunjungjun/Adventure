using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventureGame
{
    public partial class LevelScreen : Form
    {
        bool end = false;

        int initialHealth = 1000;
        int initialLevel = 1;

        Adventure AdventureForm = new Adventure();
        int currentHealth;
        int currentLevel;

        public LevelScreen()
        {
            InitializeComponent();
            AdventureForm = new Adventure(initialHealth, initialLevel, this);
            currentHealth = AdventureForm.getHealth();
            currentLevel = AdventureForm.getLevel();
        }

        void LevelScreen_KeyDown(object sender, KeyEventArgs e)
        {
            //Moves on to next floor
            if (e.KeyCode == Keys.Up && end == false)
                {
                    AdventureForm = new Adventure(currentHealth, currentLevel, this);
                    AdventureForm.Show();
                    this.Hide();
                }
         }

        //Gets health and level for next floor, switches to end screen if health was 0
        public void setHealth(int value)
        {
            this.currentHealth = value;
            if (currentHealth == 0)
            {
                end = true;
                this.BackgroundImage = Properties.Resources.EndScreen;
                levelLabel.Hide();
                playAgainButton.Visible = true;
                resultLabel.Visible = true;
                resultLabel.Text = "FLOOR " + currentLevel.ToString();
            }
        }

        public void setLevel(int value)
        {
            this.currentLevel = value;
            levelLabel.Text = "FLOOR " + currentLevel.ToString();
        }

        //Restarts game
        private void playAgainButton_Click(object sender, EventArgs e)
        {
            StartMenu startMenu = new StartMenu();
            startMenu.Show();
            this.Close();
        }
    }  
}
