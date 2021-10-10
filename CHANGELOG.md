### v1.6.1 (10/10/2021)
* Added Process Killer feature that constantly checks for the "Kill Targets" programs and kills them if found
* Added failover capability for the Remote Configuration URL, add several URLs by separating them with a comma (,)
* Changed system calls to direct system calls thus reducing detections
* Changed native loader code to reduce detections
* Removed Online Download feature due to domain being taken down
* Improved overall code
* Updated miner
### v1.6.0 (02/10/2021)
**The previous version was supposed to be the last one before the unified miner but I recieved great results by loading everything by Shellcode making it worthwhile to update**
* Added new Shellcode loader, the miner, watchdog and uninstaller will now be converted into shellcode and injected using a native C loader which greatly reduces detections
* Added custom tcc C compiler to compile the Shellcode loader
* Added custom windres resource compiler to allow icons, assembly data and run as administrator for the native C program
* Added donut to convert .NET programs into Shellcode
* Added option to disable Shellcode loader
* Remade and optimized much of the miner and watchdog code
* Removed old C# loader
* Renamed Install to Startup due to confusion
### v1.5.4 (28/07/2021)
* Fixed the GPU detection for systems that have custom lowercase characters like Turkish, seems like I failed the "Turkey Test" again
### v1.5.3 (19/07/2021)
* Hotfix (20/07/2021): Fixed compatibility for some AMD cards and newer AMD drivers
* Greatly reduced Windows Defender detections when "Bypass Windows Defender" is enabled by replacing Assembly.Load with simply writing the payload to Temp and executing it since the folders are excluded
* Fixed the paths for systems that have custom lowercase characters like Turkish
### v1.5.2 (14/07/2021)
* Remade watchdog to reduce detections
* Obfuscated more strings to reduce new Windows Defender detections
* Reworked a lot of the injector
* Fixed a bug where two environment variables for paths could return different results
### v1.5.1 (10/07/2021)
* Fixed possible critical bug that makes the miner unable to see if a miner is running or not thus opening multiple miners
* Added backup servers for Online Downloader
* Added Install to System32 option (requires administrator permissions)
* Moved RunPE injector (Mandark) into miner to avoid internal Assembly.Load and improved it a bit
* Added GPU check to only start the miner when a GPU is detected
* Fixed possiblity of duplicate random obfuscation strings
* Improved Loader
* Improved Watchdog
* Improved obfuscation
### v1.5 (05/07/2021)
**v1.5.\* is the final update before the new, greatly improved unified miner that I'm working on.**
* Added the Online Downloader option that makes the miner download the miner binary (from GitHub) during runtime to greatly decrease file size (to less then 100kb) and detections - Also added a cache so that it won't have to download the miner on every start
* Added the Stealth Targets option which allows you to enter which programs the Stealth option should pause for
* Added new options to 'Remote Configuration' that allows you to change some miner settings
* Added {COMPUTERNAME}, {USERNAME} and {RANDOM} replacement strings support into 'Remote Configuration'
* Made the Task Scheduler task start for all users
* Fixed string that was triggering Windows Defender
* Improved Watchdog program flow
* Renamed "Kill" Windows Defender to Bypass Windows Defender to better represent the new functionality
* Updated miner and made it more stable
* Improved obfuscation/encryption
* Improved overall code
### v1.4.2 (14/05/2021)
* Made the Windows Defender Killer less intrusive, ironically to reduce detections
### v1.4.1 (13/05/2021)
* Made memory allocation yield to other processes more
* Decreased Watchdog detections
* Fixed possible Run as Administrator issue on computers with low privileges
### v1.4 (12/05/2021)
* Updated miner
* Added ETC toggle switch
* Fixed Etchash algorithm
* Updated Ethash algorithm
* Compiled miner and its dependencies statically so it no longer requires Visual C++
* Updated dependencies
* Updated OpenCL which should fix the new AMD drivers bug where it can't find it, also increases AMD hashrate
* Added Max GPU and Idle GPU options, although they will mostly just reduce fan sound since they won't decrease the VRAM required
* Added a Remote Configuration feature that can get the connection settings remotely from a URL at each startup
* Added option to auto-create an uninstaller for the miner
* Added Windows Defender "Killer"
* Added option to run as administrator
* Reworked whole program flow to bypass file scan detections
* Added link to wiki in builder for quicker access
* Added better DEBUG messaging
* Changed command line option prefixes
* Fixed bugs
### v1.3.3 (10/04/2021)
* Fixed watchdog temporary path
* Updated injector
* Readded injector options svchost.exe and conhost.exe
* Decreased injector detections
* Improved error handling
### v1.3.2 (09/04/2021)
* Fixed crash when some connections are blocked by the government/ISP in places like Turkey or China
### v1.3.1 (09/04/2021)
* Fixed minor injection option bug
### v1.3 (09/04/2021)
* Fixed critial bug on some Windows systems
* Added Task Scheduler startup when miner has administrator privileges
* Replaced and improved injector
* Added advanced options form
* Added debug option to display errors for testing
* Added ability to obfuscate watchdog
* Fixed miscellaneous bugs
### v1.2 (01/04/2021)
* Updated miner
* Added timer that reinitalizes GPU and memory every 30 minutes for better longevity during long mining sessions
* Recoded injector and watchdog from VB to C#
* Overall improved watchdog and injector
* Decreased antivirus detections
* Added built-in function name obfuscation
### v1.1 (28/03/2021)
* Improved miner
* Added compatability for RTX 3000 series cards among others
* Updated Watchdog
* Improved injector workflow reliability
* Changed encryption since the code was detected
### v1.0.2 (23/03/2021)
* Better support for running XMR miner and ETH miner simultaniously
* Changed encryption
### v1.0.1 (20/03/2021)
* Added support for proxy mining
### v1.0 (20/03/2021)
* Inital release