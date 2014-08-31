﻿/*
 * Copyright 2006-2014 Bastian Eicher
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

using System.IO;
using System.Linq;
using System.Text;
using NanoByte.Common.Collections;
using NanoByte.Common.Info;
using NanoByte.Common.Storage;

namespace NanoByte.LightTag
{
    public static class Preferences
    {
        public static NamedCollection<Tag> KnownTags
        {
            get
            {
                string configPath = Locations.GetLoadConfigPaths(AppInfo.Current.Name, true, "tags.xml").FirstOrDefault();
                return (configPath == null) ? new NamedCollection<Tag>() : XmlStorage.LoadXml<NamedCollection<Tag>>(configPath);
            }
            set
            {
                string configPath = Locations.GetSaveConfigPath(AppInfo.Current.Name, true, "tags.xml");
                value.SaveXml(configPath);
            }
        }

        public static string LastSearchDirectory
        {
            get
            {
                string configPath = Locations.GetLoadConfigPaths(AppInfo.Current.Name, true, "search-directory.txt").FirstOrDefault();
                return (configPath == null) ? null : File.ReadAllText(configPath, Encoding.UTF8);
            }
            set
            {
                string configPath = Locations.GetSaveConfigPath(AppInfo.Current.Name, true, "search-directory.txt");
                File.WriteAllText(configPath, value, Encoding.UTF8);
            }
        }
    }
}