using AdventureGame.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventureGame
{
    public partial class Adventure : Form
    {
        //Accesses resources
        ResourceManager rm = Resources.ResourceManager;

        //Bitmap images
        Bitmap dogImg1;
        Bitmap dogImg2;
        Bitmap stairs;

        //booleans
        bool right;
        bool left;
        bool up;
        bool down;
        bool wasright = true;

        //integers
        int x = 0;
        int b = 0;
        int c = 0;
        int a = 0;
        int foodCount = 0;
        int foodAmount;
        int health = 1000;
        int floor = 1;
        int enemyNum = 0;
        int stairRanLocX = 0;
        int stairRanLocY = 0;

        //Random number generator
        Random randomGen = new Random();

        //List of ints
        int[] wallNumList;
        int[] eneNumList;
        int[] foodNumList;

        //Individual rectangle sprites
        Rectangle DogSpr;
        Rectangle stair;

        //Bitmap, rectangle lists
        Bitmap[] wallTextureList;
        Rectangle[] wallsToDraw;

        Bitmap[] enemyTextures;
        Rectangle[] enemyLocs;

        Bitmap[] foodPics;
        Rectangle[] foodLocs;

        LevelScreen levelForm;

        public Adventure()
        {

        }

        public Adventure(int healthValue, int curLevel, LevelScreen formValue)
        {
            this.health = healthValue;
            this.floor = curLevel;
            this.levelForm = formValue;

            InitializeComponent();

            //Set bitmap image
            dogImg1 = (Bitmap)rm.GetObject("Dog");
            dogImg2 = (Bitmap)rm.GetObject("Dog2");
            stairs = (Bitmap)rm.GetObject("Stairs");

            //Determines stair's random location
            stairRanLocX = randomGen.Next(1, 15);
            stairRanLocY = randomGen.Next(1, 15);
            stair = new Rectangle(-32, -32, 32, 32);

            //Determines wall texture, placement
            int wallNum = randomGen.Next(0, 7);

            wallNumList = new int[60];
            for (int a = 0; a < wallNumList.Length; a++)
            {
                wallNum = randomGen.Next(0, 7);
                wallNumList[a] = wallNum;
            }

            wallTextureList = new Bitmap[7];
            for (int i = 0; i < wallTextureList.Length; i++)
            {
                wallTextureList[i] = (Bitmap)rm.GetObject("GrayWall" + i);
            }

            wallsToDraw = new Rectangle[60];
            for (int j = 0; j < wallsToDraw.Length; j += 4)
            {
                wallsToDraw[j] = new Rectangle(x, 0, 32, 32);
                wallsToDraw[j + 1] = new Rectangle(480, x, 32, 32);
                wallsToDraw[j + 2] = new Rectangle(0, x, 32, 32);
                wallsToDraw[j + 3] = new Rectangle(x, 480, 32, 32);
                x += 32;
                wallsToDraw[2] = new Rectangle(480, 480, 32, 32);
            }

            //Determines enemy textures, placement, numbers
            enemyTextures = new Bitmap[3];
            for (int k = 0; k < enemyTextures.Length; k++)
            {
                enemyTextures[k] = (Bitmap)rm.GetObject("Enemy" + k);
            }

            if (1 <= floor && floor <= 5)
            {
                enemyNum = randomGen.Next(1, 11);
            }

            if (6 <= floor && floor <= 10)
            {
                enemyNum = randomGen.Next(10, 21);
            }

            if (floor >= 11)
            {
                enemyNum = randomGen.Next(20, 31);
            }

            int enemyRanLocX = randomGen.Next(1, 15);
            int enemyRanLocY = randomGen.Next(1, 15);
            enemyLocs = new Rectangle[enemyNum];
            for (int l = 0; l < enemyLocs.Length; l++)
            {
                enemyRanLocX = randomGen.Next(1, 15);
                enemyRanLocY = randomGen.Next(1, 15);
                enemyLocs[l] = new Rectangle(32 * enemyRanLocX, 32 * enemyRanLocY, 32, 32);
            }

            int eneNum = randomGen.Next(0, 3);
            eneNumList = new int[enemyNum];
            for (int m = 0; m < eneNumList.Length; m++)
            {
                eneNum = randomGen.Next(0, 3);
                eneNumList[m] = eneNum;
            }

            //Determines food texture, location, numbers
            foodPics = new Bitmap[21];
            for (int n = 0; n < foodPics.Length; n++)
            {
                foodPics[n] = (Bitmap)rm.GetObject("Food" + n);
            }

            foodAmount = randomGen.Next(1, 21);
            foodCount = foodAmount;
            int foodNum = randomGen.Next(0, 21);

            foodNumList = new int[foodAmount];
            for (int z = 0; z < foodNumList.Length; z++)
            {
                foodNum = randomGen.Next(0, 21);
                foodNumList[z] = foodNum;
            }

            int foodRanLocX = randomGen.Next(1, 15);
            int foodRanLocY = randomGen.Next(1, 15);
            foodLocs = new Rectangle[foodAmount];
            for (int n = 0; n < foodLocs.Length; n++)
            {
                foodRanLocX = randomGen.Next(1, 15);
                foodRanLocY = randomGen.Next(1, 15);
                foodLocs[n] = new Rectangle(32 * foodRanLocX, 32 * foodRanLocY, 32, 32);              
            }

            //Sets up rectangle for Dog sprite
            int dogRanLocX = randomGen.Next(1, 15);
            int dogRanLocY = randomGen.Next(1, 15);
            DogSpr = new Rectangle(32 * dogRanLocX, 32 * dogRanLocY, 32, 32);

            //Sets health
            healthBar.Maximum = 1000;
            healthBar.Value += 1000;
        }

        private void Adventure_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

            this.Paint += new PaintEventHandler(Adventure_Paint);
        }

        private void Adventure_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            //Stairs show up when food is 0
            if (foodCount == 0)
            {
                stair.X = 32 * stairRanLocX;
                stair.Y = 32 * stairRanLocY;
                e.Graphics.DrawImage(stairs, stair);
            }

            //Draws wall, textures, foods in proper locations
            foreach (Rectangle rec in wallsToDraw)
            {
                e.Graphics.DrawImage(wallTextureList[wallNumList[c]], rec);
                c += 1;
            }
            c = 0;

            foreach (Rectangle eneRec in enemyLocs)
            {
                e.Graphics.DrawImage(enemyTextures[eneNumList[b]], eneRec);
                b += 1;
            }
            b = 0;

            foreach (Rectangle foodRec in foodLocs)
            {
                e.Graphics.DrawImage(foodPics[foodNumList[a]], foodRec);
                a += 1;
            }
            a = 0;

            //Determines if dog should face left or right
            if (wasright == false)
            {
                e.Graphics.DrawImage(dogImg1, DogSpr.X + 5, DogSpr.Y + 6, 22, 19);
            }

            if (wasright == true)
            {
                e.Graphics.DrawImage(dogImg2, DogSpr.X + 5, DogSpr.Y + 6, 22, 19);
            }
        }

        private void sprTimer_Tick(object sender, EventArgs e)
        {
            healthBar.Value = health;

            //Determines movement of dog, health of dog
            if (DogSpr.X >= 448)
            {
                right = false;
            }

            if (DogSpr.X <= 32)
            {
                left = false;
            }

            if (DogSpr.Y <= 32)
            {
                up = false;
            }

            if (DogSpr.Y >= 448)
            {
                down = false;
            }

            if (right == true)
            {
                DogSpr.X += 32;

                if (health - 10 < 0)
                {
                    health = 0;
                }

                else
                {
                    health -= 10;
                }
            }

            if (left == true)
            {
                DogSpr.X -= 32;
                if (health - 10 < 0)
                {
                    health = 0;
                }

                else
                {
                    health -= 10;
                }
            }

            if (up == true)
            {
                DogSpr.Y -= 32;
                if (health - 10 < 0)
                {
                    health = 0;
                }

                else
                {
                    health -= 10;
                }
            }

            if (down == true)
            {
                DogSpr.Y += 32;
                if (health - 10 < 0)
                {
                    health = 0;
                }

                else
                {
                    health -= 10;
                }
            }

            Invalidate();
        }

        private void Adventure_KeyDown(object sender, KeyEventArgs e)
        {
            //Sets booleans to true if key is down
            if (e.KeyCode == Keys.Right)
            {
                right = true;
                wasright = true;
            }

            if (e.KeyCode == Keys.Left)
            {
                left = true;
                wasright = false;
            }

            if (e.KeyCode == Keys.Up)
            {
                up = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                down = true;
            }
        }

        private void Adventure_KeyUp(object sender, KeyEventArgs e)
        {
            //Sets boolenas to false if key is up
            if (e.KeyCode == Keys.Right)
            {
                right = false;
            }

            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }

            if (e.KeyCode == Keys.Up)
            {
                up = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                down = false;
            }
        }

        private void eneTimer_Tick(object sender, EventArgs e)
        {
            //Determines enemy random movement
            int eneMoveX = randomGen.Next(-1, 2);
            int eneMoveY = randomGen.Next(-1, 2);

            for (int eneMv = 0; eneMv < enemyLocs.Length; eneMv++)
            {
                eneMoveX = randomGen.Next(-1, 2);
                eneMoveY = randomGen.Next(-1, 2);

                enemyLocs[eneMv].X = enemyLocs[eneMv].X + (32 * eneMoveX);
                enemyLocs[eneMv].Y = enemyLocs[eneMv].Y + (32 * eneMoveY);

                if (enemyLocs[eneMv].X >= 448)
                {
                    enemyLocs[eneMv].X = 448;
                }

                if (enemyLocs[eneMv].X <= 32)
                {
                    enemyLocs[eneMv].X = 32;
                }

                if (enemyLocs[eneMv].Y <= 32)
                {
                    enemyLocs[eneMv].Y = 32;
                }

                if (enemyLocs[eneMv].Y >= 448)
                {
                    enemyLocs[eneMv].Y = 448;
                }
                Invalidate();
            }
        }

        private void colTimer_Tick(object sender, EventArgs e)
        {
            //Brings dog to next level, switch forms
            if (DogSpr.IntersectsWith(stair))
            {
                floor += 1;
                this.levelForm.setHealth(getHealth());
                this.levelForm.setLevel(getLevel());
                levelForm.Show();
                this.Close();
            }

            //Determines if dog's health goes up or down
            int damageRan = randomGen.Next(25, 101);
            int healthRan = randomGen.Next(300, 501);

            foreach (Rectangle eneRec in enemyLocs)
            {
                damageRan = randomGen.Next(25, 101);

                for (int t = 0; t < foodLocs.Length; t++)
                {
                    if (eneRec.IntersectsWith(foodLocs[t]))
                    {
                        foodLocs[t].X = -32;
                        foodLocs[t].Y = -32;
                        foodCount -= 1;
                    }
                }

                if (DogSpr.IntersectsWith(eneRec))
                {
                    if (health - damageRan < 0)
                    {
                        health = 0;
                    }

                    else
                    {
                        health -= damageRan;
                    }
                }
            }

            for (int s = 0; s < foodLocs.Length; s++)
            {
                healthRan = randomGen.Next(500, 601);

                if (DogSpr.IntersectsWith(foodLocs[s]))
                {

                    foodLocs[s].X = -32;
                    foodLocs[s].Y = -32;
                    foodCount -= 1;

                    if (health != 0)
                    {
                        if (health + healthRan > 1000)
                        {
                            health = 1000;
                        }

                        else
                        {
                            health += healthRan;
                        }
                    }

                    if (health == 0)
                    {
                        health += 0;
                    }
                }
            }
        }

        //Methods for getting current health and floor
        public int getHealth()
        {
            return this.health;
        }
        public int getLevel()
        {
            return this.floor;
        }
    }
}
