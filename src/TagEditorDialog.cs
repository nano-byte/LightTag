// Copyright Bastian Eicher
// Licensed under the MIT License

using System;
using System.Drawing;
using System.Windows.Forms;
using NanoByte.Common.Controls;

namespace NanoByte.LightTag
{
    public class TagEditorDialog : OKCancelDialog
    {
        private readonly PropertyGrid _propertyGrid = new PropertyGrid
        {
            ToolbarVisible = false,
            HelpVisible = false,
            Location = new Point(12, 12),
            Size = new Size(259, 205),
            Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom
        };

        private TagEditorDialog(Tag element)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            Text = "Tag";
            FormBorderStyle = FormBorderStyle.Sizable;

            _propertyGrid.SelectedObject = element ?? throw new ArgumentNullException(nameof(element));
            Controls.Add(_propertyGrid);
        }

        public static bool Show(IWin32Window owner, Tag element)
        {
            using (var dialog = new TagEditorDialog(element))
                return (dialog.ShowDialog(owner) == DialogResult.OK);
        }
    }
}
