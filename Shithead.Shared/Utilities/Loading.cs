namespace Shithead.Shared.Utilities
{
    public class Loading
    {
        public string Css => Value ? "loading" : string.Empty;

        public bool Value { get; set; }

        /// <summary>
        /// Is loading
        /// </summary>
        /// <param name="value"></param>
        public Loading(bool value) => Value = value;
    }
}
