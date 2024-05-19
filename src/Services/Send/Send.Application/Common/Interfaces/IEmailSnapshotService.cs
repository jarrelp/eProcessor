using Ecmanage.eProcessor.Services.Send.Send.Domain.Entities;

namespace Ecmanage.eProcessor.Services.Send.Send.Application.Common.Interfaces;

public interface IEmailSnapshotService
{
    Task SaveEmailSnapshotAsync(EmailSnapshot emailSnapshot, CancellationToken cancellationToken = default);
}