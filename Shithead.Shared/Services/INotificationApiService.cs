using System.Collections.Generic;
using System.Threading.Tasks;
using Shithead.Shared.Models;

namespace Shithead.Shared.Services
{
    public interface INotificationApiService
    {
        /// <summary>
        /// Sends a email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<DataBundel<Email>> SendEmail(Email email);

        /// <summary>
        /// Sends emails
        /// </summary>
        /// <param name="emails"></param>
        /// <returns></returns>
        Task<DataBundel<List<Email>>> SendEmails(List<Email> emails);
    }
}
