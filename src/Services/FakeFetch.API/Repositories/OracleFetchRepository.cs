namespace Ecmanage.eProcessor.Services.FakeFetch.API.Repositories;

public class OracleFetchRepository : IOracleFetchRepository
{
  private readonly OracleTestDbContext _context;

  public OracleFetchRepository(OracleTestDbContext context)
  {
    _context = context;
  }

  public async Task<List<EmailQueue>> GetAllAsync()
  {
    var emailQueues = await _context.EmailQueues
        .Include(eq => eq.XmlData)
        .ToListAsync();

    // foreach (var emailQueue in emailQueues)
    // {
    //   if (emailQueue.XmlData != null)
    //   {
    //     Console.WriteLine($"EmailQueueId: {emailQueue.EmailQueueId}, XmlData Type: {emailQueue.XmlData.GetType().Name}");
    //   }
    //   else
    //   {
    //     Console.WriteLine($"EmailQueueId: {emailQueue.EmailQueueId}, XmlData: null");
    //   }
    // }

    foreach (var emailQueue in emailQueues)
    {
      if (emailQueue.XmlData != null)
      {
        Console.WriteLine($"EmailQueueId: {emailQueue.Id}, XmlData Type: {emailQueue.XmlData.GetType().Name}");

        switch (emailQueue.XmlData)
        {
          case Login loginTemplate:
            Console.WriteLine($"Login Template Attributes:");
            Console.WriteLine($"  FullName: {loginTemplate.FullName}");
            Console.WriteLine($"  Environment: {loginTemplate.Environment}");
            Console.WriteLine($"  Date: {loginTemplate.Date}");
            Console.WriteLine($"  Time: {loginTemplate.Time}");
            break;
          case Overdue overdueTemplate:
            Console.WriteLine($"Overdue Template Attributes:");
            Console.WriteLine($"  FullName: {overdueTemplate.FullName}");
            Console.WriteLine($"  Email: {overdueTemplate.Email}");
            Console.WriteLine($"  ProductNumber: {overdueTemplate.ProductNumber}");
            Console.WriteLine($"  ProductName: {overdueTemplate.ProductName}");
            Console.WriteLine($"  OrderCode: {overdueTemplate.OrderCode}");
            Console.WriteLine($"  OrderDate: {overdueTemplate.OrderDate}");
            Console.WriteLine($"  OverdueDate: {overdueTemplate.OverdueDate}");
            break;
          case Report reportTemplate:
            Console.WriteLine($"Report Template Attributes:");
            Console.WriteLine($"  PortalName: {reportTemplate.PortalName}");
            Console.WriteLine($"  ReportName: {reportTemplate.ReportName}");
            Console.WriteLine($"  Url: {reportTemplate.Url}");
            break;
          case User userTemplate:
            Console.WriteLine($"User Template Attributes:");
            Console.WriteLine($"  ImageHeader: {userTemplate.ImageHeader}");
            Console.WriteLine($"  Email: {userTemplate.Email}");
            Console.WriteLine($"  FullName: {userTemplate.FullName}");
            Console.WriteLine($"  UserName: {userTemplate.UserName}");
            Console.WriteLine($"  Password: {userTemplate.Password}");
            Console.WriteLine($"  Company: {userTemplate.Company}");
            Console.WriteLine($"  Url: {userTemplate.Url}");
            break;
        }
      }
      else
      {
        Console.WriteLine($"EmailQueueId: {emailQueue.Id}, XmlData: null");
      }
    }

    // foreach (var emailQueue in emailQueues)
    // {
    //   if (emailQueue != null && emailQueue.XmlData != null)
    //   {
    //     switch (emailQueue.XmlData)
    //     {
    //       case Login loginTemplate:
    //         emailQueue.XmlData = loginTemplate;
    //         break;
    //       case Overdue overdueTemplate:
    //         emailQueue.XmlData = overdueTemplate;
    //         break;
    //       case Report reportTemplate:
    //         emailQueue.XmlData = reportTemplate;
    //         break;
    //       case User userTemplate:
    //         emailQueue.XmlData = userTemplate;
    //         break;
    //     }
    //   }
    // }

    return emailQueues;
  }

  public async Task<EmailQueue> GetByIdAsync(int id)
  {
    // return await _context.EmailQueues
    //   .Include(eq => eq.XmlData)
    //   .FirstOrDefaultAsync(eq => eq.EmailQueueId == id);
    var emailQueue = await _context.EmailQueues
        .Include(eq => eq.XmlData)
        .FirstOrDefaultAsync(eq => eq.Id == id) ?? throw new Exception();
    return emailQueue;
  }

  public async Task AddAsync(EmailQueue emailQueue)
  {
    await _context.EmailQueues.AddAsync(emailQueue);
    await _context.SaveChangesAsync();
  }

  public async Task UpdateAsync(EmailQueue emailQueue)
  {
    _context.Entry(emailQueue).State = EntityState.Modified;
    await _context.SaveChangesAsync();
  }

  public async Task DeleteAsync(EmailQueue emailQueue)
  {
    _context.EmailQueues.Remove(emailQueue);
    await _context.SaveChangesAsync();
  }
}
