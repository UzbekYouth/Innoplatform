using Innoplatform.Service.DTOs.Assets;

namespace Innoplatform.Service.Interfaces.IFileUploadServices
{
    public interface IFileUploadService
    {
        public Task<AssetForResultDto> FileUploadAsync(AssetForCreationDto dto);
        public Task<bool> DeleteFileAsync(string filePath);
    }
}
