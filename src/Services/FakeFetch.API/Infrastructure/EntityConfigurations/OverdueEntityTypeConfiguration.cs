namespace Ecmanage.eProcessor.Services.FakeFetch.API.Infrastructure.EntityConfigurations;

public class OverdueEntityTypeConfiguration : IEntityTypeConfiguration<Overdue>
{
    public void Configure(EntityTypeBuilder<Overdue> builder)
    {
        builder.ToTable("Overdue");

        // builder.HasKey(overdue => overdue.Id);

        // builder.Property(overdue => overdue.Id)
        //     .UseHiLo("overdue_hilo")
        //     .IsRequired();

        var overdue1 = GenerateSeedData.GenerateOverdueData1();
        var overdue2 = GenerateSeedData.GenerateOverdueData2();

        builder.HasData(
            overdue1, overdue2
        );
    }
}
