
namespace FileOrganizer.src.Categories.Interfaces;

public class ImageExtension : IFileExtension
{
    private readonly List<string> _list_of_files = new List<string>();
    public ImageExtension(List<string> file_list)
    {
        _list_of_files = file_list;
    }
    
    public void Sort()
    {
        
    }
}