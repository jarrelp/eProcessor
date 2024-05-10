namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities.EmailTemplates;

public class Login : EmailTemplate
{
    public string FullName { get; set; } = string.Empty;
    public string Environment { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
    public string Time { get; set; } = string.Empty;

    public Login(string fullName, string environment,
    // string ipAddress, 
    string date, string time)
    {
        FullName = fullName;
        Environment = environment;
        // IPAddress = ipAddress;
        Date = date;
        Time = time;
    }
}