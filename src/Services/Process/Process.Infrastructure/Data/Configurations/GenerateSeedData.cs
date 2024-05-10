using Ecmanage.eProcessor.Services.Process.Process.Domain.Entities.EmailTemplates;

namespace Ecmanage.eProcessor.Services.Process.Process.Infrastructure.Data.Configurations;

public static class GenerateSeedData
{
    public static User GenerateUserData1()
    {
        string imageHeader = "header.jpg";
        string email = "john.doe@example.com";
        string fullName = "John Doe";
        string userName = "johndoe";
        string password = "password123";
        string company = "Example Company";
        string url = "http://example.com";

        User userData = new User(imageHeader, email, fullName, userName, password, company, url);
        return userData;
    }

    public static User GenerateUserData2()
    {
        string imageHeader = "header.jpg";
        string email = "gerrit.janssen@example.com";
        string fullName = "Gerrit Janssen";
        string userName = "gerritjanssen";
        string password = "password123";
        string company = "Example Company";
        string url = "http://example.com";

        User userData = new User(imageHeader, email, fullName, userName, password, company, url);
        return userData;
    }
    public static Report GenerateReportData1()
    {
        string portalName = "Portal X";
        string reportName = "Monthly Sales Report";
        string url = "http://example.com/reports/monthly-sales";

        Report reportData = new Report(portalName, reportName, url);
        return reportData;
    }

    public static Report GenerateReportData2()
    {
        string portalName = "Portal Y";
        string reportName = "Monthly Sales Report";
        string url = "http://example.com/reports/monthly-sales";

        Report reportData = new Report(portalName, reportName, url);
        return reportData;
    }

    public static Overdue GenerateOverdueData1()
    {
        string fullName = "John Doe";
        string email = "john.doe@example.com";
        string productNumber = "PROD1";
        string productName = "Product X";
        string orderCode = "ORDER1";
        string orderDate = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
        string overdueDate = DateTime.Now.ToString("yyyy-MM-dd");

        Overdue overdueData = new Overdue(fullName, email, productNumber, productName, orderCode, orderDate, overdueDate);
        return overdueData;
    }

    public static Overdue GenerateOverdueData2()
    {
        string fullName = "Gerrit Janssen";
        string email = "gerrit.janssen@example.com";
        string productNumber = "PROD2";
        string productName = "Product Y";
        string orderCode = "ORDER2";
        string orderDate = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
        string overdueDate = DateTime.Now.ToString("yyyy-MM-dd");

        Overdue overdueData = new Overdue(fullName, email, productNumber, productName, orderCode, orderDate, overdueDate);
        return overdueData;
    }

    public static Login GenerateLoginData1()
    {
        string fullName = "John Doe";
        string environment = "Production";
        string date = DateTime.Now.ToString("yyyy-MM-dd");
        string time = DateTime.Now.ToString("HH:mm:ss");

        Login loginData = new Login(fullName, environment, date, time);
        return loginData;
    }

    public static Login GenerateLoginData2()
    {
        string fullName = "Gerrit Janssen";
        string environment = "Production";
        string date = DateTime.Now.ToString("yyyy-MM-dd");
        string time = DateTime.Now.ToString("HH:mm:ss");

        Login loginData = new Login(fullName, environment, date, time);
        return loginData;
    }
}
