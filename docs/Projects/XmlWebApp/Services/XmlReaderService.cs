using System.Xml.Linq;
using AutoMapper;

public class XmlReaderService
{
    private readonly IMapper _mapper;

    public XmlReaderService(IMapper mapper)
    {
        _mapper = mapper;
    }

    // public List<EmailQueue> ReadEmailQueues(string filePath)
    // {
    //     var xml = XDocument.Load(filePath);

    //     var emailQueues = _mapper.Map<List<EmailQueue>>(xml.Descendants("EmailQueue"));

    //     return emailQueues;
    // }

    public List<EmailQueue> ReadEmailQueues(string filePath)
    {
        var xml = XDocument.Load(filePath);

        var emailQueues = xml.Descendants("EmailQueue")
                             .Select(eq => new EmailQueue
                             {
                                 EmailQueueId = (int)eq.Element("EmailQueueId"),
                                 XmlData = new XmlData { Data = _mapper.Map<IXmlDataContent>(eq.Element("XmlData")) },
                                 XslName = (string)eq.Element("XslName"),
                                 IsoLanguage = (string)eq.Element("IsoLanguage"),
                                 Email = (string)eq.Element("Email"),
                                 SendAt = (DateTime)eq.Element("SendAt"),
                                 CompanyId = (int)eq.Element("CompanyId"),
                                 Sent = (bool)eq.Element("Sent"),
                                 Attempts = (int)eq.Element("Attempts"),
                                 Subject = (string)eq.Element("Subject"),
                                 Message = (string)eq.Element("Message"),
                                 Created_On = (DateTime)eq.Element("Created_On"),
                                 Created_By = (string)eq.Element("Created_By"),
                                 Modified_On = (DateTime)eq.Element("Modified_On"),
                                 Modified_By = (string)eq.Element("Modified_By")
                             })
                             .ToList();

        return emailQueues;
    }
}

// using System.Xml.Linq;

// public class XmlReaderService
// {
//     public List<EmailQueue> ReadEmailQueues(string filePath)
//     {
//         var xml = XDocument.Load(filePath);

//         var emailQueues = xml.Descendants("EmailQueue")
//                              .Select(eq => new EmailQueue
//                              {
//                                  EmailQueueId = (int)eq.Element("EmailQueueId"),
//                                  XmlData = new XmlData { Data = ParseXmlData(eq.Element("XmlData")) },
//                                  XslName = (string)eq.Element("XslName"),
//                                  IsoLanguage = (string)eq.Element("IsoLanguage"),
//                                  Email = (string)eq.Element("Email"),
//                                  SendAt = (DateTime)eq.Element("SendAt"),
//                                  CompanyId = (int)eq.Element("CompanyId"),
//                                  Sent = (bool)eq.Element("Sent"),
//                                  Attempts = (int)eq.Element("Attempts"),
//                                  Subject = (string)eq.Element("Subject"),
//                                  Message = (string)eq.Element("Message"),
//                                  Created_On = (DateTime)eq.Element("Created_On"),
//                                  Created_By = (string)eq.Element("Created_By"),
//                                  Modified_On = (DateTime)eq.Element("Modified_On"),
//                                  Modified_By = (string)eq.Element("Modified_By")
//                              })
//                              .ToList();

//         return emailQueues;
//     }

//     private IXmlDataContent ParseXmlData(XElement xmlDataElement)
//     {
//         if (xmlDataElement.Element("login") != null)
//         {
//             return new Login
//             {
//                 Fullname = (string)xmlDataElement.Element("login").Element("fullname"),
//                 Environment = (string)xmlDataElement.Element("login").Element("environment"),
//                 Ipaddress = (string)xmlDataElement.Element("login").Element("ipaddress"),
//                 Date = (DateTime)xmlDataElement.Element("login").Element("date"),
//                 Time = TimeSpan.Parse((string)xmlDataElement.Element("login").Element("time"))
//             };
//         }

//         if (xmlDataElement.Element("overdue") != null)
//         {
//             return new Overdue
//             {
//                 Fullname = (string)xmlDataElement.Element("overdue").Element("fullname"),
//                 Email = (string)xmlDataElement.Element("overdue").Element("email"),
//                 Productnr = (string)xmlDataElement.Element("overdue").Element("productnr"),
//                 Productname = (string)xmlDataElement.Element("overdue").Element("productname"),
//                 Ordercode = (string)xmlDataElement.Element("overdue").Element("ordercode"),
//                 Orderdate = (DateTime)xmlDataElement.Element("overdue").Element("orderdate"),
//                 Overduedate = (DateTime)xmlDataElement.Element("overdue").Element("overduedate")
//             };
//         }

