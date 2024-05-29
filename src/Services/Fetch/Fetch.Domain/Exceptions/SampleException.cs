namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Exceptions;

public class SampleException : Exception
{
    public SampleException(string text)
        : base($"This \"{text}\" is unsupported.")
    {
    }
}
