using System.Collections.Generic;

namespace AdvancedSudokuSolver
{
	class Tile
	{
		// x coord inside the matrix
		public int x;

		// y coord inside the matrix
		public int y;

		// is true if it has a final number
		public bool hasNumber;

		// if has number is true this is the number
		public int number;

		// list of all possible numbers
		public List<int> possibleNumbers;

		// returns the amount of possible numbers
		public int possibleNumbersAmount
		{
			get
			{
				return possibleNumbers.Count;
			}
		}

		public Tile(int x, int y, bool hasNumber, int number)
		{
			this.x = x;
			this.y = y;
			this.hasNumber = hasNumber;
			if(hasNumber)
			{
				possibleNumbers.Clear();
				this.number = number;
			}
			else
			{
				// if it does not have a number from the start define all possible numbers
				possibleNumbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			}
		}

		// Sets a specific number
		public void SetNumber(int number)
		{
			this.number = number;
			hasNumber = true;
			// clears the possible numbers because it has
			// a number now
			possibleNumbers.Clear();
		}

		// Sets a number from the last possible number
		public void SetNumberFromLastPossibleNumber()
		{
			SetNumber(possibleNumbers[0]);
		}

		// sets no number
		public void SetVoid()
		{
			// sets the number to zero
			this.number = 0;
			hasNumber = false;
			// sets every possible number as possible numbers
			possibleNumbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		}

		// removes a specific number from the possible numbers
		// and returns true if something changed
		public bool RemoveFromPossible(int number)
		{
			// if the list contains the number
			if(possibleNumbers.Contains(number))
			{
				// remove it
				// and return true because something
				// indeed did change
				possibleNumbers.Remove(number);
				return true;
			}
			else
			{
				// else no need to remove something
				// that is not there
				// and nothing changed
				return false;
			}
		}
	}
}
