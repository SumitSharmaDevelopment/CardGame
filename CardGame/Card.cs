namespace CardGame
{
    /// <summary>
    /// Add card properties
    /// </summary>
    public class Card
    {
        public string DisplayName { get; set; }
        public Suit Suit { get; set; }
        public int Value { get; set; }
    }
}