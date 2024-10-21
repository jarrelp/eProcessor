using System.Xml.Serialization;

namespace Models.Templates
{
    [XmlRoot("login")]
    public class Login
    {
        public string FullName { get; set; }

        public string Environment { get; set; }

        public string IpAddress { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }
    }
}