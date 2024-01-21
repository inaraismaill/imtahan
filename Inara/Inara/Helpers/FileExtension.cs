namespace Inara.Helpers
{
    public static class FileExtension
    {
        public async static Task<string> SaveAsync(this IFormFile file, string path)
        {
            string filename= Path.GetFileNameWithoutExtension(file.FileName);
            string extension=Path.GetExtension(file.FileName);
            filename = Path.Combine(path, Path.GetRandomFileName() + filename + extension);
            using(FileStream filestream= File.Create(Path.Combine(ExtenConst.RoothPath, filename)))
            {
                await file.CopyToAsync(filestream);
            }
            return filename;
        }
    }
}
