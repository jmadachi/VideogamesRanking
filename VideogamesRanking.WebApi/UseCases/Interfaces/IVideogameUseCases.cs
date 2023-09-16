namespace VideogamesRanking.UseCases
{
    public interface IVideogameUseCases
    {
        Task<VideogameDto> Create(CreateVideogameDto item);
        Task<VideogameDto> Delete(long id);
        Task<VideogameDto> ReadOne(long id);
        Task<IEnumerable<VideogameDto>> ReadSeveral();
        Task<VideogameDto> Update(VideogameDto item);
    }
}