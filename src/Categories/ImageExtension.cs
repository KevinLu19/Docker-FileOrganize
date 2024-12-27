using System.IO;

namespace FileOrganizer.src.Categories.Interfaces;

public class ImageExtension : IFileExtension
{
    // Stores list of the actual file name + file extension.
    private readonly List<string> _list_of_files = new List<string>();
    
    private const string IMAGE_PATH = "/app/img";

    public ImageExtension()
    {
        
    }
    
    public void Sort()
    {
        foreach (var items in _list_of_files)
        {
            
        }

        // Check if directory exists
        if (Directory.Exists(IMAGE_PATH))
        {
            // Loop through all files in /app folder
            foreach (var file in new DirectoryInfo("/app").GetFiles())
            {
                // Get all file extension with img and move to img_path.
            }
        }
    }

    public void CreateDirectory(string project_parent_dir)
    {
        // var current_dir = Directory.GetCurrentDirectory();
        var path = Path.Combine(project_parent_dir, "img");

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
            Console.WriteLine($"Created {path}");
        }
        else
        {
            Console.WriteLine("Path already exists");
        }
    }

}