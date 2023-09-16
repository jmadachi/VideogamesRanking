namespace VideogamesRanking.UseCases
{
    public class SellerCompanyUseCases : ISellerCompanyUseCases
    {
        private readonly ApplicationDatabaseContext Context;
        private readonly IConfiguration Configuration;

        public SellerCompanyUseCases(ApplicationDatabaseContext context, IConfiguration configuration)
        {
            Context = context;
            Configuration = configuration;
        }

        public async Task<IEnumerable<SellerCompanyDto>> ReadSeveral()
        {
            var companies = await Context.SellerCompanies.ToListAsync();

            var companiesDto =  new List<SellerCompanyDto>();
            foreach (var company in companies)
            {
                companiesDto.Add(new SellerCompanyDto()
                {
                    Id = company.Id,
                    Code= company.Code,
                    Name = company.Name,
                    ItemUpdate = company.ItemUpdate,
                    ItemUser = company.ItemUser
                });
            }
            return companiesDto;
        }

        public async Task<SellerCompanyDto> ReadOne(long id)
        {
            var company = await Context.SellerCompanies.FirstOrDefaultAsync(x => x.Id == id);
            var companyDto = new SellerCompanyDto()
            {
                Id = company.Id,
                Code = company.Code,
                Name = company.Name,
                ItemUpdate = company.ItemUpdate,
                ItemUser = company.ItemUser
            };
            return companyDto;
        }

        public async Task<SellerCompanyDto> Create(CreateSellerCompanyDto item)
        {
            var company = new SellerCompany
            {
                Code = item.Code,
                Name = item.Name
            };
            Context.SellerCompanies.Add(company);
            await Context.SaveChangesAsync();
            var companyDto = new SellerCompanyDto()
            {
                Id = company.Id,
                Code = company.Code,
                Name = company.Name,
                ItemUpdate = company.ItemUpdate,
                ItemUser = company.ItemUser
            };
            return companyDto;
        }

        public async Task<SellerCompanyDto> Update(SellerCompanyDto item)
        {
            var company = Context.SellerCompanies.FirstOrDefault(x => x.Id == item.Id);
            if (company != null)
            {
                company.Code = item.Code;
                company.Name = item.Name;
                Context.SellerCompanies.Update(company);
                await Context.SaveChangesAsync();
            }
            var companyDto = new SellerCompanyDto()
            {
                Id = company.Id,
                Code = company.Code,
                Name = company.Name,
                ItemUpdate = company.ItemUpdate,
                ItemUser = company.ItemUser
            };
            return companyDto;
        }

        public async Task<SellerCompanyDto> Delete(long id)
        {
            var company = await Context.SellerCompanies.FirstOrDefaultAsync(x => x.Id == id);
            if (company == null)
            {
                throw new Exception("No fue posible encontrar una Empresa con los Datos suministrados");
            }
            Context.SellerCompanies.Remove(company);
            await Context.SaveChangesAsync();
            var companyDto = new SellerCompanyDto()
            {
                Id = company.Id,
                Code = company.Code,
                Name = company.Name,
                ItemUpdate = company.ItemUpdate,
                ItemUser = company.ItemUser
            };
            return companyDto;
        }
    }
}
