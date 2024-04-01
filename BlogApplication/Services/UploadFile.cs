

using BlogApplication.Enums;

namespace BlogApplication.Services
{
    public class UploadFile
    {
        public static string Upload(IFormFile file, FotoTipi fotoTipi)
        {
            var extension = Path.GetExtension(file.FileName);
            var newFileName = Guid.NewGuid() + extension;
            var location = "";

                location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/", newFileName);


            var stream = new FileStream(location, FileMode.Create);
            file.CopyTo(stream);
            return newFileName;
        }
    }
}
