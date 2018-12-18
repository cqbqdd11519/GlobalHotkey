using System;
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
                ConfigClass.CommandType _type;
                if (Enum.TryParse<ConfigClass.CommandType>(obj["type"].ToString(), out _type))
                    continue;
                hotKeys.Add(key_pairs.GetHashCode(), new ConfigClass(obj["name"].ToString(), key_pairs, _type
                    , obj["exe_file"].ToString(), obj["exe_arg"].ToString(), (Keys)((int)obj["target_key"]), obj["cmd_line"].ToString()));
            }

            if (true) {
                addHotKey("Foobar Show", new[] { Keys.LControlKey, Keys.LMenu, Keys.A }, ConfigClass.CommandType.EXE, @"D:\foobar2000\foobar2000.exe", "/show", 0,null);
                addHotKey("Foobar Pause", new[] { Keys.LControlKey, Keys.LMenu, Keys.Oem7 }, ConfigClass.CommandType.EXE, @"D:\foobar2000\foobar2000.exe", "/pause", 0, null);
                addHotKey("Foobar Prev", new[] { Keys.LControlKey, Keys.LMenu, Keys.OemOpenBrackets }, ConfigClass.CommandType.EXE, @"D:\foobar2000\foobar2000.exe", "/prev", 0, null);
                addHotKey("Foobar Next", new[] { Keys.LControlKey, Keys.LMenu, Keys.Oem6 }, ConfigClass.CommandType.EXE, @"D:\foobar2000\foobar2000.exe", "/next", 0, null);
                addHotKey("Volume Up", new[] { Keys.LControlKey, Keys.LMenu, Keys.Oemplus }, ConfigClass.CommandType.KEY, null, null, Keys.VolumeUp, null);
                addHotKey("Volume Down", new[] { Keys.LControlKey, Keys.LMenu, Keys.OemMinus }, ConfigClass.CommandType.KEY, null, null, Keys.VolumeDown, null);
                addHotKey("Volume Mute", new[] { Keys.LControlKey, Keys.LMenu, Keys.Oem5 }, ConfigClass.CommandType.KEY, null, null, Keys.VolumeMute, null);
            }
        }

        public static void addHotKey(string name, Keys[] keys, ConfigClass.CommandType type, string exe_file, string exe_arg, Keys targetKey, string cmd_line)
        {
            KeyPair tmp_list = new KeyPair(keys);
            if(!hotKeys.ContainsKey(tmp_list.GetHashCode()))
                hotKeys.Add(tmp_list.GetHashCode(), new ConfigClass(name, tmp_list, type, exe_file, exe_arg, targetKey, cmd_line));
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
