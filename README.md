# ONVIF-Device-Manager
mirror of http://sourceforge.net/projects/onvifdm/
# License
GNU General Public License version 2.0 (GPLv2)
# IDE
This fork has been built using Visual Studio Community 2022. Following changes has been done:
1. in VS installer seletc following individual components:
   - F# desktop language support
   - >NET Framework 2.5 development tools
2. Uses FSharp.Core 3.0.2 from NuGet Package Manager whic is equivalent to FSharp Framework 4.3.0.0
3. Various other project settings have been fixed to make sure both x64/release and x64/Debig verisons work out of box and have been tested on Windows 11.
4. Added support for TLS1.2 by moving the exe to dotNet4.5, tested with secure camera

