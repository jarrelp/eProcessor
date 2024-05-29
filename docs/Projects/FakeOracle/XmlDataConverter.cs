using System.Xml;
using System.Xml.Serialization;
using AutoMapper;
using Models.Templates;

public class XmlDataConverter : IValueConverter<string, object>
{
    public object Convert(string sourceMember, ResolutionContext context)
    {
        if (string.IsNullOrWhiteSpace(sourceMember))
            return null;

        // Deserialiseer de XML-gegevens naar het juiste type object op basis van de inhoud van de XmlData
        using (StringReader reader = new StringReader(sourceMember))
        {
            using (XmlReader xmlReader = XmlReader.Create(reader))
            {
                // Zoek het root element om het type XML-object te identificeren
                xmlReader.MoveToContent();
                string rootElement = xmlReader.LocalName;

                // Deserialiseer naar het juiste type op basis van het root element
                switch (rootElement)
                {
                    case "login":
                        return DeserializeXml<Login>(sourceMember);
                    case "overdue":
                        return DeserializeXml<Overdue>(sourceMember);
                    case "report":
                        return DeserializeXml<Report>(sourceMember);
                    case "user":
                        return DeserializeXml<User>(sourceMember);
                    default:
                        throw new InvalidOperationException("Unknown XmlData type.");
                }
            }
        }
    }

    private T DeserializeXml<T>(string xmlData) where T : class
    {
        var serializer = new XmlSerializer(typeof(T));
        using (var reader = new StringReader(xmlData))
        {
            return serializer.Deserialize(reader) as T;
        }
    }
}