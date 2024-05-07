using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Infrastructure.Data.Configurations;

public class FakeFetchItemConfiguration : IEntityTypeConfiguration<FakeFetchItem>
{
    public void Configure(EntityTypeBuilder<FakeFetchItem> builder)
    {
        builder.Property(t => t.Title)
            .HasMaxLength(200)
            .IsRequired();
    }
}
