namespace FileOrganizer.src.Categories.Interfaces;

public class WebExtension : IFileExtension
{

    public WebExtension()
    {
        
    }

    public void Sort()
    {

    }

    public void CreateDirectory(string project_parent_dir)
    {
        // var current_dir = Directory.GetCurrentDirectory();
        var path = Path.Combine(project_parent_dir, "html");

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