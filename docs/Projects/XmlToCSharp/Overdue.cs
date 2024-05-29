using System.Xml.Serialization;

[XmlRoot("overdue")]
public class Overdue
{
    private string _fullName;
    private string _email;
    private string _productNumber;
    private string _productName;
    private string _orderCode;

    [XmlElement("fullname")]
    public string FullName
    {
        get => _fullName;
        set => _fullName = value?.Trim();
    }

    [XmlElement("email")]
    public string Email
    {
        get => _email;
        set => _email = value?.Trim();
    }

    [XmlElement("productnr")]
    public string ProductNumber
    {
        get => _productNumber;
        set => _productNumber = value?.Trim();
    }

    [XmlElement("productname")]
    public string ProductName
    {
        get => _productName;
        set => _productName = value?.Trim();
    }

    [XmlElement("ordercode")]
    public string OrderCode
    {
        get => _orderCode;
        set => _orderCode = value?.Trim();
    }

    [XmlElement("orderdate")]
    public DateTime OrderDate { get; set; }

    [XmlElement("overduedate")]
    public DateTime OverdueDate { get; set; }
}