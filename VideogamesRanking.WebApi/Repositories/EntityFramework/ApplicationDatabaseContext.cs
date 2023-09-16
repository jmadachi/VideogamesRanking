namespace VideogamesRanking.Repositories.EntityFramework
{
    public class ApplicationDatabaseContext : IdentityDbContext
    {
        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options) { }

        public DbSet<Gamer> Gamers { get; set; }
        public DbSet<Videogame> Videogames { get; set; }
        public DbSet<SellerCompany> SellerCompanies { get; set; }
        public DbSet<Score> Scores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
