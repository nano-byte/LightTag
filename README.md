# LightTag

[![Build](https://github.com/nano-byte/LightTag/actions/workflows/build.yml/badge.svg)](https://github.com/nano-byte/LightTag/actions/workflows/build.yml)
[![Download](https://img.shields.io/badge/download-app-blue.svg)](http://nano-byte.de/feeds/LightTag.xml)  
A lightweight file tagging tool for Windows.

Uses [NTFS Alternate Data Streams](https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-fscc/c54dec26-1551-4d3a-a0ea-4fa40f848eb3) on Windows or Extended File Attributes on Linux.

LightTag requires .NET Framework 4.5 or newer (or Mono on Linux).

## Building

The source code is in [`src/`](src/), a template for generating a [Zero Install](https://0install.net/) feed is in [`feed/`](feed/) and generated build artifacts are placed in `artifacts/`. The source code does not contain version numbers. Instead the version is determined during CI using [GitVersion](https://gitversion.net/).

To build install [Visual Studio 2026 v18.0 or newer](https://www.visualstudio.com/downloads/) and run `.\build.ps1`.

## Contributing

We welcome contributions to this project such as bug reports, recommendations and pull requests.

This repository contains an [EditorConfig](http://editorconfig.org/) file. Please make sure to use an editor that supports it to ensure consistent code style, file encoding, etc.. For full tooling support for all style and naming conventions consider using JetBrains' [ReSharper](https://www.jetbrains.com/resharper/) or [Rider](https://www.jetbrains.com/rider/) products.
