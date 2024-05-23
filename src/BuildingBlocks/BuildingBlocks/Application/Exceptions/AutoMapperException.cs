namespace Ecmanage.eProcessor.BuildingBlocks.BuildingBlocks.Application.Exceptions;

public class AutoMapperException : Exception
{
    public Type SourceType { get; }
    public Type DestinationType { get; }

    public AutoMapperException(Type sourceType, Type destinationType)
        : base($"Failed to map from {sourceType.FullName} to {destinationType.FullName}.")
    {
        SourceType = sourceType;
        DestinationType = destinationType;
    }

    public AutoMapperException(Type sourceType, Type destinationType, Exception innerException)
        : base($"Failed to map from {sourceType.FullName} to {destinationType.FullName}.", innerException)
    {
        SourceType = sourceType;
        DestinationType = destinationType;
    }
}