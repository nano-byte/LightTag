﻿// Copyright Bastian Eicher
// Licensed under the MIT License

using System;
using System.ComponentModel;
using System.Drawing;
using System.Xml.Serialization;
using NanoByte.Common;

namespace NanoByte.LightTag
{
    public class Tag : INamed, IHighlightColor
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlIgnore]
        public Color HighlightColor { get; set; }

        [XmlAttribute, Browsable(false)]
        public string Color
        {
            get => ColorTranslator.ToHtml(HighlightColor);
            set => HighlightColor = ColorTranslator.FromHtml(value);
        }

        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(Tag other)
        {
            return string.Compare(Name, other.Name, StringComparison.Ordinal);
        }
    }
}
