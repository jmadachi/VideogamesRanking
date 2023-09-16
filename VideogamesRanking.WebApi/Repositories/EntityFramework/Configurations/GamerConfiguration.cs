namespace VideogamesRanking.Repositories.EntityFramework
{
    public class GamerConfiguration : IEntityTypeConfiguration<Gamer>
    {
        public void Configure(EntityTypeBuilder<Gamer> builder)
        {
            builder.ToTable("Gamers");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");
            builder.Property(x => x.Nickname)
                .HasColumnName("Nickname");
            builder.Property(x => x.ItemUpdate)
                .HasColumnName("ItemUpdate");
            builder.Property(x => x.ItemUser)
                .HasColumnName("ItemUser");
        }
    }
}
