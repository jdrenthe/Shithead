using System;

namespace Shithead.Shared.Models
{
    public class Notification
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public string Image { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool Seen { get; set; }

        public DateTime Created { get; set; }

        public string Url { get; set; }
    }
}
