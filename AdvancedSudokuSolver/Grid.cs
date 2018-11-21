using System;

namespace AdvancedSudokuSolver
{
	class Grid
	{
		// size of the grid currently constantly 9
		public int size;

		// actual grid
		public Tile[,] grid;

		public Grid()
		{
			size = 9;
			grid = new Tile[size, size];

			// loop through the grid grid
			for(int y = 0; y < size; y++)
			{
				for(int x = 0; x < size; x++)
				{
					// generate a new tile for each spot with 0 as a number
					grid[x, y] = new Tile(x, y, false, 0);
				}
			}
		}

		// fills the grid grid
		public void Fill(int[,] input)
		{
			// if the sizes do not match throw
			if(input.GetLength(0) != size || input.GetLength(1) != size)
			{
				throw new Exception("Grid Fill: The Size does not match");
			}
			else
			{
				// else loop throug the input matrix
				for(int y = 0; y < size; y++)
				{
					for(int x = 0; x < size; x++)
					{
						// get the number from the input matrix
						int number = input[y, x];

						// if the number is zero
						if(number == 0)
						{
							// set void at the spot
							grid[x, y].SetVoid();
						}
						else
						{
							// else set the corresponding number
							grid[x, y].SetNumber(number);
						}
					}
				}
			}
		}

		// removes the number from all of a tiles peers
		public bool RemoveFromPeers(int xCoord, int yCoord, int number)
		{
			// if this is true somwhere in here an update occured
			// and return true so the whole proccess is called later again
			bool changedMaster = false;

			// Row
			// loop through the row of the tile
			for(int x = 0; x < size; x++)
			{
				// if the current position is the same as the input tile continue
				if(x == xCoord)
				{
					continue;
				}

				// else remove the number from the possible numbers list
				bool changedRow = grid[x, yCoord].RemoveFromPossible(number);
				// if something changed update changed master
				if(changedRow)
				{
					changedMaster = true;
				}
			}

			// Col
			// same as row but only collum
			for(int y = 0; y < size; y++)
			{
				if(y == yCoord)
				{
					continue;
				}

				bool changedCol = grid[xCoord, y].RemoveFromPossible(number);
				if(changedCol)
				{
					changedMaster = true;
				}
			}

			// Block
			// gets the index of the corresponding block where the tile is inside
			// blockX ranges from 0 to 2 from left to right
			int blockX = (int)Math.Floor((double)xCoord / (double)3);
			// blockY ranges from 0 to 2 from top to bottom
			int blockY = (int)Math.Floor((double)yCoord / (double)3);

			// loop through a 3 x 3 chunk
			for(int i = 0; i < 3; i++)
			{
				// adjust the indecies to correspond to the correct block
				int y = i + blockY * 3;

				for(int j = 0; j < 3; j++)
				{
					int x = j + blockX * 3;

					// if the currently looked at spot is the same as the input tile skip
					if(y == yCoord && x == xCoord)
					{
						continue;
					}

					// else remove the number from the possible numbers list
					bool changedBlock = grid[x, y].RemoveFromPossible(number);
					// if something changed update changed master
					if(changedBlock)
					{
						changedMaster = true;
					}
				}
			}

			// return the changedMaster to inform the caller that something did update
			return changedMaster;
		}
	}
}
