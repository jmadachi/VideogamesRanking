namespace VideogamesRanking.UseCases
{
    public class VideogameUseCases : IVideogameUseCases
    {
        private readonly ApplicationDatabaseContext Context;
        private readonly IConfiguration Configuration;

        public VideogameUseCases(ApplicationDatabaseContext context, IConfiguration configuration)
        {
            Context = context;
            Configuration = configuration;
        }

        public async Task<IEnumerable<VideogameDto>> ReadSeveral()
        {

            var queryableVideogames =
                (
                    from tVideogames in Context.Videogames
                    from tCompanies in Context.SellerCompanies.Where(x => x.Id == tVideogames.SellerCompanyId).DefaultIfEmpty()
                    select new VideogameDto
                    {
                        Id = tVideogames.Id,
                        SellerCompany = new SellerCompanyDto
                        {
                            Id = tCompanies.Id,
                            Code = tCompanies.Code,
                            Name = tCompanies.Name,
                            ItemUpdate = tCompanies.ItemUpdate,
                            ItemUser = tCompanies.ItemUser
                        },
                        Title = tVideogames.Title,
                        Score = tVideogames.Score,
                        Year = tVideogames.Year,
                        Price = tVideogames.Price,
                        ItemUpdate = tCompanies.ItemUpdate,
                        ItemUser = tCompanies.ItemUser
                    }
                ).AsQueryable();
            var listVideogames = await queryableVideogames.ToListAsync();

            return listVideogames;
        }

        public async Task<VideogameDto> ReadOne(long id)
        {
            var queryableVideogames =
                (
                    from tVideogames in Context.Videogames.Where(x => x.Id == id)
                    from tCompanies in Context.SellerCompanies.Where(x => x.Id == tVideogames.SellerCompanyId).DefaultIfEmpty()
                    select new VideogameDto
                    {
                        Id = tVideogames.Id,
                        SellerCompany = new SellerCompanyDto
                        {
                            Id = tCompanies.Id,
                            Code = tCompanies.Code,
                            Name = tCompanies.Name,
                            ItemUpdate = tCompanies.ItemUpdate,
                            ItemUser = tCompanies.ItemUser
                        },
                        Title = tVideogames.Title,
                        Score = tVideogames.Score,
                        Year = tVideogames.Year,
                        Price = tVideogames.Price,
                        ItemUpdate = tCompanies.ItemUpdate,
                        ItemUser = tCompanies.ItemUser
                    }
                ).AsQueryable();
            var videogame = await queryableVideogames.FirstOrDefaultAsync();

            return videogame;
        }

        public async Task<VideogameDto> Create(CreateVideogameDto item)
        {
            var videogame = new Videogame
            {
                SellerCompanyId = item.CompanyId,
                Title = item.Title,
                Year = item.Year,
                Price = item.Price,
                Score = 0,
                ItemUpdate = item.ItemUpdate,
                ItemUser = item.ItemUser    
            };
            Context.Videogames.Add(videogame);
            await Context.SaveChangesAsync();
            var videogameDto = new VideogameDto()
            {
                Id = videogame.Id,
                Title = videogame.Title,
                Year = videogame.Year,
                Price = videogame.Price,
                ItemUpdate = videogame.ItemUpdate,
                ItemUser = videogame.ItemUser
            };
            return videogameDto;
        }

        public async Task<VideogameDto> Update(VideogameDto item)
        {
            var videogame = Context.Videogames.FirstOrDefault(x => x.Id == item.Id);
            if (videogame != null)
            {
                videogame.SellerCompanyId = item.SellerCompany.Id;
                videogame.Title = item.Title;
                videogame.Year = item.Year;
                videogame.Price = item.Price;
                videogame.ItemUpdate = item.ItemUpdate;
                videogame.ItemUser = item.ItemUser;
                Context.Videogames.Update(videogame);
                await Context.SaveChangesAsync();
            }
            return item;
        }

        public async Task<VideogameDto> Delete(long id)
        {
            var videogame = await Context.Videogames.FirstOrDefaultAsync(x => x.Id == id);
            if (videogame == null)
            {
                throw new Exception("No fue posible encontrar una Empresa con los Datos suministrados");
            }
            Context.Videogames.Remove(videogame);
            await Context.SaveChangesAsync();
            var videogameDto = new VideogameDto()
            {
                Id = videogame.Id,
                Title = videogame.Title,
                Year = videogame.Year,
                Price = videogame.Price,
                ItemUpdate = videogame.ItemUpdate,
                ItemUser = videogame.ItemUser
            };
            return videogameDto;
        }
    }
}
