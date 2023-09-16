namespace VideogamesRanking.Repositories.EntityFramework
{
    public class ScoreConfiguration : IEntityTypeConfiguration<Score>
    {
        public void Configure(EntityTypeBuilder<Score> builder)
        {
            builder.ToTable("Scores");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");
            builder.Property(x => x.GamerId)
                .HasColumnName("GamerId");
            builder.Property(x => x.VideogameId)
                .HasColumnName("VideogameId");
            builder.Property(x => x.Value)
                .HasColumnName("Value");
            builder.Property(x => x.ItemUpdate)
                .HasColumnName("ItemUpdate");
            builder.Property(x => x.ItemUser)
                .HasColumnName("ItemUser");
        }
    }
}
