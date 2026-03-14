using Microsoft.AspNetCore.Http;
namespace ProductSystem.BLL
{
    public sealed record ImageUploadDto(IFormFile File);

}
