namespace VidegamesRanking.Entities
{
    public class Score
    {
        public string Id { get; set; }
        public long GamerId { get; set; }
        public long VideogameId { get; set; }
        public decimal Value { get; set; }
        public DateTime ItemUpdate {  get; set; }
        public string ItemUser { get; set; }
    }
}
