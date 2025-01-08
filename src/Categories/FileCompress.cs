using System.IO.Compression;
using FileOrganizer.src.Categories.Interfaces;

namespace FileOrganizer.src.Categories;

public class FileCompress : IFile
{
    // Default path for storing any .zip file.
    private const string _ARCHIVE_DIR = "/app/archive";

    // Compresses and returns .zip archives.
    public void ZipDirectory(string path)
    {
        /*
            Compressing Directory:
                - Package the directory as a .tar file then use gzip on the tar file. 
                - This requires SharpZipLib.
        */
        
        // Check if given path exists.
        if (Directory.Exists(path))
        {
            /*
                Want to extract the directory and place it in the sub-parent directory.
                Ex:
                ~/file_org/src/test/path

                ~/file_org/archive => Location for all archived files.

                Compressed + zipped path = zip_path:
                ~/file_org/src/test

                extract_path: Create a new folder and insert files inside of that folder.
                Check if folder content doesn't already exists.
            */
            var archive_dir = "/app/archive";

            // Check if archive dir exists (should not exist at first. Will need to transfer in a dir into docker)
            // Create directory if it doesn't exist.
            if (archive_dir != null)
            {
                Console.WriteLine("==============");
                ZipFile.CreateFromDirectory(path, _ARCHIVE_DIR);
                Console.WriteLine($"Created zip to path of: {_ARCHIVE_DIR}");
                Console.WriteLine("==============");
            }
        }
        else
        {
            Console.WriteLine($"{path} does not exist or cannot open. Take a look into that.");
        }
    }
    
    // Unzips .zip files.
    public void DecompressFile(string zip_file_name)
    {
        // Try and decompress given archive and store it in the archive folder (/app/archive)
        try
        {
            // Will create the directory if it doens't exist. If it exists, will proceed to extract.
            ZipFile.ExtractToDirectory(zip_file_name, _ARCHIVE_DIR);

            Console.WriteLine($"{zip_file_name} sucessfully extracted to {_ARCHIVE_DIR}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Decompressing error: {ex.Message}");
        }
    }

    // Taken from IFile interface
    public List<string> GetFileInDirectory(string path)
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] files = dir.GetFiles();

        List<string> file_name = new List<string>();


        if (Directory.Exists (path))
        {
            foreach (var item in files)
            {
                file_name.Add(item.FullName);
            }
        }

        return file_name; 
    }
}