//         if (xmlDataElement.Element("report") != null)
//         {
//             return new Report
//             {
//                 Portalname = (string)xmlDataElement.Element("report").Element("portalname"),
//                 Reportname = (string)xmlDataElement.Element("report").Element("reportname"),
//                 Url = (string)xmlDataElement.Element("report").Element("url")
//             };
//         }

//         if (xmlDataElement.Element("user") != null)
//         {
//             return new User
//             {
//                 Email = (string)xmlDataElement.Element("user").Element("email"),
//                 Fullname = (string)xmlDataElement.Element("user").Element("fullname"),
//                 Username = (string)xmlDataElement.Element("user").Element("username"),
//                 Password = (string)xmlDataElement.Element("user").Element("password"),
//                 Company = (string)xmlDataElement.Element("user").Element("company"),
//                 Url = (string)xmlDataElement.Element("user").Element("url")
//             };
//         }

//         return null;
//     }
// }

// using System.Xml;
// using System.Xml.Serialization;

// public class XmlReaderService
// {
//     public List<EmailQueue> ReadEmailQueues(string filePath)
//     {
//         var emailQueues = new List<EmailQueue>();

//         XmlDocument doc = new XmlDocument();
//         doc.Load(filePath);

//         foreach (XmlNode node in doc.SelectNodes("/EmailQueues/EmailQueue"))
//         {
//             var emailQueue = new EmailQueue();
//             emailQueue.EmailQueueId = int.Parse(node.SelectSingleNode("EmailQueueId").InnerText);
//             emailQueue.XslName = node.SelectSingleNode("XslName").InnerText;
//             emailQueue.IsoLanguage = node.SelectSingleNode("IsoLanguage").InnerText;
//             emailQueue.Email = node.SelectSingleNode("Email").InnerText;
//             emailQueue.SendAt = DateTime.Parse(node.SelectSingleNode("SendAt").InnerText);
//             emailQueue.CompanyId = int.Parse(node.SelectSingleNode("CompanyId").InnerText);
//             emailQueue.Sent = bool.Parse(node.SelectSingleNode("Sent").InnerText);
//             emailQueue.Attempts = int.Parse(node.SelectSingleNode("Attempts").InnerText);
//             emailQueue.Subject = node.SelectSingleNode("Subject").InnerText;
//             emailQueue.Message = node.SelectSingleNode("Message").InnerText;
//             emailQueue.Created_On = DateTime.Parse(node.SelectSingleNode("Created_On").InnerText);
//             emailQueue.Created_By = node.SelectSingleNode("Created_By").InnerText;
//             emailQueue.Modified_On = DateTime.Parse(node.SelectSingleNode("Modified_On").InnerText);
//             emailQueue.Modified_By = node.SelectSingleNode("Modified_By").InnerText;

//             var xmlDataNode = node.SelectSingleNode("XmlData");

//             foreach (XmlNode dataNode in xmlDataNode.ChildNodes)
//             {
//                 var serializer = new XmlSerializer(GetDataType(dataNode.Name));
//                 var reader = new StringReader(dataNode.OuterXml);
//                 var dataObject = serializer.Deserialize(reader);
//                 if (dataObject != null)
//                 {
//                     emailQueue.XmlData = (XmlData)dataObject;
//                     break;
//                 }
//             }

//             emailQueues.Add(emailQueue);
//         }

//         return emailQueues;
//     }

//     private Type GetDataType(string nodeName)
//     {
//         switch (nodeName)
//         {
//             case "login":
//                 return typeof(Login);
//             case "overdue":
//                 return typeof(Overdue);
//             case "report":
//                 return typeof(Report);
//             case "user":
//                 return typeof(User);
//             default:
//                 throw new NotSupportedException("Unsupported XmlData type: " + nodeName);
//         }
//     }
// }


// using System.Xml.Serialization;

// public class XmlReaderService
// {
//     public List<EmailQueue> ReadEmailQueues(string filePath)
//     {
//         XmlSerializer serializer = new XmlSerializer(typeof(EmailQueues));

//         using (StreamReader reader = new StreamReader(filePath))
//         {
//             var emailQueues = (EmailQueues)serializer.Deserialize(reader);
//             return emailQueues.Items;
//         }
//     }
// }