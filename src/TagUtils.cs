// Copyright Bastian Eicher
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NanoByte.Common;
using NanoByte.Common.Storage;

namespace NanoByte.LightTag
{
    public static class TagUtils
    {
        public static void WriteTags(this FileInfo file, IEnumerable<string> tags)
        {
            string tagsData = StringUtils.Join(Environment.NewLine, tags);
            FileUtils.WriteExtendedMetadata(file.FullName, "LightTag", Encoding.UTF8.GetBytes(tagsData));
        }

        public static IEnumerable<string> ReadTags(this FileInfo file)
        {
            var data = FileUtils.ReadExtendedMetadata(file.FullName, "LightTag");
            if (data == null) return Enumerable.Empty<string>();

            string tagData = Encoding.UTF8.GetString(data);
            return tagData.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
