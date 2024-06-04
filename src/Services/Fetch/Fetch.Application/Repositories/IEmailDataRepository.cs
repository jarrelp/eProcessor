namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Repositories;

public interface IEmailDataRepository
{
  void GetAll();
  void GetByEmailQueueId(int id);
  void SetSent(int id, string newSentValue);
  Task<List<string>> GetColumnNamesAsync();
}
