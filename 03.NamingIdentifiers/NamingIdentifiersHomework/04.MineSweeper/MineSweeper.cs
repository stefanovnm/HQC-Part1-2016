using System;
using System.Collections.Generic;

namespace _04.MineSweeper
{
    public class MineSweeper
    {
		public static void Main()
		{
            const int MAX_EMPTY_FIELDS = 35;

            string command = string.Empty;
            int openedFreeFields = 0;
            int row = 0;
            int col = 0;
            bool startState = true;
            bool gameWon = false;
            bool stepOnMine = false;

            char[,] field = CreateField();
			char[,] mines = PlaceMines();
			List<Points> champions = new List<Points>(6);
            
			do
			{
				if (startState)
				{
				    Console.WriteLine("Let's play “Minesweeper”. Try to find the fields without mines");
				    Console.WriteLine("Commands: ");
				    Console.WriteLine("  'top' - shows the Highscore");
				    Console.WriteLine("  'restart' - start the game again");
				    Console.WriteLine("  'exit' - stop playing");
                    
					PrintField(field);
					startState = false;
				}

				Console.Write("Give row and column: ");
				command = Console.ReadLine().Trim();

				if (command.Length >= 3)
				{
					if (int.TryParse(command[0].ToString(), out row) &&
					    int.TryParse(command[2].ToString(), out col) &&
						row <= field.GetLength(0) && col <= field.GetLength(1))
					{
						command = "turn";
					}
				}

				switch (command)
				{
					case "top":
						ShowHighscores(champions);
						break;
					case "restart":
                        field = CreateField();
						mines = PlaceMines();
						PrintField(field);
						stepOnMine = false;
						startState = false;
						break;
					case "exit":
						Console.WriteLine("Bye!");
						break;
					case "turn":
						if (mines[row, col] != '*')
						{
							if (mines[row, col] == '-')
							{
								MakeTurn(field, mines, row, col);
								openedFreeFields++;
							}

							if (MAX_EMPTY_FIELDS == openedFreeFields)
							{
								gameWon = true;
							}
							else
							{
								PrintField(field);
							}
						}
						else
						{
							stepOnMine = true;
						}

						break;
					default:
						Console.WriteLine("\nInvalid command!\n");
						break;
				}

				if (stepOnMine)
				{
					PrintField(mines);
					Console.Write("\nYou steped on mine! Game ended with {0} points. Enter your name: ", openedFreeFields);
					string name = Console.ReadLine();
					Points result = new Points(name, openedFreeFields);

					if (champions.Count < 5)
					{
						champions.Add(result);
					}
					else
					{
						for (int i = 0; i < champions.Count; i++)
						{
							if (champions[i].CurrentPoints < result.CurrentPoints)
							{
								champions.Insert(i, result);
								champions.RemoveAt(champions.Count - 1);
								break;
							}
						}
					}

					champions.Sort((Points r1, Points r2) => r2.Name.CompareTo(r1.Name));
					champions.Sort((Points r1, Points r2) => r2.CurrentPoints.CompareTo(r1.CurrentPoints));
					ShowHighscores(champions);

                    field = CreateField();
					mines = PlaceMines();

					openedFreeFields = 0;
					stepOnMine = false;
					startState = true;
				}

				if (gameWon)
				{
					Console.WriteLine("\nGood job! You opened every fields without mine.");
					PrintField(mines);

					Console.WriteLine("Enter your name: ");
					string name = Console.ReadLine();

					Points result = new Points(name, openedFreeFields);
					champions.Add(result);

					ShowHighscores(champions);
                    field = CreateField();
					mines = PlaceMines();

					openedFreeFields = 0;
					gameWon = false;
					startState = true;
				}
			}
			while (command != "exit");

			Console.WriteLine("Made in Bulgaria!");
			Console.WriteLine("Bye.");
			Console.Read();
		}

