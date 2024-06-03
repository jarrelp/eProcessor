using System.Xml.Serialization;

namespace Models.Templates
{
    [XmlRoot("overdue")]
    public class Overdue
    {
        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? ProductNumber { get; set; }

        public string? ProductName { get; set; }

        public string? OrderCode { get; set; }

        public string? OrderDate { get; set; }

        public string? OverdueDate { get; set; }
    }
}