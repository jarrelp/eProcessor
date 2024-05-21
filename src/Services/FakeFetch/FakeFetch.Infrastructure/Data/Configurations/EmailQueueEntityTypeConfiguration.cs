using System.ComponentModel.DataAnnotations.Schema;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Infrastructure.Data.Configurations;

public class EmailQueueItemEntityTypeConfiguration : IEntityTypeConfiguration<EmailQueueItem>
{
  public void Configure(EntityTypeBuilder<EmailQueueItem> builder)
  {
    builder.ToTable("EmailQueueItem");

    builder.HasKey(e => e.EmailQueueId)
        .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity);
  }
}