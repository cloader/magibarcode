using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using barc;
using System.Diagnostics;
using System.Runtime.InteropServices;
namespace barc
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
         

            String processName = "barc";
           Process[] arrayProcess= Process.GetProcessesByName(processName);
           /*
          if (arrayProcess.Length > 1)
          {
              Process p = arrayProcess[0];
             IntPtr iptr=  p.MainWindowHandle;
             SendMessage(iptr, 0x000A, 0, 0);
          }
          else
          {
            
            } */
           Application.EnableVisualStyles();
               Application.SetCompatibleTextRenderingDefault(false);
               Application.Run(new Form1());
           
        }
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hwnd, uint wMsg, int wParam, int lParam);
        
    }
}
