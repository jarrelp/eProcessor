using System.ComponentModel.DataAnnotations.Schema;

namespace Ecmanage.eProcessor.BuildingBlocks.BuildingBlocks.Domain;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTimeOffset Created { get; set; }

    public DateTimeOffset LastModified { get; set; }
}
