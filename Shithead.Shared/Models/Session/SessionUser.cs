using System;

namespace Shithead.Shared.Models.Session
{
    /// <summary>
    /// This class represents the current logged-in user if any
    /// </summary>
    public static class SessionUser
    {
        /// <summary>
        /// User data
        /// </summary>
        public static User Data
        {
            get => _user;
            set
            {
                _user = value;
                UserChanged();
            }
        }
        private static User _user;

        /// <summary>
        /// User is null or not
        /// </summary>
        public static bool IsNull => Data == null;

        /// <summary>
        /// Is loading
        /// </summary>
        public static bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                UserChanged();
            }
        }
        private static bool _isLoading;

        /// <summary>
        /// Event handler user changed
        /// Tip: subscribe to this event buy using 'SessionUser.EventHandlerUserChanged += {method name}'
        /// </summary>
        public static event EventHandler EventHandlerUserChanged;

        /// <summary>
        /// User changed
        /// This method will rigger the EventHandlerUserChanged
        /// </summary>
        public static void UserChanged()
        {
            EventHandler hanndler = EventHandlerUserChanged;
            hanndler?.Invoke(null, new EventArgs());
        }
    }
}
