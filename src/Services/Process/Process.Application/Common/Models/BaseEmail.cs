namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Models;

public abstract class BaseEmail
{
    public int EmailQueueId { get; init; }
    public string EmailFrom { get; init; } = null!;
    public string EmailTo { get; init; } = null!;
    public string Subject { get; init; } = null!;
}
