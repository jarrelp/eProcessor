using System.Xml.Serialization;

string filePath = "overdue.xml";

if (!File.Exists(filePath))
{
  Console.WriteLine("The file overdue.xml does not exist.");
  return;
}

XmlSerializer serializer = new(typeof(Overdue));
using StreamReader reader = new(filePath);
Overdue overdue = (Overdue)serializer.Deserialize(reader);
Console.WriteLine($"Full Name: {overdue.FullName}");
Console.WriteLine($"Email: {overdue.Email}");
Console.WriteLine($"Product Number: {overdue.ProductNumber}");
Console.WriteLine($"Product Name: {overdue.ProductName}");
Console.WriteLine($"Order Code: {overdue.OrderCode}");
Console.WriteLine($"Order Date: {overdue.OrderDate.ToShortDateString()}");
Console.WriteLine($"Overdue Date: {overdue.OverdueDate.ToShortDateString()}");
