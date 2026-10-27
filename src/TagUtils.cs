// Copyright Bastian Eicher
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NanoByte.Common;
using NanoByte.Common.Storage;

namespace NanoByte.LightTag;

public static class TagUtils
{
    public static void WriteTags(this FileInfo file, IEnumerable<string> tags)
        => FileUtils.WriteExtendedMetadata(file.FullName, "LightTag", Encoding.UTF8.GetBytes(StringUtils.Join(Environment.NewLine, tags)));

    public static IEnumerable<string> ReadTags(this FileInfo file)
        => FileUtils.ReadExtendedMetadata(file.FullName, "LightTag") is {} data
            ? Encoding.UTF8.GetString(data).Split([Environment.NewLine], StringSplitOptions.RemoveEmptyEntries)
            : [];
}
