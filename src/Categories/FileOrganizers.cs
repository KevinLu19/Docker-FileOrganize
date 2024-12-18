using System;
using System.IO;
using System.Text.RegularExpressions;

namespace FileOrganizer.src.Categories;

public class FileOrganizers
{
    public FileOrganizers()
    {
        // Current directory is whatever docker's directorypath is. 
        //Console.WriteLine("Current directory path: " + Directory.GetCurrentDirectory());
    }

    public void GetAllFiles()
    {
        var current_dir = Directory.GetCurrentDirectory();
        Console.WriteLine("The current directory is: " + current_dir);

        DirectoryInfo dir = new DirectoryInfo(current_dir);

        FileInfo[] files = dir.GetFiles();
        List<string> file_list = new List<string>();

        foreach (FileInfo file in files)
        {
            file_list.Add(file.Name);
        }

        foreach(var item in file_list)
        {
            Console.WriteLine(item);
        }
    }

    // First off, sort all files that have the same file extension together as the start.
    public void FilterByFileExtension()
    {
        string reg_expression_pattern = @"\.([a-zA-Z0-9]*)$";


    }
}