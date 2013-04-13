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
        /// Player 1's score.
        /// </summary>
        int player1Score = 0;
        /// <summary>
        /// Player 2's score.
        /// </summary>
        int player2Score = 0;

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
                if (player1Position.Y > 0)
                {
                    player1Position.Y += -10;
                }
            }
            //player1 move down
            if (e.KeyCode == Keys.S)
            {
                //Stop the bar from going off the screen on the bottom
                if (player1Position.Y < gameScreen.Height - 64)
                {
                    player1Position.Y += 10;
                }
            }
            //sets player1 position and refresh
            gameScreen.setSpritePosition(0, player1Position.X, player1Position.Y);

            //player2 move up
            if (e.KeyData == Keys.I)
            {
                //Stop the bar from going off the screen on the top
                if (player2Position.Y > 0)
                {
                    player2Position.Y += -10;
                }
            }
            //player2 move down
            if (e.KeyData == Keys.K)
            {
                //Stop the bar from going off the screen on the bottom
                if (player2Position.Y < gameScreen.Height - 64)
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
            player1Position.X = 0;
            player1Position.Y = 0;
            player2Position.X = gameScreen.Width - 32;
            player2Position.Y = 0;

            ballPosition.X = gameScreen.Width / 2 - 16;
            ballPosition.Y = gameScreen.Height / 2 - 32;

            ballVelocity.X = 1;
            ballVelocity.Y = 1;
            
            gameScreen.addSprite(0, Image.FromFile("images/player1.png"), player1Position.X, player1Position.Y);
            gameScreen.addSprite(1, Image.FromFile("images/player2.png"), player2Position.X, player2Position.Y);
            gameScreen.addSprite(2, Image.FromFile("images/ball.png"), ballPosition.X, ballPosition.Y);

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
            if (player1Score > 9)
            {
                gamePlayTimer.Stop();
                MessageBox.Show("Player 1 Wins!", "Game Over");
                this.Close();
            }
            if (player2Score > 9)
            {
                gamePlayTimer.Stop();
                MessageBox.Show("Player 2 Wins!", "Game Over");
                this.Close();
            }
            if (gameScreen.checkCollision(0, 2) || gameScreen.checkCollision(1, 2))
            {
                ballVelocity.X *= -1;
            }
            ballPosition.X += ballVelocity.X;
            ballPosition.Y += ballVelocity.Y;
            if (ballPosition.Y < 0)
            {
                ballPosition.Y = 0;
                ballVelocity.Y *= -1;
            }
            if (ballPosition.X < 0)
            {
                player2Score++;
                player2ScoreLabel.Text = "Player 2 Score: " + player2Score;
                ballPosition.X = gameScreen.Width / 2 - 16;
                ballPosition.Y = gameScreen.Height / 2 - 32;

                ballVelocity.X = 1;
                ballVelocity.Y = 1;
            }
            if (ballPosition.Y > gameScreen.Height - 32)
            {
                ballPosition.Y = gameScreen.Height - 32;
                ballVelocity.Y *= -1;
            }
            if (ballPosition.X > gameScreen.Width - 32)
            {
                player1Score++;
                player1ScoreLabel.Text = "Player 1 Score: " + player1Score;
                ballPosition.X = gameScreen.Width / 2 - 16;
                ballPosition.Y = gameScreen.Height / 2 - 32;

                ballVelocity.X = 1;
                ballVelocity.Y = 1;
            }
            gameScreen.setSpritePosition(2, ballPosition.X, ballPosition.Y);
            gameScreen.Refresh();
        }
    }
}
