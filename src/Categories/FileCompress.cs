using System.IO.Compression;

namespace FileOrganizer.src.Categories;

public class FileCompress
{
    // Compresses and returns .zip archives.
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
            {
                ZipFile.CreateFromDirectory(path, parent_dir);
                Console.WriteLine($"Created zip to path of: {parent_dir}");
            }
            
        }
        else
        {
            Console.WriteLine($"{path} does not exist or cannot open. Take a look into that.");
        }
    }
    
    // Unzips .zip
    public void DecompressFile(string destination_path, string zip_file)
    {
        // check if extracting path given exists. If not, create one.
        if (!Directory.Exists (destination_path))
        {
            Console.WriteLine($"Creating {destination_path}");

            Directory.CreateDirectory(destination_path);
        }
        else
        {
            // Try and decompress given archive.
            try
            {
                ZipFile.ExtractToDirectory(zip_file, destination_path);

                Console.WriteLine($"{zip_file} sucessfully extracted to {destination_path}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Decompressing error: {ex.Message}");
            }
        }
    }
}