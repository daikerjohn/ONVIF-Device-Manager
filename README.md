[![ODM](https://github.com/Apra-Labs/ONVIF-Device-Manager/actions/workflows/odm.yml/badge.svg)](https://github.com/Apra-Labs/ONVIF-Device-Manager/actions/workflows/odm.yml)

# ONVIF-Device-Manager
mirror of http://sourceforge.net/projects/onvifdm/
# License
GNU General Public License version 2.0 (GPLv2)
# IDE
This fork has been built using Visual Studio Community 2019. Following changes has been done:
1. in VS installer select following individual components:
   - F# desktop language support
   - >NET Framework 2.5 development tools
2. Uses FSharp.Core 3.0.2 from NuGet Package Manager whic is equivalent to FSharp Framework 4.3.0.0
3. Various other project settings have been fixed to make sure both x64/release and x64/Debug verisons work out of box and have been tested on Windows 11.
4. Added support for TLS1.2 by moving the exe to dotNet4.5, tested with secure camera

# Installer
MSI installer is built with every successful build. E.g. [this one](https://github.com/Apra-Labs/ONVIF-Device-Manager/actions/runs/10906247630/artifacts/1943470047)

# Language Support
 - English
 - Russian
 - Traditional Chinese
 - Spanish thanks [wolfbelmi88](https://sourceforge.net/u/wolfbelmi88/profile)

# Disclaimer
The credit for this open source project remians with the original authors (synesis.ru).
The current fork attempts to keep the project alive and make sure new builds can be easily built/debugged
Apra Labs Inc. is happy to support the incredible OSS community.


