using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Shithead.Shared.Models.Session;
using Shithead.Shared.Utilities.Enums;

namespace Shithead.Shared.Models
{
    public class Player
    {
        public Guid Id { get; set; }

        public bool Joint { get; set; }

        public bool SwitchedCards { get; set; }

        public int Position { get; set; }

        public Turn Turn { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public Guid GameId { get; set; }

        public Game Game { get; set; }

        #region Shithead 

        [JsonIgnore]
        public List<Card> Cards => SessionGame.Data?.Cards.Where(c => c.PlayerId == Id).ToList();

        [JsonIgnore]
        public List<Card> Hand => Cards?.Where(c => c.State == State.Hand).OrderByDescending(c => c.Order).ToList();

        [JsonIgnore]
        public List<Card> Open => Cards?.Where(c => c.State == State.Open).OrderByDescending(c => c.Order).ToList();

        [JsonIgnore]
        public List<Card> Closed => Cards?.Where(c => c.State == State.Closed).OrderByDescending(c => c.Order).ToList();

        [JsonIgnore]
        public bool HandChecked { get; set; }

        #endregion
    }
}
