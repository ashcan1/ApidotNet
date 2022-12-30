using StudentAdmin.Interfaces;

namespace StudentAdmin.Repository
{
    public class ImageRepository :IImageRepositiry
    {
        public async Task<string> Upload(IFormFile file, string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),@"Sources\Images", fileName);
            using Stream FileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(FileStream);
            return getServerRelativePath(filePath);
        }

        private string getServerRelativePath(string fileName)
        {
            return Path.Combine(@"Sources\Images", fileName);
        }
    }
}
