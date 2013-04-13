using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CNU_ACM_IEEE_Pong
{
    public partial class mainForm : Form
    {
        /// <summary>
        /// The velocity for the ball.
        /// </summary>
        Point ballVelocity = Point.Empty;
        /// <summary>
        /// The position for the ball.
        /// </summary>
        Point ballPosition = Point.Empty;

        /// <summary>
        /// The position of player 1.
        /// </summary>
        Point player1Position = Point.Empty;
        /// <summary>
        /// The position of player 2.
        /// </summary>
        Point player2Position = Point.Empty;

        /// <summary>
        /// The timer for the gameplay.  Updates
        /// the gameplay every 1ms.
        /// </summary>
        Timer gamePlayTimer = new Timer();

        public mainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Created by Courtney Duquette.
        /// This method handles key pressed for the game.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Used to get the key pressed from the user.</param>
        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            //escape key will exit out of sceen
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            //player1 move up
            if (e.KeyCode == Keys.W)
            {
                //Stop the bar from going off the screen on the top
                if (player1Position.Y < 0 || player1Position.Y > 0)
                {
                    player1Position.Y += -10;
                }
            }
            //player1 move down
            if (e.KeyCode == Keys.S)
            {
                //Stop the bar from going off the screen on the bottom
                if (player1Position.Y < 416 || player1Position.Y < 416)
                {
                    player1Position.Y += 10;
                }
            }
            //sets player1 position and refresh
            gameScreen.setSpritePosition(0, player1Position.X, player1Position.Y);
            gameScreen.Refresh();

            //player2 move up
            if (e.KeyCode == Keys.Up)
            {
                //Stop the bar from going off the screen on the top
                if (player2Position.Y < 0 || player2Position.Y > 0)
                {
                    player2Position.Y += -10;
                }
            }
            //player2 move down
            if (e.KeyCode == Keys.Down)
            {
                //Stop the bar from going off the screen on the bottom
                if (player2Position.Y < 416 || player2Position.Y < 416)
                {
                    player2Position.Y += 10;
                }
            }
            //sets player2 position and refresh
            gameScreen.setSpritePosition(1, player2Position.X, player2Position.Y);
            gameScreen.Refresh();
        }

        /// <summary>
        /// Created by Gerald McAlister.
        /// This method loads the game's graphics and positions them to the correct spots.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        private void mainForm_Load(object sender, EventArgs e)
        {
            gameScreen.addSprite(0, Image.FromFile("images/player1.png"), 0, 0);
            gameScreen.addSprite(1, Image.FromFile("images/player2.png"), gameScreen.Width - 32, 0);
            gameScreen.addSprite(2, Image.FromFile("images/ball.png"), gameScreen.Width / 2 - 16, gameScreen.Height / 2 - 32);

            gamePlayTimer.Interval = 1;
            gamePlayTimer.Tick += new EventHandler(gamePlayTimer_Tick);
            gamePlayTimer.Start();
        }

        /// <summary>
        /// Created by Elliot Rieflin.
        /// This method updates the gamemplay of the game.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        void gamePlayTimer_Tick(object sender, EventArgs e)
        {
        }
    }
}
