using Ecmanage.eProcessor.Services.Process.Process.Domain.Entities;
using Ecmanage.eProcessor.Services.Process.Process.Domain.Entities.EmailTemplates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecmanage.eProcessor.Services.Process.Process.Infrastructure.Data.Configurations;

public class ReportEntityTypeConfiguration : IEntityTypeConfiguration<Report>
{
    public void Configure(EntityTypeBuilder<Report> builder)
    {
        builder.ToTable("Report");

        // var report1 = GenerateSeedData.GenerateReportData1();
        // var report2 = GenerateSeedData.GenerateReportData2();

        // builder.HasData(
        //     report1, report2
        // );
    }
}
