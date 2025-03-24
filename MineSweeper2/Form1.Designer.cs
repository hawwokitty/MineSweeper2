namespace MineSweeper2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            welcomeLabel = new Label();
            numOfBombsLabel = new Label();
            bombsLabel = new Label();
            restartButton = new Button();
            SuspendLayout();
            // 
            // welcomeLabel
            // 
            welcomeLabel.AutoSize = true;
            welcomeLabel.Location = new Point(12, 9);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(147, 15);
            welcomeLabel.TabIndex = 0;
            welcomeLabel.Text = "Welcome to Minesweeper!";
            // 
            // numOfBombsLabel
            // 
            numOfBombsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numOfBombsLabel.AutoSize = true;
            numOfBombsLabel.BorderStyle = BorderStyle.FixedSingle;
            numOfBombsLabel.Location = new Point(353, 9);
            numOfBombsLabel.Name = "numOfBombsLabel";
            numOfBombsLabel.Size = new Size(15, 17);
            numOfBombsLabel.TabIndex = 1;
            numOfBombsLabel.Text = "0";
            // 
            // bombsLabel
            // 
            bombsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bombsLabel.AutoSize = true;
            bombsLabel.Location = new Point(300, 9);
            bombsLabel.Name = "bombsLabel";
            bombsLabel.Size = new Size(47, 15);
            bombsLabel.TabIndex = 2;
            bombsLabel.Text = "Bombs:";
            // 
            // restartButton
            // 
            restartButton.Location = new Point(196, 5);
            restartButton.Name = "restartButton";
            restartButton.Size = new Size(75, 23);
            restartButton.TabIndex = 3;
            restartButton.Text = "Restart";
            restartButton.UseVisualStyleBackColor = true;
            restartButton.Click += RestartButtonClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 449);
            Controls.Add(restartButton);
            Controls.Add(bombsLabel);
            Controls.Add(numOfBombsLabel);
            Controls.Add(welcomeLabel);
            Name = "Form1";
            Text = "Minesweeper";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label welcomeLabel;
        public Label numOfBombsLabel;
        private Label bombsLabel;
        private Button restartButton;
    }
}
