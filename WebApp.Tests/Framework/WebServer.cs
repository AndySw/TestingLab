using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Linq;

namespace TestingLab.Tests.Framework
{
    public class WebServer
    {
        const string IIS_EXPRESS = @"C:\Program Files\IIS Express\iisexpress.exe";
        const string CONFIG = "config";
        const string SITE = "site";
        const string APP_POOL = "apppool";
        const string PATH = "path";
        const string PORT = "port";

        private Process process;

        public string Path { get; protected set; }
        public int Port { get; protected set; }

        public static WebServer Start(string path, int port)
        {
            return new WebServer(path, port);
        }

        WebServer(string path, int port)
        {
            Path = path;
            Port = port;
            CleanUpOrphanedProcesses(IIS_EXPRESS);
            StartProcess(path, port);
        }

        private void StartProcess(string path, int port)
        {
            StringBuilder arguments = new StringBuilder();

            if (!string.IsNullOrEmpty(Path))
                arguments.AppendFormat("/{0}:{1} ", PATH, Path);

            if (!(Port <= 0))
                arguments.AppendFormat("/{0}:{1} ", PORT, Port);

            process = Process.Start(new ProcessStartInfo()
            {
                FileName = IIS_EXPRESS,
                Arguments = arguments.ToString(),
                RedirectStandardOutput = true,
                UseShellExecute = false
            });
        }

        public void Stop()
        {
            SendStopMessageToProcess(process.Id);
            process.Close();
        }

        private static void SendStopMessageToProcess(int PID)
        {
            try
            {
                for (IntPtr ptr = NativeMethods.GetTopWindow(IntPtr.Zero); ptr != IntPtr.Zero; ptr = NativeMethods.GetWindow(ptr, 2))
                {
                    uint num;
                    NativeMethods.GetWindowThreadProcessId(ptr, out num);
                    if (PID == num)
                    {
                        HandleRef hWnd = new HandleRef(null, ptr);
                        NativeMethods.PostMessage(hWnd, 0x12, IntPtr.Zero, IntPtr.Zero);
                        return;
                    }
                }
            }
            catch (ArgumentException ex)
            {
                Trace.WriteLine($"SendStopMessageToProcess: {ex.ToString()}");
            }
        }

        private static void CleanUpOrphanedProcesses(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) { return; }
            var processName = System.IO.Path.GetFileNameWithoutExtension(path);
            var processes = Process.GetProcessesByName(processName);
            foreach (var process in processes)
            {
                process.Kill();
            }
        }

        internal class NativeMethods
        {
            // Methods
            [DllImport("user32.dll", SetLastError = true)]
            internal static extern IntPtr GetTopWindow(IntPtr hWnd);
            [DllImport("user32.dll", SetLastError = true)]
            internal static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);
            [DllImport("user32.dll", SetLastError = true)]
            internal static extern uint GetWindowThreadProcessId(IntPtr hwnd, out uint lpdwProcessId);
            [DllImport("user32.dll", SetLastError = true)]
            internal static extern bool PostMessage(HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        }
    }
}