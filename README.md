LightTag
========

A lightweight file tagging tool for Windows.

Uses [NTFS Alternate Data Streams](http://blogs.technet.com/b/askcore/archive/2013/03/24/alternate-data-streams-in-ntfs.aspx) on Windows or Extended File Attributes on Linux.

Distributed with [Zero Install](http://0install.de/).

To build and run:
```
msbuild /p:Configuration=Release LightTag.sln
0launch LightTag.xml
```
