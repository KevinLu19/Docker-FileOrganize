using System;
using System.IO;
using System.Text.RegularExpressions;

namespace FileOrganizer.src.Categories;

public class FileOrganizers
{
    // This list just stores the name of the files. Not the file itself. Will need to manipulate it later on.
    private List<string> _file_list = new List<string>();
    public FileOrganizers()
    {
        // Current directory is whatever docker's directorypath is. 
        //Console.WriteLine("Current directory path: " + Directory.GetCurrentDirectory());
    }

    // Lists all files in current directory.
    public void GetAllFiles()
    {
        var current_dir = Directory.GetCurrentDirectory();
        Console.WriteLine("The current directory is: " + current_dir);

        DirectoryInfo dir = new DirectoryInfo(current_dir);

        FileInfo[] files = dir.GetFiles();
        
        foreach (FileInfo file in files)
        {
            _file_list.Add(file.Name);
        }

        // Testing what files is on the current directory. Need to move this to unit testing.
        // foreach(var item in _file_list)
        // {
        //     Console.WriteLine(item);
        // }
        // Console.WriteLine("-------------------");
    }

    // First off, sort all files that have the same file extension together as the start.
    public void FilterByFileExtension()
    {
        string reg_expression_pattern = @"\.([a-zA-Z0-9]*)$";
        Regex regex = new Regex(reg_expression_pattern);

        // Hash map for file extensions. Not storing the name of the file. Will be <file ext, number>
        Dictionary<string, int> file_hash_map = new Dictionary<string, int>();
        int hash_map_count = 1;

        // Reg Ex the list of file names.
        foreach (var item in _file_list)
        {
            MatchCollection match = regex.Matches(item);
            
            // Print all of the file extension from the current directory.
            // Pre-fills the hash map.
            foreach (Match matches in match)
            {
                // Check if key already exist in hashmap
                if (!file_hash_map.ContainsKey(matches.Value))
                {
                    file_hash_map.Add(matches.Value, hash_map_count);
                    hash_map_count++;
                }
            }
        }

        // foreach(var item in file_hash_map)
        // {
        //     Console.WriteLine(item.Key);
        // }
    }
}