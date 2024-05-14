namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Exceptions;

public class SampleException : Exception
{
    public SampleException(string text)
        : base($"This \"{text}\" is unsupported.")
    {
    }
}
