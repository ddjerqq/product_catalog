namespace Application.Common.Abstractions;

public interface IEmailSenderFactory
{
    public IEmailSender GetEmailSender(string address);
}