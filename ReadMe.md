# UnoUINugetInAppBuildIssue

Reproduces an issue that generates an error like this

Found multiple publish output files with the same relative path: C:\Users\vsoft.nuget\packages\vssl.framework.storageservices\10.65.0\contentFiles\any\net10.0-windows10.0.26100\obj\Debug\net10.0-android\lp\71\jl\res\drawable-hdpi-v4\notification_bg_low_normal.9.png, C:\Users\vsoft.nuget\packages\vssl.framework.platformproperties\10.65.0\contentFiles\any\net10.0-windows10.0.26100\obj\Debug\net10.0-android\lp\71\jl\res\drawable-hdpi-v4\notification_bg_low_normal.9.png, C:\Users\vsoft.nuget\packages\vssl.framework.loggingservices\10.65.0\contentFiles\any\net10.0-windows10.0.26100\obj\Debug\net10.0-android\lp\71\jl\res\drawable-hdpi-v4\notification_bg_low_normal.9.png, C:\Users\vsoft.nuget\packages\vssl.framework.storageservices\10.65.0\contentFiles\any\net10.0-windows10.0.26100\obj\Debug\net10.0-android\lp\71\jl\res\drawable-hdpi-v4\notification_bg_low_pressed.9.png, C:\Users\vsoft.nuget\packages\vssl.framework.platformproperties\10.65.0\contentFiles\any\net10.0-windows10.0.26100\obj\Debug\net10.0-android\lp\71\jl\res\drawable-hdpi-v4\notification_bg_low_pressed.9.png, C:\Users\vsoft.nuget\packages\vssl.framework.loggingservices\10.65.0\contentFiles\any\net10.0-windows10.0.26100\obj\Debug\net10.0-android\lp\71\jl\res\drawable-hdpi-v4\notification_bg_low_pressed.9.png, C:\Users\vsoft.nuget\packages\vssl.framework.storageservices\10.65.0\contentFiles\any\net10.0-windows10.0.26100\obj\Debug\net10.0-android\lp\71\jl\res\drawable-hdpi-v4\notification_bg_normal.9.png, C:\Users\vsoft.nuget\packages\vssl.framework.platformproperties\10.65.0\contentFiles\any\net10.0-

NOTE

To reproduce this you will need to modify this line in the two nuget libraries
        <Exec Command="%(Drive.RootDir)Nuget\nuget push bin\$(Configuration)\$(PackageId).$(PackageVersion).nupkg -Source VSSL.local" />

        And define the location of the nuget exe and the package source being pushed to

The sample has a complex project structure designed to mimic the structured layout of much larger projects.
The steps below recreate the upgrade steps that caused the issue.

The project SampleFrameworkInterfaces, SampleConverters and SampleLibrary create nuget packages. You will likely need to edit the last lines in the project files to adjust the nuget command location and the destination of the nuget packages.

Unload the TopLevelControls and UnoUINugetInAppBuildIssue projects
Edit the global.json file and switch to Uno.Sdk: 6.4.58
In the projects SampleFrameworkInterfaces, SampleConverters and SampleLibrary 
	Uncomment the net9 target frameworks and comment the net 10 target frameworks
	Uncomment the 9.x version and comment the 10.x version
In the Directory.Packages.props uncomment the net 9 versions and comment the net 10 versions
Release build the SampleFrameworkInterfaces, SampleConverters and SampleLibrary in this sequence.
Re-edit the global.json file and switch back to Uno.Sdk: 6.5.31
Reverse the steps above
Release build the net 10 versions on Uno.Sdk: 6.5.31 of SampleFrameworkInterfaces, SampleConverters and SampleLibrary in this sequence.

Switch to Debug
Reload the TopLevelControls and UnoUINugetInAppBuildIssue projects
It may be necessary to do a manual dotnet restore in these project folders

