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
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NanoByte.Common;
using NanoByte.Common.Controls;
using NanoByte.Common.Utils;

namespace NanoByte.LightTag
{
    public partial class TaggingForm : Form
    {
        #region Controls
        // Don't use WinForms designer for this, since it doesn't understand generics
        private readonly FilteredTreeView<Tag> treeTags = new FilteredTreeView<Tag>
        {
            Name = "treeTags",
            Dock = DockStyle.Fill,
            TabIndex = 0,
            Separator = '/',
            CheckBoxes = true
        };
        #endregion

        public TaggingForm(string[] paths)
        {
            InitializeComponent();

            treeTags.Nodes = Preferences.KnownTags;
            treeTags.CheckedEntriesChanged += treeTags_CheckedEntriesChanged;
            treeTags.SelectedEntryChanged += treeTags_SelectedEntryChanged;
            groupTags.Controls.Add(treeTags);

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

                listBoxFiles.BeginUpdate();
                foreach (var file in files)
                {
                    listBoxFiles.Items.Add(file);
                    foreach (string tagName in file.ReadTags())
                    {
                        Tag tag;
                        if (treeTags.Nodes.Contains(tagName))
                            tag = treeTags.Nodes[tagName];
                        else
                        {
                            tag = new Tag {Name = tagName, HighlightColor = Color.Blue};
                            treeTags.Nodes.Add(tag);
                        }

                        treeTags.CheckedEntries.Add(tag);
                    }
                }
                listBoxFiles.EndUpdate();
                treeTags.UpdateList();
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

        private void treeTags_CheckedEntriesChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (FileInfo file in listBoxFiles.Items)
                    file.WriteTags(treeTags.CheckedEntries.Select(x => x.Name));
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

        private void treeTags_SelectedEntryChanged(object sender, EventArgs e)
        {
            buttonDeleteTag.Enabled = (treeTags.SelectedEntry != null);
        }

        private void buttonAddTag_Click(object sender, EventArgs e)
        {
            string tagName = InputBox.Show(this, "Add tag", "New tag name (use slashes for groups):");
            if (string.IsNullOrEmpty(tagName) || treeTags.Nodes.Contains(tagName)) return;

            treeTags.Nodes.Add(new Tag {Name = tagName, HighlightColor = Color.Blue});
            Preferences.KnownTags = treeTags.Nodes;
        }

        private void buttonDeleteTag_Click(object sender, EventArgs e)
        {
            treeTags.Nodes.Remove(treeTags.SelectedEntry);
            Preferences.KnownTags = treeTags.Nodes;
        }
    }
}
