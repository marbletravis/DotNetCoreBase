using System.Threading.Tasks;

namespace zaAbXTwb.Service.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
