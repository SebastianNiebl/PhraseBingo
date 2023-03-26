namespace PhraseBingo
{
    public class BingoCardService
    {
        string[] phrases;
        public BingoCardService(string[] Phrases)
        {
            phrases = Phrases;
        }
        public async Task<BingoCard> GenerateCardAsync()
        {
            var random = new Random();
            var selectedPhrases = phrases.OrderBy(_ => random.Next()).Take(BingoCard.Size * BingoCard.Size).ToArray();
            var cardPhrases = new string[BingoCard.Size, BingoCard.Size];

            for (int i = 0; i < BingoCard.Size; i++)
            {
                for (int j = 0; j < BingoCard.Size; j++)
                {
                    cardPhrases[i, j] = selectedPhrases[i * BingoCard.Size + j];
                }
            }

            return new BingoCard(cardPhrases);
        }
    }
}
