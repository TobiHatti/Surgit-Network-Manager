<img align="right" width="80" height="80" data-rmimg src="https://github.com/TobiHatti/Surgit-Network-Manager/blob/master/Content/Logos/Ver2/SurgitLogoNew4_S.png">

# Surgit-Network-Manager

![GitHub](https://img.shields.io/github/license/TobiHatti/Surgit-Network-Manager)
[![GitHub Release Date](https://img.shields.io/github/release-date/TobiHatti/Surgit-Network-Manager)](https://github.com/TobiHatti/Surgit-Network-Manager/releases)
[![GitHub release (latest by date including pre-releases)](https://img.shields.io/github/v/release/TobiHatti/Surgit-Network-Manager?include_prereleases)](https://github.com/TobiHatti/Surgit-Network-Manager/releases)
[![GitHub last commit](https://img.shields.io/github/last-commit/TobiHatti/Surgit-Network-Manager)](https://github.com/TobiHatti/Surgit-Network-Manager/commits/master)
[![GitHub issues](https://img.shields.io/github/issues-raw/TobiHatti/Surgit-Network-Manager)](https://github.com/TobiHatti/Surgit-Network-Manager/issues)
[![GitHub language count](https://img.shields.io/github/languages/count/TobiHatti/Surgit-Network-Manager)](https://github.com/TobiHatti/Surgit-Network-Manager)

The Surgit-Network-Manager allows you to discover and manage your network more efficiently.
Using multiple features like Wake-On-Lan, Remote Desktop and Powerstate-Check, 
it provides all the neccecary tools to keep track of yout local network.

![image](https://github.com/TobiHatti/Surgit-Network-Manager/blob/master/Content/Logos/Ver2/SurgitSplashHD.png)

## Features
- Wake-On-Lan
- Remote-Desktop
- Network Discovery
- Visual Managent UI

## Usage
### Explore Network and Devices

![image](https://github.com/TobiHatti/Surgit-Network-Manager/blob/master/Content/SampleImages/Sample01.png)

After installing the program, the first thing you'll want to do is to set the IP-Range of your Network, e.g. 
- 10.0.0.1-10.0.0.254
- 192.168.0.100 - 192.168.0.150
- 10.50.5.129 - 10.50.5.190

After setting the IP-Range, you can start to discover your network by clicking on the "Discover Network" button. 
On the first discovery-run, it is recommended to enable the Ping-Check option. 
The "Discover-Network" function can be run every time the network should be fully updated.

The "Discover-Network" function does however not report your own machine. To add your machine to the Device-List, 
click on "Discover This Device" and select the correct network-adapter.

Every 5 Minutes, the Power-State of devices gets checked automatically. To start this process manually, 
click the "Update Devices" button. If the Power-State always reports "Off", see the FAQ below.

Devices can also be added and edited manually, using the "Add Manually" and "Edit" buttons.

### Power Management

![image](https://github.com/TobiHatti/Surgit-Network-Manager/blob/master/Content/SampleImages/Sample02.png)

Under the "Power-Management"-Tab, you can start the device via Wake-On-LAN ("WOL"), 
or just check the PowerState of the selected device.
The device must support WOL and be enabled. For more information, see the FAQ below.

### Remote Management

![image](https://github.com/TobiHatti/Surgit-Network-Manager/blob/master/Content/SampleImages/Sample03.png)

You can assign each device multiple Remote-Desktop connections (RDP), or add Device-Websites like management-sites.
You can also create an automatic-RDP-connection by clicking on "Open RDP Connection".

## FAQ
### Q: The Device always reports "Power-State: Off", even if it is turned on
A: The Power-Check works by sending a Ping to the target device. On some devices, especially servers, 
the ping-reply is disabled by default in the firewall. To enable this option, do the following:
- Press Window + R to open the "Run" Window.
- Type "wf.msc" and click [Enter] to open the "Windows Firewall with Advanced Security" screen.
- On the left, click on "Inbound Rules".
- On every Rule that says "File and Printer Sharing (Echo Request - ICMPv4-In)", right-click and select Enable Rule.

### Q: When starting a device via WOL, it still says "Monitoring..." even if the device is already powered on
A: The answer to this question is the same as above. Enable the Ping-Reply in the firewall-settings.

### Q: How do I enable Wake-On-LAN
A: There can be several steps to get WOL working:
- In the BIOS of the Target machine, enable the option that says "Remote Wake Up", "Wake On Lan", 
"Power Up On PCI/PCIE Devices", "WOL in S4/S5" or something similar.
- In Windows (or any other OS), go to your Network Adapter Settings and select your primary network adapter. 
- Click on "Properties" and in the next window "Configure".
- Under "Power Management" make sure WOL is enabled.
- Under "Advanced" can also be a Wake-On-Lan option, which needs to be enabled.
- If you don't see any WOL-Opions, try updating the driver of the network-adapter.
- Restart the system and test if WOL works.

### Q: When trying to install the programm, Windows-Defender pops up and stops me from installing the program.
A: The reason for this is the new trust-system of windows-defender that came with windows 10, it blocks any programms 
that don't have enough "reputation", which a program gains reputation by getting downloaded by many individuals. 
Therefor a new program with no reputation gets marked as "Potentially harmfull." To install it anyway, 
click on "More Info" and then on "Run anyway". Alternatively, you can just download the source-code and compile the program yourself.

## Downloads

Get the current version [here](https://github.com/TobiHatti/Surgit-Network-Manager/releases)

Version: 1.1.7

MD5: 40F51930D3DC391BE117C645718F2F7A

