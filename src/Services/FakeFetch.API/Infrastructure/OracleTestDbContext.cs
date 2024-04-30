namespace Ecmanage.eProcessor.Services.FakeFetch.API.Infrastructure;
public class OracleTestDbContext : DbContext
{
  public DbSet<EmailQueue> EmailQueues { get; set; }
  public DbSet<Login> Logins { get; set; }
  public DbSet<Overdue> Overdues { get; set; }
  public DbSet<Report> Reports { get; set; }
  public DbSet<User> Users { get; set; }

  public OracleTestDbContext(DbContextOptions<OracleTestDbContext> options)
      : base(options)
  { }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    var login1 = GenerateSeedData.GenerateLoginData1();
    var login2 = GenerateSeedData.GenerateLoginData2();
    var overdue1 = GenerateSeedData.GenerateOverdueData1();
    var overdue2 = GenerateSeedData.GenerateOverdueData2();
    var report1 = GenerateSeedData.GenerateReportData1();
    var report2 = GenerateSeedData.GenerateReportData2();
    var user1 = GenerateSeedData.GenerateUserData1();
    var user2 = GenerateSeedData.GenerateUserData2();

    builder.Entity<Login>().HasData(login1, login2);
    builder.Entity<Overdue>().HasData(overdue1, overdue2);
    builder.Entity<Report>().HasData(report1, report2);
    builder.Entity<User>().HasData(user1, user2);

    builder.Entity<EmailQueue>().HasData(
        new EmailQueue(11502, "LOGIN", "aangepast@email.adr") { EmailTemplateId = login1.Id },
        new EmailQueue(11503, "LOGIN", "dizzel@dizzel.dizz") { EmailTemplateId = login2.Id },
        new EmailQueue(11504, "OVERDUE", "aangepast@email.adr") { EmailTemplateId = overdue1.Id },
        new EmailQueue(11505, "OVERDUE", "dizzel@dizzel.dizz") { EmailTemplateId = overdue2.Id },
        new EmailQueue(11506, "REPORT", "aangepast@email.adr") { EmailTemplateId = report1.Id },
        new EmailQueue(11507, "REPORT", "dizzel@dizzel.dizz") { EmailTemplateId = report2.Id },
        new EmailQueue(11508, "USER", "aangepast@email.adr") { EmailTemplateId = user1.Id },
        new EmailQueue(11509, "USER", "dizzel@dizzel.dizz") { EmailTemplateId = user2.Id }
    );
  }
}
