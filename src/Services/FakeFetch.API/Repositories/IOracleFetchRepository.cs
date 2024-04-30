namespace Ecmanage.eProcessor.Services.FakeFetch.API.Repositories;

public interface IOracleFetchRepository
{
  Task<List<EmailQueue>> GetAllAsync();
  Task<EmailQueue> GetByIdAsync(int id);
  Task AddAsync(EmailQueue emailQueue);
  Task UpdateAsync(EmailQueue emailQueue);
  Task DeleteAsync(EmailQueue emailQueue);
}
