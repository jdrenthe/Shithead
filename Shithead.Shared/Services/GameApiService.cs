using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl.Http;
using Shithead.Shared.Models;
using Shithead.Shared.Models.Session;
using Shithead.Shared.Utilities;
using Shithead.Shared.Utilities.Enums;

namespace Shithead.Shared.Services
{
    public class GameApiService : IGameApiService
    {
        private readonly IRequestService _requestService;

        public GameApiService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        #region Game

        /// <inheritdoc/>
        public async Task<DataBundel<Game>> AddGame(Game game)
        {
            var request = await _requestService.CreateRequest("AddGame", "api/Game");
            var result = await request.PostJsonAsync(game).ReceiveJson<DataBundel<Game>>();

            if (!result.Success) return result;

            SessionGame.Data = result.Content;
            return result;
        }

        /// <inheritdoc/>
        public async Task<DataBundel<Game>> UpdateGame(Game game)
        {
            var request = await _requestService.CreateRequest("UpdateGame", "api/Game");
            var result = await request.PostJsonAsync(game).ReceiveJson<DataBundel<Game>>();

            if (!result.Success) return result;

            SessionGame.Data = result.Content;
            return result;
        }

        /// <inheritdoc/>
        public async Task<DataBundel<Game>> RemoveGame(Game game)
        {
            var request = await _requestService.CreateRequest("AddGmae", "api/Game");
            var result = await request.PostJsonAsync(game).ReceiveJson<DataBundel<Game>>();

            if (!result.Success) return result;

            SessionGame.Data = null;
            return result;
        }

        /// <inheritdoc/>
        public async Task<DataBundel<Game>> GetGame(Guid id)
        {
            SessionGame.IsLoading = true;

            var request = await _requestService.CreateRequest("GetGame", new Dictionary<string, Guid> { { "id", id } }, "api/Game");
            var result = await request.GetJsonAsync<DataBundel<Game>>();

            SessionGame.IsLoading = false;
            if (!result.Success) return result;

            SessionGame.Data = result.Content;
            return result;
        }

        #endregion

        #region Player

        /// <inheritdoc/>
        public async Task<DataBundel<List<Player>>> AddPlayers(List<Player> players)
        {
            var request = await _requestService.CreateRequest("AddPlayers", "api/Game");
            return await request.PostJsonAsync(players).ReceiveJson<DataBundel<List<Player>>>();
        }

        /// <inheritdoc/>
        public async Task<DataBundel<Player>> UpdatePlayer(Player player)
        {
            var request = await _requestService.CreateRequest("UpdatePlayer", "api/Game");
            return await request.PostJsonAsync(player).ReceiveJson<DataBundel<Player>>();
        }

        /// <inheritdoc/>
        public async Task<DataBundel<Player>> UpdatePlayers(List<Player> players)
        {
            var request = await _requestService.CreateRequest("UpdatePlayers", "api/Game");
            return await request.PostJsonAsync(players).ReceiveJson<DataBundel<Player>>();
        }

        /// <inheritdoc/>
        public async Task<DataBundel<Player>> RemovePlayer(Player player)
        {
            var request = await _requestService.CreateRequest("RemovePlayer", "api/Game");
            return await request.PostJsonAsync(player).ReceiveJson<DataBundel<Player>>();
        }
        /// <inheritdoc/>
        public List<Player> SetPositionPlayers(List<Player> players)
        {
            players.Shuffle();
            for (var i = 1; i <= players.Count; i++) players[i - 1].Position = i;

            return players;
        }

        #endregion

        #region Card

        /// <inheritdoc/>
        public async Task<DataBundel<List<Card>>> AddCards(List<Card> cards)
        {
            var request = await _requestService.CreateRequest("AddCards", "api/Game");
            return await request.PostJsonAsync(cards).ReceiveJson<DataBundel<List<Card>>>();
        }

        /// <inheritdoc/>
        public async Task<DataBundel<List<Card>>> UpdateCards(List<Card> cards)
        {
            var request = await _requestService.CreateRequest("UpdateCards", "api/Game");
            return await request.PostJsonAsync(cards).ReceiveJson<DataBundel<List<Card>>>();
        }

        /// <inheritdoc/>
        public async Task<DataBundel<List<Card>>> RemoveCards(List<Card> cards)
        {
            var request = await _requestService.CreateRequest("RemoveCards", "api/Game");
            return await request.PostJsonAsync(cards).ReceiveJson<DataBundel<List<Card>>>();
        }

        /// <inheritdoc/>
        public List<Card> CreateDeck(Game game)
        {
            List<Card> cards = new()
            {
                #region Clube

                new(2, "♣", State.Stack, game.Id),
                new(3, "♣", State.Stack, game.Id),
                new(4, "♣", State.Stack, game.Id),
                new(5, "♣", State.Stack, game.Id),
                new(6, "♣", State.Stack, game.Id),
                new(7, "♣", State.Stack, game.Id),
                new(8, "♣", State.Stack, game.Id),
                new(9, "♣", State.Stack, game.Id),
                new(10, "♣", State.Stack, game.Id),
                new(11, "♣", State.Stack, game.Id),
                new(12, "♣", State.Stack, game.Id),
                new(13, "♣", State.Stack, game.Id),
                new(14, "♣", State.Stack, game.Id),

                #endregion

                #region Diamond

                new(2, "♦", State.Stack, game.Id),
                new(3, "♦", State.Stack, game.Id),
                new(4, "♦", State.Stack, game.Id),
                new(5, "♦", State.Stack, game.Id),
                new(6, "♦", State.Stack, game.Id),
                new(7, "♦", State.Stack, game.Id),
                new(8, "♦", State.Stack, game.Id),
                new(9, "♦", State.Stack, game.Id),
                new(10, "♦", State.Stack, game.Id),
                new(11, "♦", State.Stack, game.Id),
                new(12, "♦", State.Stack, game.Id),
                new(13, "♦", State.Stack, game.Id),
                new(14, "♦", State.Stack, game.Id),

                #endregion

                #region Spade

                new(2, "♠", State.Stack, game.Id),
                new(3, "♠", State.Stack, game.Id),
                new(4, "♠", State.Stack, game.Id),
                new(5, "♠", State.Stack, game.Id),
                new(6, "♠", State.Stack, game.Id),
                new(7, "♠", State.Stack, game.Id),
                new(8, "♠", State.Stack, game.Id),
                new(9, "♠", State.Stack, game.Id),
                new(10, "♠", State.Stack, game.Id),
                new(11, "♠", State.Stack, game.Id),
                new(12, "♠", State.Stack, game.Id),
                new(13, "♠", State.Stack, game.Id),
                new(14, "♠", State.Stack, game.Id),

                #endregion

                #region  Heart

                new(2, "♥", State.Stack, game.Id),
                new(3, "♥", State.Stack, game.Id),
                new(4, "♥", State.Stack, game.Id),
                new(5, "♥", State.Stack, game.Id),
                new(6, "♥", State.Stack, game.Id),
                new(7, "♥", State.Stack, game.Id),
                new(8, "♥", State.Stack, game.Id),
                new(9, "♥", State.Stack, game.Id),
                new(10, "♥", State.Stack, game.Id),
                new(11, "♥", State.Stack, game.Id),
                new(12, "♥", State.Stack, game.Id),
                new(13, "♥", State.Stack, game.Id),
                new(14, "♥", State.Stack, game.Id),

                #endregion

                #region Joker

                new(1, "♥", State.Stack, game.Id),
                new(1, "♥", State.Stack, game.Id),

                #endregion
            };

            cards.Shuffle();
            return cards;
        }

        #endregion
    }
}
