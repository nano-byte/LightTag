// Copyright Bastian Eicher
// Licensed under the MIT License

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NanoByte.Common;
using NanoByte.Common.Storage;

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
                var files = Paths.ResolveFiles(paths);

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
