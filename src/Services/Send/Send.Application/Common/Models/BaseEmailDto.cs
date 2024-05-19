namespace Ecmanage.eProcessor.Services.Send.Send.Application.Common.Models;

public abstract class BaseEmailDto
{
    public int EmailQueueId { get; init; }
    public string EmailFrom { get; init; } = null!;
    public string EmailTo { get; init; } = null!;
    public string Subject { get; init; } = null!;
}
