using System;
using Newtonsoft.Json;
using Shithead.Shared.Utilities;
using Shithead.Shared.Utilities.Enums;

namespace Shithead.Shared.Models
{
    public class Card
    {
        public Guid Id { get; set; }

        public int Value { get; set; }

        public string Symbol { get; set; }

        public State State { get; set; }

        public Seven Seven { get; set; }

        public bool Excluded { get; set; }

        public int Order { get; set; }

        public Guid? PlayerId { get; set; }

        public Guid GameId { get; set; }

        [JsonConstructor]
        public Card() { }

        public Card(int value,
                    string symbol)
        {
            Value = value;
            Symbol = symbol;
        }

        public Card(int value,
                    string symbol,
                    State state,
                    Guid gameId,
                    Guid? playerId = null,
                    int? order = null)
        {
            Id = Guid.NewGuid();
            Value = value;
            Symbol = symbol;
            State = state;
            Seven = Seven.None;
            Excluded = false;
            Order = order.HasValue ? order.Value : 0;
            GameId = gameId;
            PlayerId = playerId;
        }

        #region Shithead 

        [JsonIgnore]
        public string CssClass => $"card-{Value.NumberToWords()} {Symbol}";

        [JsonIgnore]
        public bool IsDraggeble { get; set; }

        [JsonIgnore]
        public bool IsDroppable { get; set; }

        [JsonIgnore]
        public bool IsEmpty { get; set; }

        [JsonIgnore]
        public bool IsBlocked { get; set; }

        [JsonIgnore]
        public string Color => Symbol == "♦" || Symbol == "♥" ? "red" : Symbol == "♣" || Symbol == "♠" ? "black" : "none";

        //TODo add abilities

        #endregion

    }
}
