using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Shithead.Shared.Models;
using Shithead.Shared.Models.Session;

namespace Shithead.Server.Hubs
{
    public class GameHub : Hub
    {
        /// <summary>
        /// Adds player to game group
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task AddToGame(Guid id) => await Groups.AddToGroupAsync(Context.ConnectionId, id.ToString());

        /// <summary>
        /// Removes player from game group
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task RemoveFromGame(Guid id) => await Groups.RemoveFromGroupAsync(Context.ConnectionId, id.ToString());

        /// <summary>
        /// Updateds game data in the game group
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public async Task UpdatedGame(Game newGame) => await Clients.Group(newGame.Id.ToString()).SendAsync("UpdateReceived", newGame);

        /// <summary>
        /// Updates players game data in the game group
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public async Task UpdatePlayers(Game game, List<Player> players) => await Clients.Group(game.Id.ToString()).SendAsync("UpdatePlayersReceived", players);

        /// <summary>
        /// On connected
        /// </summary>
        /// <returns></returns>
        //public override async Task OnConnectedAsync()
        //{
        //    if (!SessionGame.IsNull) await Groups.AddToGroupAsync(Context.ConnectionId, SessionGame.Data.Id.ToString());
        //}
    }
}
