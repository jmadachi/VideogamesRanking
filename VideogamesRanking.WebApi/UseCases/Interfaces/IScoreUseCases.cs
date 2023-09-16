namespace VideogamesRanking.UseCases
{
    public interface IScoreUseCases
    {
        Task<IEnumerable<PlanoScoreDto>> ReadSeveral(int numero);
    }
}