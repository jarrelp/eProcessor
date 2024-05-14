namespace Ecmanage.eProcessor.Services.Send.Send.Application.Common.Models;

public abstract class BaseEmail
{
    public string EmailFrom { get; init; } = null!;
    public string EmailTo { get; init; } = null!;
    public string Subject { get; init; } = null!;
}
