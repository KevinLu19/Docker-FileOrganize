namespace FileOrganizer.src.Categories.Interfaces;

public interface IFile
{
    List<string> GetFileInDirectory(string path);
}