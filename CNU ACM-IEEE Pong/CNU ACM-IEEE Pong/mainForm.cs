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
        Point player1Position = Point.Empty;
        Point player2Position = Point.Empty;

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
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.W)
            {
                player1Position.Y += -1;
            }

            gameScreen.setSpritePosition(0, player1Position.X, player1Position.Y);
            gameScreen.Refresh();
        }

        /// <summary>
        /// Created by Elliot Rieflin.
        /// This method loads the game's graphics and positions them to the correct spots.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        private void mainForm_Load(object sender, EventArgs e)
        {
            gameScreen.addSprite(0, Image.FromFile("images/player1.png"), 0, 0);
        }
    }
}
