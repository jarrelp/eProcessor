using System.Xml.Linq;
using AutoMapper;

public class XmlDataConverter : ITypeConverter<XElement, IXmlDataContent>
{
    public IXmlDataContent Convert(XElement source, IXmlDataContent destination, ResolutionContext context)
    {
        if (source == null)
            return null;

        if (source.Element("login") != null)
        {
            return new Login
            {
                Fullname = (string)source.Element("login").Element("fullname"),
                Environment = (string)source.Element("login").Element("environment"),
                Ipaddress = (string)source.Element("login").Element("ipaddress"),
                Date = (DateTime)source.Element("login").Element("date"),
                Time = TimeSpan.Parse((string)source.Element("login").Element("time"))
            };
        }

        if (source.Element("overdue") != null)
        {
            return new Overdue
            {
                Fullname = (string)source.Element("overdue").Element("fullname"),
                Email = (string)source.Element("overdue").Element("email"),
                Productnr = (string)source.Element("overdue").Element("productnr"),
                Productname = (string)source.Element("overdue").Element("productname"),
                Ordercode = (string)source.Element("overdue").Element("ordercode"),
                Orderdate = (DateTime)source.Element("overdue").Element("orderdate"),
                Overduedate = (DateTime)source.Element("overdue").Element("overduedate")
            };
        }

        if (source.Element("report") != null)
        {
            return new Report
            {
                Portalname = (string)source.Element("report").Element("portalname"),
                Reportname = (string)source.Element("report").Element("reportname"),
                Url = (string)source.Element("report").Element("url")
            };
        }

        if (source.Element("user") != null)
        {
            return new User
            {
                Email = (string)source.Element("user").Element("email"),
                Fullname = (string)source.Element("user").Element("fullname"),
                Username = (string)source.Element("user").Element("username"),
                Password = (string)source.Element("user").Element("password"),
                Company = (string)source.Element("user").Element("company"),
                Url = (string)source.Element("user").Element("url")
            };
        }

        return null;
    }
}