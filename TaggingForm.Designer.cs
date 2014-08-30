namespace NanoByte.LightTag
{
    partial class TaggingForm
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
            this.groupTags = new System.Windows.Forms.GroupBox();
            this.buttonDeleteTag = new System.Windows.Forms.Button();
            this.buttonAddTag = new System.Windows.Forms.Button();
            this.groupFiles = new System.Windows.Forms.GroupBox();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.groupTags.SuspendLayout();
            this.groupFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupTags
            // 
            this.groupTags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupTags.Controls.Add(this.buttonDeleteTag);
            this.groupTags.Controls.Add(this.buttonAddTag);
            this.groupTags.Location = new System.Drawing.Point(12, 125);
            this.groupTags.Name = "groupTags";
            this.groupTags.Size = new System.Drawing.Size(284, 308);
            this.groupTags.TabIndex = 1;
            this.groupTags.TabStop = false;
            this.groupTags.Text = "Tags";
            // 
            // buttonDeleteTag
            // 
            this.buttonDeleteTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteTag.Enabled = false;
            this.buttonDeleteTag.Location = new System.Drawing.Point(240, 285);
            this.buttonDeleteTag.Name = "buttonDeleteTag";
            this.buttonDeleteTag.Size = new System.Drawing.Size(23, 23);
            this.buttonDeleteTag.TabIndex = 2;
            this.buttonDeleteTag.Text = "&-";
            this.buttonDeleteTag.UseVisualStyleBackColor = true;
            this.buttonDeleteTag.Click += new System.EventHandler(this.buttonDeleteTag_Click);
            // 
            // buttonAddTag
            // 
            this.buttonAddTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddTag.Location = new System.Drawing.Point(215, 285);
            this.buttonAddTag.Name = "buttonAddTag";
            this.buttonAddTag.Size = new System.Drawing.Size(23, 23);
            this.buttonAddTag.TabIndex = 1;
            this.buttonAddTag.Text = "&+";
            this.buttonAddTag.UseVisualStyleBackColor = true;
            this.buttonAddTag.Click += new System.EventHandler(this.buttonAddTag_Click);
            // 
            // groupFiles
            // 
            this.groupFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupFiles.Controls.Add(this.listBoxFiles);
            this.groupFiles.Location = new System.Drawing.Point(12, 12);
            this.groupFiles.Name = "groupFiles";
            this.groupFiles.Size = new System.Drawing.Size(284, 107);
            this.groupFiles.TabIndex = 0;
            this.groupFiles.TabStop = false;
            this.groupFiles.Text = "Files";
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.Location = new System.Drawing.Point(3, 16);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.Size = new System.Drawing.Size(278, 88);
            this.listBoxFiles.TabIndex = 0;
            // 
            // TaggingForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 445);
            this.Controls.Add(this.groupFiles);
            this.Controls.Add(this.groupTags);
            this.Name = "TaggingForm";
            this.Text = "LightTag - Tagging";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.TaggingForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.TaggingForm_DragEnter);
            this.groupTags.ResumeLayout(false);
            this.groupFiles.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupTags;
        private System.Windows.Forms.GroupBox groupFiles;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.Button buttonDeleteTag;
        private System.Windows.Forms.Button buttonAddTag;
    }
}