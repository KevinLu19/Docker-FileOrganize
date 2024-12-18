using System;
using FileOrganizer.src.Categories;

namespace FileOrganizer;

public class Program
{
    public static void Main(string[] args)
    {
        FileOrganizers file_obj = new FileOrganizers();
        file_obj.GetAllFiles();
        file_obj.FilterByFileExtension();
    }
}