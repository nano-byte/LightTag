/*
 * Copyright 2012-2014 Bastian Eicher
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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NanoByte.Common;
using NanoByte.Common.Utils;

namespace NanoByte.LightTag
{
    public partial class TaggingForm : Form
    {
        public TaggingForm(string[] paths)
        {
            InitializeComponent();

            AddFiles(paths);
        }

        private void TaggingForm_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void TaggingForm_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;

            var paths = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (paths == null) return;

            AddFiles(paths);
        }

        private void AddFiles(string[] paths)
        {
            try
            {
                var files = ArgumentUtils.GetFiles(paths);

                listFiles.BeginUpdate();
                foreach (var file in files)
                {
                    listFiles.Items.Add(new ListViewItem(file.Name) {Tag = file});
                    foreach (string tagName in file.ReadTags())
                        tags.TreeView.CheckedEntries.Add(tags[tagName]);
                }
                listFiles.EndUpdate();
                tags.TreeView.UpdateList();
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

        private void listFiles_DoubleClick(object sender, EventArgs e)
        {
            if (listFiles.SelectedItems.Count == 0) return;
            Process.Start(((FileInfo)listFiles.SelectedItems[0].Tag).FullName);
        }

        private void menuFilesRemove_Click(object sender, EventArgs e)
        {
            listFiles.BeginUpdate();
            foreach (ListViewItem item in listFiles.SelectedItems)
                listFiles.Items.Remove(item);
            listFiles.EndUpdate();
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem item in listFiles.Items)
                    ((FileInfo)item.Tag).WriteTags(tags.TreeView.CheckedEntries.Select(x => x.Name));
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

            listFiles.Items.Clear();

            tags.TreeView.CheckedEntries.Clear();
            tags.TreeView.UpdateList();
        }
    }
}
