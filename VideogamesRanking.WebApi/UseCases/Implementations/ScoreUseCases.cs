namespace VideogamesRanking.UseCases
{
    public class ScoreUseCases : IScoreUseCases
    {
        private readonly ApplicationDatabaseContext Context;
        private readonly IConfiguration Configuration;

        public ScoreUseCases(ApplicationDatabaseContext context, IConfiguration configuration)
        {
            Context = context;
            Configuration = configuration;
        }

        public async Task<IEnumerable<PlanoScoreDto>> ReadSeveral(int numero)
        {

            var consulta = Context.Videogames
                .Join(
                    Context.SellerCompanies,
                    videogame => videogame.SellerCompanyId,
                    seller => seller.Id,
                    (videogame, seller) => new { Videogame = videogame, SellerCompany = seller }
                )
                .Join(
                    Context.Scores,
                    videogameSeller => videogameSeller.Videogame.Id,
                    score => score.VideogameId,
                    (videogameSeller, score) => new { VideogameSeller = videogameSeller, Score = score }
                )
                .GroupBy(
                    entry => new
                    {
                        entry.VideogameSeller.Videogame.Title,
                        entry.VideogameSeller.SellerCompany.Name
                    },
                    entry => entry.Score.Value
                )
                .Select(group => new PlanoScoreDto
                {
                    Title = group.Key.Title,
                    Company = group.Key.Name,
                    Score = group.Average()
                })
                .OrderByDescending(result => result.Score)
                .Take(numero)
                .ToList();


            return consulta;
        }
                
    }
}
