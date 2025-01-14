using FileOrganizer.src.Categories;
using Microsoft.AspNetCore.Builder;

namespace FileOrganizer;

public class Program
{
    public static void Main(string[] args)
    {
        FileOrganizers file_obj = new FileOrganizers();
        // Currently set to get all files in current directory in the docker container.
        file_obj.GetAllFiles();
        file_obj.FilterByFileExtension();

        file_obj.SortFiles();

        // Test for file compress
        FileCompress file_compress = new FileCompress();
        file_compress.ZipDirectory("/app/test_folder");         // Zips directory to /app/archive dir
        file_compress.DecompressFile("/app/test_folder.zip");   // Unzips given .zip file.
        file_compress.GetFileInDirectory("/app/archive");       // Prints everything in path
    }
}