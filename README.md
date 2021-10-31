# ACT Wrath Math

This [Advanced Combat Tracker (ACT)](http://advancedcombattracker.com/) plugin will help with the math during the Abandoned Labomination encounter.

## Setup
1. Download ACT
2. Download the plugin [ActWrathMath.dll](https://github.com/walkerjam/ActWrathMath/blob/master/bin/Release/ActWrathMath.dll?raw=true) to a location on your hard drive
3. Setup ACT as you would normally
4. Open ACT and select the __Plugins__ tab
5. Click __Browse...__, and select the location where you saved the plugin
6. Click __Add/Enable Plugin__
7. The plugin should open a new window on your desktop - this is where you will see detriment info (as well as help and settings)

## Building
This project was created using [Visual Studio Community](https://visualstudio.microsoft.com/vs/community/).

The project user file is configured to launch ACT during debug -- this path may be different on your machine.

The entry point for the plugin is in __WrathMath.cs__, and the main UI is __WrathMathHud.cs__.

The plugin saves its settings in the following location: __%userprofile%\appdata\Roaming\Advanced Combat Tracker\Config\\WrathMath.config.xml__.

## Contact
Send an in-game tell to Skyfire.Reapp if you have questions.
