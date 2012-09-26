DotNetExtensions
======

Building solution
========================

To keep the git repository size as low as possible dependencies have not been included.

Dependencies will be downloaded at build time using nuget as outlined here http://blog.nuget.org/20120518/package-restore-and-consent.html

When building the solution if you get an error regarding explicit consent to download packages you may need to adjust your visual studio settings. With NuGet Package Manager 1.8 the setting can be found under Tools-> Options-> Package Manager-> General : "Package Restore : Allow NuGet to download missing packages during build".