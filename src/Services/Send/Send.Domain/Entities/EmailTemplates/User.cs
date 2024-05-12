namespace Ecmanage.eProcessor.Services.Send.Send.Domain.Entities.EmailTemplates;

public class User : EmailTemplate
{
    public string ImageHeader { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Company { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    // Constructor
    public User(string imageHeader, string email, string fullName, string userName, string password, string company, string url)
    {
        ImageHeader = imageHeader;
        Email = email;
        FullName = fullName;
        UserName = userName;
        Password = password;
        Company = company;
        Url = url;
    }
}
