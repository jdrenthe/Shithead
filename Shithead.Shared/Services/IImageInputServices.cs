using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using Shithead.Shared.Models;

namespace Shithead.Shared.Services
{
    public interface IImageInputServices
    {
        Task<Image> CompressToBase64(InputFileChangeEventArgs args);
    }
}
