using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GlobalHotKey
{
    class MainClass
    {
        [STAThread]
        public static void Main()
        {
            initNotifyIcon();

            HotKeyManager.parseHotKeys();
            InterceptKeys.initKeyHook();

            Application.EnableVisualStyles();
            Application.Run();

            InterceptKeys.terminateKeyHook();
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
            ConfigForm cForm = new ConfigForm();
            cForm.Show();
        }
        private static void exitClicked(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
