namespace VideogamesRanking.DTOs
{
    public class CreateScoreDto
    {
        public GamerDto Gamer { get; set; }
        public VideogameDto Videogame { get; set; }
        public decimal Value { get; set; }
        public DateTime ItemUpdate { get; set; }
        public string ItemUser { get; set; }
    }
}
