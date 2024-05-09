using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Infrastructure.Data.Configurations;

public class EmailQueueItemEntityTypeConfiguration : IEntityTypeConfiguration<EmailQueueItem>
{
  public void Configure(EntityTypeBuilder<EmailQueueItem> builder)
  {
    builder.ToTable("EmailQueueItem");

    // builder.HasOne(e => e.EmailTemplate)
    // .WithOne()
    // .HasForeignKey<EmailTemplate>(e => e.Id);

    // builder.HasOne(EmailQueueItem => EmailQueueItem.EmailTemplate)
    //     .WithOne()
    //     .HasForeignKey<EmailTemplate>(emailTemplate => emailTemplate.Id);

    // builder.OwnsOne(e => e.EmailTemplate);

    // builder.HasData(
    // new EmailQueueItem(11502, "LOGIN", "aangepast@email.adr", 1),
    // new EmailQueueItem(11503, "LOGIN", "dizzel@dizzel.dizz", 2),
    // new EmailQueueItem(11504, "OVERDUE", "aangepast@email.adr", 7),
    // new EmailQueueItem(11505, "OVERDUE", "dizzel@dizzel.dizz", 8),
    // new EmailQueueItem(11506, "REPORT", "aangepast@email.adr", 5),
    // new EmailQueueItem(11507, "REPORT", "dizzel@dizzel.dizz", 6),
    // new EmailQueueItem(11508, "USER", "aangepast@email.adr", 3),
    // new EmailQueueItem(11509, "USER", "dizzel@dizzel.dizz", 4)
    // );
  }
}