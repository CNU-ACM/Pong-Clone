namespace CNU_ACM_IEEE_Pong
{
    partial class mainForm
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
            this.gameScreen = new CNU_ACM_IEEE_Pong.GameScreen();
            this.SuspendLayout();
            // 
            // gameScreen
            // 
            this.gameScreen.BackColor = System.Drawing.Color.White;
            this.gameScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gameScreen.Location = new System.Drawing.Point(13, 13);
            this.gameScreen.Name = "gameScreen";
            this.gameScreen.Size = new System.Drawing.Size(599, 416);
            this.gameScreen.TabIndex = 0;
            this.gameScreen.Text = "gameScreen1";
            this.gameScreen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainForm_KeyDown);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.gameScreen);
            this.Name = "mainForm";
            this.Text = "Pong";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private GameScreen gameScreen;
    }
}

