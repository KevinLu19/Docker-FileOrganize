﻿using FileOrganizer.src.Categories;

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
    }
}