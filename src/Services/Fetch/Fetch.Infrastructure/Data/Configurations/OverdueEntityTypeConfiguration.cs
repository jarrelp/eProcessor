using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities.EmailTemplates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Infrastructure.Data.Configurations;

public class OverdueEntityTypeConfiguration : IEntityTypeConfiguration<Overdue>
{
    public void Configure(EntityTypeBuilder<Overdue> builder)
    {
        builder.ToTable("Overdue");

        // var overdue1 = GenerateSeedData.GenerateOverdueData1();
        // var overdue2 = GenerateSeedData.GenerateOverdueData2();

        // builder.HasData(
        //     overdue1, overdue2
        // );
    }
}
