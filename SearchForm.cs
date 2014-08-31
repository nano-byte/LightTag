/*
 * Copyright 2014 Bastian Eicher
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NanoByte.Common;
using NanoByte.Common.Tasks;
using NanoByte.Common.Utils;

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
                var handler = new GuiTaskHandler(this);
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
