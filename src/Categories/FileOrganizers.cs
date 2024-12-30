using System.Text.RegularExpressions;
using FileOrganizer.src.Categories.Interfaces;
using System.IO;

using FileOrganizer.src.Categories.Enumerate;

namespace FileOrganizer.src.Categories;

public class FileOrganizers
{
    // This list just stores the name of the files. Not the file itself. Will need to manipulate it later on.
    private List<string> _file_list = new List<string>();

    private const string DOCKER_PARENT_PATH = "/app";

    public FileOrganizers()
    {
        // Current directory is whatever docker's directorypath is. 
        //Console.WriteLine("Current directory path: " + Directory.GetCurrentDirectory());
    }
    
    private Dictionary<string, int> GetItemInDictionary()
    {
        // Hash map for file extensions. Not storing the name of the file. Will be <file ext, number>
        Dictionary<string, int> file_hash_map = new Dictionary<string, int>();

        return file_hash_map;
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

        // // Testing what files is on the current directory. Need to move this to unit testing.
        // // Returns the <name of the file>.<file extension>
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

        var dict_items = GetItemInDictionary();
        
        int hash_map_count = 1;

        // Reg Ex the list of file names.
        // Primes the hash map.
        foreach (var item in _file_list)
        {
            MatchCollection match = regex.Matches(item);
            
            // Print all of the file extension from the current directory.
            // Pre-fills the hash map.
            foreach (Match matches in match)
            {
                // Check if key already exist in hashmap
                if (!dict_items.ContainsKey(matches.Value))
                {
                    dict_items.Add(matches.Value, hash_map_count);
                    hash_map_count++;
                }
            }
        }

        // foreach(var item in file_hash_map)
        // {
        //     Console.WriteLine(item.Key);
        // }
    }
    
    /*
        Problem: Hard/ force sorting for the user. For initial start.
        Images: Ext- /img
            - PNG, JPEG, GIF, SVG, JPG
        Documents: Ext- /document
            - PDF, Doc, Docx, TXT, CSV, ODT
        Programming: Ext- /programming
            - CS, PY, CPP, JS, C, JAR, JAVA, SH, H
        Web Related: Ext- /html
            - JSON, XML, HTTP
    */
    public void SortFiles()
    {
        string destination_path = null;

        // Loop through the file name on the file extension
        foreach (var item in _file_list)
        {
            // Move the file to proper directory based on extension.
            if (item.EndsWith("PNG", StringComparison.OrdinalIgnoreCase) ||
            item.EndsWith("JPEG", StringComparison.OrdinalIgnoreCase) ||
            item.EndsWith("GIF", StringComparison.OrdinalIgnoreCase) ||
            item.EndsWith("JPG", StringComparison.OrdinalIgnoreCase) ||
            item.EndsWith("SVG", StringComparison.OrdinalIgnoreCase))
            {
                destination_path = Path.Combine(DOCKER_PARENT_PATH, "img");
            }
            else if (item.EndsWith("JSON", StringComparison.OrdinalIgnoreCase) ||
                 item.EndsWith("XML", StringComparison.OrdinalIgnoreCase) ||
                 item.EndsWith("HTTP", StringComparison.OrdinalIgnoreCase))
            {
                destination_path = Path.Combine(DOCKER_PARENT_PATH, "html");
            }
           
            if (destination_path != null)
            {
                Console.WriteLine($"Moving {item} to {destination_path}");
                MovingFiles(destination_path);
            }
            else
            {
                Console.WriteLine($"{item} does not fit into any of the filtered extenstions.");
            }
        }

    }

    public void MovingFiles(string destination_path)
    {
        // Example destination path.
        // destination_path = Path.Combine("/app", "/img");

        // Creating directory if it doesn't exist.
        if (!Directory.Exists(destination_path))
        {
            Console.WriteLine($"Creating directory: {destination_path}");
            Directory.CreateDirectory(destination_path);
        }

        foreach (var item in _file_list)
        {
            string file_name = Path.GetFileName(item);
            string new_file_path = Path.Combine(destination_path, file_name);

            try
            {
                // Move file
                File.Move(item, new_file_path);
                Console.WriteLine($"Moved {file_name} to {new_file_path}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to move {file_name}: {ex:Message}");
            }
        }

        // Print out the entire files in the directory.
        foreach (var item in Directory.GetFiles(destination_path))
        {
            Console.WriteLine(item);  // Full path
        }
    }
}