// Copyright Bastian Eicher
// Licensed under the MIT License

using System.Drawing;
using System.Windows.Forms;
using NanoByte.Common;
using NanoByte.Common.Controls;

namespace NanoByte.LightTag
{
    public partial class TagSelectionControl : UserControl
    {
        public readonly FilteredTreeView<Tag> TreeView = new FilteredTreeView<Tag>
        {
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
            if (!TagEditorDialog.Show(this, tag)) return;

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
