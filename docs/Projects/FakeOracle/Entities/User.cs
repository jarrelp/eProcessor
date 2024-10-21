using System.Xml.Serialization;

namespace Models.Templates
{
    [XmlRoot("user")]
    public class User
    {
        public string Email { get; set; }

        public string FullName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Company { get; set; }

        public string Url { get; set; }
    }
}