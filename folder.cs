using System;
using System.IO;
using System.Collections.Generic;

namespace FileSizes
{
    public class Folder
    {
        public string Name { get; private set; }
        public string Path { get; private set; }
        public long TotalSize { get; private set; }
        public long FileSize { get; private set; }
        public List<Folder> Subdirectories;

        // Initialise folder with foldername and path
        public Folder(string name, string path)
        {
            Name = name;
            Path = path;
            Subdirectories = new List<Folder>();
            FileSize = 0;
            TotalSize = 0;
        }

        // Calculate the file sizes and total sizes
        public void calculateSizes()
        {
            string[] files = null;
            string[] subDirectories = null;

            try
            {
                files = Directory.GetFiles(Path);
                subDirectories = Directory.GetDirectories(Path);
            }
            catch (UnauthorizedAccessException e)
            {
                // For now, just console log inaccessible files (later create a proper log)
                System.Diagnostics.Debug.Write(e.Message);
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }

            if (files != null)
            {
                foreach (string file in files)
                {
                    try
                    {
                        FileSize += new FileInfo(file).Length;
                    }
                    catch (FileNotFoundException e)
                    {
                        System.Diagnostics.Debug.Write(e.Message);
                    }
                }

                // Iterate through the sub folders
                foreach (string subDirectory in subDirectories)
                {
                    // Do not iterate through reparse points
                    if ((File.GetAttributes(subDirectory) &
                        FileAttributes.ReparsePoint) !=
                        FileAttributes.ReparsePoint)
                    {
                        Folder newFolder = new Folder(subDirectory, System.IO.Path.Combine(Path, subDirectory));
                        newFolder.calculateSizes();
                        TotalSize += newFolder.TotalSize;
                        // Store the new folder in its parent's subdirectory list
                        Subdirectories.Add(newFolder);
                    }
                }
            }

            TotalSize += FileSize;
        }

    }
}
