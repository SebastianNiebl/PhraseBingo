namespace PhraseBingo
{
    public class BingoCard
    {
        public static int Size = 5;
        public string[,] Phrases { get; set; }
        public bool[,] Marked { get; set; }

        public BingoCard(string[,] phrases)
        {
            Phrases = phrases;
            Marked = new bool[Size, Size];
        }

        public void Mark(int row, int col)
        {
            try
            {
                Marked[row, col] = true;
            }
            catch (Exception)
            {

                Console.WriteLine(row);
                Console.WriteLine(col);
            }
        }

        public bool CheckWin()
        {
            // Check rows and columns
            for (int i = 0; i < Size; i++)
            {
                if (Enumerable.Range(0, Size).All(j => Marked[i, j]) ||
                    Enumerable.Range(0, Size).All(j => Marked[j, i]))
                {
                    return true;
                }
            }

            // Check diagonals
            if (Enumerable.Range(0, Size).All(i => Marked[i, i]) ||
                Enumerable.Range(0, Size).All(i => Marked[i, Size - 1 - i]))
            {
                return true;
            }

            return false;
        }
    }

}
