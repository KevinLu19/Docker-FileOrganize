using System.Text.RegularExpressions;
using System.IO;

namespace FileOrganizer.src.Categories;

public class FileOrganizers
{
    // This list just stores the name of the files. Not the file itself. Will need to manipulate it later on.
    private List<string> _file_list = new List<string>();

    private const string DOCKER_PARENT_PATH = "/app/test_folder";

    private Dictionary<string, int> GetItemInDictionary()
    {
        // Hash map for file extensions. Not storing the name of the file. Will be <file ext, number>
        Dictionary<string, int> file_hash_map = new Dictionary<string, int>();

        return file_hash_map;
    }

    // Lists all files in current directory.
    public void GetAllFiles()
    {
        Console.WriteLine("The current directory is: " + DOCKER_PARENT_PATH);

        DirectoryInfo dir = new DirectoryInfo(DOCKER_PARENT_PATH);

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
        Music Related:
         
    */
    public void SortFiles()
    {
        string? destination_path = null;

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
            else if (item.EndsWith("PDF", StringComparison.OrdinalIgnoreCase) ||
                    item.EndsWith("DOC", StringComparison.OrdinalIgnoreCase)  || 
                    item.EndsWith("DOCX", StringComparison.OrdinalIgnoreCase) ||
                    item.EndsWith("TXT", StringComparison.OrdinalIgnoreCase)  ||
                    item.EndsWith("CSV", StringComparison.OrdinalIgnoreCase)  ||
                    item.EndsWith("ODT", StringComparison.OrdinalIgnoreCase))
            {
                destination_path = Path.Combine(DOCKER_PARENT_PATH, "documents");
            }
            else if (item.EndsWith("CS", StringComparison.OrdinalIgnoreCase) ||
                    item.EndsWith("PY", StringComparison.OrdinalIgnoreCase) ||
                    item.EndsWith("CPP", StringComparison.OrdinalIgnoreCase) ||
                    item.EndsWith("JS", StringComparison.OrdinalIgnoreCase) ||
                    item.EndsWith("C", StringComparison.OrdinalIgnoreCase) ||
                    item.EndsWith("JAR", StringComparison.OrdinalIgnoreCase) ||
                    item.EndsWith("JAVA", StringComparison.OrdinalIgnoreCase) ||
                    item.EndsWith("SH", StringComparison.OrdinalIgnoreCase) ||
                    item.EndsWith("H", StringComparison.OrdinalIgnoreCase))
            {
                destination_path = Path.Combine(DOCKER_PARENT_PATH, "programming");
            }
            else if (item.EndsWith("MP3", StringComparison.OrdinalIgnoreCase) ||
                    item.EndsWith("WAV", StringComparison.OrdinalIgnoreCase))
            {
                destination_path = Path.Combine(DOCKER_PARENT_PATH, "audio");
            }
            else if (item.EndsWith("MP4", StringComparison.OrdinalIgnoreCase) ||
                    item.EndsWith("AVI", StringComparison.OrdinalIgnoreCase) ||
                    item.EndsWith("MOV", StringComparison.OrdinalIgnoreCase) || 
                    item.EndsWith("WebM", StringComparison.OrdinalIgnoreCase) ||
                    item.EndsWith("MKV", StringComparison.OrdinalIgnoreCase))
            {
                destination_path = Path.Combine(DOCKER_PARENT_PATH, "video");
            }
            else
            {
                destination_path = null;
                Console.WriteLine($"{item} does not fit into any of the filtered extenstions.");
            }

            if (destination_path != null)
            {
                MovingFiles(destination_path);
                Console.WriteLine($"Moving {item} to {destination_path}");

                PrintItemInDirectory(destination_path);     // Check items inside of the destination.
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
                // Validate if file exists. Hopefully this removes error even if file has moved.
                if (File.Exists(item))
                {
                    // Move file
                    File.Move(item, new_file_path);
                    Console.WriteLine($"Moved {file_name} to {new_file_path}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to move {file_name}: {ex:Message}");
            }
        }
    }

    public void PrintItemInDirectory(string destination_path)
    {
        // Print out the entire files in the directory.
        foreach (var item in Directory.GetFiles(destination_path))
        {
            Console.WriteLine(item);  // Full path
        }
    }
}