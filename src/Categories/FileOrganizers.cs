using System;
using System.IO;

namespace FileOrganizer.src.Categories;

public class FileOrganizers
{
    public FileOrganizers()
    {
        // try
        // {
        //     Directory.SetCurrentDirectory(_test_dir_path);
        //     Console.WriteLine("Current Directory Set to: ", _test_dir_path);
        // }
        // catch (DirectoryNotFoundException e)
        // {
        //      Console.WriteLine(e.Message);
        // }

        // Current directory is whatever docker's directorypath is. 
        Console.WriteLine("Current directory path: " + Directory.GetCurrentDirectory());

    }
}