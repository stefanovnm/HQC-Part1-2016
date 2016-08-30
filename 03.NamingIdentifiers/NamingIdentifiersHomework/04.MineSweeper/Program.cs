using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.MineSweeper
{
	public class minite
	{
		static void Main(string[] аргументи)
		{
            const int MAX = 35;

            string command = string.Empty;
			char[,] boardField = CreateBoard();
			char[,] mines = PlaceMines();
			int broya4 = 0;
			bool grum = false;
			List<Points> champions = new List<Points>(6);
			int row = 0;
			int col = 0;
			bool flag = true;
            bool flag2 = false;
            
			do
			{
				if (flag)
				{
					Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
					" Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
					dumpp(boardField);
					flag = false;
				}
				Console.Write("Daj red i kolona : ");
				command = Console.ReadLine().Trim();
				if (command.Length >= 3)
				{
					if (int.TryParse(command[0].ToString(), out row) &&
					int.TryParse(command[2].ToString(), out col) &&
						row <= boardField.GetLength(0) && col <= boardField.GetLength(1))
					{
						command = "turn";
					}
				}
				switch (command)
				{
					case "top":
						ShowChart(champions);
						break;
					case "restart":
						boardField = CreateBoard();
						mines = PlaceMines();
						dumpp(boardField);
						grum = false;
						flag = false;
						break;
					case "exit":
						Console.WriteLine("4a0, 4a0, 4a0!");
						break;
					case "turn":
						if (mines[row, col] != '*')
						{
							if (mines[row, col] == '-')
							{
								tisinahod(boardField, mines, row, col);
								broya4++;
							}
							if (MAX == broya4)
							{
								flag2 = true;
							}
							else
							{
								dumpp(boardField);
							}
						}
						else
						{
							grum = true;
						}
						break;
					default:
						Console.WriteLine("\nGreshka! nevalidna Komanda\n");
						break;
				}
				if (grum)
				{
					dumpp(mines);
					Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " +
						"Daj si niknejm: ", broya4);
					string niknejm = Console.ReadLine();
					Points t = new Points(niknejm, broya4);
					if (champions.Count < 5)
					{
						champions.Add(t);
					}
					else
					{
						for (int i = 0; i < champions.Count; i++)
						{
							if (champions[i].CurrentPoints < t.CurrentPoints)
							{
								champions.Insert(i, t);
								champions.RemoveAt(champions.Count - 1);
								break;
							}
						}
					}
					champions.Sort((Points r1, Points r2) => r2.Name.CompareTo(r1.Name));
					champions.Sort((Points r1, Points r2) => r2.CurrentPoints.CompareTo(r1.CurrentPoints));
					ShowChart(champions);

					boardField = CreateBoard();
					mines = PlaceMines();
					broya4 = 0;
					grum = false;
					flag = true;
				}
				if (flag2)
				{
					Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
					dumpp(mines);
					Console.WriteLine("Daj si imeto, batka: ");
					string imeee = Console.ReadLine();
					Points to4kii = new Points(imeee, broya4);
					champions.Add(to4kii);
					ShowChart(champions);
					boardField = CreateBoard();
					mines = PlaceMines();
					broya4 = 0;
					flag2 = false;
					flag = true;
				}
			}
			while (command != "exit");
			Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
			Console.WriteLine("AREEEEEEeeeeeee.");
			Console.Read();
		}

		private static void ShowChart(List<Points> points)
		{
			Console.WriteLine("\nTo4KI:");
			if (points.Count > 0)
			{
				for (int i = 0; i < points.Count; i++)
				{
					Console.WriteLine("{0}. {1} --> {2} kutii",
						i + 1, points[i].Name, points[i].CurrentPoints);
				}
				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("prazna klasaciq!\n");
			}
		}

		private static void tisinahod(char[,] field,
			char[,] mines, int row, int col)
		{
			char minesCount = kolko(mines, row, col);
            mines[row, col] = minesCount;
            field[row, col] = minesCount;
		}

		private static void dumpp(char[,] board)
		{
			int rows = board.GetLength(0);
			int cols = board.GetLength(1);
			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("   ---------------------");
			for (int i = 0; i < rows; i++)
			{
				Console.Write("{0} | ", i);
				for (int j = 0; j < cols; j++)
				{
					Console.Write(string.Format("{0} ", board[i, j]));
				}
				Console.Write("|");
				Console.WriteLine();
			}
			Console.WriteLine("   ---------------------\n");
		}

		private static char[,] CreateBoard()
		{
			int boardRows = 5;
			int boardColumns = 10;
			char[,] board = new char[boardRows, boardColumns];
			for (int i = 0; i < boardRows; i++)
			{
				for (int j = 0; j < boardColumns; j++)
				{
					board[i, j] = '?';
				}
			}

			return board;
		}

		private static char[,] PlaceMines()
		{
			int rows = 5;
			int cols = 10;
			char[,] field = new char[rows, cols];

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
                    field[i, j] = '-';
				}
			}

			List<int> r3 = new List<int>();
			while (r3.Count < 15)
			{
				Random random = new Random();
				int asfd = random.Next(50);
				if (!r3.Contains(asfd))
				{
					r3.Add(asfd);
				}
			}

			foreach (int i2 in r3)
			{
				int col = (i2 / cols);
				int row = (i2 % cols);
				if (row == 0 && i2 != 0)
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

		private static void smetki(char[,] pole)
		{
			int col = pole.GetLength(0);
			int row = pole.GetLength(1);

			for (int i = 0; i < col; i++)
			{
				for (int j = 0; j < row; j++)
				{
					if (pole[i, j] != '*')
					{
						char kolkoo = kolko(pole, i, j);
						pole[i, j] = kolkoo;
					}
				}
			}
		}

		private static char kolko(char[,] r, int rr, int rrr)
		{
			int brojkata = 0;
			int reds = r.GetLength(0);
			int kols = r.GetLength(1);

			if (rr - 1 >= 0)
			{
				if (r[rr - 1, rrr] == '*')
				{ 
					brojkata++; 
				}
			}
			if (rr + 1 < reds)
			{
				if (r[rr + 1, rrr] == '*')
				{ 
					brojkata++; 
				}
			}
			if (rrr - 1 >= 0)
			{
				if (r[rr, rrr - 1] == '*')
				{ 
					brojkata++;
				}
			}
			if (rrr + 1 < kols)
			{
				if (r[rr, rrr + 1] == '*')
				{ 
					brojkata++;
				}
			}
			if ((rr - 1 >= 0) && (rrr - 1 >= 0))
			{
				if (r[rr - 1, rrr - 1] == '*')
				{ 
					brojkata++; 
				}
			}
			if ((rr - 1 >= 0) && (rrr + 1 < kols))
			{
				if (r[rr - 1, rrr + 1] == '*')
				{ 
					brojkata++; 
				}
			}
			if ((rr + 1 < reds) && (rrr - 1 >= 0))
			{
				if (r[rr + 1, rrr - 1] == '*')
				{ 
					brojkata++; 
				}
			}
			if ((rr + 1 < reds) && (rrr + 1 < kols))
			{
				if (r[rr + 1, rrr + 1] == '*')
				{ 
					brojkata++; 
				}
			}
			return char.Parse(brojkata.ToString());
		}
	}
}
