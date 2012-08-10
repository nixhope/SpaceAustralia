using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileSizes
{
    public partial class Form1 : Form
    {
        Size originalSize;

        public Form1()
        {
            InitializeComponent();
            originalSize = this.ClientSize;
        }

        private void FileBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            //folderDialog.
            //folderDialog.Title = "Select a base directory";
            folderDialog.Description = "Choose a folder to analyse";
            folderDialog.ShowNewFolderButton = false;
            folderDialog.SelectedPath = textFilePath.Text;
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                textFilePath.Text = folderDialog.SelectedPath.ToString();
            }
        }

        private void buttonAnalyse_Click(object sender, EventArgs e)
        {
            string path = textFilePath.Text;
            string[] parts = path.Split('\\');
            string folderName = parts[parts.Length-1];
            Folder rootFolder = new Folder(folderName, path);
            rootFolder.calculateSizes();
            textFilePath.Text = reformatSize(rootFolder.TotalSize);

            populateData(rootFolder);
        }

        // Add data to the table
        private void populateData(Folder rootFolder)
        {
            DataSet sizes = new DataSet("FolderSizes");
            DataTable sizesTable = sizes.Tables.Add("Sizes");

            // Add the table's columns
            sizesTable.Columns.Add("Folder Name", typeof(string));
            DataColumn folderPath =  sizesTable.Columns.Add("Path", typeof(string));
            sizesTable.Columns.Add("Total Size", typeof(string));
            sizesTable.Columns.Add("File Size", typeof(string));
            sizesTable.Columns.Add("Total Size #", typeof(long));
            sizesTable.Columns.Add("File Size #", typeof(long));
            sizesTable.PrimaryKey = new DataColumn[] { folderPath };

            // Add the rows
            addRows(rootFolder, sizesTable);

            // Add table to the DataGridView
            dataGridView1.DataSource = sizes.Tables["Sizes"];
        }

        // Recursively add rows to the data table
        private void addRows(Folder folder, DataTable table)
        {
            DataRow newRow = table.NewRow();
            newRow["Folder Name"] = folder.Name;
            newRow["Path"] = folder.Path;
            newRow["Total Size"] = reformatSize(folder.TotalSize);
            newRow["File Size"] = reformatSize(folder.FileSize);
            newRow["Total Size #"] = folder.TotalSize;
            newRow["File Size #"] = folder.FileSize;
            table.Rows.Add(newRow);
            // Recurse for subfolders:
            foreach (Folder subFolder in folder.Subdirectories)
            {
                addRows(subFolder, table);
            }
        }

        private string reformatSize(long input)
        {
            var suffixes = new [] {"", "K", "M", "G", "T", "P", "E"};
            decimal size = (decimal)input;
            var magnitude = 0;
            while (size > 1024 && magnitude < suffixes.Length - 1)
            {
                size /= 1024;
                magnitude++;
            }

            return String.Format("{0}{1}", 
                Math.Round(size, 2, MidpointRounding.AwayFromZero),
                suffixes[magnitude]);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            int x = this.ClientSize.Width - originalSize.Width;
            int y = this.ClientSize.Height - originalSize.Height;
            this.dataGridView1.Size = new System.Drawing.Size(759 + x, 508 + y);
        }
    }
}
