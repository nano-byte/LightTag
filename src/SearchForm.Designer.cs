namespace NanoByte.LightTag
{
    partial class SearchForm
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
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.textFolder = new NanoByte.Common.Controls.HintTextBox();
            this.buttonBrowseFolder = new System.Windows.Forms.Button();
            this.groupTags = new System.Windows.Forms.GroupBox();
            this.tags = new NanoByte.LightTag.TagSelectionControl();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.groupTags.SuspendLayout();
            this.SuspendLayout();
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Folder to search for tagged files:";
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // textFolder
            // 
            this.textFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textFolder.HintText = "Select folder to search";
            this.textFolder.Location = new System.Drawing.Point(12, 12);
            this.textFolder.Name = "textFolder";
            this.textFolder.Size = new System.Drawing.Size(253, 20);
            this.textFolder.TabIndex = 2;
            // 
            // buttonBrowseFolder
            // 
            this.buttonBrowseFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseFolder.Location = new System.Drawing.Point(271, 12);
            this.buttonBrowseFolder.Name = "buttonBrowseFolder";
            this.buttonBrowseFolder.Size = new System.Drawing.Size(25, 23);
            this.buttonBrowseFolder.TabIndex = 3;
            this.buttonBrowseFolder.Text = "...";
            this.buttonBrowseFolder.UseVisualStyleBackColor = true;
            this.buttonBrowseFolder.Click += new System.EventHandler(this.buttonBrowseFolder_Click);
            // 
            // groupTags
            // 
            this.groupTags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupTags.Controls.Add(this.tags);
            this.groupTags.Location = new System.Drawing.Point(12, 41);
            this.groupTags.Name = "groupTags";
            this.groupTags.Size = new System.Drawing.Size(284, 303);
            this.groupTags.TabIndex = 0;
            this.groupTags.TabStop = false;
            this.groupTags.Tag = "";
            this.groupTags.Text = "Tags";
            // 
            // tags
            // 
            this.tags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tags.Location = new System.Drawing.Point(3, 16);
            this.tags.Name = "tags";
            this.tags.Size = new System.Drawing.Size(278, 284);
            this.tags.TabIndex = 5;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.Enabled = false;
            this.buttonSearch.Location = new System.Drawing.Point(12, 350);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(284, 23);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // SearchForm
            // 
            this.AcceptButton = this.buttonSearch;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 385);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.groupTags);
            this.Controls.Add(this.buttonBrowseFolder);
            this.Controls.Add(this.textFolder);
            this.Name = "SearchForm";
            this.Text = "LightTag - Search";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.SearchForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.SearchForm_DragEnter);
            this.groupTags.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private NanoByte.Common.Controls.HintTextBox textFolder;
        private System.Windows.Forms.Button buttonBrowseFolder;
        private System.Windows.Forms.GroupBox groupTags;
        private System.Windows.Forms.Button buttonSearch;
        private TagSelectionControl tags;
    }
}

