using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CTRE.Phoenix
{
    /// <summary>
    /// http://www.mono-project.com/docs/advanced/pinvoke/
    /// </summary>
    public class CTRENativeWrapper
    {
        //public static bool LibraryLoaded { get; private set; } = false;
        //public static IntPtr pDLL = IntPtr.Zero;

        //static CTRENativeWrapper()
        //{
        //    if (!LibraryLoaded)
        //    {
        //        try
        //        {
        //            pDLL = NativeMethods.LoadLibrary(@"PathToDLL");
        //            if(pDLL == IntPtr.Zero)
        //            {
        //                throw new ExternalException("DLL pointer is zero.");
        //            }
        //        }
        //        catch(DllNotFoundException ex)
        //        {
        //            Console.WriteLine("Exception importing CTRE libraries.\n - Stacktrace: {0}\n - Source: {1}\n - Message: {2}", ex.StackTrace, ex.Source, ex.Message);
        //            Environment.Exit(1);
        //        }
        //        LibraryLoaded = true;
        //    }
        //}

        [DllImport("CTRE_PhoenixCCI")]
        public static extern int getPortWithModule(byte module, byte channel);

        [DllImport("CTRE_PhoenixCCI")]
        public static extern int getPort(byte channel);
    }

    //sealed class NativeMethods
    //{
    //    [DllImport("kernel32.dll")]
    //    public static extern IntPtr LoadLibrary(string dllToLoad);

    //    [DllImport("kernel32.dll")]
    //    public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

    //    [DllImport("kernel32.dll")]
    //    public static extern bool FreeLibrary(IntPtr hModule);
    //}
}
