namespace VideogamesRanking.DTOs
{
    public class VideogameDto
    {
        public long Id { get; set; }
        public SellerCompanyDto SellerCompany { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public decimal Score { get; set; }
        public DateTime ItemUpdate { get; set; }
        public string ItemUser { get; set; }
    }
}
