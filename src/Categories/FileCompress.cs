using System.IO.Compression;

namespace FileOrganizer.src.Categories;

public class FileCompress
{
    private readonly string _compress_file_name;

    // ZipFile usages.
    private string _zip_path;
    private string _extract_path;           // Destination for the ziped file.
    private string _start_path;

    public FileCompress(string file_name)
    {
        _compress_file_name = file_name;
    }
    
    public void ZipDirectory(string path)
    {
        /*
            Compressing Directory:
                - Package the directory as a .tar file then use gzip on the tar file. 
                - This requires SharpZipLib.
        */
        
        // Check if path exists
        if (Directory.Exists(path))
        {
            /*
                Want to extract the directory and place it in the sub-parent directory.
                Ex:
                ~/file_org/src/test/path

                Compressed + zipped path = zip_path:
                ~/file_org/src/test

                extract_path: Create a new folder and insert files inside of that folder.
                Check if folder content doesn't already exists.
            */
            var parent_dir = Directory.GetParent(path)?.FullName;

            // Check if parent dir exists (it shoudl exist)
            if (parent_dir != null)
                ZipFile.CreateFromDirectory(path, parent_dir);
            
        }
        else
        {
            Console.WriteLine($"{path} does not exist or cannot open. Take a look into that.");
        }
    }

    public void CompressFile(string file_name)
    {
        if (string.IsNullOrEmpty(file_name))
        {
            
        }
    }

    public void DecompressFile()
    {

    }
}