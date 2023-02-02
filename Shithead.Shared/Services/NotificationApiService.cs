using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Shithead.Shared.Models;

namespace Shithead.Shared.Services
{
    public class NotificationApiService : INotificationApiService
    {
        private readonly IRequestService _requestService;

        public NotificationApiService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        /// <inheritdoc/>
        public async Task<DataBundel<Email>> SendEmail(Email email)
        {
            // Removed for public branch does work on live
            //var request = await _requestService.CreateRequest("SendEmail", "api/Notification");
            //return await request.PostJsonAsync(email).ReceiveJson<DataBundel<Email>>();

            return new DataBundel<Email>(null, true, null);
        }

        /// <inheritdoc/>
        public async Task<DataBundel<List<Email>>> SendEmails(List<Email> emails)
        {
            // Removed for public branch does work on live
            //var request = await _requestService.CreateRequest("SendEmails", "api/Notification");
            //return await request.PostJsonAsync(emails).ReceiveJson<DataBundel<List<Email>>>();

            return new DataBundel<List<Email>>(null, true, null);
        }
    }
}
