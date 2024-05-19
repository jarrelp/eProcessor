namespace Ecmanage.eProcessor.Services.Send.Send.Application.Common.Interfaces;

public interface IEmailCleanupService
{
    Task CleanupOldEmails(CancellationToken cancellationToken = default);
}