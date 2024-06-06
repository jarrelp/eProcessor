using Ecmanage.eProcessor.BuildingBlocks.EventBus.Events;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Repositories;

public interface IEmailDataRepository
{
  Task<List<IntegrationEvent>> GetIntegrationEvents(int count = 5);
  void GetAllProcessed();
  void GetAllNotPickedUp();
  void SetSentToNotPickedUp(int id);
  void SetSentToProcessed(int id);
  void SetAllSentToNotPickedUp();
  void SetSentToIsBusy(int id);
  void SetSentToError(int id);
  void SetAttempt(int id, int attempts);
  void DeleteAllEmailQueueItems();
  void GenerateEmails(int amount);
  Task<List<string>> GetColumnNamesAsync();
}