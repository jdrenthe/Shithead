using System;

namespace Shithead.Shared.Models.Session
{
    public class SessionGame
    {
        /// <summary>
        /// Game data
        /// </summary>
        public static Game Data
        {
            get => _game;
            set
            {
                _game = value;
                GameChanged();
            }
        }
        private static Game _game;

        /// <summary>
        /// Game is null or not
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
                GameChanged();
            }
        }
        private static bool _isLoading;

        /// <summary>
        /// Draggable card id
        /// </summary>
        public static string DraggableCardId { get; set; }

        /// <summary>
        /// Droppable card id
        /// </summary>
        public static string DroppableCardId { get; set; }

        /// <summary>
        /// Event handler game changed
        /// Tip: subscribe to this event buy using 'SessionGame.EventHandlerGameChanged += {method name}'
        /// </summary>
        public static event EventHandler EventHandlerGameChanged;

        /// <summary>
        /// Event handler game changed
        /// Tip: subscribe to this event buy using 'SessionGame.EventHandlerCardDropped += {method name}'
        /// </summary>
        public static event EventHandler EventHandlerCardDropped;

        /// <summary>
        /// Game changed
        /// This method will rigger the EventHandlerGameChanged
        /// </summary>
        public static void GameChanged()
        {
            EventHandler hanndler = EventHandlerGameChanged;
            hanndler?.Invoke(null, new EventArgs());
        }

        /// <summary>
        /// Card dropped
        /// This method will rigger the EventHandlerCardDropped
        /// </summary>
        public static void CardDropped()
        {
            EventHandler hanndler = EventHandlerCardDropped;
            hanndler?.Invoke(null, new EventArgs());
        }
    }
}
