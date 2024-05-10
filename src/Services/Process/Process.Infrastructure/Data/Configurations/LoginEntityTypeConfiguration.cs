using Ecmanage.eProcessor.Services.Process.Process.Domain.Entities;
using Ecmanage.eProcessor.Services.Process.Process.Domain.Entities.EmailTemplates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecmanage.eProcessor.Services.Process.Process.Infrastructure.Data.Configurations;

public class LoginEntityTypeConfiguration : IEntityTypeConfiguration<Login>
{
    public void Configure(EntityTypeBuilder<Login> builder)
    {
        builder.ToTable("Login");

        // var login1 = GenerateSeedData.GenerateLoginData1();
        // var login2 = GenerateSeedData.GenerateLoginData2();

        // builder.HasData(
        //     login1, login2
        // );
    }
}
