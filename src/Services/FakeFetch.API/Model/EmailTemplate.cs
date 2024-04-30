using System.ComponentModel.DataAnnotations;

namespace Ecmanage.eProcessor.Services.FakeFetch.API.Model;

public abstract class EmailTemplate
{
  [Key]
  public int Id { get; set; }

  public EmailTemplate(int id)
  {
    Id = id;
  }
}
