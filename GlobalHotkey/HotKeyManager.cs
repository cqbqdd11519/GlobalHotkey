﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace GlobalHotKey
{
    using HotKeyDict = Dictionary<int, ConfigClass>;
    class HotKeyManager
    {
        private static HotKeyDict hotKeys = new HotKeyDict();

        public static HotKeyDict getHotKeys() { return hotKeys; }

        public static void parseHotKeys() {
            hotKeys = new HotKeyDict();
            JArray keys_arr = JArray.Parse(Properties.Settings.Default.HotKeys);
            foreach (JObject obj in keys_arr.Children<JObject>())
            {
                KeyPair key_pairs = new KeyPair();
                JArray key_pairs_tmp = (JArray)obj["key_pairs"];
                foreach (int key in key_pairs_tmp) {
                    key_pairs.Add((Keys)key);
                }
                hotKeys.Add(key_pairs.GetHashCode(), new ConfigClass(obj["name"].ToString(), key_pairs, obj["type"].ToString().Equals("CMD") ? ConfigClass.CommandType.CMD:ConfigClass.CommandType.KEY,
                    obj["cmd_file"].ToString(), obj["cmd_arg"].ToString(), (Keys)((int)obj["target_key"])));
            }

            if (true) {
                addHotKey("Foobar Show", new[] { Keys.LControlKey, Keys.LMenu, Keys.A }, ConfigClass.CommandType.CMD, @"D:\foobar2000\foobar2000.exe", "/show", 0);
                addHotKey("Foobar Pause", new[] { Keys.LControlKey, Keys.LMenu, Keys.Oem7 }, ConfigClass.CommandType.CMD, @"D:\foobar2000\foobar2000.exe", "/pause", 0);
                addHotKey("Foobar Prev", new[] { Keys.LControlKey, Keys.LMenu, Keys.OemOpenBrackets }, ConfigClass.CommandType.CMD, @"D:\foobar2000\foobar2000.exe", "/prev", 0);
                addHotKey("Foobar Next", new[] { Keys.LControlKey, Keys.LMenu, Keys.Oem6 }, ConfigClass.CommandType.CMD, @"D:\foobar2000\foobar2000.exe", "/next", 0);
                addHotKey("Volume Up", new[] { Keys.LControlKey, Keys.LMenu, Keys.Oemplus }, ConfigClass.CommandType.KEY, null, null, Keys.VolumeUp);
                addHotKey("Volume Down", new[] { Keys.LControlKey, Keys.LMenu, Keys.OemMinus }, ConfigClass.CommandType.KEY, null, null, Keys.VolumeDown);
                addHotKey("Volume Mute", new[] { Keys.LControlKey, Keys.LMenu, Keys.Oem5 }, ConfigClass.CommandType.KEY, null, null, Keys.VolumeMute);
            }
        }

        public static void addHotKey(string name, Keys[] keys, ConfigClass.CommandType type, string cmd_file, string cmd_arg, Keys targetKey)
        {
            KeyPair tmp_list = new KeyPair(keys);
            if(!hotKeys.ContainsKey(tmp_list.GetHashCode()))
                hotKeys.Add(tmp_list.GetHashCode(), new ConfigClass(name, tmp_list, type, cmd_file, cmd_arg, targetKey));
        }

        public static void setHotKeys(HotKeyDict dict) {
            hotKeys = new HotKeyDict(dict);
            JArray arr = new JArray();
            foreach (KeyValuePair<int, ConfigClass> pair in hotKeys)
            {
                arr.Add(pair.Value.getJObject());
            }
            Properties.Settings.Default.HotKeys = arr.ToString();
            Properties.Settings.Default.Save();
        }
    }
}