namespace Ecmanage.eProcessor.Services.FakeFetch.API.Infrastructure.EntityConfigurations;

public class EmailQueueEntityTypeConfiguration : IEntityTypeConfiguration<EmailQueue>
{
  public void Configure(EntityTypeBuilder<EmailQueue> builder)
  {
    builder.ToTable("EmailQueue");

    builder.HasKey(emailQueue => emailQueue.Id);

    builder.HasOne(e => e.EmailTemplate)
    .WithOne()
    .HasForeignKey<EmailTemplate>(e => e.Id);

    // builder.HasOne(emailQueue => emailQueue.EmailTemplate)
    //     .WithOne()
    //     .HasForeignKey<EmailTemplate>(emailTemplate => emailTemplate.Id);

    // builder.OwnsOne(e => e.EmailTemplate);

    builder.HasData(
    new EmailQueue(11502, "LOGIN", "aangepast@email.adr", 1),
    new EmailQueue(11503, "LOGIN", "dizzel@dizzel.dizz", 2),
    new EmailQueue(11504, "OVERDUE", "aangepast@email.adr", 7),
    new EmailQueue(11505, "OVERDUE", "dizzel@dizzel.dizz", 8),
    new EmailQueue(11506, "REPORT", "aangepast@email.adr", 5),
    new EmailQueue(11507, "REPORT", "dizzel@dizzel.dizz", 6),
    new EmailQueue(11508, "USER", "aangepast@email.adr", 3),
    new EmailQueue(11509, "USER", "dizzel@dizzel.dizz", 4)
    );
  }
}