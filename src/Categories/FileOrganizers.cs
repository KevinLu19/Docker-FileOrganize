using System.Text.RegularExpressions;
using FileOrganizer.src.Categories.Interfaces;

namespace FileOrganizer.src.Categories;

public class FileOrganizers
{
    // This list just stores the name of the files. Not the file itself. Will need to manipulate it later on.
    private List<string> _file_list = new List<string>();

    // Create different lists with each type as the sorted folders. Need a generic list type.
    private IList<IFileExtension> _image_collection = new List<IFileExtension>(); 

    // Hash map for file extensions. Not storing the name of the file. Will be <file ext, number>
    private Dictionary<string, int> _file_hash_map = new Dictionary<string, int>();

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
                if (!_file_hash_map.ContainsKey(matches.Value))
                {
                    _file_hash_map.Add(matches.Value, hash_map_count);
                    hash_map_count++;
                }
            }
        }

        // foreach(var item in file_hash_map)
        // {
        //     Console.WriteLine(item.Key);
        // }
    }

    public void FilterHashMap()
    {
        // Create a dictionary of enums to solve the below comment
    }
    /*
        Problem: Hard/ force sorting for the user. For initial start.
        Images:
            - PNG, JPEG, GIF, SVG, JPG
        Documents:
            - PDF, Doc, Docx, TXT, CSV, ODT
        Programming:
            - CS, PY, CPP, JS, C, JAR, JAVA, Sh, H
        Web Related:
            - JSON, XML, HTTP
    */
    public void SortFiles()
    {
        // Sort via Images and put in image folder.
        ImageExtension image_ext = new ImageExtension(_file_list);

        image_ext.CreateImgDirectory();
    }
}