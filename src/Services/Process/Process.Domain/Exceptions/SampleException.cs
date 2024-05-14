namespace Ecmanage.eProcessor.Services.Process.Process.Domain.Exceptions;

public class SampleException : Exception
{
    public SampleException(string text)
        : base($"This \"{text}\" is unsupported.")
    {
    }
}
