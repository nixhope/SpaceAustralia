using System;
using System.IO;
using System.Collections.Generic;

public class Folder
{
    public string Name { get; private set; }
    public string Path { get; private set; }
    public long TotalSize { get; private set; }
    public long FileSize { get; private set; }
    public List<Folder> Subdirectories;

	public Folder(string name, string path)
	{
        Name = name;
        Path = path;
        Subdirectories = new List<Folder>();
        FileSize = 0;
	}

    public void calculateSizes()
    {
        string[] files = Directory.GetFiles(Path);
        string[] subDirectories = Directory.GetDirectories(Path);

        foreach (string file in files)
        {
            FileSize += new FileInfo(file).Length;
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
                Subdirectories.Add(newFolder);
            }
        }

        TotalSize += FileSize;
    }

}
