namespace VideogamesRanking.Repositories.EntityFramework
{
    public class VideogameConfiguration : IEntityTypeConfiguration<Videogame>
    {
        public void Configure(EntityTypeBuilder<Videogame> builder)
        {
            builder.ToTable("Videogames");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");
            builder.Property(x => x.SellerCompanyId)
                .HasColumnName("SellerCompanyId");
            builder.Property(x => x.Title)
                .HasColumnName("Title");
            builder.Property(x => x.Year)
                .HasColumnName("Year");
            builder.Property(x => x.Price)
                .HasColumnName("Price");
            builder.Property(x => x.Score)
                .HasColumnName("Score");
            builder.Property(x => x.ItemUpdate)
                .HasColumnName("ItemUpdate");
            builder.Property(x => x.ItemUser)
                .HasColumnName("ItemUser");
        }
    }
}
