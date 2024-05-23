namespace Ecmanage.eProcessor.Services.Send.Send.Domain.Exceptions;

public class SendMailFailedException : Exception
{
    public SendMailFailedException(string text)
        : base($"Email Sending Failed. {text}") { }
}
