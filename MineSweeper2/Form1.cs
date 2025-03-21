using System;

namespace MineSweeper2
{
    public partial class Form1 : Form
    {
        private Button[,] buttons = new Button[9, 9]; 
        private const int buttonSize = 40; 
        private int numOfBombs = 6;
        private List<Point> bombPositions = new List<Point>();
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            try
            {
                Load += (s, e) => CreateGrid();
                numOfBombsLabel.Text = $"{numOfBombs}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateGrid()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    Button btn = new Button
                    {
                        Size = new Size(buttonSize, buttonSize),
                        Location = new Point(col * buttonSize, row * buttonSize + 40),
                        Name = $"btn_{row}_{col}",
                        Tag = new ButtonInfo(new Point(row, col), false)
                    };

                    // Attach click event handler
                    btn.Click += Button_Click;

                    // Attach right-click event handler
                    btn.MouseDown += Button_MouseDown;


                    // Store button in array
                    buttons[row, col] = btn;

                    // Add button to form
                    this.Controls.Add(btn);
                }
            }

            // Randomly place bombs
            while (bombPositions.Count < numOfBombs)
            {
                int row = random.Next(0, 9);  
                int col = random.Next(0, 9);  
                Point position = new Point(row, col);

                // Ensure the bomb position is unique
                if (!bombPositions.Contains(position))
                {
                    bombPositions.Add(position);
                    ButtonInfo info = (ButtonInfo)buttons[row, col].Tag;
                    info.HasBomb = true;  
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null && clickedButton.Tag is ButtonInfo info)
            {
                //MessageBox.Show($"You clicked on ({info.Position.X}, {info.Position.Y})\nHas Bomb: {info.HasBomb}");
                if (info.HasBomb)
                {
                    clickedButton.Text = "x";
                    MessageBox.Show("Oof, you died");

                }
                else
                {
                    checkNeighbors(info, clickedButton);
                }

            }
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Button clickedButton)
            {
                if (e.Button == MouseButtons.Right) // Check if right mouse button was clicked
                {
                    clickedButton.Text = "X";
                }
            }
        }


        private HashSet<Button> visitedButtons = new HashSet<Button>(); // Track visited buttons

        private void checkNeighbors(ButtonInfo info, Button clickedButton)
        {
            // If the button has already been checked, stop recursion
            if (visitedButtons.Contains(clickedButton))
                return;

            visitedButtons.Add(clickedButton); // Mark this button as visited

            int bombCount = 0;
            int row = info.Position.X;
            int col = info.Position.Y;

            // Directions for 8 neighboring cells
            int[] dX = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dY = { -1, 0, 1, -1, 1, -1, 0, 1 };

            // First Pass: Count the number of bombs around the clicked button
            for (int i = 0; i < 8; i++)
            {
                int newRow = row + dX[i];
                int newCol = col + dY[i];

                if (newRow >= 0 && newRow < 9 && newCol >= 0 && newCol < 9) // Ensure within bounds
                {
                    Button neighborButton = buttons[newRow, newCol];

                    if (neighborButton?.Tag is ButtonInfo neighborInfo && neighborInfo.HasBomb)
                    {
                        bombCount++;
                    }
                }
            }

            // Update the clicked button's text
            clickedButton.Text = bombCount > 0 ? bombCount.ToString() : "0";

            // If no bombs nearby, reveal neighbors recursively
            if (bombCount == 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    int newRow = row + dX[i];
                    int newCol = col + dY[i];

                    if (newRow >= 0 && newRow < 9 && newCol >= 0 && newCol < 9)
                    {
                        Button neighborButton = buttons[newRow, newCol];

                        if (neighborButton?.Tag is ButtonInfo neighborInfo && !visitedButtons.Contains(neighborButton))
                        {
                            checkNeighbors(neighborInfo, neighborButton);
                        }
                    }
                }
            }
        }

    }
}
