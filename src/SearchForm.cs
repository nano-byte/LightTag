// Copyright Bastian Eicher
// Licensed under the MIT License

using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NanoByte.Common;
using NanoByte.Common.Storage;
using NanoByte.Common.Tasks;

namespace NanoByte.LightTag
{
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
            tags.TreeView.CheckedEntriesChanged += tags_TreeView_CheckedEntriesChanged;

            textFolder.Text = Preferences.LastSearchDirectory;
        }

        private void SearchForm_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void SearchForm_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;

            var paths = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (paths == null) return;

            // Replace "search" dialog with "tagging" dialog
            var taggingForm = new TaggingForm(paths) {Location = Location, StartPosition = FormStartPosition.Manual};
            taggingForm.FormClosing += delegate { Close(); };
            taggingForm.Show();
            Hide();
        }

        private void buttonBrowseFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog(this);
            textFolder.Text = folderBrowserDialog.SelectedPath;
        }

        private void tags_TreeView_CheckedEntriesChanged(object sender, EventArgs e)
        {
            buttonSearch.Enabled = (tags.TreeView.CheckedEntries.Count != 0);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DirectoryInfo searchDirectory;
            try
            {
                searchDirectory = new DirectoryInfo(textFolder.Text);
            }
                #region Error handling
            catch (ArgumentException ex)
            {
                Msg.Inform(this, ex.Message, MsgSeverity.Error);
                return;
            }
            #endregion

            if (!searchDirectory.Exists)
            {
                Msg.Inform(this, "Directory does not exist.", MsgSeverity.Warn);
                return;
            }
            Preferences.LastSearchDirectory = searchDirectory.FullName;

            var resultSet = new ResultSet();
            var checkedTags = tags.TreeView.CheckedEntries.Select(x => x.Name).ToList();
            try
            {
                var handler = new DialogTaskHandler(this);
                handler.RunTask(new SimpleTask("Searching", () =>
                    searchDirectory.Walk(fileAction: file =>
                    {
                        var fileTags = file.ReadTags();
                        if (checkedTags.All(fileTags.Contains)) resultSet.Add(file);
                    })));
                resultSet.Show();
            }
                #region Error handling
            catch (IOException ex)
            {
                Msg.Inform(this, ex.Message, MsgSeverity.Error);
            }
            catch (UnauthorizedAccessException ex)
            {
                Msg.Inform(this, ex.Message, MsgSeverity.Error);
            }
            catch (Win32Exception ex)
            {
                Msg.Inform(this, ex.Message, MsgSeverity.Error);
            }
            #endregion
        }
    }
}
