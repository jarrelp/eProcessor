using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Models.Templates;
using System;
using System.IO;

class Program
{
  static void Main(string[] args)
  {
    var serviceProvider = ConfigureServices();
    using (var serviceScope = serviceProvider.CreateScope())
    {
      var services = serviceScope.ServiceProvider;

      // Ophalen van de IMapper uit de DI-container
      var mapper = services.GetRequiredService<IMapper>();

      // XML-bestandspad
      string emailQueuesFilePath = "XmlFiles/emailqueues.xml";

      if (!File.Exists(emailQueuesFilePath))
      {
        Console.WriteLine("The file emailqueues.xml does not exist.");
        return;
      }

      // Deserialize XML-bestand naar EmailQueues object
      var emailQueues = XmlDeserializer.DeserializeFromFile<EmailQueues>(emailQueuesFilePath);

      foreach (var emailQueue in emailQueues.EmailQueueList)
      {
        // Map EmailQueue naar EmailQueueDto met behulp van AutoMapper
        var emailQueueDto = mapper.Map<EmailQueueDto>(emailQueue);

        // Output gemapte gegevens
        Console.WriteLine($"EmailQueueId: {emailQueueDto.EmailQueueId}");
        Console.WriteLine($"XmlData: {emailQueueDto.XmlData}");
        Console.WriteLine($"XslName: {emailQueueDto.XslName}");
        Console.WriteLine($"IsoLanguage: {emailQueueDto.IsoLanguage}");
        Console.WriteLine($"Email: {emailQueueDto.Email}");
        Console.WriteLine($"SendAt: {emailQueueDto.SendAt}");
        Console.WriteLine($"CompanyId: {emailQueueDto.CompanyId}");
        Console.WriteLine($"Sent: {emailQueueDto.Sent}");
        Console.WriteLine($"Attempts: {emailQueueDto.Attempts}");
        Console.WriteLine($"Subject: {emailQueueDto.Subject}");
        Console.WriteLine($"Message: {emailQueueDto.Message}");
        Console.WriteLine($"Created_On: {emailQueueDto.Created_On}");
        Console.WriteLine($"Created_By: {emailQueueDto.Created_By}");
        Console.WriteLine($"Modified_On: {emailQueueDto.Modified_On}");
        Console.WriteLine($"Modified_By: {emailQueueDto.Modified_By}");

        // Verwerk de XmlData
        var xmlData = emailQueueDto.XmlData;

        Console.WriteLine("Type: " + xmlData.GetType());

        // Verwerk de specifieke eigenschappen van XmlData afhankelijk van het type
        switch (xmlData)
        {
          case LoginDto loginData:
            Console.WriteLine("XmlData Type: Login");
            Console.WriteLine($"FullName: {loginData.FullName}");
            Console.WriteLine($"Environment: {loginData.Environment}");
            Console.WriteLine($"Date: {loginData.Date}");
            Console.WriteLine($"Time: {loginData.Time}");
            break;

          case OverdueDto overdueData:
            Console.WriteLine("XmlData Type: Overdue");
            Console.WriteLine($"FullName: {overdueData.FullName}");
            Console.WriteLine($"Email: {overdueData.Email}");
            Console.WriteLine($"ProductNumber: {overdueData.ProductNumber}");
            Console.WriteLine($"ProductName: {overdueData.ProductName}");
            Console.WriteLine($"OrderCode: {overdueData.OrderCode}");
            Console.WriteLine($"OrderDate: {overdueData.OrderDate}");
            Console.WriteLine($"OverdueDate: {overdueData.OverdueDate}");
            break;

          case ReportDto reportData:
            Console.WriteLine("XmlData Type: Report");
            Console.WriteLine($"PortalName: {reportData.PortalName}");
            Console.WriteLine($"ReportName: {reportData.ReportName}");
            Console.WriteLine($"Url: {reportData.Url}");
            break;

          case UserDto userData:
            Console.WriteLine("XmlData Type: User");
            Console.WriteLine($"Email: {userData.Email}");
            Console.WriteLine($"FullName: {userData.FullName}");
            Console.WriteLine($"UserName: {userData.Username}");
            Console.WriteLine($"Password: {userData.Password}");
            Console.WriteLine($"Company: {userData.Company}");
            Console.WriteLine($"Url: {userData.Url}");
            break;

          default:
            Console.WriteLine("Unknown XmlData Type");
            break;
        }
      }
    }
  }

  // Configuratie van de DI-container
  static IServiceProvider ConfigureServices()
  {
    var services = new ServiceCollection();

    // Registratie van AutoMapper en profiel
    services.AddAutoMapper(typeof(Program));

    // Registratie van andere services
    // services.AddTransient<IMyService, MyService>();

    return services.BuildServiceProvider();
  }
}