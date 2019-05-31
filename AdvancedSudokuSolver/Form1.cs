using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AdvancedSudokuSolver
{
    public partial class Form1 : Form
    {

        #region Variables

        // In there is the sudoku saved
        Grid sudokuField = new Grid();

        // Label matrix to show the output
        Label[,] output = new Label[9, 9];

        // Numeric Up Down matrix for the input
        NumericUpDown[,] numericInput = new NumericUpDown[9, 9];

        // lable size
        int ls;

        // if the grid should be shown every step
        bool liveUpdate;

        // how many steps the logic part took
        int logicSteps;

        // how many steps the brute force part took
        int bruteForceSteps;

        // stopwatch to stop the time it takes to solve the sudoku
        Stopwatch sw = new Stopwatch();

        // Testing
        int[,] correct = new int[9, 9]
        {
            { 4, 1, 7, 3, 6, 9, 8, 2, 5 },
            { 6, 3, 2, 1, 5, 8, 9, 4, 7 },
            { 9, 5, 8, 7, 2, 4, 3, 1, 6 },

            { 8, 2, 5, 4, 3, 7, 1, 6, 9 },
            { 7, 9, 1, 5, 8, 6, 4, 3, 2 },
            { 3, 4, 6, 9, 1, 2, 7, 5, 8 },

            { 2, 8, 9, 6, 4, 3, 5, 7, 1 },
            { 5, 7, 3, 2, 9, 1, 6, 8, 4 },
            { 1, 6, 4, 8, 7, 5, 2, 9, 3 }
        };
        int[,] inputEasy = new int[9, 9]
        {
            { 0, 0, 7, 3, 0, 9, 8, 2, 5 },
            { 6, 0, 2, 1, 0, 8, 0, 0, 7 },
            { 9, 0, 8, 7, 0, 4, 3, 0, 6 },

            { 0, 0, 5, 0, 0, 7, 1, 6, 0 },
            { 7, 9, 0, 5, 0, 0, 0, 0, 2 },
            { 3, 0, 6, 9, 1, 2, 7, 5, 8 },

            { 2, 0, 0, 6, 0, 3, 5, 7, 1 },
            { 0, 0, 3, 0, 0, 1, 6, 0, 0 },
            { 0, 6, 4, 8, 7, 5, 2, 0, 3 }
        };
        int[,] inputHard = new int[9, 9]
        {
            { 0, 0, 0, 0, 0, 9, 8, 2, 5 },
            { 6, 0, 2, 1, 0, 8, 0, 0, 7 },
            { 9, 0, 8, 7, 0, 4, 3, 0, 6 },

            { 0, 0, 0, 0, 0, 0, 1, 0, 0 },
            { 0, 0, 0, 5, 0, 0, 0, 0, 2 },
            { 3, 0, 6, 0, 1, 2, 7, 5, 0 },

            { 2, 0, 0, 6, 0, 0, 0, 0, 1 },
            { 0, 0, 3, 0, 0, 0, 6, 0, 0 },
            { 0, 6, 4, 0, 0, 5, 2, 0, 0 }
        };

        #endregion

        public Form1()
        {
            InitializeComponent();
            SetupOutput();
            SetInput();
        }

        // Display the sudokuField matrix in the console
        void ParseGridToConsole()
        {
            // Some margin from the rest of the console
            Console.WriteLine();
            Console.WriteLine();
            // for each row
            for (int y = 0; y < sudokuField.size; y++)
            {
                // start a new row string
                string row = "";

                // for each col
                for (int x = 0; x < sudokuField.size; x++)
                {
                    // if the index is a multiple of 3 it means
                    // there is the right end of a block
                    if (x != 0 && x % 3 == 0)
                    {
                        row += "| ";
                    }

                    // Add the value of the tile
                    row += sudokuField.grid[x, y].number.ToString();
                    // Add a space for better readablitiy
                    row += " ";
                }

                // if the index is a multiple of 3 it means
                // there is the bottom end of a block

                if (y != 0 && y % 3 == 0)
                {
                    Console.WriteLine("----------------------");
                }

                // Write the whole row to the console
                Console.WriteLine(row);
            }

            // more margin
            Console.WriteLine();
            Console.WriteLine();
        }

        // Display any matrix in the console
        void ParseGridToConsole(int[,] a)
        {
            // Ident with the normal ParsGridToConsole method but it
            // uses a matrix as parameter

            Console.WriteLine();
            Console.WriteLine();

            for (int y = 0; y < a.GetLength(0); y++)
            {
                string row = "";

                for (int x = 0; x < a.GetLength(1); x++)
                {
                    if (x != 0 && x % 3 == 0)
                    {
                        row += "| ";
                    }

                    row += a[x, y].ToString();
                    row += " ";
                }

                if (y != 0 && y % 3 == 0)
                {
                    Console.WriteLine("----------------------");
                }

                Console.WriteLine(row);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        // Sets up all the lables needed to show the output
        void SetupOutput()
        {
            // Size of the lable
            ls = 23;
            // Total width of all labels side by side
            int totalWidth = 9 * ls;
            // Total height of all labels side by side
            int totalHeight = 9 * ls;
            // width of the groupbox
            int w = groupBox2.Width;
            // height of the groupbox
            int h = groupBox2.Height;

            // loop through the amount of labels needed
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    // generate a new label
                    Label l = new Label();
                    // give it a name
                    l.Name = "outputLabel_" + x + "_" + y;
                    // give it a text
                    l.Text = "0";
                    // set the text align to middle center
                    l.TextAlign = ContentAlignment.MiddleCenter;
                    // duplicates the font but changes the size to 11 instead of 8.25
                    l.Font = new Font(l.Font.FontFamily, 11);
                    // set autosize to false so i can set the size manually
                    l.AutoSize = false;
                    // sets the size
                    l.Size = new Size(ls, ls);
                    // sets the location of the label
                    // so its centert inside of the groupbox
                    l.Location = new Point(x * ls + ((w - totalWidth) / 2), y * ls + ((h - totalHeight) / 2));
                    l.BackColor = Color.Transparent;
                    // adds the label to the groupbox
                    groupBox2.Controls.Add(l);
                    // adds the label to the output array
                    output[y, x] = l;
                }
            }
        }

        void SetInput()
        {
            // Size of the numeric
            int nw = 21 + 10;
            int nh = 21;
            // Total width of all numeric side by side
            int totalWidth = 9 * nw;
            // Total height of all numeric side by side
            int totalHeight = 9 * nh;
            // width of the groupbox
            int w = tabControl_input.TabPages[1].Width;
            // height of the groupbox
            int h = tabControl_input.TabPages[1].Height;

            // loop through the amount of numeric needed
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    // generate a new numeric
                    NumericUpDown n = new NumericUpDown();
                    n.BorderStyle = BorderStyle.FixedSingle;
                    // give it a name
                    n.Name = "inputNumericUpDown_" + x + "_" + y;
                    // give it a value aswell as maximum and minimum amount
                    n.Value = 0;
                    n.Minimum = 0;
                    n.Maximum = 9;
                    // duplicates the font but changes the size to 11 instead of 8.25
                    n.Font = new Font(n.Font.FontFamily, 11);
                    n.TextAlign = HorizontalAlignment.Center;
                    n.AutoSize = false;
                    // sets the size
                    n.Size = new Size(nw, nh);
                    // sets the location of the label
                    // so its centert inside of the groupbox
                    n.Location = new Point(x * nw + ((w - totalWidth) / 2), y * nh + ((h - totalHeight) / 2));
                    //n.BackColor = Color.Transparent;
                    // adds the label to the groupbox
                    tabControl_input.TabPages[1].Controls.Add(n);
                    // adds the label to the output array
                    numericInput[y, x] = n;
                }
            }
        }

        // Parses the input in the text box to a int matix and returns it
        int[,] GetInput()
        {
            // generates a new inputMatrix
            int[,] inputMatrix = new int[9, 9];
            // the raw input
            string input = textBox_input.Text;
            // removes everything that is not a number
            input = Regex.Replace(input, "[^0-9]", "");
            // if the input is zero throw a new exception
            if (input == "")
            {
                for (int y = 0; y < 9; y++)
                {
                    for (int x = 0; x < 9; x++)
                    {
                        // converts the 1D input string into a 2d array
                        inputMatrix[x, y] = Convert.ToInt32(numericInput[x, y].Value);
                    }
                }

                // throw new Exception("No input");
                //MessageBox.Show("No input given!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                //return null;
            }
            else
            {
                // else try to convert every digit into an int
                try
                {
                    // fore each slot in the matrix

                    for (int y = 0; y < 9; y++)
                    {
                        for (int x = 0; x < 9; x++)
                        {
                            // converts the 1D input string into a 2d array
                            inputMatrix[y, x] = Convert.ToInt32(input[x + sudokuField.size * y].ToString());
                            numericInput[y, x].Value = inputMatrix[y, x];
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
            // returns the filled input matrix
            return inputMatrix;
        }

        // Sets the input into the sudokuField
        void SetValues()
        {
            // fills the sudoku field from the get input return
            int[,] input = GetInput();
            if (input != null)
            {
                sudokuField.Fill(input);
            }
            ParseGridToConsole();
        }

        // Solving the Sudoku using two different algorithms
        void Solve()
        {
            History("Start");

            // in this part it tries to solve as much as possible
            // from the sudoku just by using logic
            LogicPart();
            Console.WriteLine("LogicPart over");

            History("Logic part exhausted");

            History("Bruteforce attempt started");

            // in this part it can solve every solvable sudoku in an finite amount if time
            // but it might take a very long while
            // all it does is try every possible arrangement and checks if it is indeed possible
            BruteForce();
            Console.WriteLine("BruteForce over");

            History("Bruteforce attempt finished");
        }

        // The logic part of the solving process
        void LogicPart()
        {
            // how many steps the logic part took
            logicSteps = 0;

            bool ableToProgress;
            do
            {
                ableToProgress = RefreshTilesInGrid();

                // eliminate process
                // this means if in one unit (row, col, block) only one possiblity for a number is given
                // set the number

                // Row
                for (int y = 0; y < sudokuField.size; y++)
                {
                    // loop through all the numbers that are possible for a tile
                    for (int i = 1; i < 9; i++)
                    {
                        // the amount of possibilities in the given unit
                        int amount = 0;
                        // tile where there is a possibility
                        // if amount is larger than 1 found tile is obsolete
                        Tile foundTile = null;

                        for (int x = 0; x < sudokuField.size; x++)
                        {
                            // if a tile already has the number break and continue with the next number
                            // because in one unit each number can only appear once
                            if (sudokuField.grid[x, y].number == i)
                            {
                                break;
                            }

                            if (sudokuField.grid[x, y].possibleNumbers.Contains(i) && sudokuField.grid[x, y].hasNumber == false)
                            {
                                // increment the amount of possibilities if a tile has it
                                // in its possible numbers list
                                amount++;
                                // if the amount is higher than 1 there are too many possible tiles
                                // therfore the process is stopped
                                if (amount >= 2)
                                {
                                    break;
                                }
                                foundTile = sudokuField.grid[x, y];
                            }
                        }
                        // After every tile in the unit is look up
                        // if only one possible spot is available
                        // set the number at the found spot
                        if (amount == 1)
                        {
                            foundTile.SetNumber(i);
                            logicSteps++;
                            ableToProgress = true;
                            History("Eliminated " + i + " in row " + foundTile.y);
                        }
                    }
                }

                // After that it checks the whole grid again and updates the peers
                // if a tile has a number in it
                // I dont know why i is nessesary but it wont work without this

                ableToProgress = RefreshTilesInGrid();

                // The same like above but this time it checks the collums
                // Col
                for (int x = 0; x < sudokuField.size; x++)
                {
                    for (int i = 1; i < 9; i++)
                    {
                        int amount = 0;
                        // if amount is larger than 1 found tile is obsolete
                        Tile foundTile = null;
                        for (int y = 0; y < sudokuField.size; y++)
                        {
                            if (sudokuField.grid[x, y].number == i)
                            {
                                break;
                            }

                            if (sudokuField.grid[x, y].possibleNumbers.Contains(i) && sudokuField.grid[x, y].hasNumber == false)
                            {
                                amount++;
                                if (amount >= 2)
                                {
                                    break;
                                }
                                foundTile = sudokuField.grid[x, y];
                            }
                        }

                        if (amount == 1)
                        {
                            foundTile.SetNumber(i);
                            logicSteps++;
                            ableToProgress = true;
                            History("Eliminated " + i + " in collum " + foundTile.x);
                        }
                    }
                }

                // After that it checks the whole grid again and updates the peers
                // if a tile has a number in it
                // I dont know why it is nessesary but it wont work without this

                ableToProgress = RefreshTilesInGrid();

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {

                        int amount = 0;
                        // if amount is larger than 1 found tile is obsolete
                        Tile foundTile = null;

                        for (int y = 0; y < 3; y++)
                        {
                            for (int x = 0; x < 3; x++)
                            {
                                int xx = j * 3 + x;
                                int yy = i * 3 + y;

                                if (sudokuField.grid[xx, yy].number == i)
                                {
                                    break;
                                }

                                if (sudokuField.grid[xx, yy].possibleNumbers.Contains(i) && sudokuField.grid[xx, yy].hasNumber == false)
                                {
                                    amount++;
                                    if (amount >= 2)
                                    {
                                        break;
                                    }
                                    foundTile = sudokuField.grid[xx, yy];
                                }
                            }
                        }

                        if (amount == 1)
                        {
                            foundTile.SetNumber(i);
                            logicSteps++;
                            ableToProgress = true;

                            // gets the index of the corresponding block where the tile is inside
                            // blockX ranges from 0 to 2 from left to right
                            int blockX = (int)Math.Floor((double)foundTile.x / (double)3);
                            // blockY ranges from 0 to 2 from top to bottom
                            int blockY = (int)Math.Floor((double)foundTile.y / (double)3);

                            History("Eliminated " + i + " in block [" + blockX + ", " + blockY + "]");
                        }
                    }
                }

                // After that it checks the whole grid again and updates the peers
                // if a tile has a number in it
                // I dont know why it is nessesary but it wont work without this

                ableToProgress = RefreshTilesInGrid();

                // loops through the whole grid and set the number to a tile
                // if the tile only has one possible number left

                for (int y = 0; y < sudokuField.size; y++)
                {
                    for (int x = 0; x < sudokuField.size; x++)
                    {
                        // if there is only 1 possible number left
                        if (sudokuField.grid[x, y].possibleNumbersAmount == 1)
                        {
                            // Sets this last number
                            sudokuField.grid[x, y].SetNumberFromLastPossibleNumber();
                            // Updates peers
                            sudokuField.RemoveFromPeers(x, y, sudokuField.grid[x, y].number);
                            // i assume there is progress possible if we set a number to a tile
                            ableToProgress = true;
                            logicSteps++;

                            History("Set " + sudokuField.grid[x, y].number + " in cell [" + x + ", " + y + "]");
                        }
                    }
                }

                // Displays the sudokuField
                if (liveUpdate)
                {
                    Display();
                }
                logicSteps++;

            } while (ableToProgress);

            History(logicSteps + " Logic steps");

            Console.WriteLine("Logic Steps: " + logicSteps);
        }

        // refreshes the grid
        bool RefreshTilesInGrid()
        {
            // is true if somewhere in here a change occured
            bool c = false;

            // for each tile in the sudoku check if it has a number
            // if it has a number update all the peers and remove the number
            // from their possible numbers list
            for (int y = 0; y < sudokuField.size; y++)
            {
                for (int x = 0; x < sudokuField.size; x++)
                {
                    if (sudokuField.grid[x, y].hasNumber)
                    {
                        // RemoveFromPeers returns true if something changed
                        // if something changed the whole process repeats later on
                        // because ableToProgress is set to true
                        // it needs to repeat because this action might reveal new possibilities
                        bool changed = sudokuField.RemoveFromPeers(x, y, sudokuField.grid[x, y].number);
                        if (changed)
                        {
                            History("Removed " + sudokuField.grid[x, y].number + " from the [" + x + ", " + y + "] peers");
                            c = true;
                            logicSteps++;
                        }
                    }
                }
            }

            return c;
        }

        // brute force part of the solving process
        void BruteForce()
        {
            // index of all emptyTiles
            int index = 0;

            bruteForceSteps = 0;

            // the tile that is currently looked at
            Tile cur;

            // a list of all empty tiles
            List<Tile> emptyTiles = new List<Tile>();

            // fill the empty tiles list if the tile does not have a number
            foreach (Tile t in sudokuField.grid)
            {
                if (!t.hasNumber)
                {
                    emptyTiles.Add(t);
                }
            }

            // while the grid is not finished
            while (!isFinished())
            {
            // start position of the algorithm
            StartPosition:

                bruteForceSteps++;

                // Display the grid
                if (liveUpdate)
                {
                    Display();
                }

                // gets the first tile of all empty tiles
                cur = emptyTiles[index];
                // sets has number to make it able to show in the display function
                // even if it does not really have a number
                cur.hasNumber = true;
                do
                {
                    bruteForceSteps++;

                IncrementPosition:
                    // increment the current number if possible
                    if (cur.number < 9)
                    {
                        cur.number++;

                        if (cur.possibleNumbers.Contains(cur.number) == false)
                        {
                            goto IncrementPosition;
                        }

                    }
                    else
                    {
                        // set the cur number to 0
                        cur.number = 0;
                        // go on tile back in the list
                        index--;
                        // go to the start
                        goto StartPosition;
                    }
                    // do this while it is not a possible value
                } while (!CheckIfOk(cur));

                // if it is possible increment the index
                index++;

                // if every empty tile is used
                // it is finished or not possible
                if (index > emptyTiles.Count)
                {
                    break;
                }
            }

            // display the finished grid
            Display();

            Console.WriteLine("Brute Force Steps: " + bruteForceSteps);

            History(bruteForceSteps + " bruteforce steps");
        }

        // checks of the current number of a tile is feasable
        bool CheckIfOk(Tile t)
        {
            // row
            // check if a tile inside of the same row does have the same number
            for (int i = 0; i < 9; i++)
            {
                if (sudokuField.grid[i, t.y].number == t.number && sudokuField.grid[i, t.y] != t)
                {
                    // if it does return false because it is not a possible spot
                    return false;
                }
            }

            // col
            // same like row just for the collum
            for (int j = 0; j < 9; j++)
            {
                if (sudokuField.grid[t.x, j].number == t.number && sudokuField.grid[t.x, j] != t)
                {
                    return false;
                }
            }

            // Block
            // gets the index of the corresponding block where the tile is inside
            // blockX ranges from 0 to 2 from left to right
            int blockX = (int)Math.Floor((double)t.x / (double)3);
            // blockY ranges from 0 to 2 from top to bottom
            int blockY = (int)Math.Floor((double)t.y / (double)3);

            // loop through a 3 x 3 chunk
            for (int i = 0; i < 3; i++)
            {
                // adjust the indecies to correspond to the correct block
                int y = i + blockY * 3;

                for (int j = 0; j < 3; j++)
                {
                    int x = j + blockX * 3;
                    if (sudokuField.grid[x, y].number == t.number && sudokuField.grid[x, y] != t)
                    {
                        // return false if the number already exists
                        return false;
                    }
                }
            }

            // return true if nowhere else it returned false
            return true;
        }

        // checks of a grid is finished
        bool isFinished()
        {
            // the sum of the complete grid
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    // checks if the number of the grid is greater than zero
                    // because the possible numbers for a tile are positive
                    if (sudokuField.grid[i, j].number > 0)
                    {
                        // if true add the number to the total sum
                        sum += sudokuField.grid[i, j].number;
                    }
                    else
                    {
                        // return false because on tile has a 0 as number
                        // which suggests it is not finished
                        return false;
                    }
                }
            }

            // 45 is the sum every row has to have it is finished correctly
            // it is multiplied with the amount of rows
            // it does only check the final sum and not the amount of every number!
            if (sum == 45 * 9)
            {
                // if the sum is large enough it retruns true
                return true;
            }
            else
            {
                // else return false
                return false;
            }
        }

        // displays the grid in the windows form
        void Display()
        {
            // loop through the whole grid
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    string s;
                    // if the tile has a number the string becomes that number
                    if (sudokuField.grid[x, y].hasNumber)
                    {
                        s = sudokuField.grid[x, y].number.ToString();
                    }
                    else
                    {
                        // else the string is a zero
                        s = "0";
                    }

                    // invokes the label and sets its text to s
                    output[y, x].Invoke((MethodInvoker)(() => output[y, x].Text = s));
                }
            }
        }

        // Adds a statement to the history box with a timestamp
        public void History(string s)
        {
            listBox_history.Invoke((MethodInvoker)(() => listBox_history.Items.Add(string.Format("[{0}]: {1}", sw.Elapsed, s))));
        }

        // if the start button was pressed
        private void button_start_Click(object sender, EventArgs e)
        {
            // if liveupdate is checked
            liveUpdate = checkBox_liveUpdate.Checked;

            // start the stopwatch
            sw.Restart();

            // clear the history box
            listBox_history.Items.Clear();

            // start the background worker if the start button is pressed
            backgroundWorker1.RunWorkerAsync();
        }

        // background worker does the work here
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // sets the 
            SetValues();
            // starts solving
            Solve();
            Console.WriteLine("Solve Finished");
        }

        // when the background worker is finished
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // start the stopwatch
            sw.Stop();
            label_elapsed.Text = sw.Elapsed.ToString();
            Console.WriteLine(sw.Elapsed);

            // finally display the final grid
            Display();

            // show a message box to inform the user
            MessageBox.Show("Finished", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        // Draw the lines for the sudoku
        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            // Create a new pen
            Pen p;

            // calculating the margins
            // adding 1 because of the stroke weight
            int spaceTop = (groupBox2.Height - ls * 9) / 2 + 1;
            int spaceLeft = (groupBox2.Width - ls * 9) / 2 + 1;

            // drawing all the lines
            for (int i = 0; i <= 9; i++)
            {
                // if the modulus of i = 0 then draw a thick line
                if (i % 3 == 0)
                {
                    p = new Pen(Color.Black, 2);
                }
                else
                {
                    p = new Pen(Color.Black, 1);
                }

                // Drawing the line from left to right
                Point left = new Point(spaceLeft, spaceTop + i * ls);
                Point right = new Point(groupBox2.Width - spaceLeft, spaceTop + i * ls);

                e.Graphics.DrawLine(p, left, right);

                // and from top to bottom
                Point top = new Point(spaceLeft + i * ls, spaceTop);
                Point bottom = new Point(spaceLeft + i * ls, groupBox2.Height - spaceTop);

                e.Graphics.DrawLine(p, top, bottom);
            }
        }
    }
}
