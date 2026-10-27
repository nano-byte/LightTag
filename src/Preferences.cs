// Copyright Bastian Eicher
// Licensed under the MIT License

using System.IO;
using System.Linq;
using System.Text;
using NanoByte.Common.Collections;
using NanoByte.Common.Storage;

namespace NanoByte.LightTag;

public static class Preferences
{
    public static NamedCollection<Tag> KnownTags
    {
        get => Locations.GetLoadConfigPaths("LightTag", isFile: true, "tags.xml").FirstOrDefault() is {} path
            ? XmlStorage.LoadXml<NamedCollection<Tag>>(path)
            : [];
        set => value.SaveXml(Locations.GetSaveConfigPath("LightTag", isFile: true, "tags.xml"));
    }

    public static string? LastSearchDirectory
    {
        get => Locations.GetLoadConfigPaths("LightTag", isFile: true, "search-directory.txt").FirstOrDefault() is {} path
            ? File.ReadAllText(path, Encoding.UTF8)
            : null;
        set => File.WriteAllText(Locations.GetSaveConfigPath("LightTag", isFile: true, "search-directory.txt"), value, Encoding.UTF8);
    }
}
