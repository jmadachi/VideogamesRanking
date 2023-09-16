﻿namespace VidegamesRanking.Entities
{
    public class Videogame
    {
        public long Id { get; set; }
        public long SellerCompanyId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public decimal Score { get; set; }
        public DateTime ItemUpdate {  get; set; }
        public string ItemUser { get; set; }
    }
}
