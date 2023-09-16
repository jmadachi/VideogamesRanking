namespace VideogamesRanking.UseCases
{
    public interface ISellerCompanyUseCases
    {
        Task<SellerCompanyDto> Create(CreateSellerCompanyDto item);
        Task<SellerCompanyDto> Delete(long id);
        Task<SellerCompanyDto> ReadOne(long id);
        Task<IEnumerable<SellerCompanyDto>> ReadSeveral();
        Task<SellerCompanyDto> Update(SellerCompanyDto item);
    }
}