		private static void ShowHighscores(List<Points> points)
		{
			Console.WriteLine("\nPoints: ");
			if (points.Count > 0)
			{
				for (int i = 0; i < points.Count; i++)
				{
					Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, points[i].Name, points[i].CurrentPoints);
				}

				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("Empty highscore!\n");
			}
		}

		private static void MakeTurn(char[,] field, char[,] mines, int row, int col)
		{
			char minesCount = CountMinesAround(mines, row, col);
            mines[row, col] = minesCount;
            field[row, col] = minesCount;
		}

		private static void PrintField(char[,] board)
		{
			int rows = board.GetLength(0);
			int cols = board.GetLength(1);
			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("   ---------------------");

			for (int row = 0; row < rows; row++)
			{
				Console.Write("{0} | ", row);

				for (int col = 0; col < cols; col++)
				{
					Console.Write(string.Format("{0} ", board[row, col]));
				}

				Console.WriteLine("|");
			}

			Console.WriteLine("   ---------------------\n");
		}

		private static char[,] CreateField()
		{
			int boardRows = 5;
			int boardColumns = 10;
			char[,] board = new char[boardRows, boardColumns];

            for (int row = 0; row < boardRows; row++)
			{
				for (int col = 0; col < boardColumns; col++)
				{
					board[row, col] = '?';
				}
			}

			return board;
		}

		private static char[,] PlaceMines()
		{
			int rows = 5;
			int cols = 10;
			char[,] field = new char[rows, cols];

			for (int row = 0; row < rows; row++)
			{
				for (int col = 0; col < cols; col++)
				{
                    field[row, col] = '-';
				}
			}

			List<int> mines = new List<int>();

			while (mines.Count < 15)
			{
				Random random = new Random();
				int randomNumber = random.Next(50);

				if (!mines.Contains(randomNumber))
				{
                    mines.Add(randomNumber);
				}
			}

			foreach (int mine in mines)
			{
				int col = mine / cols;
				int row = mine % cols;

				if (row == 0 && mine != 0)
				{
                    col--;
					row = cols;
				}
				else
				{
					row++;
				}

                field[col, row - 1] = '*';
			}

			return field;
		}

		private static void ShowPlayfield(char[,] field)
		{
			int cols = field.GetLength(0);
			int rows = field.GetLength(1);

			for (int i = 0; i < cols; i++)
			{
				for (int j = 0; j < rows; j++)
				{
					if (field[i, j] != '*')
					{
						char minesAround = CountMinesAround(field, i, j);
                        field[i, j] = minesAround;
					}
				}
			}
		}

		private static char CountMinesAround(char[,] field, int row, int col)
		{
			int minesCount = 0;
			int rows = field.GetLength(0);
			int cols = field.GetLength(1);

			if (row - 1 >= 0)
			{
				if (field[row - 1, col] == '*')
				{ 
					minesCount++; 
				}
			}

			if (row + 1 < rows)
			{
				if (field[row + 1, col] == '*')
				{ 
					minesCount++; 
				}
			}

			if (col - 1 >= 0)
			{
				if (field[row, col - 1] == '*')
				{ 
					minesCount++;
				}
			}

			if (col + 1 < cols)
			{
				if (field[row, col + 1] == '*')
				{ 
					minesCount++;
				}
			}

			if ((row - 1 >= 0) && (col - 1 >= 0))
			{
				if (field[row - 1, col - 1] == '*')
				{ 
					minesCount++; 
				}
			}

			if ((row - 1 >= 0) && (col + 1 < cols))
			{
				if (field[row - 1, col + 1] == '*')
				{ 
					minesCount++; 
				}
			}

			if ((row + 1 < rows) && (col - 1 >= 0))
			{
				if (field[row + 1, col - 1] == '*')
				{ 
					minesCount++; 
				}
			}

			if ((row + 1 < rows) && (col + 1 < cols))
			{
				if (field[row + 1, col + 1] == '*')
				{ 
					minesCount++; 
				}
			}

			return char.Parse(minesCount.ToString());
		}
	}
}

// can be done a lot of refactoring and optimizing, but not in the scope of this homework... I personally would start with do{}while() in Main....