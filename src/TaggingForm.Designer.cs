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
            this.components = new System.ComponentModel.Container();
            this.groupTags = new System.Windows.Forms.GroupBox();
            this.groupFiles = new System.Windows.Forms.GroupBox();
            this.listFiles = new System.Windows.Forms.ListView();
            this.menuFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuFilesRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonApply = new System.Windows.Forms.Button();
            this.tags = new NanoByte.LightTag.TagSelectionControl();
            this.groupTags.SuspendLayout();
            this.groupFiles.SuspendLayout();
            this.menuFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupTags
            // 
            this.groupTags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupTags.Controls.Add(this.tags);
            this.groupTags.Location = new System.Drawing.Point(12, 125);
            this.groupTags.Name = "groupTags";
            this.groupTags.Size = new System.Drawing.Size(284, 279);
            this.groupTags.TabIndex = 1;
            this.groupTags.TabStop = false;
            this.groupTags.Text = "Tags";
            // 
            // groupFiles
            // 
            this.groupFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupFiles.Controls.Add(this.listFiles);
            this.groupFiles.Location = new System.Drawing.Point(12, 12);
            this.groupFiles.Name = "groupFiles";
            this.groupFiles.Size = new System.Drawing.Size(284, 107);
            this.groupFiles.TabIndex = 0;
            this.groupFiles.TabStop = false;
            this.groupFiles.Text = "Files";
            // 
            // listFiles
            // 
            this.listFiles.ContextMenuStrip = this.menuFiles;
            this.listFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listFiles.Location = new System.Drawing.Point(3, 16);
            this.listFiles.Name = "listFiles";
            this.listFiles.Size = new System.Drawing.Size(278, 88);
            this.listFiles.TabIndex = 0;
            this.listFiles.UseCompatibleStateImageBehavior = false;
            this.listFiles.DoubleClick += new System.EventHandler(this.listFiles_DoubleClick);
            // 
            // menuFiles
            // 
            this.menuFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFilesRemove});
            this.menuFiles.Name = "menuFiles";
            this.menuFiles.Size = new System.Drawing.Size(118, 26);
            // 
            // menuFilesRemove
            // 
            this.menuFilesRemove.Name = "menuFilesRemove";
            this.menuFilesRemove.Size = new System.Drawing.Size(117, 22);
            this.menuFilesRemove.Text = "&Remove";
            this.menuFilesRemove.Click += new System.EventHandler(this.menuFilesRemove_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(221, 410);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 2;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // tags
            // 
            this.tags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tags.Location = new System.Drawing.Point(3, 16);
            this.tags.Name = "tags";
            this.tags.Size = new System.Drawing.Size(278, 260);
            this.tags.TabIndex = 0;
            // 
            // TaggingForm
            // 
            this.AcceptButton = this.buttonApply;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 445);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.groupFiles);
            this.Controls.Add(this.groupTags);
            this.Name = "TaggingForm";
            this.Text = "LightTag - Tagging";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.TaggingForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.TaggingForm_DragEnter);
            this.groupTags.ResumeLayout(false);
            this.groupFiles.ResumeLayout(false);
            this.menuFiles.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupTags;
        private System.Windows.Forms.GroupBox groupFiles;
        private System.Windows.Forms.ListView listFiles;
        private System.Windows.Forms.Button buttonApply;
        private TagSelectionControl tags;
        private System.Windows.Forms.ContextMenuStrip menuFiles;
        private System.Windows.Forms.ToolStripMenuItem menuFilesRemove;
    }
}