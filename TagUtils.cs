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
