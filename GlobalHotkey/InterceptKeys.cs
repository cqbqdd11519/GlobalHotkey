﻿using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace GlobalHotKey
{
    class InterceptKeys
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_SYSKEYUP = 0x0105;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        public static bool enableKeyHook { get; set; } = true ;
        private static KeyPair pressedKeys = new KeyPair();

        public static KeyPair getPressedKeys() {
            return pressedKeys;
        }

        public static void initKeyHook() {
            pressedKeys = new KeyPair();
            _hookID = SetHook(_proc);
        }

        public static void terminateKeyHook() {
            UnhookWindowsHookEx(_hookID);
        }

        private static void findAndCall(KeyPair keypair)
        {
            if (!enableKeyHook)
                return;
            if (!HotKeyManager.getHotKeys().ContainsKey(keypair.GetHashCode()))
                return;
            ConfigClass cl = HotKeyManager.getHotKeys()[keypair.GetHashCode()];
            if (cl.getType() == ConfigClass.CommandType.CMD)
            {
                CallProcess(cl.getCmdFile(),cl.getCmdArg());
            }
            else if(cl.getType() == ConfigClass.CommandType.KEY){
                keybd_event((byte)cl.getTargetKey(), 0, 0x0001, 0); //Key Down
                keybd_event((byte)cl.getTargetKey(), 0, 0x0002, 0); //Key Up
            }
        }

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        private static void CallProcess(string name, string args)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = name;
            proc.StartInfo.Arguments = args;
            proc.Start();
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN))
            {
                int vkCode = Marshal.ReadInt32(lParam);

                //FixMe : Kanamode & Hanjamode doesn't call KEYUP event
                if(!pressedKeys.Contains((Keys)vkCode) && (Keys)vkCode != Keys.KanaMode && (Keys)vkCode != Keys.HanjaMode)
                    pressedKeys.Add((Keys)vkCode);
                findAndCall(pressedKeys);
            }
            else if (nCode >= 0 && (wParam == (IntPtr)WM_KEYUP || wParam == (IntPtr)WM_SYSKEYUP))
            {
                int vkCode = Marshal.ReadInt32(lParam);
                pressedKeys.Remove((Keys)vkCode);
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]

        private static extern bool UnhookWindowsHookEx(IntPtr hhk);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern IntPtr GetModuleHandle(string lpModuleName);

    }
}