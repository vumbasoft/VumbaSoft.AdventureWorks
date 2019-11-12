using System;
using System.Threading.Tasks;

namespace VumbaSoft.AdventureWorks.Components.Mail
{
    public interface IMailClient
    {
        Task SendAsync(String email, String subject, String body);
    }
}
