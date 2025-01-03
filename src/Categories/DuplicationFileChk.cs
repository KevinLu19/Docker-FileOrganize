using FileOrganizer.src.Categories.Interfaces;

namespace FileOrganizer.src.Categories;

public class DuplicationFileChk : IFile
{

    public List<string> GetFileInDirectory(string path)
    {
        DirectoryInfo dir = new DirectoryInfo(path);

        FileInfo[] files = dir.GetFiles();

        List<string> file_name = new List<string>();

        foreach (FileInfo file in files)
        {
            file_name.Add(file.Name);
        }

        return file_name;
    }   

    public bool ChkDuplicationFiles(string file_name ,string destination_path)
    {
        // Get all the files in given destination path.
        var dir_file_name = GetFileInDirectory(destination_path);

        // Check if file_name is in among the files.
        if (dir_file_name != null)
        {
            foreach (var file in dir_file_name)
            {
                // If not, return true -> meaning accpet the move file as it doesn't exist.
                if (file_name.ToLower() == file.ToLower())
                {
                    return true;
                }
            }
        }

        // Else, return false -> meaning don't accept the move file as it already exists

        return false;
    }
}