using System.Threading.Tasks;
using Talent.Backend.Email.Models;

namespace Talent.Backend.Email.Contracts
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
        Task SendEmailAsync(Message message);
    }
}
