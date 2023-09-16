namespace VideogamesRanking.Repositories.EntityFramework
{
    public class CompanyConfiguration : IEntityTypeConfiguration<SellerCompany>
    {
        public void Configure(EntityTypeBuilder<SellerCompany> builder)
        {
            builder.ToTable("SellerCompanies");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");
            builder.Property(x => x.Code)
                .HasColumnName("Code");
            builder.Property(x => x.Name)
                .HasColumnName("Name");
            builder.Property(x => x.ItemUpdate)
                .HasColumnName("ItemUpdate");
            builder.Property(x => x.ItemUser)
                .HasColumnName("ItemUser");
        }
    }
}
