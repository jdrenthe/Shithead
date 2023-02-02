using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shithead.Shared.Models;

namespace Shithead.Shared.Services
{
    public interface IUserApiService
    {
        /// <summary>
        /// Gets a user by it's userId
        /// </summary>
        /// <returns>DataBundel</returns>
        Task<DataBundel<User>> GetUser();

        /// <summary>
        /// Gets all the users
        /// </summary>
        /// <returns>DataBundel</returns>
        Task<DataBundel<List<User>>> GetAllUsers();

        /// <summary>
        /// Gets user by it's id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>DataBundel</returns>
        Task<DataBundel<User>> GetUserById(Guid userId);

        /// <summary>
        /// Sings up a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>DataBundel</returns>
        Task<DataBundel<User>> SingUp(User user);

        /// <summary>
        /// Sings in a user with it's password and email
        /// </summary>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <returns>DataBundel</returns>
        Task<DataBundel<Credentials>> SingIn(SingIn singIn);

        /// <summary>
        /// Cleans the oautToken from local Storage
        /// </summary>
        Task SingOut();

        /// <summary>
        /// Updates the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>DataBundel</returns>
        Task<DataBundel<User>> UpdateUser(User user);

        /// <summary>
        /// Add friends
        /// </summary>
        /// <param name="friends"></param>
        /// <returns>DataBundel</returns>
        Task<DataBundel<List<UserFriend>>> AddFriends(List<UserFriend> friends);

        /// <summary>
        /// Generates qor-code from string
        /// </summary>
        /// <param name="value"></param>
        /// <returns>DataBundel</returns>
        Task<DataBundel<string>> GeneratQR(string value);

        /// <summary>
        /// Sets the session user
        /// </summary>
        Task SetUser();

        /// <summary>
        /// Generates a password reset token and sends it to the users email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>DataBundel</returns>
        Task<DataBundel<Email>> SendPasswordResetTokenEmail(Email email);
    }
}
