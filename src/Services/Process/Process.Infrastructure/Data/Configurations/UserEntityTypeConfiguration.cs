using Ecmanage.eProcessor.Services.Process.Process.Domain.Entities;
using Ecmanage.eProcessor.Services.Process.Process.Domain.Entities.EmailTemplates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecmanage.eProcessor.Services.Process.Process.Infrastructure.Data.Configurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        // var user1 = GenerateSeedData.GenerateUserData1();
        // var user2 = GenerateSeedData.GenerateUserData2();

        // builder.HasData(
        //     user1, user2
        // );
    }
}
