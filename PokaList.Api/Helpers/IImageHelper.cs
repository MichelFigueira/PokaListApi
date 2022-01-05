using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace PokaList.Api.Helpers
{
    public interface IImageHelper
    {
        Task<string> SaveImage(IFormFile imageFile, string path);
        void DeleteImage(string imageName, string path);
    }
}
