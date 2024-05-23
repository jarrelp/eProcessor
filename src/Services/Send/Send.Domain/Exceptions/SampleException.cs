namespace Ecmanage.eProcessor.Services.Send.Send.Domain.Exceptions;

public class SampleException : Exception
{
    public SampleException()
        : base($"Mail failed to send to email client.")
    {
    }
}
