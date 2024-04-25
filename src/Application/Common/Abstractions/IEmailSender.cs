namespace Application.Common.Abstractions;

public interface IEmailSender
{
    public Task SendEmail(string address, string subject, string content);
}