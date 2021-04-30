# LightTag

[![Download](https://img.shields.io/badge/download-app-blue.svg)](http://nano-byte.de/feeds/LightTag.xml)
[![Build status](https://img.shields.io/appveyor/ci/nano-byte/lighttag.svg)](https://ci.appveyor.com/project/nano-byte/lighttag)  
A lightweight file tagging tool for Windows.

Uses [NTFS Alternate Data Streams](http://blogs.technet.com/b/askcore/archive/2013/03/24/alternate-data-streams-in-ntfs.aspx) on Windows or Extended File Attributes on Linux.

## Building

The source code is in [`src/`](src/) and generated build artifacts are placed in `artifacts/`.  
There is a template in [`feed/`](feed/) for generating a Zero Install feed from the artifacts. For official releases this is published at: http://nano-byte.de/feeds/LightTag.xml

You need [Visual Studio 2017](https://www.visualstudio.com/downloads/) to build this project.

Run `.\build.ps1` in PowerShell to build everything. This script takes a version number as an input argument. The source code itself only contains dummy version numbers. The actual version is picked by continuous integration using [GitVersion](https://gitversion.net/).

## Contributing

We welcome contributions to this project such as bug reports, recommendations and pull requests.

This repository contains an [EditorConfig](http://editorconfig.org/) file. Please make sure to use an editor that supports it to ensure consistent code style, file encoding, etc.. For full tooling support for all style and naming conventions consider using JetBrains' [ReSharper](https://www.jetbrains.com/resharper/) or [Rider](https://www.jetbrains.com/rider/) products.
