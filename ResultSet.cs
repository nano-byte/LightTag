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
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using IWshRuntimeLibrary;
using NanoByte.Common.Storage;
using NanoByte.Common.Utils;

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
