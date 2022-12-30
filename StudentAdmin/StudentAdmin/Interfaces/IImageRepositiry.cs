namespace StudentAdmin.Interfaces
{
    public interface IImageRepositiry
    {
        Task<string> Upload(IFormFile file, string fileName);


    }
}
