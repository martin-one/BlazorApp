using Microsoft.AspNetCore.Components.Forms;

namespace BlazorApp.Server.Service.IService
{
    public interface IFileUpload
    {
        Task<string> UploadFile(IBrowserFile file);
        bool DeleteFile(string url);
    }
}
