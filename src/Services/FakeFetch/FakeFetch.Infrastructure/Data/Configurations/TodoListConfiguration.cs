using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Infrastructure.Data.Configurations;

public class FakeFetchListConfiguration : IEntityTypeConfiguration<FakeFetchList>
{
    public void Configure(EntityTypeBuilder<FakeFetchList> builder)
    {
        builder.Property(t => t.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder
            .OwnsOne(b => b.Colour);
    }
}
