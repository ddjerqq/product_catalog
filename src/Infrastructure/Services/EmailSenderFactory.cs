using Application.Common.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services;

public class EmailSenderFactory(IServiceProvider sp) : IEmailSenderFactory
{
    public IEmailSender GetEmailSender(string address)
    {
        return address.Split("@") switch
        {
            [.., "gmail.com"] => sp.GetRequiredService<GoogleEmailSender>(),
            [.., "proton.me"] => sp.GetRequiredService<ProtonEmailSender>(),
            _ => throw new NotImplementedException("This host is not supported"),
        };
    }
}