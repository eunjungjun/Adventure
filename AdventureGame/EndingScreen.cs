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
    public partial class EndingScreen : Form
    {
        int currentLevel;

        public EndingScreen()
        {
            InitializeComponent();
        }

        private void playAgainButton_Click(object sender, EventArgs e)
        {
            StartMenu StartMenuForm = new StartMenu();
            StartMenuForm.Show();
            this.Close();
        }

        public void setLevel(int value)
        {
            this.currentLevel = value;
            aa.Text = "FLOOR " + currentLevel.ToString();
        }
    }
}
