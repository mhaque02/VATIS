/* VATIS 1.0 by SYAM
 * Application Copyright 2011 by SYAM HAQUE
 * All rights reserved 2011
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Text;
using SpeechLib;
using System.Windows.Forms;
using System.Diagnostics;


namespace VATIS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application. Where VATIS is born!
        /// </summary>
        [STAThread]
        static void Main()
        {
            string running = Process.GetCurrentProcess().ProcessName;
            Process[] list = Process.GetProcessesByName(running);
            if (list.Length > 1)
            {
                MessageBox.Show("Application is already running!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                Application.ExitThread();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new VATIS());
            }
        }
    }
}
