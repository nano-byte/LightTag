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

using System.Drawing;
using System.Windows.Forms;
using NanoByte.Common;
using NanoByte.Common.Controls;

namespace NanoByte.LightTag
{
    public partial class TagSelectionControl : UserControl
    {
        // Don't use WinForms designer for this, since it doesn't understand generics
        public readonly FilteredTreeView<Tag> TreeView = new FilteredTreeView<Tag>
        {
            Name = "TreeView",
            Dock = DockStyle.Fill,
            TabIndex = 0,
            Separator = '/',
            CheckBoxes = true
        };

        public TagSelectionControl()
        {
            InitializeComponent();
            TreeView.Nodes = Preferences.KnownTags;
            TreeView.SelectedEntryChanged += delegate { buttonRemove.Enabled = (TreeView.SelectedEntry != null); };
            Controls.Add(TreeView);
        }

        public Tag this[string name]
        {
            get
            {
                if (TreeView.Nodes.Contains(name)) return TreeView.Nodes[name];
                else
                {
                    var tag = new Tag {Name = name, HighlightColor = Color.Blue};
                    AddTag(tag);
                    return tag;
                }
            }
        }

        private void buttonAdd_Click(object sender, System.EventArgs e)
        {
            var tag = new Tag {HighlightColor = Color.Blue};
            using (var dialog = new EditorDialog<Tag>())
                dialog.ShowDialog(this, tag);

            if (string.IsNullOrEmpty(tag.Name)) Msg.Inform(this, "Tag name cannot be empty.", MsgSeverity.Warn);
            else if (TreeView.Nodes.Contains(tag.Name)) Msg.Inform(this, "Tag name already used.", MsgSeverity.Warn);
            else AddTag(tag);
        }

        private void buttonRemove_Click(object sender, System.EventArgs e)
        {
            RemoveTag(TreeView.SelectedEntry);
            buttonRemove.Enabled = false;
        }

        private void AddTag(Tag tag)
        {
            TreeView.Nodes.Add(tag);
            Preferences.KnownTags = TreeView.Nodes;
        }

        private void RemoveTag(Tag tag)
        {
            TreeView.Nodes.Remove(tag);
            Preferences.KnownTags = TreeView.Nodes;
        }
    }
}
