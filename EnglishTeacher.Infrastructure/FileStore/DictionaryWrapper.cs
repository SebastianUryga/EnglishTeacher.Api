using EnglishTeacher.Application.Common.Interfaces;

namespace EnglishTeacher.Infrastructure.FileStore
{
    public class DirectoryWrapper : IDirectoryWrapper
    {
        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }
    }
}
