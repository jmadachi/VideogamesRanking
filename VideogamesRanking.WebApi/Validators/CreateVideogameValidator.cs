namespace VideogamesRanking.WebApi.Validators
{
    public class CreateVideogameValidator: AbstractValidator<CreateVideogameDto>
    {
        public CreateVideogameValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty();
            RuleFor(x => x.Price)
                .NotEmpty().GreaterThanOrEqualTo(0);
        }
    }
}
