using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Folder;

namespace FileSizes
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
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
                //MessageBox.Show(folderDialog.SelectedPath.ToString());
                textFilePath.Text = folderDialog.SelectedPath.ToString();
            }
        }

        private void buttonAnalyse_Click(object sender, EventArgs e)
        {
            var path = textFilePath.Text;

        }

    }
}
