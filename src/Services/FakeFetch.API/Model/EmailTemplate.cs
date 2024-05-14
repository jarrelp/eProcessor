using System.ComponentModel.DataAnnotations;

namespace Ecmanage.eProcessor.Services.FakeFetch.API.Model;

public abstract class XmlData
{
  [Key]
  public int Id { get; set; }

  public XmlData(int id)
  {
    Id = id;
  }
}
