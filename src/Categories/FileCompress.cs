using System.IO.Compression;

namespace FileOrganizer.src.Categories;

public class FileCompress
{
    private readonly string _compress_file_name;

    public FileCompress(string file_name)
    {
        _compress_file_name = file_name;
    }
    
    public void CompressDirectory(string path)
    {
        /*
            Compressing Directory:
                - Package the directory as a .tar file then use gzip on the tar file. 
                - This requires SharpZipLib.
        */
        
        // Check if path exists
        if (Directory.Exists(path))
        {

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