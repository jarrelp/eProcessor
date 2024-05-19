namespace Ecmanage.eProcessor.Services.Send.Send.Domain.Exceptions;

public class SendMailFailedException : Exception
{
    public SendMailFailedException(string text)
        : base($"This \"{text}\" is unsupported.")
    {
    }
}
