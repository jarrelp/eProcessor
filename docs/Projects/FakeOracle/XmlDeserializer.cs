using System.Xml;
using System.Xml.Serialization;

public static class XmlDeserializer
{
    public static T Deserialize<T>(string xml)
    {
        XmlSerializer serializer = new(typeof(T));
        using StringReader reader = new(xml);
        return (T)serializer.Deserialize(reader);
    }

    public static T DeserializeFromFile<T>(string filePath) where T : class
    {
        var serializer = new XmlSerializer(typeof(T));
        using (var reader = XmlReader.Create(filePath))
        {
            return serializer.Deserialize(reader) as T;
        }
    }
}