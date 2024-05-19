using Ecmanage.eProcessor.Services.Send.Send.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecmanage.eProcessor.Services.Send.Send.Infrastructure.Data.Configurations;

public class EmailSnapshotEntityTypeConfiguration : IEntityTypeConfiguration<EmailSnapshot>
{
  public void Configure(EntityTypeBuilder<EmailSnapshot> builder)
  {
    builder.ToTable("EmailSnapshot");
  }
}