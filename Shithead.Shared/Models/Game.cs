using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;
using Shithead.Shared.Models.Session;
using Shithead.Shared.Utilities.Enums;

namespace Shithead.Shared.Models
{
    public class Game
    {
        public Guid Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        [Required(ErrorMessage = "Select an amount.")]
        public int Deacks { get; set; }

        [Required(ErrorMessage = "Select an amount.")]
        public TurnTime TurnTime { get; set; }

        public List<Player> Players { get; set; }

        public List<Card> Cards { get; set; }

        #region Shithead

        [JsonIgnore]
        public List<Card> Pile => Cards?.Where(c => c.State == State.Pile || c.State == State.Blocked).OrderByDescending(c => c.Order).ToList();

        [JsonIgnore]
        public List<Card> Trash => Cards?.Where(c => c.State == State.Trash).OrderByDescending(c => c.Order).ToList();

        [JsonIgnore]
        public List<Card> Stack => Cards?.Where(c => c.State == State.Stack).OrderByDescending(c => c.Order).ToList();

        [JsonIgnore]
        public Player Previous => SessionGame.Data?.Players?.FirstOrDefault(p => p.Turn == Turn.Previous);

        [JsonIgnore]
        public Player Current => SessionGame.Data?.Players?.FirstOrDefault(p => p.Turn == Turn.Current);

        [JsonIgnore]
        public Player Next => SessionGame.Data?.Players?.FirstOrDefault(p => p.Turn == Turn.Next);

        [JsonIgnore]
        public Rule? Rule { get; set; }

        #endregion
    }
}
