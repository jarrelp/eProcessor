using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Infrastructure.Data.Configurations;

public class EmailQueueItemEntityTypeConfiguration : IEntityTypeConfiguration<EmailQueueItem>
{
  public void Configure(EntityTypeBuilder<EmailQueueItem> builder)
  {
    builder.ToTable("EmailQueueItem")
      .Property(e => e.EmailQueueId)
      .ValueGeneratedOnAdd() // Zorg ervoor dat de waarde wordt gegenereerd bij het toevoegen
      .HasDefaultValueSql("CONVERT(int, Id)"); // Stel de waarde in op dezelfde als de Id
  }
}