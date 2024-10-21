using AutoMapper;
using Models;
using Models.Templates;

class Program
{
  static void Main(string[] args)
  {
    var config = new MapperConfiguration(cfg =>
    {
      cfg.AddProfile<EmailQueueProfile>();
    });

    var mapper = config.CreateMapper();

    // XML-bestandspad
    string emailQueuesFilePath = "XmlFiles/emailqueues.xml";

    if (!File.Exists(emailQueuesFilePath))
    {
      Console.WriteLine("The file emailqueues.xml does not exist.");
      return;
    }

    // Deserialize XML-bestand naar EmailQueue object
    var emailQueues = XmlDeserializer.DeserializeFromFile<EmailQueues>(emailQueuesFilePath);

    foreach (var emailQueue in emailQueues.EmailQueueList)
    {
      // Map EmailQueue naar EmailQueueDto
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

      var xmlData = emailQueueDto.XmlData;

      Console.WriteLine("Type: " + xmlData.GetType());

      // Gebruik switch statement om de juiste eigenschappen van xmlData te printen
      switch (xmlData)
      {
        case Login loginData:
          Console.WriteLine("XmlData Type: Login");
          Console.WriteLine($"FullName: {loginData.FullName}");
          Console.WriteLine($"Environment: {loginData.Environment}");
          Console.WriteLine($"Date: {loginData.Date}");
          Console.WriteLine($"Time: {loginData.Time}");
          break;

        case Overdue overdueData:
          Console.WriteLine("XmlData Type: Overdue");
          Console.WriteLine($"FullName: {overdueData.FullName}");
          Console.WriteLine($"Email: {overdueData.Email}");
          Console.WriteLine($"ProductNumber: {overdueData.ProductNumber}");
          Console.WriteLine($"ProductName: {overdueData.ProductName}");
          Console.WriteLine($"OrderCode: {overdueData.OrderCode}");
          Console.WriteLine($"OrderDate: {overdueData.OrderDate}");
          Console.WriteLine($"OverdueDate: {overdueData.OverdueDate}");
          break;

        case Report reportData:
          Console.WriteLine("XmlData Type: Report");
          Console.WriteLine($"PortalName: {reportData.PortalName}");
          Console.WriteLine($"ReportName: {reportData.ReportName}");
          Console.WriteLine($"Url: {reportData.Url}");
          break;

        case User userData:
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




// using AutoMapper;
// using Models;
// using Models.Templates;

// class Program
// {
//   static void Main(string[] args)
//   {
//     var config = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
//     var mapper = config.CreateMapper();

//     string emailQueuesFilePath = "XmlFiles/emailqueues.xml";

//     if (!File.Exists(emailQueuesFilePath))
//     {
//       Console.WriteLine("The file emailqueues.xml does not exist.");
//       return;
//     }

//     EmailQueues emailQueues = XmlDeserializer.DeserializeFromFile<EmailQueues>(emailQueuesFilePath);

//     foreach (var queue in emailQueues.EmailQueueList)
//     {
//       var queueDto = mapper.Map<EmailQueueDto>(queue);

//       Console.WriteLine($"EmailQueueId: {queueDto.EmailQueueId}");
//       Console.WriteLine($"XslName: {queueDto.XslName}");
//       Console.WriteLine($"IsoLanguage: {queueDto.IsoLanguage}");
//       Console.WriteLine($"Email: {queueDto.Email}");
//       Console.WriteLine($"SendAt: {queueDto.SendAt}");
//       Console.WriteLine($"CompanyId: {queueDto.CompanyId}");
//       Console.WriteLine($"Sent: {queueDto.Sent}");
//       Console.WriteLine($"Attempts: {queueDto.Attempts}");
//       Console.WriteLine($"Subject: {queueDto.Subject}");
//       Console.WriteLine($"Message: {queueDto.Message}");
//       Console.WriteLine($"Created_On: {queueDto.Created_On}");
//       Console.WriteLine($"Created_By: {queueDto.Created_By}");
//       Console.WriteLine($"Modified_On: {queueDto.Modified_On}");
//       Console.WriteLine($"Modified_By: {queueDto.Modified_By}");

//       string xmlDataFilePath = queueDto.XmlData;

//       if (!File.Exists(xmlDataFilePath))
//       {
//         Console.WriteLine($"The file {xmlDataFilePath} does not exist.");
//         continue;
//       }

//       string xmlData = File.ReadAllText(xmlDataFilePath);

//       switch (queueDto.XslName)
//       {
//         case "LoginTemplate":
//           var login = XmlDeserializer.Deserialize<Login>(xmlData);
//           var loginDto = mapper.Map<LoginDto>(login);
//           Console.WriteLine($"FullName: {loginDto.FullName}");
//           Console.WriteLine($"Environment: {loginDto.Environment}");
//           Console.WriteLine($"IpAddress: {loginDto.IpAddress}");
//           Console.WriteLine($"Date: {loginDto.Date}");
//           Console.WriteLine($"Time: {loginDto.Time}");
//           break;

//         case "OverdueTemplate":
//           var overdue = XmlDeserializer.Deserialize<Overdue>(xmlData);
//           var overdueDto = mapper.Map<OverdueDto>(overdue);
//           Console.WriteLine($"FullName: {overdueDto.FullName}");
//           Console.WriteLine($"Email: {overdueDto.Email}");
//           Console.WriteLine($"ProductNumber: {overdueDto.ProductNumber}");
//           Console.WriteLine($"ProductName: {overdueDto.ProductName}");
//           Console.WriteLine($"OrderCode: {overdueDto.OrderCode}");
//           Console.WriteLine($"OrderDate: {overdueDto.OrderDate}");
//           Console.WriteLine($"OverdueDate: {overdueDto.OverdueDate}");
//           break;

//         case "ReportTemplate":
//           var report = XmlDeserializer.Deserialize<Report>(xmlData);
//           var reportDto = mapper.Map<ReportDto>(report);
//           Console.WriteLine($"PortalName: {reportDto.PortalName}");
//           Console.WriteLine($"ReportName: {reportDto.ReportName}");
//           Console.WriteLine($"Url: {reportDto.Url}");
//           break;

//         case "UserTemplate":
//           var user = XmlDeserializer.Deserialize<User>(xmlData);
//           var userDto = mapper.Map<UserDto>(user);
//           Console.WriteLine($"Email: {userDto.Email}");
//           Console.WriteLine($"FullName: {userDto.FullName}");
//           Console.WriteLine($"Username: {userDto.Username}");
//           Console.WriteLine($"Password: {userDto.Password}");
//           Console.WriteLine($"Company: {userDto.Company}");
//           Console.WriteLine($"Url: {userDto.Url}");
//           break;

//         default:
//           Console.WriteLine("Unknown XslName");
//           break;
//       }

//       Console.WriteLine();
//     }
//   }
// }