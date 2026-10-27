// Copyright Bastian Eicher
// Licensed under the MIT License

using System;
using System.Diagnostics;
using System.IO;
using NanoByte.Common;
using NanoByte.Common.Native;
using NanoByte.Common.Storage;
using Windows.Win32.System.Com;
using Windows.Win32.UI.Shell;

namespace NanoByte.LightTag;

public sealed class ResultSet
{
    private readonly DirectoryInfo _directory = new(Path.Combine(Locations.UserCacheDir, "LightTag", "Results", ((UnixTime)DateTime.UtcNow).ToString()));

    public ResultSet()
    {
        _directory.Create();
    }

    public void Show()
        => Process.Start(new ProcessStartInfo(_directory.FullName) {UseShellExecute = true});

    public void Add(FileInfo file)
    {
        string linkPath = Path.Combine(_directory.FullName, file.Name);
        if (WindowsUtils.IsWindows) CreateShortcut(linkPath + ".lnk", file.FullName);
        else if (UnixUtils.IsUnix) UnixUtils.CreateSymlink(linkPath, file.FullName);
    }

    private static unsafe void CreateShortcut(string path, string targetPath)
    {
        ShellLink.CreateInstance(out IShellLinkW* shellLink).ThrowOnFailure();
        IPersistFile* persistFile = null;
        try
        {
            shellLink->SetPath(targetPath);
            shellLink->QueryInterface(out persistFile).ThrowOnFailure();
            persistFile->Save(path, fRemember: true);
        }
        finally
        {
            if (persistFile != null) persistFile->Release();
            shellLink->Release();
        }
    }
}
