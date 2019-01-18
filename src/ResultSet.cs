// Copyright Bastian Eicher
// Licensed under the MIT License

using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using IWshRuntimeLibrary;
using NanoByte.Common.Native;
using NanoByte.Common.Storage;

namespace NanoByte.LightTag
{
    public sealed class ResultSet
    {
        private readonly WshShellClass _wshShell = new WshShellClass();
        private readonly DirectoryInfo _directory;

        public ResultSet()
        {
            _directory = new DirectoryInfo(new[] {Locations.UserCacheDir, "LightTag", "Results", DateTime.Now.ToUnixTime().ToString(CultureInfo.InvariantCulture)}.Aggregate(Path.Combine));
            _directory.Create();
        }

        public void Show()
        {
            Process.Start(new ProcessStartInfo(_directory.FullName) {UseShellExecute = true});
        }

        public void Add(FileInfo file)
        {
            string linkPath = Path.Combine(_directory.FullName, file.Name);
            if (WindowsUtils.IsWindows)
            {
                var shortcut = (IWshShortcut)_wshShell.CreateShortcut(linkPath + ".lnk");
                shortcut.TargetPath = file.FullName;
                shortcut.Save();
            }
            else if (UnixUtils.IsUnix) UnixUtils.CreateSymlink(linkPath, file.FullName);
        }
    }
}
