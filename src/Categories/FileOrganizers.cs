using System;
using System.IO;

namespace FileOrganizer.src.Categories;

public class FileOrganizers
{
    // Test directory (parent directory)
    private string _test_dir_path = "/home/kevin/test/";
    public FileOrganizers()
    {
        try
        {
            Directory.SetCurrentDirectory(_test_dir_path);
            Console.WriteLine("Current Directory Set to: ", _test_dir_path);
        }
        catch (DirectoryNotFoundException e)
        {
             Console.WriteLine(e.Message);
        }
    }
}