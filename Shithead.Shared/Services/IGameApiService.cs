using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shithead.Shared.Models;

namespace Shithead.Shared.Services
{
    public interface IGameApiService
    {
        #region Game

        /// <summary>
        /// Adds a game
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        Task<DataBundel<Game>> AddGame(Game game);

        /// <summary>
        /// Updates a game
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        Task<DataBundel<Game>> UpdateGame(Game game);

        /// <summary>
        /// Removes a game
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        Task<DataBundel<Game>> RemoveGame(Game game);

        /// <summary>
        /// Gets a game by player userId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DataBundel<Game>> GetGame(Guid id);

        #endregion

        #region Player

        /// <summary>
        /// Adds a players
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        Task<DataBundel<List<Player>>> AddPlayers(List<Player> players);

        /// <summary>
        /// Updates a player
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        Task<DataBundel<Player>> UpdatePlayer(Player player);

        /// <summary>
        /// Updates players
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        Task<DataBundel<Player>> UpdatePlayers(List<Player> players);

        /// <summary>
        /// Removes a player
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        Task<DataBundel<Player>> RemovePlayer(Player player);
        
        /// <summary>
        /// Sets position of players
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        List<Player> SetPositionPlayers(List<Player> players);

        #endregion

        #region Card

        /// <summary>
        /// Adds cards
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        Task<DataBundel<List<Card>>> AddCards(List<Card> cards);

        /// <summary>
        /// Updates cards
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        Task<DataBundel<List<Card>>> UpdateCards(List<Card> cards);

        /// <summary>
        /// Removes cards
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        Task<DataBundel<List<Card>>> RemoveCards(List<Card> cards);

        /// <summary>
        /// Creates a new deck
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        List<Card> CreateDeck(Game game);

        #endregion
    }
}