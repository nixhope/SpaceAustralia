namespace FileSizes
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonFileBrowse = new System.Windows.Forms.Button();
            this.textFilePath = new System.Windows.Forms.TextBox();
            this.buttonAnalyse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonFileBrowse
            // 
            this.buttonFileBrowse.Location = new System.Drawing.Point(13, 13);
            this.buttonFileBrowse.Name = "buttonFileBrowse";
            this.buttonFileBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonFileBrowse.TabIndex = 0;
            this.buttonFileBrowse.Text = "Browse...";
            this.buttonFileBrowse.UseVisualStyleBackColor = true;
            this.buttonFileBrowse.Click += new System.EventHandler(this.FileBrowseButton_Click);
            // 
            // textFilePath
            // 
            this.textFilePath.Location = new System.Drawing.Point(95, 13);
            this.textFilePath.Name = "textFilePath";
            this.textFilePath.Size = new System.Drawing.Size(200, 20);
            this.textFilePath.TabIndex = 1;
            this.textFilePath.Text = "C:\\";
            // 
            // buttonAnalyse
            // 
            this.buttonAnalyse.Location = new System.Drawing.Point(302, 13);
            this.buttonAnalyse.Name = "buttonAnalyse";
            this.buttonAnalyse.Size = new System.Drawing.Size(75, 23);
            this.buttonAnalyse.TabIndex = 2;
            this.buttonAnalyse.Text = "Analyse!";
            this.buttonAnalyse.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.buttonAnalyse);
            this.Controls.Add(this.textFilePath);
            this.Controls.Add(this.buttonFileBrowse);
            this.Name = "Form1";
            this.Text = "Folder size analyser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFileBrowse;
        private System.Windows.Forms.TextBox textFilePath;
        private System.Windows.Forms.Button buttonAnalyse;
    }
}

