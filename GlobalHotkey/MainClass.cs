using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace GlobalHotKey
{
    class MainClass
    {
        private static string appGuid = "f64974de-8973-42e4-8912-8687bb7d5a1b";

        [STAThread]
        public static void Main()
        {
            using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
            {
                if (!mutex.WaitOne(0, false)){
                    MessageBox.Show("Instance already running");
                    return;
                }
                initNotifyIcon();

                HotKeyManager.parseHotKeys();
                InterceptKeys.initKeyHook();

                Application.EnableVisualStyles();
                Application.Run();

                InterceptKeys.terminateKeyHook();
            }
        }

        private static void initNotifyIcon()
        {
            var icon = Properties.Resources.remote;
            var noti = new NotifyIcon();
            noti.Text = Properties.Resources.AppName;
            noti.Icon = icon;
            noti.DoubleClick += configClicked;
            noti.ContextMenuStrip = new ContextMenuStrip();
            noti.ContextMenuStrip.Items.Add("Configuration", null, configClicked);
            noti.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            noti.ContextMenuStrip.Items.Add("Exit", null, exitClicked);
            noti.Visible = true;
        }

        private static void configClicked(object sender, EventArgs e)
        {
            ConfigForm cForm = ConfigForm.GetInstance();
            cForm.Show();
            cForm.BringToFront();
        }
        private static void exitClicked(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
