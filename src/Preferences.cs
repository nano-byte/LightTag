// Copyright Bastian Eicher
// Licensed under the MIT License

using System.IO;
using System.Linq;
using System.Text;
using NanoByte.Common.Collections;
using NanoByte.Common.Storage;

namespace NanoByte.LightTag
{
    public static class Preferences
    {
        public static NamedCollection<Tag> KnownTags
        {
            get
            {
                string configPath = Locations.GetLoadConfigPaths("LightTag", true, "tags.xml").FirstOrDefault();
                return (configPath == null) ? new NamedCollection<Tag>() : XmlStorage.LoadXml<NamedCollection<Tag>>(configPath);
            }
            set
            {
                string configPath = Locations.GetSaveConfigPath("LightTag", true, "tags.xml");
                value.SaveXml(configPath);
            }
        }

        public static string LastSearchDirectory
        {
            get
            {
                string configPath = Locations.GetLoadConfigPaths("LightTag", true, "search-directory.txt").FirstOrDefault();
                return (configPath == null) ? null : File.ReadAllText(configPath, Encoding.UTF8);
            }
            set
            {
                string configPath = Locations.GetSaveConfigPath("LightTag", true, "search-directory.txt");
                File.WriteAllText(configPath, value, Encoding.UTF8);
            }
        }
    }
}
